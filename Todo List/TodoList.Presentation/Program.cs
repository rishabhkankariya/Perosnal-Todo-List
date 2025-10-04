using TodoList.BusinessLogic;
using TodoList.DataAccess;
using TodoList.Presentation.Forms;

namespace TodoList.Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            // Initialize database
            var databaseContext = new SqliteDatabaseContext();
            try
            {
                databaseContext.InitializeAsync().Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Initialize services
            var todoService = new TodoService(databaseContext);
            
            // Start the main form
            Application.Run(new MainForm(todoService));
        }
    }
}
