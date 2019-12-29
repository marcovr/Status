namespace Status
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.batteryFrame = new System.Windows.Forms.GroupBox();
            this.checkbox_battery2 = new System.Windows.Forms.CheckBox();
            this.checkbox_battery1 = new System.Windows.Forms.CheckBox();
            this.mediaFrame = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.volumeTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.contentPanel.SuspendLayout();
            this.batteryFrame.SuspendLayout();
            this.mediaFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.ColumnCount = 1;
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentPanel.Controls.Add(this.batteryFrame, 0, 0);
            this.contentPanel.Controls.Add(this.mediaFrame, 0, 2);
            this.contentPanel.Controls.Add(this.panel3, 0, 3);
            this.contentPanel.Location = new System.Drawing.Point(12, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RowCount = 4;
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.Size = new System.Drawing.Size(176, 222);
            this.contentPanel.TabIndex = 5;
            // 
            // batteryFrame
            // 
            this.batteryFrame.Controls.Add(this.checkbox_battery2);
            this.batteryFrame.Controls.Add(this.checkbox_battery1);
            this.batteryFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batteryFrame.ForeColor = System.Drawing.Color.White;
            this.batteryFrame.Location = new System.Drawing.Point(3, 3);
            this.batteryFrame.Name = "batteryFrame";
            this.batteryFrame.Size = new System.Drawing.Size(170, 65);
            this.batteryFrame.TabIndex = 6;
            this.batteryFrame.TabStop = false;
            this.batteryFrame.Text = "Battery";
            // 
            // checkbox_battery2
            // 
            this.checkbox_battery2.AutoSize = true;
            this.checkbox_battery2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_battery2.Location = new System.Drawing.Point(6, 42);
            this.checkbox_battery2.Name = "checkbox_battery2";
            this.checkbox_battery2.Size = new System.Drawing.Size(124, 17);
            this.checkbox_battery2.TabIndex = 3;
            this.checkbox_battery2.Text = "Show while charging";
            this.checkbox_battery2.UseVisualStyleBackColor = true;
            // 
            // checkbox_battery1
            // 
            this.checkbox_battery1.AutoSize = true;
            this.checkbox_battery1.Checked = true;
            this.checkbox_battery1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_battery1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_battery1.Location = new System.Drawing.Point(6, 19);
            this.checkbox_battery1.Name = "checkbox_battery1";
            this.checkbox_battery1.Size = new System.Drawing.Size(114, 17);
            this.checkbox_battery1.TabIndex = 2;
            this.checkbox_battery1.Text = "Show battery state";
            this.checkbox_battery1.UseVisualStyleBackColor = true;
            // 
            // mediaFrame
            // 
            this.mediaFrame.Controls.Add(this.textBox2);
            this.mediaFrame.Controls.Add(this.radioButton2);
            this.mediaFrame.Controls.Add(this.textBox1);
            this.mediaFrame.Controls.Add(this.radioButton1);
            this.mediaFrame.Controls.Add(this.volumeBar);
            this.mediaFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaFrame.ForeColor = System.Drawing.Color.White;
            this.mediaFrame.Location = new System.Drawing.Point(3, 74);
            this.mediaFrame.Name = "mediaFrame";
            this.mediaFrame.Size = new System.Drawing.Size(170, 110);
            this.mediaFrame.TabIndex = 8;
            this.mediaFrame.TabStop = false;
            this.mediaFrame.Text = "Media Player Source";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(26, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 20);
            this.textBox2.TabIndex = 4;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(26, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "http://www.swr3.de/wraps/musik/webradio/aplayer/stream_extern.php?format=mp3e&channel=0";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // volumeBar
            // 
            this.volumeBar.AutoSize = false;
            this.volumeBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.volumeBar.LargeChange = 10;
            this.volumeBar.Location = new System.Drawing.Point(6, 67);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(158, 33);
            this.volumeBar.SmallChange = 5;
            this.volumeBar.TabIndex = 5;
            this.volumeBar.TickFrequency = 10;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeBar.Scroll += new System.EventHandler(this.Volume_changing);
            this.volumeBar.MouseEnter += new System.EventHandler(this.VolumeBar_mouse_enter);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_stop);
            this.panel3.Controls.Add(this.btn_play);
            this.panel3.Location = new System.Drawing.Point(3, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 29);
            this.panel3.TabIndex = 9;
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.Red;
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.ForeColor = System.Drawing.Color.White;
            this.btn_stop.Location = new System.Drawing.Point(92, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Cancel";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.Btn_close_click);
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Location = new System.Drawing.Point(6, 3);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 2;
            this.btn_play.Text = "Save";
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Click += new System.EventHandler(this.Btn_save_click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.Location = new System.Drawing.Point(182, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 5;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_click);
            // 
            // volumeTooltip
            // 
            this.volumeTooltip.ToolTipTitle = "Volume";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(200, 248);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.contentPanel);
            this.Name = "SettingsWindow";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Window_loading);
            this.contentPanel.ResumeLayout(false);
            this.batteryFrame.ResumeLayout(false);
            this.batteryFrame.PerformLayout();
            this.mediaFrame.ResumeLayout(false);
            this.mediaFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.GroupBox batteryFrame;
        private System.Windows.Forms.GroupBox mediaFrame;
        private System.Windows.Forms.CheckBox checkbox_battery2;
        private System.Windows.Forms.CheckBox checkbox_battery1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.ToolTip volumeTooltip;
    }
}