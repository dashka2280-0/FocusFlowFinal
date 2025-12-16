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
    public partial class SettingsForm : Form
    {
        private ThemeSettings theme;
        

        public SettingsForm(ThemeSettings theme)
        {
            this.theme = theme;
            InitializeComponent();
            LoadPreview();
        }

        private void LoadPreview()
        {
            string previewPath = theme.GetPreviewPath();
            if (!string.IsNullOrEmpty(previewPath) && File.Exists(previewPath))
            {
                try
                {
                    picPreview.Image = Image.FromFile(previewPath);
                }
                catch
                {
                    picPreview.BackColor = Color.Gray;
                }
            }
            else
            {
                picPreview.BackColor = Color.Gray;
                picPreview.Image = null;
            }

            lblThemeName.Text = theme.DisplayName;
            numDuration.Value = theme.DurationMinutes;
            trackVolume.Value = theme.Volume;
            lblVolume.Text = $"{theme.Volume}%";
            chkMinimalist.Checked = theme.IsMinimalist;
            chkUseVideo.Checked = theme.UseVideo;

            // Проверяем наличие файлов
            bool hasAudio = File.Exists(theme.GetAudioPath());
            bool hasVideo = File.Exists(theme.GetVideoPath());

            if (!hasAudio)
            {
                lblAudioStatus.Text = "Аудиофайл не найден";
                lblAudioStatus.ForeColor = Color.Red;
            }
            else
            {
                lblAudioStatus.Text = "Аудиофайл готов";
                lblAudioStatus.ForeColor = Color.LightGreen;
            }

            if (!hasVideo)
            {
                lblVideoStatus.Text = "Видеофайл не найден";
                lblVideoStatus.ForeColor = Color.Red;
                chkUseVideo.Enabled = false;
            }
            else
            {
                lblVideoStatus.Text = "Видеофайл готов";
                lblVideoStatus.ForeColor = Color.LightGreen;
            }
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            lblVolume.Text = $"{trackVolume.Value}%";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            theme.DurationMinutes = (int)numDuration.Value;
            theme.Volume = trackVolume.Value;
            theme.IsMinimalist = chkMinimalist.Checked;
            theme.UseVideo = chkUseVideo.Checked;

            // Проверяем наличие аудио
            if (!File.Exists(theme.GetAudioPath()))
            {
                MessageBox.Show("Аудиофайл не найден! Добавьте файл audio.mp3 в папку темы.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем видео если оно включено
            if (theme.UseVideo && !File.Exists(theme.GetVideoPath()))
            {
                MessageBox.Show("Видеофайл не найден, но видеофон включен. Выключите видеофон или добавьте video.mp4.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimerForm timerForm = new TimerForm(theme);
            this.Hide();
            timerForm.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
