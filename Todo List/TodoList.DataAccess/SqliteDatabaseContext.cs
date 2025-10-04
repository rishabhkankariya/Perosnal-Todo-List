using Microsoft.Data.Sqlite;
using TodoList.Models;
using System.Data;

namespace TodoList.DataAccess
{
    public class SqliteDatabaseContext : IDatabaseContext
    {
        private readonly string _connectionString;
        private readonly string _databasePath;

        public SqliteDatabaseContext()
        {
            _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TodoList", "todolist.db");
            var directory = Path.GetDirectoryName(_databasePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }
            _connectionString = $"Data Source={_databasePath}";
        }

        public async Task InitializeAsync()
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var createTableCommand = connection.CreateCommand();
            createTableCommand.CommandText = @"
                CREATE TABLE IF NOT EXISTS TodoTasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT,
                    Category TEXT,
                    DueDate TEXT,
                    Status INTEGER NOT NULL DEFAULT 0,
                    CreatedDate TEXT NOT NULL,
                    ModifiedDate TEXT
                )";

            await createTableCommand.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasksAsync()
        {
            var tasks = new List<TodoTask>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Title, Description, Category, DueDate, Status, CreatedDate, ModifiedDate
                FROM TodoTasks
                ORDER BY CreatedDate DESC";

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                tasks.Add(MapReaderToTask(reader));
            }

            return tasks;
        }

        public async Task<TodoTask?> GetTaskByIdAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Title, Description, Category, DueDate, Status, CreatedDate, ModifiedDate
                FROM TodoTasks
                WHERE Id = @id";

            command.Parameters.AddWithValue("@id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapReaderToTask(reader);
            }

            return null;
        }

        public async Task<TodoTask> CreateTaskAsync(TodoTask task)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO TodoTasks (Title, Description, Category, DueDate, Status, CreatedDate, ModifiedDate)
                VALUES (@title, @description, @category, @dueDate, @status, @createdDate, @modifiedDate);
                SELECT last_insert_rowid();";

            command.Parameters.AddWithValue("@title", task.Title ?? string.Empty);
            command.Parameters.AddWithValue("@description", task.Description ?? string.Empty);
            command.Parameters.AddWithValue("@category", task.Category ?? "General");
            command.Parameters.AddWithValue("@dueDate", task.DueDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@status", (int)task.Status);
            command.Parameters.AddWithValue("@createdDate", task.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@modifiedDate", task.ModifiedDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);

            var id = Convert.ToInt32(await command.ExecuteScalarAsync());
            task.Id = id;

            return task;
        }

        public async Task<TodoTask> UpdateTaskAsync(TodoTask task)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE TodoTasks
                SET Title = @title, Description = @description, Category = @category, 
                    DueDate = @dueDate, Status = @status, ModifiedDate = @modifiedDate
                WHERE Id = @id";

            command.Parameters.AddWithValue("@id", task.Id);
            command.Parameters.AddWithValue("@title", task.Title ?? string.Empty);
            command.Parameters.AddWithValue("@description", task.Description ?? string.Empty);
            command.Parameters.AddWithValue("@category", task.Category ?? "General");
            command.Parameters.AddWithValue("@dueDate", task.DueDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@status", (int)task.Status);
            command.Parameters.AddWithValue("@modifiedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            await command.ExecuteNonQueryAsync();
            task.ModifiedDate = DateTime.Now;

            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM TodoTasks WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<TodoTask>> GetTasksByStatusAsync(Models.TaskStatus status)
        {
            var tasks = new List<TodoTask>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Title, Description, Category, DueDate, Status, CreatedDate, ModifiedDate
                FROM TodoTasks
                WHERE Status = @status
                ORDER BY CreatedDate DESC";

            command.Parameters.AddWithValue("@status", (int)status);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                tasks.Add(MapReaderToTask(reader));
            }

            return tasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTasksByCategoryAsync(string category)
        {
            var tasks = new List<TodoTask>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Title, Description, Category, DueDate, Status, CreatedDate, ModifiedDate
                FROM TodoTasks
                WHERE Category = @category
                ORDER BY CreatedDate DESC";

            command.Parameters.AddWithValue("@category", category);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                tasks.Add(MapReaderToTask(reader));
            }

            return tasks;
        }

        public async Task<IEnumerable<TodoTask>> SearchTasksAsync(string searchTerm)
        {
            var tasks = new List<TodoTask>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Title, Description, Category, DueDate, Status, CreatedDate, ModifiedDate
                FROM TodoTasks
                WHERE Title LIKE @searchTerm OR Description LIKE @searchTerm OR Category LIKE @searchTerm
                ORDER BY CreatedDate DESC";

            command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                tasks.Add(MapReaderToTask(reader));
            }

            return tasks;
        }

        public async Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            var categories = new List<string>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT DISTINCT Category
                FROM TodoTasks
                WHERE Category IS NOT NULL AND Category != ''
                ORDER BY Category";

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                categories.Add(reader.GetString("Category"));
            }

            return categories;
        }

        public async Task<bool> TaskExistsAsync(string title)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM TodoTasks WHERE Title = @title";
            command.Parameters.AddWithValue("@title", title);

            var count = Convert.ToInt32(await command.ExecuteScalarAsync());
            return count > 0;
        }

        private static TodoTask MapReaderToTask(SqliteDataReader reader)
        {
            return new TodoTask
            {
                Id = reader.GetInt32("Id"),
                Title = reader.GetString("Title"),
                Description = reader.IsDBNull("Description") ? string.Empty : reader.GetString("Description"),
                Category = reader.IsDBNull("Category") ? "General" : reader.GetString("Category"),
                DueDate = reader.IsDBNull("DueDate") ? null : DateTime.Parse(reader.GetString("DueDate")),
                Status = (Models.TaskStatus)reader.GetInt32("Status"),
                CreatedDate = DateTime.Parse(reader.GetString("CreatedDate")),
                ModifiedDate = reader.IsDBNull("ModifiedDate") ? null : DateTime.Parse(reader.GetString("ModifiedDate"))
            };
        }
    }
}
