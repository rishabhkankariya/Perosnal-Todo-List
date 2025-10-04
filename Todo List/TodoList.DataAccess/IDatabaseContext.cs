using TodoList.Models;

namespace TodoList.DataAccess
{
    public interface IDatabaseContext
    {
        Task InitializeAsync();
        Task<IEnumerable<TodoTask>> GetAllTasksAsync();
        Task<TodoTask?> GetTaskByIdAsync(int id);
        Task<TodoTask> CreateTaskAsync(TodoTask task);
        Task<TodoTask> UpdateTaskAsync(TodoTask task);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<TodoTask>> GetTasksByStatusAsync(Models.TaskStatus status);
        Task<IEnumerable<TodoTask>> GetTasksByCategoryAsync(string category);
        Task<IEnumerable<TodoTask>> SearchTasksAsync(string searchTerm);
        Task<IEnumerable<string>> GetAllCategoriesAsync();
        Task<bool> TaskExistsAsync(string title);
    }
}
