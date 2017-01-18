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
		this.components = new System.ComponentModel.Container();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.btn_debug_1 = new System.Windows.Forms.Button();
		this.txt_debug_3 = new System.Windows.Forms.Label();
		this.txt_debug_2 = new System.Windows.Forms.Label();
		this.txt_debug_1 = new System.Windows.Forms.Label();
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		this.SuspendLayout();
		// 
		// timer1
		// 
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		// 
		// groupBox1
		// 
		this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox1.Controls.Add(this.btn_debug_1);
		this.groupBox1.Controls.Add(this.txt_debug_3);
		this.groupBox1.Controls.Add(this.txt_debug_2);
		this.groupBox1.Controls.Add(this.txt_debug_1);
		this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
		this.groupBox1.Location = new System.Drawing.Point(12, 915);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(1877, 106);
		this.groupBox1.TabIndex = 2;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Debug";
		// 
		// btn_debug_1
		// 
		this.btn_debug_1.Location = new System.Drawing.Point(185, 26);
		this.btn_debug_1.Name = "btn_debug_1";
		this.btn_debug_1.Size = new System.Drawing.Size(104, 63);
		this.btn_debug_1.TabIndex = 3;
		this.btn_debug_1.Text = "Reconnect joystick";
		this.btn_debug_1.UseVisualStyleBackColor = true;
		this.btn_debug_1.Click += new System.EventHandler(this.btn_debug_1_Click);
		// 
		// txt_debug_3
		// 
		this.txt_debug_3.AutoSize = true;
		this.txt_debug_3.Location = new System.Drawing.Point(11, 72);
		this.txt_debug_3.Margin = new System.Windows.Forms.Padding(8, 3, 8, 8);
		this.txt_debug_3.Name = "txt_debug_3";
		this.txt_debug_3.Size = new System.Drawing.Size(86, 17);
		this.txt_debug_3.TabIndex = 2;
		this.txt_debug_3.Text = "txt_debug_3";
		// 
		// txt_debug_2
		// 
		this.txt_debug_2.AutoSize = true;
		this.txt_debug_2.Location = new System.Drawing.Point(11, 49);
		this.txt_debug_2.Margin = new System.Windows.Forms.Padding(8, 3, 8, 8);
		this.txt_debug_2.Name = "txt_debug_2";
		this.txt_debug_2.Size = new System.Drawing.Size(86, 17);
		this.txt_debug_2.TabIndex = 1;
		this.txt_debug_2.Text = "txt_debug_2";
		// 
		// txt_debug_1
		// 
		this.txt_debug_1.AutoSize = true;
		this.txt_debug_1.Location = new System.Drawing.Point(11, 26);
		this.txt_debug_1.Margin = new System.Windows.Forms.Padding(8, 8, 3, 3);
		this.txt_debug_1.Name = "txt_debug_1";
		this.txt_debug_1.Size = new System.Drawing.Size(86, 17);
		this.txt_debug_1.TabIndex = 0;
		this.txt_debug_1.Text = "txt_debug_1";
		// 
		// webBrowser1
		// 
		this.webBrowser1.Location = new System.Drawing.Point(12, 12);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(1742, 897);
		this.webBrowser1.TabIndex = 3;
		this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
		// 
		// button1
		// 
		this.button1.Location = new System.Drawing.Point(1760, 12);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(129, 104);
		this.button1.TabIndex = 4;
		this.button1.Text = "Cam 1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		// 
		// button2
		// 
		this.button2.Location = new System.Drawing.Point(1760, 122);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(129, 104);
		this.button2.TabIndex = 5;
		this.button2.Text = "Cam 2";
		this.button2.UseVisualStyleBackColor = true;
		// 
		// WindowCamera
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
		this.ClientSize = new System.Drawing.Size(1901, 1033);
		this.Controls.Add(this.button2);
		this.Controls.Add(this.button1);
		this.Controls.Add(this.webBrowser1);
		this.Controls.Add(this.groupBox1);
		this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.Name = "WindowCamera";
		this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Camera";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Load += new System.EventHandler(this.WindowCamera_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.ResumeLayout(false);

    }

	#endregion
	private System.Windows.Forms.Timer timer1;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.Label txt_debug_3;
	private System.Windows.Forms.Label txt_debug_2;
	private System.Windows.Forms.Label txt_debug_1;
	private System.Windows.Forms.WebBrowser webBrowser1;
	private System.Windows.Forms.Button btn_debug_1;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button2;
}


