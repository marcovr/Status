namespace Status
{
    partial class mainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.contentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cpuFrame = new System.Windows.Forms.GroupBox();
            this.ramImg = new System.Windows.Forms.PictureBox();
            this.cpuImg = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ramBar = new Status.ProgressBarEx();
            this.label1 = new System.Windows.Forms.Label();
            this.cpuBar = new Status.ProgressBarEx();
            this.driveFrame = new System.Windows.Forms.GroupBox();
            this.batteryFrame = new System.Windows.Forms.GroupBox();
            this.BatteryImg = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.batteryBar = new Status.ProgressBarEx();
            this.diskFrame = new System.Windows.Forms.GroupBox();
            this.diskImg = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.diskBar = new Status.ProgressBarEx();
            this.mediaFrame = new System.Windows.Forms.GroupBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.playerinfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.cpuFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuImg)).BeginInit();
            this.batteryFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryImg)).BeginInit();
            this.diskFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diskImg)).BeginInit();
            this.mediaFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.ColumnCount = 1;
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentPanel.Controls.Add(this.cpuFrame, 0, 0);
            this.contentPanel.Controls.Add(this.driveFrame, 0, 3);
            this.contentPanel.Controls.Add(this.batteryFrame, 0, 1);
            this.contentPanel.Controls.Add(this.diskFrame, 0, 2);
            this.contentPanel.Controls.Add(this.mediaFrame, 0, 4);
            this.contentPanel.Location = new System.Drawing.Point(12, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RowCount = 5;
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.Size = new System.Drawing.Size(176, 345);
            this.contentPanel.TabIndex = 1;
            // 
            // cpuFrame
            // 
            this.cpuFrame.Controls.Add(this.ramImg);
            this.cpuFrame.Controls.Add(this.cpuImg);
            this.cpuFrame.Controls.Add(this.label2);
            this.cpuFrame.Controls.Add(this.ramBar);
            this.cpuFrame.Controls.Add(this.label1);
            this.cpuFrame.Controls.Add(this.cpuBar);
            this.cpuFrame.ForeColor = System.Drawing.Color.White;
            this.cpuFrame.Location = new System.Drawing.Point(3, 3);
            this.cpuFrame.Name = "cpuFrame";
            this.cpuFrame.Size = new System.Drawing.Size(170, 71);
            this.cpuFrame.TabIndex = 3;
            this.cpuFrame.TabStop = false;
            this.cpuFrame.Text = "CPU / RAM";
            // 
            // ramImg
            // 
            this.ramImg.Image = global::Status.Properties.Resources.RAM;
            this.ramImg.Location = new System.Drawing.Point(6, 41);
            this.ramImg.Name = "ramImg";
            this.ramImg.Size = new System.Drawing.Size(16, 16);
            this.ramImg.TabIndex = 5;
            this.ramImg.TabStop = false;
            // 
            // cpuImg
            // 
            this.cpuImg.Image = global::Status.Properties.Resources.CPU;
            this.cpuImg.Location = new System.Drawing.Point(6, 19);
            this.cpuImg.Name = "cpuImg";
            this.cpuImg.Size = new System.Drawing.Size(16, 16);
            this.cpuImg.TabIndex = 4;
            this.cpuImg.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // ramBar
            // 
            this.ramBar.Location = new System.Drawing.Point(28, 41);
            this.ramBar.Name = "ramBar";
            this.ramBar.Size = new System.Drawing.Size(115, 16);
            this.ramBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            // 
            // cpuBar
            // 
            this.cpuBar.Location = new System.Drawing.Point(28, 19);
            this.cpuBar.Name = "cpuBar";
            this.cpuBar.Size = new System.Drawing.Size(115, 16);
            this.cpuBar.TabIndex = 0;
            // 
            // driveFrame
            // 
            this.driveFrame.ForeColor = System.Drawing.Color.White;
            this.driveFrame.Location = new System.Drawing.Point(3, 190);
            this.driveFrame.Name = "driveFrame";
            this.driveFrame.Size = new System.Drawing.Size(170, 71);
            this.driveFrame.TabIndex = 2;
            this.driveFrame.TabStop = false;
            this.driveFrame.Text = "Drive Capacity";
            // 
            // batteryFrame
            // 
            this.batteryFrame.Controls.Add(this.BatteryImg);
            this.batteryFrame.Controls.Add(this.label4);
            this.batteryFrame.Controls.Add(this.batteryBar);
            this.batteryFrame.ForeColor = System.Drawing.Color.White;
            this.batteryFrame.Location = new System.Drawing.Point(3, 80);
            this.batteryFrame.Name = "batteryFrame";
            this.batteryFrame.Size = new System.Drawing.Size(170, 49);
            this.batteryFrame.TabIndex = 6;
            this.batteryFrame.TabStop = false;
            this.batteryFrame.Text = "Battery";
            // 
            // BatteryImg
            // 
            this.BatteryImg.Image = global::Status.Properties.Resources.Battery;
            this.BatteryImg.Location = new System.Drawing.Point(6, 19);
            this.BatteryImg.Name = "BatteryImg";
            this.BatteryImg.Size = new System.Drawing.Size(16, 16);
            this.BatteryImg.TabIndex = 4;
            this.BatteryImg.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "%";
            // 
            // batteryBar
            // 
            this.batteryBar.Location = new System.Drawing.Point(28, 19);
            this.batteryBar.Name = "batteryBar";
            this.batteryBar.Size = new System.Drawing.Size(115, 16);
            this.batteryBar.TabIndex = 0;
            // 
            // diskFrame
            // 
            this.diskFrame.Controls.Add(this.diskImg);
            this.diskFrame.Controls.Add(this.label3);
            this.diskFrame.Controls.Add(this.diskBar);
            this.diskFrame.ForeColor = System.Drawing.Color.White;
            this.diskFrame.Location = new System.Drawing.Point(3, 135);
            this.diskFrame.Name = "diskFrame";
            this.diskFrame.Size = new System.Drawing.Size(170, 49);
            this.diskFrame.TabIndex = 7;
            this.diskFrame.TabStop = false;
            this.diskFrame.Text = "Disk Usage";
            // 
            // diskImg
            // 
            this.diskImg.Image = global::Status.Properties.Resources.drive;
            this.diskImg.Location = new System.Drawing.Point(6, 19);
            this.diskImg.Name = "diskImg";
            this.diskImg.Size = new System.Drawing.Size(16, 16);
            this.diskImg.TabIndex = 4;
            this.diskImg.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "%";
            // 
            // diskBar
            // 
            this.diskBar.Location = new System.Drawing.Point(28, 19);
            this.diskBar.Name = "diskBar";
            this.diskBar.Size = new System.Drawing.Size(115, 16);
            this.diskBar.TabIndex = 0;
            // 
            // mediaFrame
            // 
            this.mediaFrame.Controls.Add(this.btn_stop);
            this.mediaFrame.Controls.Add(this.btn_play);
            this.mediaFrame.Controls.Add(this.playerinfo);
            this.mediaFrame.ForeColor = System.Drawing.Color.White;
            this.mediaFrame.Location = new System.Drawing.Point(3, 267);
            this.mediaFrame.Name = "mediaFrame";
            this.mediaFrame.Size = new System.Drawing.Size(170, 75);
            this.mediaFrame.TabIndex = 8;
            this.mediaFrame.TabStop = false;
            this.mediaFrame.Text = "Media Player";
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_stop.Location = new System.Drawing.Point(89, 46);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_click);
            // 
            // btn_play
            // 
            this.btn_play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_play.Location = new System.Drawing.Point(6, 46);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Click += new System.EventHandler(this.btn_play_click);
            // 
            // playerinfo
            // 
            this.playerinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playerinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerinfo.ForeColor = System.Drawing.Color.White;
            this.playerinfo.Location = new System.Drawing.Point(6, 16);
            this.playerinfo.Name = "playerinfo";
            this.playerinfo.Size = new System.Drawing.Size(158, 24);
            this.playerinfo.TabIndex = 12;
            this.playerinfo.Text = "Info";
            this.playerinfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.playerinfo.Click += new System.EventHandler(this.playerinfo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 2);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 2);
            this.panel2.TabIndex = 3;
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(190, 359);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(10, 10);
            this.player.TabIndex = 9;
            this.player.Visible = false;
            this.player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.player_statechanged);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.Location = new System.Drawing.Point(182, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 2;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_click);
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_settings.Location = new System.Drawing.Point(166, 2);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(16, 16);
            this.btn_settings.TabIndex = 10;
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_click);
            // 
            // mainWindow
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(200, 369);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.player);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouse_move);
            this.contentPanel.ResumeLayout(false);
            this.cpuFrame.ResumeLayout(false);
            this.cpuFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuImg)).EndInit();
            this.batteryFrame.ResumeLayout(false);
            this.batteryFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryImg)).EndInit();
            this.diskFrame.ResumeLayout(false);
            this.diskFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diskImg)).EndInit();
            this.mediaFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.GroupBox cpuFrame;
        private System.Windows.Forms.Label label2;
        private ProgressBarEx ramBar;
        private System.Windows.Forms.Label label1;
        private ProgressBarEx cpuBar;
        public System.Windows.Forms.GroupBox driveFrame;
        private System.Windows.Forms.PictureBox ramImg;
        private System.Windows.Forms.PictureBox cpuImg;
        private System.Windows.Forms.GroupBox batteryFrame;
        private System.Windows.Forms.PictureBox BatteryImg;
        private System.Windows.Forms.Label label4;
        private ProgressBarEx batteryBar;
        private System.Windows.Forms.GroupBox diskFrame;
        private System.Windows.Forms.PictureBox diskImg;
        private System.Windows.Forms.Label label3;
        private ProgressBarEx diskBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.GroupBox mediaFrame;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Label playerinfo;
    }
}

