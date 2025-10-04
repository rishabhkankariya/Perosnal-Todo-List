using System.ComponentModel;
using TodoList.BusinessLogic;
using TodoList.Models;
using TodoList.Presentation.Managers;

namespace TodoList.Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly ITodoService _todoService;
        private readonly ThemeManager _themeManager;
        private readonly AnimationManager _animationManager;
        private List<TodoTask> _allTasks = new();
        private List<TodoTask> _filteredTasks = new();
        private Models.TaskStatus _currentFilter = Models.TaskStatus.Pending;
        private string _currentSearchTerm = string.Empty;

        public MainForm(ITodoService todoService)
        {
            _todoService = todoService;
            _themeManager = new ThemeManager();
            _animationManager = new AnimationManager();
            
            InitializeComponent();
            InitializeTheme();
            SetupEventHandlers();
            LoadTasksAsync();
            
            // Ensure form is visible and properly configured
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void InitializeTheme()
        {
            _themeManager.ApplyTheme(this, false);
        }

        private void SetupEventHandlers()
        {
            // Navigation panel events
            btnAllTasks.Click += (s, e) => FilterTasks(Models.TaskStatus.Pending, "All Tasks");
            btnPending.Click += (s, e) => FilterTasks(Models.TaskStatus.Pending, "Pending");
            btnInProgress.Click += (s, e) => FilterTasks(Models.TaskStatus.InProgress, "In Progress");
            btnCompleted.Click += (s, e) => FilterTasks(Models.TaskStatus.Done, "Completed");
            btnOverdue.Click += (s, e) => ShowOverdueTasks();
            btnDueToday.Click += (s, e) => ShowTasksDueToday();

            // Theme toggle - removed (dark mode only)
            // btnThemeToggle.Click += ToggleTheme;

            // GitHub link
            btnGitHub.Click += (s, e) => {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://github.com/yourusername",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open GitHub profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            // Search functionality
            txtSearch.TextChanged += OnSearchTextChanged;

            // Add task button
            btnAddTask.Click += ShowAddTaskForm;

            // Export buttons
            btnExportCsv.Click += ExportToCsv;
            btnExportExcel.Click += ExportToExcel;

            // Task list events
            lstTasks.SelectedIndexChanged += OnTaskSelected;
            lstTasks.DoubleClick += EditSelectedTask;

            // Form events
            this.Resize += OnFormResize;
            this.Load += OnFormLoad;
        }

        private async void LoadTasksAsync()
        {
            try
            {
                _allTasks = (await _todoService.GetAllTasksAsync()).ToList();
                FilterTasks(_currentFilter, GetFilterDisplayName(_currentFilter));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterTasks(Models.TaskStatus status, string filterName)
        {
            _currentFilter = status;
            lblFilterStatus.Text = filterName;
            
            _filteredTasks = _allTasks.Where(t => 
                (filterName == "All Tasks" || t.Status == status) && 
                (string.IsNullOrEmpty(_currentSearchTerm) || 
                 t.Title.Contains(_currentSearchTerm, StringComparison.OrdinalIgnoreCase) ||
                 t.Description.Contains(_currentSearchTerm, StringComparison.OrdinalIgnoreCase) ||
                 t.Category.Contains(_currentSearchTerm, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            RefreshTaskList();
        }

        private async void ShowOverdueTasks()
        {
            try
            {
                _filteredTasks = (await _todoService.GetOverdueTasksAsync()).ToList();
                lblFilterStatus.Text = "Overdue Tasks";
                RefreshTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading overdue tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ShowTasksDueToday()
        {
            try
            {
                _filteredTasks = (await _todoService.GetTasksDueTodayAsync()).ToList();
                lblFilterStatus.Text = "Due Today";
                RefreshTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks due today: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTaskList()
        {
            lstTasks.Items.Clear();
            
            foreach (var task in _filteredTasks)
            {
                var item = new ListViewItem(task.Title)
                {
                    Tag = task,
                    SubItems = {
                        task.Category,
                        task.DueDate?.ToString("MM/dd/yyyy") ?? "No due date",
                        task.Status.ToString()
                    }
                };

                // Color coding based on status and due date
                if (task.IsOverdue)
                    item.BackColor = Color.FromArgb(80, 40, 40); // Dark red for overdue
                else if (task.IsCompleted)
                    item.BackColor = Color.FromArgb(40, 80, 40); // Dark green for completed
                else if (task.Status == Models.TaskStatus.InProgress)
                    item.BackColor = Color.FromArgb(80, 80, 40); // Dark yellow for in progress
                else
                    item.BackColor = Color.FromArgb(60, 60, 60); // Default dark gray

                lstTasks.Items.Add(item);
            }

            _animationManager.AnimateListUpdate(lstTasks);
        }

        private void OnSearchTextChanged(object? sender, EventArgs e)
        {
            _currentSearchTerm = txtSearch.Text;
            var currentFilterName = lblFilterStatus.Text;
            FilterTasks(_currentFilter, currentFilterName);
        }

        private string GetFilterDisplayName(Models.TaskStatus status)
        {
            return status switch
            {
                Models.TaskStatus.Pending => "Pending",
                Models.TaskStatus.InProgress => "In Progress",
                Models.TaskStatus.Done => "Completed",
                _ => "All Tasks"
            };
        }

        private void ShowAddTaskForm(object? sender, EventArgs e)
        {
            var addForm = new TaskForm(_todoService, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTasksAsync();
            }
        }

        private void EditSelectedTask(object? sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0 && lstTasks.SelectedItems[0].Tag is TodoTask task)
            {
                var editForm = new TaskForm(_todoService, task);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTasksAsync();
                }
            }
        }

        private void OnTaskSelected(object? sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0 && lstTasks.SelectedItems[0].Tag is TodoTask task)
            {
                ShowTaskDetails(task);
            }
        }

        private void ShowTaskDetails(TodoTask task)
        {
            lblTaskTitle.Text = task.Title;
            lblTaskDescription.Text = task.Description;
            lblTaskCategory.Text = $"Category: {task.Category}";
            lblTaskDueDate.Text = task.DueDate?.ToString("MM/dd/yyyy HH:mm") ?? "No due date";
            lblTaskStatus.Text = $"Status: {task.Status}";
            lblTaskCreated.Text = $"Created: {task.CreatedDate:MM/dd/yyyy}";
        }

        private void ToggleTheme(object? sender, EventArgs e)
        {
            _themeManager.ToggleTheme();
            _themeManager.ApplyTheme(this, _themeManager.IsDarkMode);
            btnThemeToggle.Text = _themeManager.IsDarkMode ? "☀️" : "🌙";
        }

        private async void ExportToCsv(object? sender, EventArgs e)
        {
            try
            {
                using var saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = $"TodoTasks_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    await _todoService.ExportToCsvAsync(_filteredTasks, saveDialog.FileName);
                    MessageBox.Show($"Tasks exported successfully to {saveDialog.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ExportToExcel(object? sender, EventArgs e)
        {
            try
            {
                using var saveDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    DefaultExt = "xlsx",
                    FileName = $"TodoTasks_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    await _todoService.ExportToExcelAsync(_filteredTasks, saveDialog.FileName);
                    MessageBox.Show($"Tasks exported successfully to {saveDialog.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFormResize(object? sender, EventArgs e)
        {
            // Responsive design adjustments
            AdjustLayoutForSize();
        }

        private void OnFormLoad(object? sender, EventArgs e)
        {
            AdjustLayoutForSize();
        }

        private void AdjustLayoutForSize()
        {
            // Adjust panel sizes based on form size
            if (this.Width < 800)
            {
                pnlNavigation.Width = 200;
            }
            else
            {
                pnlNavigation.Width = 250;
            }

            // Adjust list view columns
            if (lstTasks.Columns.Count > 0)
            {
                var totalWidth = lstTasks.Width - 20;
                lstTasks.Columns[0].Width = (int)(totalWidth * 0.4); // Title
                lstTasks.Columns[1].Width = (int)(totalWidth * 0.2); // Category
                lstTasks.Columns[2].Width = (int)(totalWidth * 0.2); // Due Date
                lstTasks.Columns[3].Width = (int)(totalWidth * 0.2); // Status
            }
        }
    }
}
