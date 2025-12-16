namespace FocusFlowFinal
{
    partial class TimerForm
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label lblTimer;
        public System.Windows.Forms.Label lblTheme;
        public System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Button btnContinue;
        public System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.Button btnMenu;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerForm));
            lblTimer = new Label();
            lblTheme = new Label();
            btnPause = new Button();
            btnContinue = new Button();
            btnStop = new Button();
            btnMenu = new Button();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.Transparent;
            lblTimer.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTimer.ForeColor = Color.FromArgb(220, 255, 255, 255);
            lblTimer.Location = new Point(272, 183);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(300, 128);
            lblTimer.TabIndex = 0;
            lblTimer.Text = "25:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTheme
            // 
            lblTheme.AutoSize = true;
            lblTheme.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTheme.ForeColor = Color.White;
            lblTheme.Location = new Point(327, 311);
            lblTheme.Margin = new Padding(4, 0, 4, 0);
            lblTheme.Name = "lblTheme";
            lblTheme.Size = new Size(95, 45);
            lblTheme.TabIndex = 1;
            lblTheme.Text = "Тема";
            lblTheme.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.FromArgb(60, 60, 80, 150);
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.Font = new Font("Segoe UI", 11F);
            btnPause.ForeColor = Color.White;
            btnPause.Location = new Point(200, 572);
            btnPause.Margin = new Padding(4, 3, 4, 3);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(140, 58);
            btnPause.TabIndex = 2;
            btnPause.Text = "⏸️ Пауза";
            btnPause.UseVisualStyleBackColor = false;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.FromArgb(60, 60, 80, 150);
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI", 11F);
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(200, 572);
            btnContinue.Margin = new Padding(4, 3, 4, 3);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(140, 58);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "▶️ Продолжить";
            btnContinue.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(60, 60, 80, 150);
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 11F);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(364, 572);
            btnStop.Margin = new Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(140, 58);
            btnStop.TabIndex = 4;
            btnStop.Text = "⏹️ Остановить";
            btnStop.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(60, 60, 80, 150);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 11F);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(527, 572);
            btnMenu.Margin = new Padding(4, 3, 4, 3);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(140, 58);
            btnMenu.TabIndex = 5;
            btnMenu.Text = "↩️ В меню";
            btnMenu.UseVisualStyleBackColor = false;
            // 
            // TimerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            ClientSize = new Size(867, 655);
            Controls.Add(btnMenu);
            Controls.Add(btnStop);
            Controls.Add(btnContinue);
            Controls.Add(btnPause);
            Controls.Add(lblTheme);
            Controls.Add(lblTimer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "TimerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FocusFlow - Таймер";
            ResumeLayout(false);
            PerformLayout();


        }
    }
}