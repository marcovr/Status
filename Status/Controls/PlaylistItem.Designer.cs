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
            this.timelabel = new System.Windows.Forms.Label();
            this.titlelabel = new System.Windows.Forms.Label();
            this.wholabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.timelabel.Location = new System.Drawing.Point(3, 3);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(39, 16);
            this.timelabel.TabIndex = 3;
            this.timelabel.Text = "00:00";
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.Location = new System.Drawing.Point(48, 3);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(33, 16);
            this.titlelabel.TabIndex = 1;
            this.titlelabel.Text = "title";
            this.titlelabel.Click += new System.EventHandler(this.Title_Click);
            // 
            // wholabel
            // 
            this.wholabel.AutoSize = true;
            this.wholabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wholabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wholabel.Location = new System.Drawing.Point(48, 19);
            this.wholabel.Name = "wholabel";
            this.wholabel.Size = new System.Drawing.Size(32, 16);
            this.wholabel.TabIndex = 2;
            this.wholabel.TabStop = true;
            this.wholabel.Text = "who";
            this.wholabel.Click += new System.EventHandler(this.Title_Click);
            // 
            // PlaylistItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.wholabel);
            this.Controls.Add(this.titlelabel);
            this.Name = "PlaylistItem";
            this.Size = new System.Drawing.Size(330, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label wholabel;
    }
}
