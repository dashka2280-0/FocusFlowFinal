using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using NAudio.Wave;
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
    public partial class TimerForm : Form
    {
        private ThemeSettings theme;
        private int timeLeft;
        private bool isPaused = false;
        private AudioFileReader audioFileReader;
        private WaveOutEvent waveOut;
        private VideoView videoView;
        private LibVLC libVLC;
        private System.Windows.Forms.Timer countdownTimer;



        public TimerForm(ThemeSettings theme)
        {
            this.theme = theme;
            this.timeLeft = theme.DurationMinutes * 60;

            InitializeComponent();

            if (theme.UseVideo)
            {
                InitializeVLC();
            }

            InitializeUI();
            InitializeSound();
            StartTimer();
            AttachEvents();
        }

        private void InitializeVLC()
        {
            try
            {
                Core.Initialize();
                libVLC = new LibVLC("--no-video-title-show", "--input-repeat=65535", "--quiet");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации видео: {ex.Message}\nБудет использовано изображение.",
                    "FocusFlow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                libVLC = null;
                theme.UseVideo = false;
            }
        }

        private void InitializeUI()
        {
            if (theme.IsMinimalist)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Size = new Size(900, 700);
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            this.Text = $"FocusFlow - {theme.DisplayName}";

            if (theme.UseVideo && libVLC != null)
            {
                LoadVideoBackground();
            }
            else
            {
                LoadImageBackground();
            }

            lblTimer.Text = FormatTime(timeLeft);
            lblTheme.Text = theme.DisplayName;

            if (videoView != null)
            {
                lblTimer.BackColor = Color.Transparent;
                lblTheme.BackColor = Color.Transparent;
                btnPause.BackColor = Color.FromArgb(150, 70, 70, 90);
                btnContinue.BackColor = Color.FromArgb(150, 70, 70, 90);
                btnStop.BackColor = Color.FromArgb(150, 70, 70, 90);
                btnMenu.BackColor = Color.FromArgb(150, 70, 70, 90);
            }

            btnContinue.Visible = false;
        }

        private void LoadVideoBackground()
        {
            string videoPath = theme.GetVideoPath();
            if (!File.Exists(videoPath))
            {
                LoadImageBackground();
                return;
            }

            try
            {
                videoView = new VideoView();
                videoView.Dock = DockStyle.Fill;
                videoView.BackColor = Color.Black;
                videoView.MediaPlayer = new MediaPlayer(libVLC);
                videoView.MediaPlayer.EnableMouseInput = false;
                videoView.MediaPlayer.EnableKeyInput = false;

                this.Controls.Add(videoView);
                videoView.SendToBack();

                var media = new Media(libVLC, videoPath);
                media.AddOption(":input-repeat=65535");
                media.AddOption(":no-video-title-show");

                videoView.MediaPlayer.Play(media);
                videoView.MediaPlayer.Volume = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить видео: {ex.Message}\nБудет использовано изображение.",
                    "FocusFlow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadImageBackground();
            }
        }

        private void LoadImageBackground()
        {
            string previewPath = theme.GetPreviewPath();
            if (!string.IsNullOrEmpty(previewPath) && File.Exists(previewPath))
            {
                try
                {
                    this.BackgroundImage = Image.FromFile(previewPath);
                    this.BackgroundImageLayout = theme.IsMinimalist ?
                        ImageLayout.Zoom : ImageLayout.Stretch;
                }
                catch { }
            }
            else
            {
                this.BackColor = Color.FromArgb(30, 30, 40);
            }
        }

        private void InitializeSound()
        {
            string audioPath = theme.GetAudioPath();
            if (!File.Exists(audioPath)) return;

            try
            {
                audioFileReader = new AudioFileReader(audioPath);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFileReader);

                float volume = theme.Volume / 100.0f;
                audioFileReader.Volume = volume;

                waveOut.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось воспроизвести звук: {ex.Message}",
                    "FocusFlow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void StartTimer()
        {
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void AttachEvents()
        {
            btnPause.Click += BtnPause_Click;
            btnContinue.Click += BtnContinue_Click;
            btnStop.Click += BtnStop_Click;
            btnMenu.Click += BtnMenu_Click;

            this.KeyPreview = true;
            this.KeyDown += TimerForm_KeyDown;
            this.Resize += TimerForm_Resize;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                timeLeft--;
                lblTimer.Text = FormatTime(timeLeft);

                if (timeLeft <= 0)
                {
                    countdownTimer.Stop();
                    SessionCompleted();
                }
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            btnPause.Visible = false;
            btnContinue.Visible = true;

            if (waveOut != null)
                waveOut.Pause();

            if (videoView?.MediaPlayer != null)
                videoView.MediaPlayer.Pause();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            isPaused = false;
            btnPause.Visible = true;
            btnContinue.Visible = false;

            if (waveOut != null)
                waveOut.Play();

            if (videoView?.MediaPlayer != null)
                videoView.MediaPlayer.Play();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();

            if (waveOut != null)
                waveOut.Stop();

            if (videoView?.MediaPlayer != null)
                videoView.MediaPlayer.Stop();

            DialogResult result = MessageBox.Show("Завершить сессию досрочно?", "FocusFlow",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ReturnToMainMenu();
            }
            else
            {
                countdownTimer.Start();
                if (waveOut != null && !isPaused)
                    waveOut.Play();
                if (videoView?.MediaPlayer != null && !isPaused)
                    videoView.MediaPlayer.Play();
            }
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();
        }

        private void SessionCompleted()
        {
            if (waveOut != null)
                waveOut.Stop();

            if (videoView?.MediaPlayer != null)
                videoView.MediaPlayer.Stop();

            System.Media.SystemSounds.Exclamation.Play();

            MessageBox.Show($"Сессия '{theme.DisplayName}' завершена!\nОтличная работа! 🎉",
                "FocusFlow", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReturnToMainMenu();
        }

        private void ReturnToMainMenu()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }

            if (audioFileReader != null)
                audioFileReader.Dispose();

            if (videoView != null)
            {
                if (videoView.MediaPlayer != null)
                {
                    videoView.MediaPlayer.Stop();
                    videoView.MediaPlayer.Dispose();
                }
                videoView.Dispose();
            }

            if (libVLC != null)
                libVLC.Dispose();

            this.Close();
        }

        private void TimerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (isPaused) BtnContinue_Click(sender, e);
                    else BtnPause_Click(sender, e);
                    break;
                case Keys.Escape:
                    ReturnToMainMenu();
                    break;
                case Keys.S:
                    BtnStop_Click(sender, e);
                    break;
                case Keys.M:
                    ReturnToMainMenu();
                    break;
            }
        }

        private void TimerForm_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            if (lblTimer != null)
            {
                lblTimer.Left = (this.ClientSize.Width - lblTimer.Width) / 2;
                lblTimer.Top = this.ClientSize.Height / 3 - lblTimer.Height / 2;
            }

            if (lblTheme != null)
            {
                lblTheme.Left = (this.ClientSize.Width - lblTheme.Width) / 2;
                lblTheme.Top = lblTimer.Bottom + 20;
            }

            if (btnPause != null)
            {
                int buttonY = this.ClientSize.Height - 100;
                int totalWidth = btnPause.Width * 4 + 30;
                int startX = (this.ClientSize.Width - totalWidth) / 2;

                btnPause.Left = startX;
                btnPause.Top = buttonY;
                btnContinue.Left = startX;
                btnContinue.Top = buttonY;
                btnStop.Left = startX + btnPause.Width + 10;
                btnStop.Top = buttonY;
                btnMenu.Left = startX + btnPause.Width * 2 + 20;
                btnMenu.Top = buttonY;
            }
        }

        private string FormatTime(int seconds)
        {
            int minutes = seconds / 60;
            int secs = seconds % 60;
            return $"{minutes:00}:{secs:00}";
        }
    }
}
