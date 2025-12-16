namespace FocusFlowFinal
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblThemeName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label lblVolumeValue;
        private System.Windows.Forms.CheckBox chkMinimalist;
        private System.Windows.Forms.CheckBox chkUseVideo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblAudioStatus;
        private System.Windows.Forms.Label lblVideoStatus;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            picPreview = new PictureBox();
            lblThemeName = new Label();
            lblDuration = new Label();
            numDuration = new NumericUpDown();
            lblVolume = new Label();
            trackVolume = new TrackBar();
            lblVolumeValue = new Label();
            chkMinimalist = new CheckBox();
            chkUseVideo = new CheckBox();
            btnStart = new Button();
            btnBack = new Button();
            lblAudioStatus = new Label();
            lblVideoStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackVolume).BeginInit();
            SuspendLayout();
            // 
            // picPreview
            // 
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(35, 92);
            picPreview.Margin = new Padding(4, 3, 4, 3);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(291, 207);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 0;
            picPreview.TabStop = false;
            // 
            // lblThemeName
            // 
            lblThemeName.AutoSize = true;
            lblThemeName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblThemeName.ForeColor = Color.White;
            lblThemeName.Location = new Point(350, 35);
            lblThemeName.Margin = new Padding(4, 0, 4, 0);
            lblThemeName.Name = "lblThemeName";
            lblThemeName.Size = new Size(180, 30);
            lblThemeName.TabIndex = 1;
            lblThemeName.Text = "Название темы";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.ForeColor = Color.White;
            lblDuration.Location = new Point(350, 115);
            lblDuration.Margin = new Padding(4, 0, 4, 0);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(132, 15);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Длительность (минут):";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(350, 138);
            numDuration.Margin = new Padding(4, 3, 4, 3);
            numDuration.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(140, 23);
            numDuration.TabIndex = 3;
            numDuration.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.ForeColor = Color.White;
            lblVolume.Location = new Point(350, 185);
            lblVolume.Margin = new Padding(4, 0, 4, 0);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(69, 15);
            lblVolume.TabIndex = 4;
            lblVolume.Text = "Громкость:";
            // 
            // trackVolume
            // 
            trackVolume.Location = new Point(350, 208);
            trackVolume.Margin = new Padding(4, 3, 4, 3);
            trackVolume.Maximum = 100;
            trackVolume.Name = "trackVolume";
            trackVolume.Size = new Size(175, 45);
            trackVolume.TabIndex = 5;
            trackVolume.Value = 70;
            trackVolume.Scroll += trackVolume_Scroll;
            // 
            // lblVolumeValue
            // 
            lblVolumeValue.AutoSize = true;
            lblVolumeValue.ForeColor = Color.White;
            lblVolumeValue.Location = new Point(537, 208);
            lblVolumeValue.Margin = new Padding(4, 0, 4, 0);
            lblVolumeValue.Name = "lblVolumeValue";
            lblVolumeValue.Size = new Size(29, 15);
            lblVolumeValue.TabIndex = 6;
            lblVolumeValue.Text = "70%";
            // 
            // chkMinimalist
            // 
            chkMinimalist.AutoSize = true;
            chkMinimalist.ForeColor = Color.White;
            chkMinimalist.Location = new Point(350, 277);
            chkMinimalist.Margin = new Padding(4, 3, 4, 3);
            chkMinimalist.Name = "chkMinimalist";
            chkMinimalist.Size = new Size(107, 19);
            chkMinimalist.TabIndex = 7;
            chkMinimalist.Text = "Полный экран";
            chkMinimalist.UseVisualStyleBackColor = true;
            // 
            // chkUseVideo
            // 
            chkUseVideo.AutoSize = true;
            chkUseVideo.ForeColor = Color.White;
            chkUseVideo.Location = new Point(350, 312);
            chkUseVideo.Margin = new Padding(4, 3, 4, 3);
            chkUseVideo.Name = "chkUseVideo";
            chkUseVideo.Size = new Size(138, 19);
            chkUseVideo.TabIndex = 8;
            chkUseVideo.Text = "Использовать видео";
            chkUseVideo.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(50, 180, 100);
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(233, 404);
            btnStart.Margin = new Padding(4, 3, 4, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(233, 58);
            btnStart.TabIndex = 9;
            btnStart.Text = "▶ НАЧАТЬ СЕССИЮ";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(100, 100, 120);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(35, 35);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(93, 35);
            btnBack.TabIndex = 10;
            btnBack.Text = "← Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblAudioStatus
            // 
            lblAudioStatus.AutoSize = true;
            lblAudioStatus.ForeColor = Color.LightGreen;
            lblAudioStatus.Location = new Point(35, 312);
            lblAudioStatus.Margin = new Padding(4, 0, 4, 0);
            lblAudioStatus.Name = "lblAudioStatus";
            lblAudioStatus.Size = new Size(100, 15);
            lblAudioStatus.TabIndex = 11;
            lblAudioStatus.Text = "Статус аудио: OK";
            // 
            // lblVideoStatus
            // 
            lblVideoStatus.AutoSize = true;
            lblVideoStatus.ForeColor = Color.LightGreen;
            lblVideoStatus.Location = new Point(35, 335);
            lblVideoStatus.Margin = new Padding(4, 0, 4, 0);
            lblVideoStatus.Name = "lblVideoStatus";
            lblVideoStatus.Size = new Size(100, 15);
            lblVideoStatus.TabIndex = 12;
            lblVideoStatus.Text = "Статус видео: OK";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            ClientSize = new Size(700, 519);
            Controls.Add(lblVideoStatus);
            Controls.Add(lblAudioStatus);
            Controls.Add(btnBack);
            Controls.Add(btnStart);
            Controls.Add(chkUseVideo);
            Controls.Add(chkMinimalist);
            Controls.Add(lblVolumeValue);
            Controls.Add(trackVolume);
            Controls.Add(lblVolume);
            Controls.Add(numDuration);
            Controls.Add(lblDuration);
            Controls.Add(lblThemeName);
            Controls.Add(picPreview);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройки сессии";
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}