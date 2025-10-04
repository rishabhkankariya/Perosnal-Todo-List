using TodoList.BusinessLogic;
using TodoList.Models;
using TodoList.Presentation.Managers;

namespace TodoList.Presentation.Forms
{
    public partial class TaskForm : Form
    {
        private readonly ITodoService _todoService;
        private readonly TodoTask? _existingTask;
        private readonly ThemeManager _themeManager;

        public TaskForm(ITodoService todoService, TodoTask? existingTask = null)
        {
            _todoService = todoService;
            _existingTask = existingTask;
            _themeManager = new ThemeManager();
            
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_existingTask != null)
            {
                this.Text = "Edit Task";
                btnSave.Text = "Update Task";
                LoadExistingTask();
            }
            else
            {
                this.Text = "Add New Task";
                btnSave.Text = "Create Task";
                dtpDueDate.Value = DateTime.Now.AddDays(1);
            }

            _themeManager.ApplyTheme(this, false);
        }

        private void LoadExistingTask()
        {
            if (_existingTask == null) return;

            txtTitle.Text = _existingTask.Title;
            txtDescription.Text = _existingTask.Description;
            txtCategory.Text = _existingTask.Category;
            cmbStatus.SelectedItem = _existingTask.Status;
            
            if (_existingTask.DueDate.HasValue)
            {
                dtpDueDate.Value = _existingTask.DueDate.Value;
                chkHasDueDate.Checked = true;
            }
            else
            {
                chkHasDueDate.Checked = false;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                var task = _existingTask ?? new TodoTask();
                task.Title = txtTitle.Text.Trim();
                task.Description = txtDescription.Text.Trim();
                task.Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? "General" : txtCategory.Text.Trim();
                task.Status = cmbStatus.SelectedItem is Models.TaskStatus status ? status : Models.TaskStatus.Pending;
                task.DueDate = chkHasDueDate.Checked ? dtpDueDate.Value : null;

                if (_existingTask == null)
                {
                    await _todoService.CreateTaskAsync(task);
                    MessageBox.Show("Task created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _todoService.UpdateTaskAsync(task);
                    MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title for the task.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (txtTitle.Text.Length > 200)
            {
                MessageBox.Show("Title cannot exceed 200 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (txtDescription.Text.Length > 1000)
            {
                MessageBox.Show("Description cannot exceed 1000 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (txtCategory.Text.Length > 50)
            {
                MessageBox.Show("Category cannot exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status for the task.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkHasDueDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDueDate.Enabled = chkHasDueDate.Checked;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            lblTitleCount.Text = $"{txtTitle.Text.Length}/200";
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescriptionCount.Text = $"{txtDescription.Text.Length}/1000";
        }
    }
}
