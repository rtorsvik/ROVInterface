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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_debug_1 = new System.Windows.Forms.Button();
			this.txt_debug_3 = new System.Windows.Forms.Label();
			this.txt_debug_2 = new System.Windows.Forms.Label();
			this.txt_debug_1 = new System.Windows.Forms.Label();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.pnl_video1 = new System.Windows.Forms.Panel();
			this.pnl_video2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pnl_video3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pnl_video4 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.bgw_video1 = new System.ComponentModel.BackgroundWorker();
			this.bgw_video2 = new System.ComponentModel.BackgroundWorker();
			this.bgw_video3 = new System.ComponentModel.BackgroundWorker();
			this.bgw_video4 = new System.ComponentModel.BackgroundWorker();
			this.btn_startCam2 = new System.Windows.Forms.Button();
			this.btn_startCam1 = new System.Windows.Forms.Button();
			this.btn_startCam3 = new System.Windows.Forms.Button();
			this.btn_startCam4 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.headingIndicatorInstrumentControl1 = new Avionics.HeadingIndicatorInstrumentControl();
			this.turnCoordinatorInstrumentControl1 = new Avionics.TurnCoordinatorInstrumentControl();
			this.attitudeIndicatorInstrumentControl1 = new Avionics.AttitudeIndicatorInstrumentControl();
			this.groupBox1.SuspendLayout();
			this.pnl_video2.SuspendLayout();
			this.pnl_video3.SuspendLayout();
			this.pnl_video4.SuspendLayout();
			this.SuspendLayout();
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
			this.groupBox1.Location = new System.Drawing.Point(9, 1172);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(1408, 86);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Debug";
			// 
			// btn_debug_1
			// 
			this.btn_debug_1.Location = new System.Drawing.Point(139, 21);
			this.btn_debug_1.Margin = new System.Windows.Forms.Padding(2);
			this.btn_debug_1.Name = "btn_debug_1";
			this.btn_debug_1.Size = new System.Drawing.Size(78, 51);
			this.btn_debug_1.TabIndex = 3;
			this.btn_debug_1.Text = "Reconnect joystick";
			this.btn_debug_1.UseVisualStyleBackColor = true;
			this.btn_debug_1.Click += new System.EventHandler(this.btn_debug_1_Click);
			// 
			// txt_debug_3
			// 
			this.txt_debug_3.AutoSize = true;
			this.txt_debug_3.Location = new System.Drawing.Point(8, 58);
			this.txt_debug_3.Margin = new System.Windows.Forms.Padding(6, 2, 6, 6);
			this.txt_debug_3.Name = "txt_debug_3";
			this.txt_debug_3.Size = new System.Drawing.Size(66, 13);
			this.txt_debug_3.TabIndex = 2;
			this.txt_debug_3.Text = "txt_debug_3";
			// 
			// txt_debug_2
			// 
			this.txt_debug_2.AutoSize = true;
			this.txt_debug_2.Location = new System.Drawing.Point(8, 40);
			this.txt_debug_2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 6);
			this.txt_debug_2.Name = "txt_debug_2";
			this.txt_debug_2.Size = new System.Drawing.Size(66, 13);
			this.txt_debug_2.TabIndex = 1;
			this.txt_debug_2.Text = "txt_debug_2";
			// 
			// txt_debug_1
			// 
			this.txt_debug_1.AutoSize = true;
			this.txt_debug_1.Location = new System.Drawing.Point(8, 21);
			this.txt_debug_1.Margin = new System.Windows.Forms.Padding(6, 6, 2, 2);
			this.txt_debug_1.Name = "txt_debug_1";
			this.txt_debug_1.Size = new System.Drawing.Size(66, 13);
			this.txt_debug_1.TabIndex = 0;
			this.txt_debug_1.Text = "txt_debug_1";
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(12, 12);
			this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(15, 16);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(1400, 690);
			this.webBrowser1.TabIndex = 3;
			this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
			this.webBrowser1.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1171, 710);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 119);
			this.button1.TabIndex = 4;
			this.button1.Text = "Demo 1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1295, 710);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 119);
			this.button2.TabIndex = 5;
			this.button2.Text = "Demo 2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// pnl_video1
			// 
			this.pnl_video1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_video1.Location = new System.Drawing.Point(12, 12);
			this.pnl_video1.Name = "pnl_video1";
			this.pnl_video1.Size = new System.Drawing.Size(1402, 692);
			this.pnl_video1.TabIndex = 30;
			this.pnl_video1.Click += new System.EventHandler(this.pnl_video1_Click);
			// 
			// pnl_video2
			// 
			this.pnl_video2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_video2.Controls.Add(this.label1);
			this.pnl_video2.Location = new System.Drawing.Point(143, 710);
			this.pnl_video2.Name = "pnl_video2";
			this.pnl_video2.Size = new System.Drawing.Size(125, 90);
			this.pnl_video2.TabIndex = 31;
			this.pnl_video2.Click += new System.EventHandler(this.pnl_video2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 19);
			this.label1.TabIndex = 37;
			this.label1.Text = "F2";
			// 
			// pnl_video3
			// 
			this.pnl_video3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_video3.Controls.Add(this.label3);
			this.pnl_video3.Location = new System.Drawing.Point(274, 710);
			this.pnl_video3.Name = "pnl_video3";
			this.pnl_video3.Size = new System.Drawing.Size(125, 90);
			this.pnl_video3.TabIndex = 31;
			this.pnl_video3.Click += new System.EventHandler(this.pnl_video3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(3, 3);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 19);
			this.label3.TabIndex = 39;
			this.label3.Text = "F3";
			// 
			// pnl_video4
			// 
			this.pnl_video4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_video4.Controls.Add(this.label4);
			this.pnl_video4.Location = new System.Drawing.Point(405, 710);
			this.pnl_video4.Name = "pnl_video4";
			this.pnl_video4.Size = new System.Drawing.Size(125, 90);
			this.pnl_video4.TabIndex = 31;
			this.pnl_video4.Click += new System.EventHandler(this.pnl_video4_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(3, 3);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 19);
			this.label4.TabIndex = 40;
			this.label4.Text = "F4";
			// 
			// bgw_video1
			// 
			this.bgw_video1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_video1_DoWork);
			// 
			// bgw_video2
			// 
			this.bgw_video2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_video2_DoWork);
			// 
			// bgw_video3
			// 
			this.bgw_video3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_video3_DoWork);
			// 
			// btn_startCam2
			// 
			this.btn_startCam2.Location = new System.Drawing.Point(143, 806);
			this.btn_startCam2.Name = "btn_startCam2";
			this.btn_startCam2.Size = new System.Drawing.Size(125, 23);
			this.btn_startCam2.TabIndex = 33;
			this.btn_startCam2.Text = "Start Cam 2";
			this.btn_startCam2.UseVisualStyleBackColor = true;
			this.btn_startCam2.Click += new System.EventHandler(this.btn_startCam2_Click);
			// 
			// btn_startCam1
			// 
			this.btn_startCam1.Location = new System.Drawing.Point(12, 806);
			this.btn_startCam1.Name = "btn_startCam1";
			this.btn_startCam1.Size = new System.Drawing.Size(125, 23);
			this.btn_startCam1.TabIndex = 34;
			this.btn_startCam1.Text = "Start Cam 1";
			this.btn_startCam1.UseVisualStyleBackColor = true;
			this.btn_startCam1.Click += new System.EventHandler(this.btn_startCam1_Click);
			// 
			// btn_startCam3
			// 
			this.btn_startCam3.Location = new System.Drawing.Point(274, 806);
			this.btn_startCam3.Name = "btn_startCam3";
			this.btn_startCam3.Size = new System.Drawing.Size(125, 23);
			this.btn_startCam3.TabIndex = 35;
			this.btn_startCam3.Text = "Start Cam 3";
			this.btn_startCam3.UseVisualStyleBackColor = true;
			this.btn_startCam3.Click += new System.EventHandler(this.btn_startCam3_Click);
			// 
			// btn_startCam4
			// 
			this.btn_startCam4.Location = new System.Drawing.Point(405, 806);
			this.btn_startCam4.Name = "btn_startCam4";
			this.btn_startCam4.Size = new System.Drawing.Size(125, 23);
			this.btn_startCam4.TabIndex = 36;
			this.btn_startCam4.Text = "Start Cam 4";
			this.btn_startCam4.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(16, 714);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 19);
			this.label2.TabIndex = 38;
			this.label2.Text = "F1";
			// 
			// headingIndicatorInstrumentControl1
			// 
			this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(803, 709);
			this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
			this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(120, 120);
			this.headingIndicatorInstrumentControl1.TabIndex = 23;
			this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
			// 
			// turnCoordinatorInstrumentControl1
			// 
			this.turnCoordinatorInstrumentControl1.Location = new System.Drawing.Point(551, 709);
			this.turnCoordinatorInstrumentControl1.Name = "turnCoordinatorInstrumentControl1";
			this.turnCoordinatorInstrumentControl1.Size = new System.Drawing.Size(120, 120);
			this.turnCoordinatorInstrumentControl1.TabIndex = 22;
			this.turnCoordinatorInstrumentControl1.Text = "turnCoordinatorInstrumentControl1";
			// 
			// attitudeIndicatorInstrumentControl1
			// 
			this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(677, 709);
			this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
			this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(120, 120);
			this.attitudeIndicatorInstrumentControl1.TabIndex = 21;
			this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
			// 
			// WindowCamera
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(1426, 840);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_startCam4);
			this.Controls.Add(this.btn_startCam3);
			this.Controls.Add(this.btn_startCam1);
			this.Controls.Add(this.btn_startCam2);
			this.Controls.Add(this.pnl_video4);
			this.Controls.Add(this.pnl_video3);
			this.Controls.Add(this.pnl_video2);
			this.Controls.Add(this.pnl_video1);
			this.Controls.Add(this.headingIndicatorInstrumentControl1);
			this.Controls.Add(this.turnCoordinatorInstrumentControl1);
			this.Controls.Add(this.attitudeIndicatorInstrumentControl1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "WindowCamera";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Camera";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.WindowCamera_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.pnl_video2.ResumeLayout(false);
			this.pnl_video2.PerformLayout();
			this.pnl_video3.ResumeLayout(false);
			this.pnl_video3.PerformLayout();
			this.pnl_video4.ResumeLayout(false);
			this.pnl_video4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

	#endregion
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.Label txt_debug_3;
	private System.Windows.Forms.Label txt_debug_2;
	private System.Windows.Forms.Label txt_debug_1;
	private System.Windows.Forms.WebBrowser webBrowser1;
	private System.Windows.Forms.Button btn_debug_1;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button2;
	private Avionics.AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
	private Avionics.TurnCoordinatorInstrumentControl turnCoordinatorInstrumentControl1;
	private Avionics.HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
	private System.Windows.Forms.Panel pnl_video1;
	private System.Windows.Forms.Panel pnl_video2;
	private System.Windows.Forms.Panel pnl_video3;
	private System.Windows.Forms.Panel pnl_video4;
	private System.ComponentModel.BackgroundWorker bgw_video1;
	private System.ComponentModel.BackgroundWorker bgw_video2;
	private System.ComponentModel.BackgroundWorker bgw_video3;
	private System.ComponentModel.BackgroundWorker bgw_video4;
	private System.Windows.Forms.Button btn_startCam2;
	private System.Windows.Forms.Button btn_startCam1;
	private System.Windows.Forms.Button btn_startCam3;
	private System.Windows.Forms.Button btn_startCam4;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label2;
}


