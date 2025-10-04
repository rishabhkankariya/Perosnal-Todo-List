namespace TodoList.Presentation.Forms
{
    partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblTitleCount;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblDescriptionCount;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblDueDate;
        private CheckBox chkHasDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnSave;
        private Button btnCancel;
        private Panel pnlMain;

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
            this.pnlMain = new Panel();
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblTitleCount = new Label();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblDescriptionCount = new Label();
            this.lblCategory = new Label();
            this.txtCategory = new TextBox();
            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();
            this.lblDueDate = new Label();
            this.chkHasDueDate = new CheckBox();
            this.dtpDueDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add New Task";

            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.dtpDueDate);
            this.pnlMain.Controls.Add(this.chkHasDueDate);
            this.pnlMain.Controls.Add(this.lblDueDate);
            this.pnlMain.Controls.Add(this.cmbStatus);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.txtCategory);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.lblDescriptionCount);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.lblTitleCount);
            this.pnlMain.Controls.Add(this.txtTitle);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(500, 600);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(50, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";

            // 
            // txtTitle
            // 
            this.txtTitle.Font = new Font("Segoe UI", 10F);
            this.txtTitle.Location = new Point(30, 60);
            this.txtTitle.MaxLength = 200;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Enter task title...";
            this.txtTitle.Size = new Size(440, 30);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new EventHandler(this.txtTitle_TextChanged);

            // 
            // lblTitleCount
            // 
            this.lblTitleCount.AutoSize = true;
            this.lblTitleCount.Font = new Font("Segoe UI", 8F);
            this.lblTitleCount.ForeColor = Color.Gray;
            this.lblTitleCount.Location = new Point(30, 95);
            this.lblTitleCount.Name = "lblTitleCount";
            this.lblTitleCount.Size = new Size(50, 19);
            this.lblTitleCount.TabIndex = 2;
            this.lblTitleCount.Text = "0/200";

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDescription.Location = new Point(30, 130);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(100, 23);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";

            // 
            // txtDescription
            // 
            this.txtDescription.Font = new Font("Segoe UI", 10F);
            this.txtDescription.Location = new Point(30, 160);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Enter task description (optional)...";
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.Size = new Size(440, 100);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextChanged += new EventHandler(this.txtDescription_TextChanged);

            // 
            // lblDescriptionCount
            // 
            this.lblDescriptionCount.AutoSize = true;
            this.lblDescriptionCount.Font = new Font("Segoe UI", 8F);
            this.lblDescriptionCount.ForeColor = Color.Gray;
            this.lblDescriptionCount.Location = new Point(30, 265);
            this.lblDescriptionCount.Name = "lblDescriptionCount";
            this.lblDescriptionCount.Size = new Size(60, 19);
            this.lblDescriptionCount.TabIndex = 5;
            this.lblDescriptionCount.Text = "0/1000";

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCategory.Location = new Point(30, 300);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(80, 23);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category:";

            // 
            // txtCategory
            // 
            this.txtCategory.Font = new Font("Segoe UI", 10F);
            this.txtCategory.Location = new Point(30, 330);
            this.txtCategory.MaxLength = 50;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.PlaceholderText = "Enter category (optional)...";
            this.txtCategory.Size = new Size(440, 30);
            this.txtCategory.TabIndex = 7;

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatus.Location = new Point(30, 380);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(60, 23);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";

            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new Point(30, 410);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(200, 31);
            this.cmbStatus.TabIndex = 9;

            // Add status items
            this.cmbStatus.Items.AddRange(new object[] {
                Models.TaskStatus.Pending,
                Models.TaskStatus.InProgress,
                Models.TaskStatus.Done
            });
            this.cmbStatus.SelectedIndex = 0;

            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDueDate.Location = new Point(30, 460);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new Size(80, 23);
            this.lblDueDate.TabIndex = 10;
            this.lblDueDate.Text = "Due Date:";

            // 
            // chkHasDueDate
            // 
            this.chkHasDueDate.AutoSize = true;
            this.chkHasDueDate.Font = new Font("Segoe UI", 10F);
            this.chkHasDueDate.Location = new Point(30, 490);
            this.chkHasDueDate.Name = "chkHasDueDate";
            this.chkHasDueDate.Size = new Size(120, 27);
            this.chkHasDueDate.TabIndex = 11;
            this.chkHasDueDate.Text = "Set due date";
            this.chkHasDueDate.UseVisualStyleBackColor = true;
            this.chkHasDueDate.CheckedChanged += new EventHandler(this.chkHasDueDate_CheckedChanged);

            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Font = new Font("Segoe UI", 10F);
            this.dtpDueDate.Format = DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new Point(160, 488);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new Size(200, 30);
            this.dtpDueDate.TabIndex = 12;
            this.dtpDueDate.CustomFormat = "MM/dd/yyyy HH:mm";

            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(0, 120, 212);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(300, 540);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Create Task";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(410, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
