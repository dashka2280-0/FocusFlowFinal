using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusFlowFinal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateThemeButtons();
        }

        private void CreateThemeButtons()
        {
            // Очищаем существующие кнопки
            

            ThemeSettings[] themes = {
                new ThemeSettings { ThemeName = "Rain", DisplayName = "🌧️ Дождь" },
                new ThemeSettings { ThemeName = "Forest", DisplayName = "🌲 Лес" },
                new ThemeSettings { ThemeName = "Fireplace", DisplayName = "🔥 Камин" },
                new ThemeSettings { ThemeName = "City", DisplayName = "🏙️ Город" },
                new ThemeSettings { ThemeName = "Ocean", DisplayName = "🌊 Океан" },
                new ThemeSettings { ThemeName = "Library", DisplayName = "📚 Библиотека" }
            };

            int x = 50;
            int y = 100;
            int buttonWidth = 180;
            int buttonHeight = 100;
            int spacing = 20;

            foreach (var theme in themes)
            {
                Button btn = new Button();
                btn.Text = theme.DisplayName;
                btn.Font = new Font("Segoe UI", 11);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(70, 130, 180);
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.Location = new Point(x, y);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Tag = theme;
                btn.Click += ThemeButton_Click;

                // Проверяем наличие файлов
                string themePath = theme.GetThemePath();
                bool hasFiles = Directory.Exists(themePath) &&
                               (File.Exists(theme.GetAudioPath()) || File.Exists(theme.GetVideoPath()));

                if (!hasFiles)
                {
                    btn.BackColor = Color.FromArgb(100, 100, 100);
                    btn.Text += "\n(нет файлов)";
                }

                this.Controls.Add(btn);

                x += buttonWidth + spacing;
                if (x + buttonWidth > this.ClientSize.Width - 50)
                {
                    x = 50;
                    y += buttonHeight + spacing;
                }
            }

            // Позиционируем кнопку создания темы
           
        }

        private void ThemeButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ThemeSettings theme = btn.Tag as ThemeSettings;

            SettingsForm settingsForm = new SettingsForm(theme);
            this.Hide();
            settingsForm.ShowDialog();
            this.Show();
            CreateThemeButtons(); // Обновляем кнопки
        }



        private void MainForm_Resize(object sender, EventArgs e)
        {
            CreateThemeButtons();
        }

        private void btnCustomTheme_Click(object sender, EventArgs e)
        {

        }
    }
}