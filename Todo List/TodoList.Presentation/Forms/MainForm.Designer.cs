namespace TodoList.Presentation.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlNavigation;
        private Panel pnlMain;
        private Panel pnlTaskDetails;
        private Panel pnlTopControls;
        private Button btnAllTasks;
        private Button btnPending;
        private Button btnInProgress;
        private Button btnCompleted;
        private Button btnOverdue;
        private Button btnDueToday;
        private Button btnThemeToggle;
        private Button btnGitHub;
        private Button btnAddTask;
        private Button btnExportCsv;
        private Button btnExportExcel;
        private TextBox txtSearch;
        private ListView lstTasks;
        private Label lblFilterStatus;
        private Label lblTaskTitle;
        private Label lblTaskDescription;
        private Label lblTaskCategory;
        private Label lblTaskDueDate;
        private Label lblTaskStatus;
        private Label lblTaskCreated;
        private Label lblSearch;
        private Label lblNavigation;
        private Label lblTaskDetails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.pnlNavigation = new Panel();
            this.pnlMain = new Panel();
            this.pnlTaskDetails = new Panel();
            this.pnlTopControls = new Panel();
            this.btnAllTasks = new Button();
            this.btnPending = new Button();
            this.btnInProgress = new Button();
            this.btnCompleted = new Button();
            this.btnOverdue = new Button();
            this.btnDueToday = new Button();
            this.btnThemeToggle = new Button();
            this.btnGitHub = new Button();
            this.btnAddTask = new Button();
            this.btnExportCsv = new Button();
            this.btnExportExcel = new Button();
            this.txtSearch = new TextBox();
            this.lstTasks = new ListView();
            this.lblFilterStatus = new Label();
            this.lblTaskTitle = new Label();
            this.lblTaskDescription = new Label();
            this.lblTaskCategory = new Label();
            this.lblTaskDueDate = new Label();
            this.lblTaskStatus = new Label();
            this.lblTaskCreated = new Label();
            this.lblSearch = new Label();
            this.lblNavigation = new Label();
            this.lblTaskDetails = new Label();
            this.pnlNavigation.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTaskDetails.SuspendLayout();
            this.SuspendLayout();

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // fixed size window
            this.MaximizeBox = false; // disable maximize button
            this.MinimizeBox = true;  // optional: keep minimize
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Todo List Application";


            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = Color.FromArgb(45, 45, 48);
            this.pnlNavigation.Controls.Add(this.lblNavigation);
            this.pnlNavigation.Controls.Add(this.btnAllTasks);
            this.pnlNavigation.Controls.Add(this.btnPending);
            this.pnlNavigation.Controls.Add(this.btnInProgress);
            this.pnlNavigation.Controls.Add(this.btnCompleted);
            this.pnlNavigation.Controls.Add(this.btnOverdue);
            this.pnlNavigation.Controls.Add(this.btnDueToday);
            this.pnlNavigation.Controls.Add(this.btnThemeToggle);
            this.pnlNavigation.Controls.Add(this.btnGitHub);
            this.pnlNavigation.Dock = DockStyle.Left;
            this.pnlNavigation.Location = new Point(0, 0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Width = 250;   // fixed sidebar width
            this.pnlNavigation.Height = 1200;
            this.pnlNavigation.TabIndex = 0;


            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlTaskDetails);
            this.pnlMain.Controls.Add(this.lstTasks);
            this.pnlMain.Controls.Add(this.pnlTopControls);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(250, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(0);
            this.pnlMain.Size = new Size(950, 1200);
            this.pnlMain.TabIndex = 1;

            // 
            // pnlTopControls
            // 
            this.pnlTopControls.Controls.Add(this.lblFilterStatus);
            this.pnlTopControls.Controls.Add(this.btnExportExcel);
            this.pnlTopControls.Controls.Add(this.btnExportCsv);
            this.pnlTopControls.Controls.Add(this.btnAddTask);
            this.pnlTopControls.Controls.Add(this.lblSearch);
            this.pnlTopControls.Controls.Add(this.txtSearch);
            this.pnlTopControls.Dock = DockStyle.Top;
            this.pnlTopControls.Location = new Point(0, 0);
            this.pnlTopControls.Name = "pnlTopControls";
            this.pnlTopControls.Size = new Size(600, 100);
            this.pnlTopControls.TabIndex = 0;

            // 
            // pnlTaskDetails
            // 
            this.pnlTaskDetails.BackColor = Color.FromArgb(240, 240, 240);
            this.pnlTaskDetails.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTaskDetails.Controls.Add(this.lblTaskDetails);
            this.pnlTaskDetails.Controls.Add(this.lblTaskCreated);
            this.pnlTaskDetails.Controls.Add(this.lblTaskStatus);
            this.pnlTaskDetails.Controls.Add(this.lblTaskDueDate);
            this.pnlTaskDetails.Controls.Add(this.lblTaskCategory);
            this.pnlTaskDetails.Controls.Add(this.lblTaskDescription);
            this.pnlTaskDetails.Controls.Add(this.lblTaskTitle);
            this.pnlTaskDetails.Dock = DockStyle.Right;
            this.pnlTaskDetails.Name = "pnlTaskDetails";
            this.pnlTaskDetails.Padding = new Padding(100);
            // wider size so details fit well
            this.pnlTaskDetails.Size = new Size(50, 100); 
            this.pnlTaskDetails.TabIndex = 0;


            // Navigation Labels and Buttons
            this.lblNavigation.AutoSize = true;
            this.lblNavigation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblNavigation.ForeColor = Color.White;
            this.lblNavigation.Location = new Point(20, 20);
            this.lblNavigation.Name = "lblNavigation";
            this.lblNavigation.Size = new Size(100, 28);
            this.lblNavigation.TabIndex = 0;
            this.lblNavigation.Text = "Navigation";

            this.btnAllTasks.BackColor = Color.FromArgb(0, 120, 212);
            this.btnAllTasks.FlatAppearance.BorderSize = 0;
            this.btnAllTasks.FlatStyle = FlatStyle.Flat;
            this.btnAllTasks.Font = new Font("Segoe UI", 10F);
            this.btnAllTasks.ForeColor = Color.White;
            this.btnAllTasks.Location = new Point(20, 60);
            this.btnAllTasks.Name = "btnAllTasks";
            this.btnAllTasks.Size = new Size(210, 40);
            this.btnAllTasks.TabIndex = 1;
            this.btnAllTasks.Text = "📋 All Tasks";
            this.btnAllTasks.UseVisualStyleBackColor = false;

            this.btnPending.BackColor = Color.FromArgb(45, 45, 48);
            this.btnPending.FlatAppearance.BorderSize = 0;
            this.btnPending.FlatStyle = FlatStyle.Flat;
            this.btnPending.Font = new Font("Segoe UI", 10F);
            this.btnPending.ForeColor = Color.White;
            this.btnPending.Location = new Point(20, 110);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new Size(210, 40);
            this.btnPending.TabIndex = 2;
            this.btnPending.Text = "⏳ Pending";
            this.btnPending.UseVisualStyleBackColor = false;

            this.btnInProgress.BackColor = Color.FromArgb(45, 45, 48);
            this.btnInProgress.FlatAppearance.BorderSize = 0;
            this.btnInProgress.FlatStyle = FlatStyle.Flat;
            this.btnInProgress.Font = new Font("Segoe UI", 10F);
            this.btnInProgress.ForeColor = Color.White;
            this.btnInProgress.Location = new Point(20, 160);
            this.btnInProgress.Name = "btnInProgress";
            this.btnInProgress.Size = new Size(210, 40);
            this.btnInProgress.TabIndex = 3;
            this.btnInProgress.Text = "🔄 In Progress";
            this.btnInProgress.UseVisualStyleBackColor = false;

            this.btnCompleted.BackColor = Color.FromArgb(45, 45, 48);
            this.btnCompleted.FlatAppearance.BorderSize = 0;
            this.btnCompleted.FlatStyle = FlatStyle.Flat;
            this.btnCompleted.Font = new Font("Segoe UI", 10F);
            this.btnCompleted.ForeColor = Color.White;
            this.btnCompleted.Location = new Point(20, 210);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new Size(210, 40);
            this.btnCompleted.TabIndex = 4;
            this.btnCompleted.Text = "✅ Completed";
            this.btnCompleted.UseVisualStyleBackColor = false;

            this.btnOverdue.BackColor = Color.FromArgb(45, 45, 48);
            this.btnOverdue.FlatAppearance.BorderSize = 0;
            this.btnOverdue.FlatStyle = FlatStyle.Flat;
            this.btnOverdue.Font = new Font("Segoe UI", 10F);
            this.btnOverdue.ForeColor = Color.White;
            this.btnOverdue.Location = new Point(20, 260);
            this.btnOverdue.Name = "btnOverdue";
            this.btnOverdue.Size = new Size(210, 40);
            this.btnOverdue.TabIndex = 5;
            this.btnOverdue.Text = "⚠️ Overdue";
            this.btnOverdue.UseVisualStyleBackColor = false;

            this.btnDueToday.BackColor = Color.FromArgb(45, 45, 48);
            this.btnDueToday.FlatAppearance.BorderSize = 0;
            this.btnDueToday.FlatStyle = FlatStyle.Flat;
            this.btnDueToday.Font = new Font("Segoe UI", 10F);
            this.btnDueToday.ForeColor = Color.White;
            this.btnDueToday.Location = new Point(20, 310);
            this.btnDueToday.Name = "btnDueToday";
            this.btnDueToday.Size = new Size(210, 40);
            this.btnDueToday.TabIndex = 6;
            this.btnDueToday.Text = "📅 Due Today";
            this.btnDueToday.UseVisualStyleBackColor = false;

            this.btnThemeToggle.BackColor = Color.FromArgb(45, 45, 48);
            this.btnThemeToggle.FlatAppearance.BorderSize = 0;
            this.btnThemeToggle.FlatStyle = FlatStyle.Flat;
            this.btnThemeToggle.Font = new Font("Segoe UI", 12F);
            this.btnThemeToggle.ForeColor = Color.White;
            this.btnThemeToggle.Location = new Point(20, 400);
            this.btnThemeToggle.Name = "btnThemeToggle";
            this.btnThemeToggle.Size = new Size(50, 50);
            this.btnThemeToggle.TabIndex = 7;
            this.btnThemeToggle.Text = "🌙";
            this.btnThemeToggle.UseVisualStyleBackColor = false;

            this.btnGitHub.BackColor = Color.FromArgb(45, 45, 48);
            this.btnGitHub.FlatAppearance.BorderSize = 0;
            this.btnGitHub.FlatStyle = FlatStyle.Flat;
            this.btnGitHub.Font = new Font("Segoe UI", 10F);
            this.btnGitHub.ForeColor = Color.White;
            this.btnGitHub.Location = new Point(20, 500);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new Size(210, 40);
            this.btnGitHub.TabIndex = 8;
            this.btnGitHub.Text = "🐙 GitHub Profile";
            this.btnGitHub.UseVisualStyleBackColor = false;

            // Top Controls Panel
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F);
            this.lblSearch.Location = new Point(20, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(60, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";

            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(90, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search tasks...";
            this.txtSearch.Size = new Size(300, 30);
            this.txtSearch.TabIndex = 1;

            this.btnAddTask.BackColor = Color.FromArgb(0, 120, 212);
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.FlatStyle = FlatStyle.Flat;
            this.btnAddTask.Font = new Font("Segoe UI", 10F);
            this.btnAddTask.ForeColor = Color.White;
            this.btnAddTask.Location = new Point(420, 15);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new Size(120, 35);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "➕ Add Task";
            this.btnAddTask.UseVisualStyleBackColor = false;

            this.btnExportCsv.BackColor = Color.FromArgb(16, 124, 16);
            this.btnExportCsv.FlatAppearance.BorderSize = 0;
            this.btnExportCsv.FlatStyle = FlatStyle.Flat;
            this.btnExportCsv.Font = new Font("Segoe UI", 9F);
            this.btnExportCsv.ForeColor = Color.White;
            this.btnExportCsv.Location = new Point(560, 15);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new Size(80, 35);
            this.btnExportCsv.TabIndex = 3;
            this.btnExportCsv.Text = "📊 CSV";
            this.btnExportCsv.UseVisualStyleBackColor = false;

            this.btnExportExcel.BackColor = Color.FromArgb(16, 124, 16);
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = FlatStyle.Flat;
            this.btnExportExcel.Font = new Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = Color.White;
            this.btnExportExcel.Location = new Point(650, 15);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new Size(80, 35);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "📈 Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;

            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblFilterStatus.Location = new Point(20, 60);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new Size(100, 28);
            this.lblFilterStatus.TabIndex = 5;
            this.lblFilterStatus.Text = "All Tasks";

            this.lstTasks.Font = new Font("Segoe UI", 10F);
            this.lstTasks.FullRowSelect = true;
            this.lstTasks.GridLines = true;
            this.lstTasks.HideSelection = false;
            this.lstTasks.Dock = DockStyle.Fill;
            this.lstTasks.MultiSelect = false;
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.TabIndex = 6;
            this.lstTasks.UseCompatibleStateImageBehavior = false;
            this.lstTasks.View = View.Details;
            this.lstTasks.BackColor = Color.FromArgb(50, 50, 50);
            this.lstTasks.ForeColor = Color.White;
            this.lstTasks.BorderStyle = BorderStyle.FixedSingle;

            // ListView Columns
            this.lstTasks.Columns.Add("Title", 200);
            this.lstTasks.Columns.Add("Category", 120);
            this.lstTasks.Columns.Add("Due Date", 120);
            this.lstTasks.Columns.Add("Status", 100);

            // Task Details Panel
            this.lblTaskDetails.AutoSize = true;
            this.lblTaskDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTaskDetails.Location = new Point(15, 15);
            this.lblTaskDetails.Name = "lblTaskDetails";
            this.lblTaskDetails.Size = new Size(120, 28);
            this.lblTaskDetails.TabIndex = 0;
            this.lblTaskDetails.Text = "Task Details";

            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskTitle.Location = new Point(15, 60);
            this.lblTaskTitle.MaximumSize = new Size(300, 0);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new Size(100, 25);
            this.lblTaskTitle.TabIndex = 1;
            this.lblTaskTitle.Text = "Select a task";

            this.lblTaskDescription.AutoSize = true;
            this.lblTaskDescription.Font = new Font("Segoe UI", 10F);
            this.lblTaskDescription.Location = new Point(15, 100);
            this.lblTaskDescription.MaximumSize = new Size(300, 0);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new Size(0, 23);
            this.lblTaskDescription.TabIndex = 2;

            this.lblTaskCategory.AutoSize = true;
            this.lblTaskCategory.Font = new Font("Segoe UI", 10F);
            this.lblTaskCategory.Location = new Point(15, 140);
            this.lblTaskCategory.Name = "lblTaskCategory";
            this.lblTaskCategory.Size = new Size(0, 23);
            this.lblTaskCategory.TabIndex = 3;

            this.lblTaskDueDate.AutoSize = true;
            this.lblTaskDueDate.Font = new Font("Segoe UI", 10F);
            this.lblTaskDueDate.Location = new Point(15, 180);
            this.lblTaskDueDate.Name = "lblTaskDueDate";
            this.lblTaskDueDate.Size = new Size(0, 23);
            this.lblTaskDueDate.TabIndex = 4;

            this.lblTaskStatus.AutoSize = true;
            this.lblTaskStatus.Font = new Font("Segoe UI", 10F);
            this.lblTaskStatus.Location = new Point(15, 220);
            this.lblTaskStatus.Name = "lblTaskStatus";
            this.lblTaskStatus.Size = new Size(0, 23);
            this.lblTaskStatus.TabIndex = 5;

            this.lblTaskCreated.AutoSize = true;
            this.lblTaskCreated.Font = new Font("Segoe UI", 10F);
            this.lblTaskCreated.Location = new Point(15, 260);
            this.lblTaskCreated.Name = "lblTaskCreated";
            this.lblTaskCreated.Size = new Size(0, 23);
            this.lblTaskCreated.TabIndex = 6;

            // Add panels to main form
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlNavigation);

            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            this.pnlTopControls.ResumeLayout(false);
            this.pnlTopControls.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTaskDetails.ResumeLayout(false);
            this.pnlTaskDetails.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
