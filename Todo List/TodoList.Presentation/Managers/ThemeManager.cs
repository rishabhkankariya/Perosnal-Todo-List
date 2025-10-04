using TodoList.Models;

namespace TodoList.Presentation.Managers
{
    public class ThemeManager
    {
        private ThemeSettings _currentTheme = new();
        private readonly string _themeFilePath;

        public bool IsDarkMode => _currentTheme.IsDarkMode;

        public ThemeManager()
        {
            _themeFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TodoList", "theme.json");
            LoadTheme();
        }

        private void LoadTheme()
        {
            try
            {
                if (File.Exists(_themeFilePath))
                {
                    var json = File.ReadAllText(_themeFilePath);
                    _currentTheme = System.Text.Json.JsonSerializer.Deserialize<ThemeSettings>(json) ?? new ThemeSettings();
                }
                else
                {
                    _currentTheme = new ThemeSettings();
                }
            }
            catch
            {
                _currentTheme = new ThemeSettings();
            }
        }

        private void SaveTheme()
        {
            try
            {
                var directory = Path.GetDirectoryName(_themeFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory!);
                }

                var json = System.Text.Json.JsonSerializer.Serialize(_currentTheme, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_themeFilePath, json);
            }
            catch
            {
                // Ignore save errors
            }
        }

        public void ToggleTheme()
        {
            _currentTheme.IsDarkMode = !_currentTheme.IsDarkMode;
            SaveTheme();
        }

        public void ApplyTheme(Form form, bool isDarkMode)
        {
            _currentTheme.IsDarkMode = true; // Always dark mode
            
            ApplyDarkTheme(form);
        }

        private void ApplyDarkTheme(Form form)
        {
            form.BackColor = Color.FromArgb(32, 32, 32);
            form.ForeColor = Color.White;

            ApplyDarkThemeToControls(form.Controls);
        }

        private void ApplyLightTheme(Form form)
        {
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;

            ApplyLightThemeToControls(form.Controls);
        }

        private void ApplyDarkThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Panel panel:
                        if (panel.Name.Contains("Navigation") || panel.Name.Contains("nav"))
                        {
                            panel.BackColor = Color.FromArgb(45, 45, 48);
                        }
                        else
                        {
                            panel.BackColor = Color.FromArgb(40, 40, 40);
                        }
                        panel.ForeColor = Color.White;
                        break;

                    case Button button:
                        if (button.Name.Contains("Add") || button.Name.Contains("Save"))
                        {
                            button.BackColor = Color.FromArgb(0, 120, 212);
                        }
                        else if (button.Name.Contains("Export"))
                        {
                            button.BackColor = Color.FromArgb(16, 124, 16);
                        }
                        else if (button.Name.Contains("Cancel"))
                        {
                            button.BackColor = Color.FromArgb(108, 117, 125);
                        }
                        else
                        {
                            button.BackColor = Color.FromArgb(60, 60, 60);
                        }
                        button.ForeColor = Color.White;
                        button.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
                        break;

                    case TextBox textBox:
                        textBox.BackColor = Color.FromArgb(60, 60, 60);
                        textBox.ForeColor = Color.White;
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case ComboBox comboBox:
                        comboBox.BackColor = Color.FromArgb(60, 60, 60);
                        comboBox.ForeColor = Color.White;
                        comboBox.FlatStyle = FlatStyle.Flat;
                        break;

                    case ListView listView:
                        listView.BackColor = Color.FromArgb(50, 50, 50);
                        listView.ForeColor = Color.White;
                        listView.BorderStyle = BorderStyle.FixedSingle;
                        // Set header colors
                        listView.OwnerDraw = false;
                        break;

                    case Label label:
                        label.ForeColor = Color.White;
                        break;

                    case CheckBox checkBox:
                        checkBox.ForeColor = Color.White;
                        break;

                    case DateTimePicker dateTimePicker:
                        dateTimePicker.BackColor = Color.FromArgb(60, 60, 60);
                        dateTimePicker.ForeColor = Color.White;
                        dateTimePicker.CalendarTitleBackColor = Color.FromArgb(60, 60, 60);
                        dateTimePicker.CalendarTitleForeColor = Color.White;
                        dateTimePicker.CalendarTrailingForeColor = Color.Gray;
                        break;
                }

                if (control.HasChildren)
                {
                    ApplyDarkThemeToControls(control.Controls);
                }
            }
        }

        private void ApplyLightThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Panel panel:
                        if (panel.Name.Contains("Navigation") || panel.Name.Contains("nav"))
                        {
                            panel.BackColor = Color.FromArgb(45, 45, 48);
                        }
                        else
                        {
                            panel.BackColor = SystemColors.Control;
                        }
                        panel.ForeColor = SystemColors.ControlText;
                        break;

                    case Button button:
                        if (button.Name.Contains("Add") || button.Name.Contains("Save"))
                        {
                            button.BackColor = Color.FromArgb(0, 120, 212);
                        }
                        else if (button.Name.Contains("Export"))
                        {
                            button.BackColor = Color.FromArgb(16, 124, 16);
                        }
                        else if (button.Name.Contains("Cancel"))
                        {
                            button.BackColor = Color.FromArgb(108, 117, 125);
                        }
                        else
                        {
                            button.BackColor = SystemColors.Control;
                        }
                        button.ForeColor = Color.White;
                        button.FlatAppearance.BorderColor = SystemColors.ControlDark;
                        break;

                    case TextBox textBox:
                        textBox.BackColor = SystemColors.Window;
                        textBox.ForeColor = SystemColors.WindowText;
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case ComboBox comboBox:
                        comboBox.BackColor = SystemColors.Window;
                        comboBox.ForeColor = SystemColors.WindowText;
                        comboBox.FlatStyle = FlatStyle.Standard;
                        break;

                    case ListView listView:
                        listView.BackColor = SystemColors.Window;
                        listView.ForeColor = SystemColors.WindowText;
                        listView.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case Label label:
                        label.ForeColor = SystemColors.ControlText;
                        break;

                    case CheckBox checkBox:
                        checkBox.ForeColor = SystemColors.ControlText;
                        break;

                    case DateTimePicker dateTimePicker:
                        dateTimePicker.BackColor = SystemColors.Window;
                        dateTimePicker.ForeColor = SystemColors.WindowText;
                        dateTimePicker.CalendarTitleBackColor = SystemColors.Control;
                        dateTimePicker.CalendarTitleForeColor = SystemColors.ControlText;
                        dateTimePicker.CalendarTrailingForeColor = SystemColors.GrayText;
                        break;
                }

                if (control.HasChildren)
                {
                    ApplyLightThemeToControls(control.Controls);
                }
            }
        }
    }
}
