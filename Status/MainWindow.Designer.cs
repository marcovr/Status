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
            this.ramItem = new Status.StatusItem();
            this.cpuItem = new Status.StatusItem();
            this.driveFrame = new System.Windows.Forms.GroupBox();
            this.batteryFrame = new System.Windows.Forms.GroupBox();
            this.batteryItem = new Status.StatusItem();
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
            this.batteryFrame.SuspendLayout();
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
            this.contentPanel.Controls.Add(this.mediaFrame, 0, 4);
            this.contentPanel.Location = new System.Drawing.Point(12, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RowCount = 5;
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.Size = new System.Drawing.Size(176, 290);
            this.contentPanel.TabIndex = 1;
            // 
            // cpuFrame
            // 
            this.cpuFrame.Controls.Add(this.ramItem);
            this.cpuFrame.Controls.Add(this.cpuItem);
            this.cpuFrame.ForeColor = System.Drawing.Color.White;
            this.cpuFrame.Location = new System.Drawing.Point(3, 3);
            this.cpuFrame.Name = "cpuFrame";
            this.cpuFrame.Size = new System.Drawing.Size(170, 71);
            this.cpuFrame.TabIndex = 3;
            this.cpuFrame.TabStop = false;
            this.cpuFrame.Text = "CPU / RAM";
            // 
            // ramItem
            // 
            this.ramItem.Image = global::Status.Properties.Resources.RAM;
            this.ramItem.InvertedCritical = false;
            this.ramItem.Label = "%";
            this.ramItem.Location = new System.Drawing.Point(4, 39);
            this.ramItem.Name = "ramItem";
            this.ramItem.Size = new System.Drawing.Size(166, 20);
            this.ramItem.TabIndex = 7;
            this.ramItem.Value = 0;
            // 
            // cpuItem
            // 
            this.cpuItem.Image = global::Status.Properties.Resources.CPU;
            this.cpuItem.InvertedCritical = false;
            this.cpuItem.Label = "%";
            this.cpuItem.Location = new System.Drawing.Point(4, 17);
            this.cpuItem.Name = "cpuItem";
            this.cpuItem.Size = new System.Drawing.Size(166, 20);
            this.cpuItem.TabIndex = 6;
            this.cpuItem.Value = 0;
            // 
            // driveFrame
            // 
            this.driveFrame.ForeColor = System.Drawing.Color.White;
            this.driveFrame.Location = new System.Drawing.Point(3, 135);
            this.driveFrame.Name = "driveFrame";
            this.driveFrame.Size = new System.Drawing.Size(170, 71);
            this.driveFrame.TabIndex = 2;
            this.driveFrame.TabStop = false;
            this.driveFrame.Text = "Drive Capacity";
            // 
            // batteryFrame
            // 
            this.batteryFrame.Controls.Add(this.batteryItem);
            this.batteryFrame.ForeColor = System.Drawing.Color.White;
            this.batteryFrame.Location = new System.Drawing.Point(3, 80);
            this.batteryFrame.Name = "batteryFrame";
            this.batteryFrame.Size = new System.Drawing.Size(170, 49);
            this.batteryFrame.TabIndex = 6;
            this.batteryFrame.TabStop = false;
            this.batteryFrame.Text = "Battery";
            // 
            // batteryItem
            // 
            this.batteryItem.Image = global::Status.Properties.Resources.Battery;
            this.batteryItem.InvertedCritical = true;
            this.batteryItem.Label = "%";
            this.batteryItem.Location = new System.Drawing.Point(4, 17);
            this.batteryItem.Name = "batteryItem";
            this.batteryItem.Size = new System.Drawing.Size(166, 20);
            this.batteryItem.TabIndex = 5;
            this.batteryItem.Value = 0;
            // 
            // mediaFrame
            // 
            this.mediaFrame.Controls.Add(this.btn_stop);
            this.mediaFrame.Controls.Add(this.btn_play);
            this.mediaFrame.Controls.Add(this.playerinfo);
            this.mediaFrame.ForeColor = System.Drawing.Color.White;
            this.mediaFrame.Location = new System.Drawing.Point(3, 212);
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
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_click);
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
            this.btn_play.Click += new System.EventHandler(this.Btn_play_click);
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
            this.playerinfo.Text = "...";
            this.playerinfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.playerinfo.Click += new System.EventHandler(this.Playerinfo_Click);
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
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 2);
            this.panel2.TabIndex = 3;
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(190, 304);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(10, 10);
            this.player.TabIndex = 9;
            this.player.Visible = false;
            this.player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Player_statechanged);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.Location = new System.Drawing.Point(182, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 2;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_click);
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_settings.Location = new System.Drawing.Point(166, 2);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(16, 16);
            this.btn_settings.TabIndex = 10;
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.Btn_settings_click);
            // 
            // mainWindow
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(200, 314);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_moved);
            this.contentPanel.ResumeLayout(false);
            this.cpuFrame.ResumeLayout(false);
            this.batteryFrame.ResumeLayout(false);
            this.mediaFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.GroupBox cpuFrame;
        public System.Windows.Forms.GroupBox driveFrame;
        private System.Windows.Forms.GroupBox batteryFrame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.GroupBox mediaFrame;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Label playerinfo;
        private StatusItem ramItem;
        private StatusItem cpuItem;
        private StatusItem batteryItem;
    }
}

