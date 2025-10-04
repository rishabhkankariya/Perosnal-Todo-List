using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CsvHelper;
using OfficeOpenXml;
using TodoList.DataAccess;
using TodoList.Models;

namespace TodoList.BusinessLogic
{
    public class TodoService : ITodoService
    {
        private readonly IDatabaseContext _databaseContext;

        public TodoService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasksAsync()
        {
            return await _databaseContext.GetAllTasksAsync();
        }

        public async Task<TodoTask?> GetTaskByIdAsync(int id)
        {
            return await _databaseContext.GetTaskByIdAsync(id);
        }

        public async Task<TodoTask> CreateTaskAsync(TodoTask task)
        {
            if (!ValidateTask(task))
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException("Task validation failed");
            }

            // Check for duplicate titles
            if (await _databaseContext.TaskExistsAsync(task.Title))
            {
                throw new InvalidOperationException("A task with this title already exists");
            }

            return await _databaseContext.CreateTaskAsync(task);
        }

        public async Task<TodoTask> UpdateTaskAsync(TodoTask task)
        {
            if (!ValidateTask(task))
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException("Task validation failed");
            }

            return await _databaseContext.UpdateTaskAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _databaseContext.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<TodoTask>> GetTasksByStatusAsync(Models.TaskStatus status)
        {
            return await _databaseContext.GetTasksByStatusAsync(status);
        }

        public async Task<IEnumerable<TodoTask>> GetTasksByCategoryAsync(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return await GetAllTasksAsync();
            }

            return await _databaseContext.GetTasksByCategoryAsync(category);
        }

        public async Task<IEnumerable<TodoTask>> SearchTasksAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllTasksAsync();
            }

            return await _databaseContext.SearchTasksAsync(searchTerm);
        }

        public async Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            return await _databaseContext.GetAllCategoriesAsync();
        }

        public bool ValidateTask(TodoTask task)
        {
            if (task == null)
                return false;

            if (string.IsNullOrWhiteSpace(task.Title))
                return false;

            if (task.Title.Length > 200)
                return false;

            if (task.Description != null && task.Description.Length > 1000)
                return false;

            if (task.Category != null && task.Category.Length > 50)
                return false;

            if (task.DueDate.HasValue && task.DueDate.Value < DateTime.Now.AddDays(-1))
                return false;

            return true;
        }

        public async Task<string> ExportToCsvAsync(IEnumerable<TodoTask> tasks, string filePath)
        {
            try
            {
                using var writer = new StreamWriter(filePath);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                
                await csv.WriteRecordsAsync(tasks);
                return filePath;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to export to CSV: {ex.Message}", ex);
            }
        }

        public async Task<string> ExportToExcelAsync(IEnumerable<TodoTask> tasks, string filePath)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Todo Tasks");

                // Add headers
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Title";
                worksheet.Cells[1, 3].Value = "Description";
                worksheet.Cells[1, 4].Value = "Category";
                worksheet.Cells[1, 5].Value = "Due Date";
                worksheet.Cells[1, 6].Value = "Status";
                worksheet.Cells[1, 7].Value = "Created Date";
                worksheet.Cells[1, 8].Value = "Modified Date";

                // Add data
                int row = 2;
                foreach (var task in tasks)
                {
                    worksheet.Cells[row, 1].Value = task.Id;
                    worksheet.Cells[row, 2].Value = task.Title;
                    worksheet.Cells[row, 3].Value = task.Description;
                    worksheet.Cells[row, 4].Value = task.Category;
                    worksheet.Cells[row, 5].Value = task.DueDate?.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 6].Value = task.Status.ToString();
                    worksheet.Cells[row, 7].Value = task.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 8].Value = task.ModifiedDate?.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }

                // Auto-fit columns
                worksheet.Cells.AutoFitColumns();

                await package.SaveAsAsync(new FileInfo(filePath));
                return filePath;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to export to Excel: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<TodoTask>> GetOverdueTasksAsync()
        {
            var allTasks = await GetAllTasksAsync();
            return allTasks.Where(t => t.IsOverdue);
        }

        public async Task<IEnumerable<TodoTask>> GetTasksDueTodayAsync()
        {
            var allTasks = await GetAllTasksAsync();
            var today = DateTime.Today;
            return allTasks.Where(t => t.DueDate?.Date == today);
        }
    }
}
