namespace ROVInterface
{
    partial class WindowCamera
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
            this.cbox_comports = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbox_comports
            // 
            this.cbox_comports.FormattingEnabled = true;
            this.cbox_comports.Location = new System.Drawing.Point(521, 306);
            this.cbox_comports.Name = "cbox_comports";
            this.cbox_comports.Size = new System.Drawing.Size(121, 24);
            this.cbox_comports.TabIndex = 0;
            // 
            // WindowCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1902, 953);
            this.Controls.Add(this.cbox_comports);
            this.Name = "WindowCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Camera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WindowCamera_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_comports;
    }
}

