using TodoList.Models;

namespace TodoList.BusinessLogic
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoTask>> GetAllTasksAsync();
        Task<TodoTask?> GetTaskByIdAsync(int id);
        Task<TodoTask> CreateTaskAsync(TodoTask task);
        Task<TodoTask> UpdateTaskAsync(TodoTask task);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<TodoTask>> GetTasksByStatusAsync(Models.TaskStatus status);
        Task<IEnumerable<TodoTask>> GetTasksByCategoryAsync(string category);
        Task<IEnumerable<TodoTask>> SearchTasksAsync(string searchTerm);
        Task<IEnumerable<string>> GetAllCategoriesAsync();
        bool ValidateTask(TodoTask task);
        Task<string> ExportToCsvAsync(IEnumerable<TodoTask> tasks, string filePath);
        Task<string> ExportToExcelAsync(IEnumerable<TodoTask> tasks, string filePath);
        Task<IEnumerable<TodoTask>> GetOverdueTasksAsync();
        Task<IEnumerable<TodoTask>> GetTasksDueTodayAsync();
    }
}
