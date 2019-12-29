namespace Status
{
    partial class PlaylistWindow
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
            this.contentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playlistFrame = new System.Windows.Forms.GroupBox();
            this.playlist = new System.Windows.Forms.TableLayoutPanel();
            this.btn_close = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.playlistFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.ColumnCount = 1;
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentPanel.Controls.Add(this.playlistFrame, 0, 1);
            this.contentPanel.Location = new System.Drawing.Point(12, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RowCount = 1;
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentPanel.Size = new System.Drawing.Size(376, 306);
            this.contentPanel.TabIndex = 5;
            // 
            // playlistFrame
            // 
            this.playlistFrame.Controls.Add(this.playlist);
            this.playlistFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlistFrame.ForeColor = System.Drawing.Color.White;
            this.playlistFrame.Location = new System.Drawing.Point(3, 3);
            this.playlistFrame.Name = "playlistFrame";
            this.playlistFrame.Size = new System.Drawing.Size(370, 300);
            this.playlistFrame.TabIndex = 8;
            this.playlistFrame.TabStop = false;
            this.playlistFrame.Text = "Playlist";
            // 
            // playlist
            // 
            this.playlist.AutoScroll = true;
            this.playlist.ColumnCount = 1;
            this.playlist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlist.Location = new System.Drawing.Point(3, 16);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(364, 281);
            this.playlist.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.Location = new System.Drawing.Point(382, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 5;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_click);
            // 
            // PlaylistWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.contentPanel);
            this.Name = "PlaylistWindow";
            this.Text = "Playlist";
            this.Load += new System.EventHandler(this.Window_loading);
            this.contentPanel.ResumeLayout(false);
            this.playlistFrame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.GroupBox playlistFrame;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TableLayoutPanel playlist;
    }
}