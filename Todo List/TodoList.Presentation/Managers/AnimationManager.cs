using System.Drawing.Drawing2D;

namespace TodoList.Presentation.Managers
{
    public class AnimationManager
    {
        private readonly System.Windows.Forms.Timer _fadeTimer;
        private readonly System.Windows.Forms.Timer _slideTimer;
        private Control? _currentControl;
        private float _currentOpacity = 1.0f;
        private int _currentSlideOffset = 0;
        private bool _isAnimating = false;

        public AnimationManager()
        {
            _fadeTimer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            _fadeTimer.Tick += OnFadeTimerTick;

            _slideTimer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            _slideTimer.Tick += OnSlideTimerTick;
        }

        public void AnimateButtonHover(Button button, bool isHovering)
        {
            if (_isAnimating) return;

            _isAnimating = true;
            _currentControl = button;

            if (isHovering)
            {
                AnimateButtonHoverIn(button);
            }
            else
            {
                AnimateButtonHoverOut(button);
            }
        }

        private void AnimateButtonHoverIn(Button button)
        {
            var originalColor = button.BackColor;
            var hoverColor = Color.FromArgb(
                Math.Min(255, originalColor.R + 20),
                Math.Min(255, originalColor.G + 20),
                Math.Min(255, originalColor.B + 20)
            );

            // Simple color transition
            Task.Run(async () =>
            {
                for (int i = 0; i <= 10; i++)
                {
                    var ratio = i / 10.0f;
                    var r = (int)(originalColor.R + (hoverColor.R - originalColor.R) * ratio);
                    var g = (int)(originalColor.G + (hoverColor.G - originalColor.G) * ratio);
                    var b = (int)(originalColor.B + (hoverColor.B - originalColor.B) * ratio);

                    if (button.InvokeRequired)
                    {
                        button.Invoke(new Action(() => button.BackColor = Color.FromArgb(r, g, b)));
                    }
                    else
                    {
                        button.BackColor = Color.FromArgb(r, g, b);
                    }

                    await Task.Delay(20);
                }
                _isAnimating = false;
            });
        }

        private void AnimateButtonHoverOut(Button button)
        {
            var currentColor = button.BackColor;
            var originalColor = GetOriginalButtonColor(button);

            Task.Run(async () =>
            {
                for (int i = 10; i >= 0; i--)
                {
                    var ratio = i / 10.0f;
                    var r = (int)(originalColor.R + (currentColor.R - originalColor.R) * ratio);
                    var g = (int)(originalColor.G + (currentColor.G - originalColor.G) * ratio);
                    var b = (int)(originalColor.B + (currentColor.B - originalColor.B) * ratio);

                    if (button.InvokeRequired)
                    {
                        button.Invoke(new Action(() => button.BackColor = Color.FromArgb(r, g, b)));
                    }
                    else
                    {
                        button.BackColor = Color.FromArgb(r, g, b);
                    }

                    await Task.Delay(20);
                }
                _isAnimating = false;
            });
        }

        private Color GetOriginalButtonColor(Button button)
        {
            if (button.Name.Contains("Add") || button.Name.Contains("Save"))
                return Color.FromArgb(0, 120, 212);
            else if (button.Name.Contains("Export"))
                return Color.FromArgb(16, 124, 16);
            else if (button.Name.Contains("Cancel"))
                return Color.FromArgb(108, 117, 125);
            else
                return Color.FromArgb(45, 45, 48);
        }

        public void AnimateListUpdate(ListView listView)
        {
            if (_isAnimating) return;

            _isAnimating = true;
            _currentControl = listView;
            
            // Simple refresh animation for ListView
            listView.BeginUpdate();
            listView.EndUpdate();
            _isAnimating = false;
        }

        private void OnFadeTimerTick(object? sender, EventArgs e)
        {
            if (_currentControl == null) return;

            _currentOpacity += 0.05f;

            if (_currentOpacity >= 1.0f)
            {
                _currentOpacity = 1.0f;
                _fadeTimer.Stop();
                _isAnimating = false;
            }

            // Opacity animation not supported for WinForms controls
            // This method is kept for potential future use with custom controls
        }

        public void AnimateFormTransition(Form form, bool isClosing)
        {
            if (_isAnimating) return;

            _isAnimating = true;
            _currentControl = form;

            // Simple form transition without opacity
            if (isClosing)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            else
            {
                form.WindowState = FormWindowState.Normal;
            }
            _isAnimating = false;
        }

        private void OnSlideTimerTick(object? sender, EventArgs e)
        {
            if (_currentControl == null) return;

            _currentSlideOffset += 5;

            if (_currentSlideOffset >= 20)
            {
                _currentSlideOffset = 0;
                _slideTimer.Stop();
                _isAnimating = false;
            }

            // Apply slide animation to control
            if (_currentControl is Panel panel)
            {
                panel.Location = new Point(panel.Location.X, panel.Location.Y + _currentSlideOffset);
            }
        }

        public void AnimateControlSlide(Control control, int targetX, int targetY)
        {
            if (_isAnimating) return;

            _isAnimating = true;
            _currentControl = control;

            Task.Run(async () =>
            {
                var startX = control.Location.X;
                var startY = control.Location.Y;
                var steps = 20;

                for (int i = 0; i <= steps; i++)
                {
                    var ratio = i / (float)steps;
                    var currentX = (int)(startX + (targetX - startX) * ratio);
                    var currentY = (int)(startY + (targetY - startY) * ratio);

                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(() => control.Location = new Point(currentX, currentY)));
                    }
                    else
                    {
                        control.Location = new Point(currentX, currentY);
                    }

                    await Task.Delay(20);
                }
                _isAnimating = false;
            });
        }

        public void AnimateControlFade(Control control, bool fadeIn)
        {
            if (_isAnimating) return;

            _isAnimating = true;
            _currentControl = control;

            // Simple visibility toggle since WinForms doesn't support opacity
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => control.Visible = fadeIn));
            }
            else
            {
                control.Visible = fadeIn;
            }
            _isAnimating = false;
        }

        public void Dispose()
        {
            _fadeTimer?.Dispose();
            _slideTimer?.Dispose();
        }
    }
}
