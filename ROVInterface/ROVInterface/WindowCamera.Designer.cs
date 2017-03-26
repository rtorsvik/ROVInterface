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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowCamera));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_debug_1 = new System.Windows.Forms.Button();
			this.txt_debug_3 = new System.Windows.Forms.Label();
			this.txt_debug_2 = new System.Windows.Forms.Label();
			this.txt_debug_1 = new System.Windows.Forms.Label();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.vlcPlayer = new AxAXVLC.AxVLCPlugin2();
			this.btn_cam1 = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.headingIndicatorInstrumentControl1 = new Avionics.HeadingIndicatorInstrumentControl();
			this.turnCoordinatorInstrumentControl1 = new Avionics.TurnCoordinatorInstrumentControl();
			this.attitudeIndicatorInstrumentControl1 = new Avionics.AttitudeIndicatorInstrumentControl();
			this.aGauge2 = new AGaugeApp.AGauge();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vlcPlayer)).BeginInit();
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
			this.groupBox1.Location = new System.Drawing.Point(14, 1375);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(2112, 132);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Debug";
			// 
			// btn_debug_1
			// 
			this.btn_debug_1.Location = new System.Drawing.Point(208, 32);
			this.btn_debug_1.Name = "btn_debug_1";
			this.btn_debug_1.Size = new System.Drawing.Size(117, 78);
			this.btn_debug_1.TabIndex = 3;
			this.btn_debug_1.Text = "Reconnect joystick";
			this.btn_debug_1.UseVisualStyleBackColor = true;
			this.btn_debug_1.Click += new System.EventHandler(this.btn_debug_1_Click);
			// 
			// txt_debug_3
			// 
			this.txt_debug_3.AutoSize = true;
			this.txt_debug_3.Location = new System.Drawing.Point(12, 89);
			this.txt_debug_3.Margin = new System.Windows.Forms.Padding(9, 3, 9, 9);
			this.txt_debug_3.Name = "txt_debug_3";
			this.txt_debug_3.Size = new System.Drawing.Size(98, 20);
			this.txt_debug_3.TabIndex = 2;
			this.txt_debug_3.Text = "txt_debug_3";
			// 
			// txt_debug_2
			// 
			this.txt_debug_2.AutoSize = true;
			this.txt_debug_2.Location = new System.Drawing.Point(12, 62);
			this.txt_debug_2.Margin = new System.Windows.Forms.Padding(9, 3, 9, 9);
			this.txt_debug_2.Name = "txt_debug_2";
			this.txt_debug_2.Size = new System.Drawing.Size(98, 20);
			this.txt_debug_2.TabIndex = 1;
			this.txt_debug_2.Text = "txt_debug_2";
			// 
			// txt_debug_1
			// 
			this.txt_debug_1.AutoSize = true;
			this.txt_debug_1.Location = new System.Drawing.Point(12, 32);
			this.txt_debug_1.Margin = new System.Windows.Forms.Padding(9, 9, 3, 3);
			this.txt_debug_1.Name = "txt_debug_1";
			this.txt_debug_1.Size = new System.Drawing.Size(98, 20);
			this.txt_debug_1.TabIndex = 0;
			this.txt_debug_1.Text = "txt_debug_1";
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(1718, 15);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(22, 25);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(405, 426);
			this.webBrowser1.TabIndex = 3;
			this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(14, 1089);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(188, 183);
			this.button1.TabIndex = 4;
			this.button1.Text = "Cam 1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(207, 1089);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(180, 183);
			this.button2.TabIndex = 5;
			this.button2.Text = "Cam 2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// vlcPlayer
			// 
			this.vlcPlayer.Enabled = true;
			this.vlcPlayer.Location = new System.Drawing.Point(383, 287);
			this.vlcPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.vlcPlayer.Name = "vlcPlayer";
			this.vlcPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("vlcPlayer.OcxState")));
			this.vlcPlayer.Size = new System.Drawing.Size(339, 239);
			this.vlcPlayer.TabIndex = 24;
			// 
			// btn_cam1
			// 
			this.btn_cam1.Location = new System.Drawing.Point(1935, 1092);
			this.btn_cam1.Name = "btn_cam1";
			this.btn_cam1.Size = new System.Drawing.Size(188, 183);
			this.btn_cam1.TabIndex = 25;
			this.btn_cam1.Text = "Cam 1";
			this.btn_cam1.UseVisualStyleBackColor = true;
			this.btn_cam1.Click += new System.EventHandler(this.btn_cam1_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(729, 287);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(96, 41);
			this.btnStart.TabIndex = 27;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(729, 334);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(96, 41);
			this.btnStop.TabIndex = 28;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// headingIndicatorInstrumentControl1
			// 
			this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(1204, 1091);
			this.headingIndicatorInstrumentControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
			this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(180, 185);
			this.headingIndicatorInstrumentControl1.TabIndex = 23;
			this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
			// 
			// turnCoordinatorInstrumentControl1
			// 
			this.turnCoordinatorInstrumentControl1.Location = new System.Drawing.Point(826, 1091);
			this.turnCoordinatorInstrumentControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.turnCoordinatorInstrumentControl1.Name = "turnCoordinatorInstrumentControl1";
			this.turnCoordinatorInstrumentControl1.Size = new System.Drawing.Size(180, 185);
			this.turnCoordinatorInstrumentControl1.TabIndex = 22;
			this.turnCoordinatorInstrumentControl1.Text = "turnCoordinatorInstrumentControl1";
			// 
			// attitudeIndicatorInstrumentControl1
			// 
			this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(1016, 1091);
			this.attitudeIndicatorInstrumentControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
			this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(180, 185);
			this.attitudeIndicatorInstrumentControl1.TabIndex = 21;
			this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
			// 
			// aGauge2
			// 
			this.aGauge2.BaseArcColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge2.BaseArcRadius = 80;
			this.aGauge2.BaseArcStart = 180;
			this.aGauge2.BaseArcSweep = 180;
			this.aGauge2.BaseArcWidth = 5;
			this.aGauge2.Cap_Idx = ((byte)(1));
			this.aGauge2.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
			this.aGauge2.CapPosition = new System.Drawing.Point(10, 10);
			this.aGauge2.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
			this.aGauge2.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
			this.aGauge2.CapText = "";
			this.aGauge2.Center = new System.Drawing.Point(100, 100);
			this.aGauge2.Location = new System.Drawing.Point(394, 1089);
			this.aGauge2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.aGauge2.MaxValue = 100F;
			this.aGauge2.MinValue = 0F;
			this.aGauge2.Name = "aGauge2";
			this.aGauge2.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Gray;
			this.aGauge2.NeedleColor2 = System.Drawing.Color.DimGray;
			this.aGauge2.NeedleRadius = 80;
			this.aGauge2.NeedleType = 0;
			this.aGauge2.NeedleWidth = 2;
			this.aGauge2.Range_Idx = ((byte)(0));
			this.aGauge2.RangeColor = System.Drawing.Color.Red;
			this.aGauge2.RangeEnabled = true;
			this.aGauge2.RangeEndValue = 20F;
			this.aGauge2.RangeInnerRadius = 60;
			this.aGauge2.RangeOuterRadius = 80;
			this.aGauge2.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.LightGreen,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
			this.aGauge2.RangesEnabled = new bool[] {
        true,
        true,
        false,
        false,
        false};
			this.aGauge2.RangesEndValue = new float[] {
        20F,
        100F,
        0F,
        0F,
        0F};
			this.aGauge2.RangesInnerRadius = new int[] {
        60,
        60,
        60,
        70,
        70};
			this.aGauge2.RangesOuterRadius = new int[] {
        80,
        80,
        80,
        80,
        80};
			this.aGauge2.RangesStartValue = new float[] {
        0F,
        20F,
        0F,
        0F,
        0F};
			this.aGauge2.RangeStartValue = 0F;
			this.aGauge2.ScaleLinesInterColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge2.ScaleLinesInterInnerRadius = 70;
			this.aGauge2.ScaleLinesInterOuterRadius = 80;
			this.aGauge2.ScaleLinesInterWidth = 1;
			this.aGauge2.ScaleLinesMajorColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge2.ScaleLinesMajorInnerRadius = 70;
			this.aGauge2.ScaleLinesMajorOuterRadius = 80;
			this.aGauge2.ScaleLinesMajorStepValue = 20F;
			this.aGauge2.ScaleLinesMajorWidth = 4;
			this.aGauge2.ScaleLinesMinorColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge2.ScaleLinesMinorInnerRadius = 75;
			this.aGauge2.ScaleLinesMinorNumOf = 9;
			this.aGauge2.ScaleLinesMinorOuterRadius = 80;
			this.aGauge2.ScaleLinesMinorWidth = 1;
			this.aGauge2.ScaleNumbersColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge2.ScaleNumbersFormat = null;
			this.aGauge2.ScaleNumbersRadius = 95;
			this.aGauge2.ScaleNumbersRotation = 0;
			this.aGauge2.ScaleNumbersStartScaleLine = 0;
			this.aGauge2.ScaleNumbersStepScaleLines = 1;
			this.aGauge2.Size = new System.Drawing.Size(310, 183);
			this.aGauge2.TabIndex = 19;
			this.aGauge2.Text = "aGauge2";
			this.aGauge2.Value = 20F;
			// 
			// WindowCamera
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(2139, 865);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btn_cam1);
			this.Controls.Add(this.vlcPlayer);
			this.Controls.Add(this.headingIndicatorInstrumentControl1);
			this.Controls.Add(this.turnCoordinatorInstrumentControl1);
			this.Controls.Add(this.attitudeIndicatorInstrumentControl1);
			this.Controls.Add(this.aGauge2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.groupBox1);
			this.Name = "WindowCamera";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Camera";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.WindowCamera_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.vlcPlayer)).EndInit();
			this.ResumeLayout(false);

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
	private AGaugeApp.AGauge aGauge2;
	private Avionics.AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
	private Avionics.TurnCoordinatorInstrumentControl turnCoordinatorInstrumentControl1;
	private Avionics.HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
	private AxAXVLC.AxVLCPlugin2 vlcPlayer;
	private System.Windows.Forms.Button btn_cam1;
	private System.Windows.Forms.Button btnStart;
	private System.Windows.Forms.Button btnStop;
}


