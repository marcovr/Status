namespace Status
{
    partial class PlaylistItem
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.titlelabel = new System.Windows.Forms.Label();
            this.album = new System.Windows.Forms.PictureBox();
            this.wholabel = new System.Windows.Forms.Label();
            this.timelabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.album)).BeginInit();
            this.SuspendLayout();
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.Location = new System.Drawing.Point(89, 12);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(33, 16);
            this.titlelabel.TabIndex = 1;
            this.titlelabel.Text = "title";
            // 
            // album
            // 
            this.album.Cursor = System.Windows.Forms.Cursors.Hand;
            this.album.Location = new System.Drawing.Point(3, 3);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(80, 80);
            this.album.TabIndex = 0;
            this.album.TabStop = false;
            this.album.Click += new System.EventHandler(this.album_Click);
            // 
            // wholabel
            // 
            this.wholabel.AutoSize = true;
            this.wholabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wholabel.Location = new System.Drawing.Point(89, 34);
            this.wholabel.Name = "wholabel";
            this.wholabel.Size = new System.Drawing.Size(32, 16);
            this.wholabel.TabIndex = 2;
            this.wholabel.TabStop = true;
            this.wholabel.Text = "who";
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Location = new System.Drawing.Point(89, 61);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(26, 13);
            this.timelabel.TabIndex = 3;
            this.timelabel.Text = "time";
            // 
            // PlaylistItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.wholabel);
            this.Controls.Add(this.titlelabel);
            this.Controls.Add(this.album);
            this.Name = "PlaylistItem";
            this.Size = new System.Drawing.Size(330, 86);
            ((System.ComponentModel.ISupportInitialize)(this.album)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox album;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Label wholabel;
    }
}
