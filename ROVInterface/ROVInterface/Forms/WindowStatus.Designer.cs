partial class WindowStatus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowStatus));
			this.connectionTab = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.nud_navigation_attitude_rolldiv = new System.Windows.Forms.NumericUpDown();
			this.nud_navigation_attitude_pitchdiv = new System.Windows.Forms.NumericUpDown();
			this.aGauge2 = new AGaugeApp.AGauge();
			this.aGauge1 = new AGaugeApp.AGauge();
			this.nud_navigation_attitude_rollindex = new System.Windows.Forms.NumericUpDown();
			this.nud_navigation_heading_index = new System.Windows.Forms.NumericUpDown();
			this.nud_navigation_attitude_pitchindex = new System.Windows.Forms.NumericUpDown();
			this.nud_navigation_depth_index = new System.Windows.Forms.NumericUpDown();
			this.nud_navigation_height_index = new System.Windows.Forms.NumericUpDown();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ali_navigation_depth_instrument = new Avionics.AltimeterInstrumentControl();
			this.airSpeedIndicatorInstrumentControl1 = new Avionics.AirSpeedIndicatorInstrumentControl();
			this.verticalSpeedIndicatorInstrumentControl1 = new Avionics.VerticalSpeedIndicatorInstrumentControl();
			this.aii_navigation_attitude_instrument = new Avionics.AttitudeIndicatorInstrumentControl();
			this.ali_navigation_height_instrument = new Avionics.AltimeterInstrumentControl();
			this.hdi_navigation_heading_instrument = new Avionics.HeadingIndicatorInstrumentControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.pan_graphicsCreator = new System.Windows.Forms.Panel();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.pan_graphicToolbox = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.label47 = new System.Windows.Forms.Label();
			this.nud_aegir_gyro_calibration = new System.Windows.Forms.NumericUpDown();
			this.label46 = new System.Windows.Forms.Label();
			this.nud_aegir_man_depth_SP = new System.Windows.Forms.NumericUpDown();
			this.label44 = new System.Windows.Forms.Label();
			this.nud_aegir_zerodepth = new System.Windows.Forms.NumericUpDown();
			this.label43 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.nud_aegir_rot_p = new System.Windows.Forms.NumericUpDown();
			this.nud_aegir_rot_i = new System.Windows.Forms.NumericUpDown();
			this.nud_aegir_rot_d = new System.Windows.Forms.NumericUpDown();
			this.nud_aegir_trans_p = new System.Windows.Forms.NumericUpDown();
			this.nud_aegir_trans_i = new System.Windows.Forms.NumericUpDown();
			this.nud_aegir_trans_d = new System.Windows.Forms.NumericUpDown();
			this.btn_aegir_RegAuto = new System.Windows.Forms.Button();
			this.label37 = new System.Windows.Forms.Label();
			this.btn_aegir_coolingfan = new System.Windows.Forms.Button();
			this.btn_aegir_armmotors = new System.Windows.Forms.Button();
			this.nud_aegir_lightdim = new System.Windows.Forms.NumericUpDown();
			this.btn_aegir_light = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdb_comm_status_bytes = new System.Windows.Forms.RadioButton();
			this.rdb_comm_status_hex = new System.Windows.Forms.RadioButton();
			this.rdb_comm_status_dec = new System.Windows.Forms.RadioButton();
			this.label28 = new System.Windows.Forms.Label();
			this.nud_comm_transfreq = new System.Windows.Forms.NumericUpDown();
			this.btn_startTransmission = new System.Windows.Forms.Button();
			this.lbl_heartBeat_ms = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.pbr_heartBeat = new System.Windows.Forms.ProgressBar();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_con_messageSendt = new System.Windows.Forms.TextBox();
			this.txt_con_messageRecieved = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.nud_con_serial_value = new System.Windows.Forms.NumericUpDown();
			this.nud_con_serial_index = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_comm_serialSend = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmb_comport = new System.Windows.Forms.ComboBox();
			this.btn_comm_serialConnect = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmb_baudrate = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.btn_comm_sendethernetmessage = new System.Windows.Forms.Button();
			this.txt_comm_ethernetmessage = new System.Windows.Forms.TextBox();
			this.lbx_comm_messages = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txt_comm_clientport = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.txt_comm_clientip = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.btn_comm_ethernetConnect = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txt_comm_serverport = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.txt_comm_serverip = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.btn_comm_startserver = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label36 = new System.Windows.Forms.Label();
			this.txt_comm_CANreply = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.btn_comm_CANsend = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.txt_comm_CANport = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.txt_comm_CANip = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.btn_comm_CANconnect = new System.Windows.Forms.Button();
			this.txt_comm_CANmessage = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tbl_IndexSettings = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_InsertIndexSetting = new System.Windows.Forms.Button();
			this.btn_Instructions = new System.Windows.Forms.Button();
			this.grp_IndexInstructions = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label8 = new System.Windows.Forms.Label();
			this.panel_IndexSettings = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.picGraph = new System.Windows.Forms.PictureBox();
			this.flp_joysticksetting_buttons = new System.Windows.Forms.FlowLayoutPanel();
			this.flp_joysticksetting_axis = new System.Windows.Forms.FlowLayoutPanel();
			this.grp_JoystickInstructions = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.btn_joystick_instruction = new System.Windows.Forms.Button();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.label27 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtbox_graphicsloaded = new System.Windows.Forms.TextBox();
			this.txtbox_dllimported = new System.Windows.Forms.TextBox();
			this.btn_graphicsloaded = new System.Windows.Forms.Button();
			this.btn_loaddll = new System.Windows.Forms.Button();
			this.lab_GraphicsLoaded = new System.Windows.Forms.Label();
			this.lab_DLLimported = new System.Windows.Forms.Label();
			this.btn_LoadSettings = new System.Windows.Forms.Button();
			this.btn_ExportSettings = new System.Windows.Forms.Button();
			this.tim_10ms_update = new System.Windows.Forms.Timer(this.components);
			this.panel_IndexStats = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_EditMode = new System.Windows.Forms.Button();
			this.btn_AddIndexStat = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.nud_puls_on = new System.Windows.Forms.NumericUpDown();
			this.nud_puls_off = new System.Windows.Forms.NumericUpDown();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tim_heartBeat = new System.Windows.Forms.Timer(this.components);
			this.txt_error = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.tim_100ms_update = new System.Windows.Forms.Timer(this.components);
			this.tim_SendCommandsDelay = new System.Windows.Forms.Timer(this.components);
			this.bgw_ethernetMessageRecieveHandler = new System.ComponentModel.BackgroundWorker();
			this.bgw_ethernetMessageSendHandler = new System.ComponentModel.BackgroundWorker();
			this.bgw_aegirMessageRequest = new System.ComponentModel.BackgroundWorker();
			this.rightclickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.btn_MenuReposition = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_MenuDeleteControl = new System.Windows.Forms.ToolStripMenuItem();
			this.AegirMessageRequest = new System.ComponentModel.BackgroundWorker();
			this.tim_puls = new System.Windows.Forms.Timer(this.components);
			this.connectionTab.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_rolldiv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_pitchdiv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_rollindex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_heading_index)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_pitchindex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_depth_index)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_height_index)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.pan_graphicsCreator.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_gyro_calibration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_man_depth_SP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_zerodepth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_rot_p)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_rot_i)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_rot_d)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_trans_p)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_trans_i)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_trans_d)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_lightdim)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_comm_transfreq)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_con_serial_value)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_con_serial_index)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tbl_IndexSettings.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.grp_IndexInstructions.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
			this.grp_JoystickInstructions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.flowLayoutPanel5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_puls_on)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_puls_off)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.rightclickMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// connectionTab
			// 
			this.connectionTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.connectionTab.Controls.Add(this.tabPage1);
			this.connectionTab.Controls.Add(this.tabPage2);
			this.connectionTab.Controls.Add(this.tabPage3);
			this.connectionTab.Controls.Add(this.tabPage4);
			this.connectionTab.Controls.Add(this.tabPage5);
			this.connectionTab.Controls.Add(this.tabPage6);
			this.connectionTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.connectionTab.ItemSize = new System.Drawing.Size(72, 21);
			this.connectionTab.Location = new System.Drawing.Point(12, 12);
			this.connectionTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.connectionTab.Name = "connectionTab";
			this.connectionTab.SelectedIndex = 0;
			this.connectionTab.Size = new System.Drawing.Size(1400, 629);
			this.connectionTab.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage1.Controls.Add(this.nud_navigation_attitude_rolldiv);
			this.tabPage1.Controls.Add(this.nud_navigation_attitude_pitchdiv);
			this.tabPage1.Controls.Add(this.aGauge2);
			this.tabPage1.Controls.Add(this.aGauge1);
			this.tabPage1.Controls.Add(this.nud_navigation_attitude_rollindex);
			this.tabPage1.Controls.Add(this.nud_navigation_heading_index);
			this.tabPage1.Controls.Add(this.nud_navigation_attitude_pitchindex);
			this.tabPage1.Controls.Add(this.nud_navigation_depth_index);
			this.tabPage1.Controls.Add(this.nud_navigation_height_index);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.ali_navigation_depth_instrument);
			this.tabPage1.Controls.Add(this.airSpeedIndicatorInstrumentControl1);
			this.tabPage1.Controls.Add(this.verticalSpeedIndicatorInstrumentControl1);
			this.tabPage1.Controls.Add(this.aii_navigation_attitude_instrument);
			this.tabPage1.Controls.Add(this.ali_navigation_height_instrument);
			this.tabPage1.Controls.Add(this.hdi_navigation_heading_instrument);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(1392, 600);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = "Navigation";
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			// 
			// nud_navigation_attitude_rolldiv
			// 
			this.nud_navigation_attitude_rolldiv.Location = new System.Drawing.Point(890, 200);
			this.nud_navigation_attitude_rolldiv.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.nud_navigation_attitude_rolldiv.Name = "nud_navigation_attitude_rolldiv";
			this.nud_navigation_attitude_rolldiv.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_attitude_rolldiv.TabIndex = 20;
			this.nud_navigation_attitude_rolldiv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// nud_navigation_attitude_pitchdiv
			// 
			this.nud_navigation_attitude_pitchdiv.Location = new System.Drawing.Point(889, 171);
			this.nud_navigation_attitude_pitchdiv.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.nud_navigation_attitude_pitchdiv.Name = "nud_navigation_attitude_pitchdiv";
			this.nud_navigation_attitude_pitchdiv.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_attitude_pitchdiv.TabIndex = 19;
			this.nud_navigation_attitude_pitchdiv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
			this.aGauge2.Location = new System.Drawing.Point(493, 460);
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
			this.aGauge2.Size = new System.Drawing.Size(214, 127);
			this.aGauge2.TabIndex = 18;
			this.aGauge2.Text = "aGauge2";
			this.aGauge2.Value = 20F;
			// 
			// aGauge1
			// 
			this.aGauge1.BaseArcColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge1.BaseArcRadius = 80;
			this.aGauge1.BaseArcStart = 180;
			this.aGauge1.BaseArcSweep = 180;
			this.aGauge1.BaseArcWidth = 5;
			this.aGauge1.Cap_Idx = ((byte)(1));
			this.aGauge1.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
			this.aGauge1.CapPosition = new System.Drawing.Point(10, 10);
			this.aGauge1.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
			this.aGauge1.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
			this.aGauge1.CapText = "";
			this.aGauge1.Center = new System.Drawing.Point(100, 100);
			this.aGauge1.Location = new System.Drawing.Point(733, 460);
			this.aGauge1.MaxValue = 100F;
			this.aGauge1.MinValue = 0F;
			this.aGauge1.Name = "aGauge1";
			this.aGauge1.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Gray;
			this.aGauge1.NeedleColor2 = System.Drawing.Color.DimGray;
			this.aGauge1.NeedleRadius = 80;
			this.aGauge1.NeedleType = 0;
			this.aGauge1.NeedleWidth = 2;
			this.aGauge1.Range_Idx = ((byte)(0));
			this.aGauge1.RangeColor = System.Drawing.Color.Red;
			this.aGauge1.RangeEnabled = true;
			this.aGauge1.RangeEndValue = 20F;
			this.aGauge1.RangeInnerRadius = 60;
			this.aGauge1.RangeOuterRadius = 80;
			this.aGauge1.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.LightGreen,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
			this.aGauge1.RangesEnabled = new bool[] {
        true,
        true,
        false,
        false,
        false};
			this.aGauge1.RangesEndValue = new float[] {
        20F,
        100F,
        0F,
        0F,
        0F};
			this.aGauge1.RangesInnerRadius = new int[] {
        60,
        60,
        60,
        70,
        70};
			this.aGauge1.RangesOuterRadius = new int[] {
        80,
        80,
        80,
        80,
        80};
			this.aGauge1.RangesStartValue = new float[] {
        0F,
        20F,
        0F,
        0F,
        0F};
			this.aGauge1.RangeStartValue = 0F;
			this.aGauge1.ScaleLinesInterColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge1.ScaleLinesInterInnerRadius = 70;
			this.aGauge1.ScaleLinesInterOuterRadius = 80;
			this.aGauge1.ScaleLinesInterWidth = 1;
			this.aGauge1.ScaleLinesMajorColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge1.ScaleLinesMajorInnerRadius = 70;
			this.aGauge1.ScaleLinesMajorOuterRadius = 80;
			this.aGauge1.ScaleLinesMajorStepValue = 20F;
			this.aGauge1.ScaleLinesMajorWidth = 4;
			this.aGauge1.ScaleLinesMinorColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge1.ScaleLinesMinorInnerRadius = 75;
			this.aGauge1.ScaleLinesMinorNumOf = 9;
			this.aGauge1.ScaleLinesMinorOuterRadius = 80;
			this.aGauge1.ScaleLinesMinorWidth = 1;
			this.aGauge1.ScaleNumbersColor = System.Drawing.SystemColors.MenuHighlight;
			this.aGauge1.ScaleNumbersFormat = null;
			this.aGauge1.ScaleNumbersRadius = 95;
			this.aGauge1.ScaleNumbersRotation = 0;
			this.aGauge1.ScaleNumbersStartScaleLine = 0;
			this.aGauge1.ScaleNumbersStepScaleLines = 1;
			this.aGauge1.Size = new System.Drawing.Size(214, 127);
			this.aGauge1.TabIndex = 17;
			this.aGauge1.Text = "aGauge1";
			this.aGauge1.Value = 20F;
			// 
			// nud_navigation_attitude_rollindex
			// 
			this.nud_navigation_attitude_rollindex.Location = new System.Drawing.Point(826, 200);
			this.nud_navigation_attitude_rollindex.Name = "nud_navigation_attitude_rollindex";
			this.nud_navigation_attitude_rollindex.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_attitude_rollindex.TabIndex = 16;
			this.nud_navigation_attitude_rollindex.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// nud_navigation_heading_index
			// 
			this.nud_navigation_heading_index.Location = new System.Drawing.Point(772, 4);
			this.nud_navigation_heading_index.Name = "nud_navigation_heading_index";
			this.nud_navigation_heading_index.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_heading_index.TabIndex = 15;
			this.nud_navigation_heading_index.Value = new decimal(new int[] {
            37,
            0,
            0,
            0});
			// 
			// nud_navigation_attitude_pitchindex
			// 
			this.nud_navigation_attitude_pitchindex.Location = new System.Drawing.Point(826, 171);
			this.nud_navigation_attitude_pitchindex.Name = "nud_navigation_attitude_pitchindex";
			this.nud_navigation_attitude_pitchindex.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_attitude_pitchindex.TabIndex = 14;
			this.nud_navigation_attitude_pitchindex.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// nud_navigation_depth_index
			// 
			this.nud_navigation_depth_index.Location = new System.Drawing.Point(1308, 379);
			this.nud_navigation_depth_index.Name = "nud_navigation_depth_index";
			this.nud_navigation_depth_index.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_depth_index.TabIndex = 13;
			this.nud_navigation_depth_index.Value = new decimal(new int[] {
            52,
            0,
            0,
            0});
			// 
			// nud_navigation_height_index
			// 
			this.nud_navigation_height_index.Location = new System.Drawing.Point(1308, 154);
			this.nud_navigation_height_index.Name = "nud_navigation_height_index";
			this.nud_navigation_height_index.Size = new System.Drawing.Size(57, 23);
			this.nud_navigation_height_index.TabIndex = 12;
			this.nud_navigation_height_index.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// textBox4
			// 
			this.textBox4.BackColor = System.Drawing.SystemColors.ControlLight;
			this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox4.Location = new System.Drawing.Point(1150, 379);
			this.textBox4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(152, 23);
			this.textBox4.TabIndex = 11;
			this.textBox4.Text = "Depth";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(1150, 154);
			this.textBox3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(152, 23);
			this.textBox3.TabIndex = 10;
			this.textBox3.Text = "Height";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(639, 3);
			this.textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(127, 23);
			this.textBox2.TabIndex = 9;
			this.textBox2.Text = "Heading";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(583, 170);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(237, 23);
			this.textBox1.TabIndex = 8;
			this.textBox1.Text = "Attitude";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ali_navigation_depth_instrument
			// 
			this.ali_navigation_depth_instrument.Location = new System.Drawing.Point(1150, 406);
			this.ali_navigation_depth_instrument.Name = "ali_navigation_depth_instrument";
			this.ali_navigation_depth_instrument.Size = new System.Drawing.Size(152, 154);
			this.ali_navigation_depth_instrument.TabIndex = 7;
			this.ali_navigation_depth_instrument.Text = "altimeterInstrumentControl2";
			// 
			// airSpeedIndicatorInstrumentControl1
			// 
			this.airSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(80, 351);
			this.airSpeedIndicatorInstrumentControl1.Name = "airSpeedIndicatorInstrumentControl1";
			this.airSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(208, 209);
			this.airSpeedIndicatorInstrumentControl1.TabIndex = 6;
			this.airSpeedIndicatorInstrumentControl1.Text = "airSpeedIndicatorInstrumentControl1";
			// 
			// verticalSpeedIndicatorInstrumentControl1
			// 
			this.verticalSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(107, 188);
			this.verticalSpeedIndicatorInstrumentControl1.Name = "verticalSpeedIndicatorInstrumentControl1";
			this.verticalSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(152, 157);
			this.verticalSpeedIndicatorInstrumentControl1.TabIndex = 5;
			this.verticalSpeedIndicatorInstrumentControl1.Text = "verticalSpeedIndicatorInstrumentControl1";
			// 
			// aii_navigation_attitude_instrument
			// 
			this.aii_navigation_attitude_instrument.Location = new System.Drawing.Point(583, 196);
			this.aii_navigation_attitude_instrument.Name = "aii_navigation_attitude_instrument";
			this.aii_navigation_attitude_instrument.Size = new System.Drawing.Size(237, 240);
			this.aii_navigation_attitude_instrument.TabIndex = 1;
			this.aii_navigation_attitude_instrument.Text = "aii_navigation_attitude_instrument";
			// 
			// ali_navigation_height_instrument
			// 
			this.ali_navigation_height_instrument.Location = new System.Drawing.Point(1150, 181);
			this.ali_navigation_height_instrument.Name = "ali_navigation_height_instrument";
			this.ali_navigation_height_instrument.Size = new System.Drawing.Size(152, 154);
			this.ali_navigation_height_instrument.TabIndex = 0;
			this.ali_navigation_height_instrument.Text = "altimeterInstrumentControl1";
			// 
			// hdi_navigation_heading_instrument
			// 
			this.hdi_navigation_heading_instrument.Location = new System.Drawing.Point(639, 30);
			this.hdi_navigation_heading_instrument.Name = "hdi_navigation_heading_instrument";
			this.hdi_navigation_heading_instrument.Size = new System.Drawing.Size(127, 134);
			this.hdi_navigation_heading_instrument.TabIndex = 3;
			this.hdi_navigation_heading_instrument.Text = "headingIndicatorInstrumentControl1";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage2.Controls.Add(this.pan_graphicsCreator);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage2.Size = new System.Drawing.Size(1392, 600);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Robot status";
			// 
			// pan_graphicsCreator
			// 
			this.pan_graphicsCreator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.pan_graphicsCreator.Controls.Add(this.groupBox12);
			this.pan_graphicsCreator.Controls.Add(this.groupBox11);
			this.pan_graphicsCreator.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pan_graphicsCreator.Location = new System.Drawing.Point(3, 2);
			this.pan_graphicsCreator.Name = "pan_graphicsCreator";
			this.pan_graphicsCreator.Size = new System.Drawing.Size(1386, 596);
			this.pan_graphicsCreator.TabIndex = 0;
			this.pan_graphicsCreator.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_graphicsCreator_Paint);
			this.pan_graphicsCreator.DoubleClick += new System.EventHandler(this.pan_graphicsCreator_DoubleClick);
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.pan_graphicToolbox);
			this.groupBox12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox12.Location = new System.Drawing.Point(826, 3);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(200, 590);
			this.groupBox12.TabIndex = 2;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Toolbox";
			// 
			// pan_graphicToolbox
			// 
			this.pan_graphicToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pan_graphicToolbox.Location = new System.Drawing.Point(3, 19);
			this.pan_graphicToolbox.Name = "pan_graphicToolbox";
			this.pan_graphicToolbox.Size = new System.Drawing.Size(194, 568);
			this.pan_graphicToolbox.TabIndex = 0;
			// 
			// groupBox11
			// 
			this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox11.Controls.Add(this.label47);
			this.groupBox11.Controls.Add(this.nud_aegir_gyro_calibration);
			this.groupBox11.Controls.Add(this.label46);
			this.groupBox11.Controls.Add(this.nud_aegir_man_depth_SP);
			this.groupBox11.Controls.Add(this.label44);
			this.groupBox11.Controls.Add(this.nud_aegir_zerodepth);
			this.groupBox11.Controls.Add(this.label43);
			this.groupBox11.Controls.Add(this.label42);
			this.groupBox11.Controls.Add(this.label41);
			this.groupBox11.Controls.Add(this.label40);
			this.groupBox11.Controls.Add(this.label39);
			this.groupBox11.Controls.Add(this.nud_aegir_rot_p);
			this.groupBox11.Controls.Add(this.nud_aegir_rot_i);
			this.groupBox11.Controls.Add(this.nud_aegir_rot_d);
			this.groupBox11.Controls.Add(this.nud_aegir_trans_p);
			this.groupBox11.Controls.Add(this.nud_aegir_trans_i);
			this.groupBox11.Controls.Add(this.nud_aegir_trans_d);
			this.groupBox11.Controls.Add(this.btn_aegir_RegAuto);
			this.groupBox11.Controls.Add(this.label37);
			this.groupBox11.Controls.Add(this.btn_aegir_coolingfan);
			this.groupBox11.Controls.Add(this.btn_aegir_armmotors);
			this.groupBox11.Controls.Add(this.nud_aegir_lightdim);
			this.groupBox11.Controls.Add(this.btn_aegir_light);
			this.groupBox11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox11.Location = new System.Drawing.Point(1032, 3);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(351, 590);
			this.groupBox11.TabIndex = 0;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Ægir TEMP";
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(18, 480);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(108, 17);
			this.label47.TabIndex = 22;
			this.label47.Text = "Gyro calibration";
			// 
			// nud_aegir_gyro_calibration
			// 
			this.nud_aegir_gyro_calibration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_gyro_calibration.Location = new System.Drawing.Point(284, 478);
			this.nud_aegir_gyro_calibration.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
			this.nud_aegir_gyro_calibration.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
			this.nud_aegir_gyro_calibration.Name = "nud_aegir_gyro_calibration";
			this.nud_aegir_gyro_calibration.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_gyro_calibration.TabIndex = 21;
			this.nud_aegir_gyro_calibration.ValueChanged += new System.EventHandler(this.nud_aegir_gyro_calibration_ValueChanged);
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(16, 402);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(229, 17);
			this.label46.TabIndex = 20;
			this.label46.Text = "Depth SP (0: auto SP, >0: man SP)";
			// 
			// nud_aegir_man_depth_SP
			// 
			this.nud_aegir_man_depth_SP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_man_depth_SP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nud_aegir_man_depth_SP.Location = new System.Drawing.Point(282, 400);
			this.nud_aegir_man_depth_SP.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.nud_aegir_man_depth_SP.Name = "nud_aegir_man_depth_SP";
			this.nud_aegir_man_depth_SP.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_man_depth_SP.TabIndex = 19;
			this.nud_aegir_man_depth_SP.ValueChanged += new System.EventHandler(this.nud_man_depth_SP_ValueChanged);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(18, 451);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(78, 17);
			this.label44.TabIndex = 18;
			this.label44.Text = "Zero depth";
			// 
			// nud_aegir_zerodepth
			// 
			this.nud_aegir_zerodepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_zerodepth.Location = new System.Drawing.Point(284, 449);
			this.nud_aegir_zerodepth.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_aegir_zerodepth.Name = "nud_aegir_zerodepth";
			this.nud_aegir_zerodepth.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_zerodepth.TabIndex = 17;
			this.nud_aegir_zerodepth.ValueChanged += new System.EventHandler(this.nud_aegir_zerodepth_ValueChanged);
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(281, 321);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(18, 17);
			this.label43.TabIndex = 16;
			this.label43.Text = "D";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(224, 321);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(11, 17);
			this.label42.TabIndex = 15;
			this.label42.Text = "I";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(170, 321);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(17, 17);
			this.label41.TabIndex = 14;
			this.label41.Text = "P";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(18, 372);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(90, 17);
			this.label40.TabIndex = 13;
			this.label40.Text = "Rotation reg.";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(18, 343);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(108, 17);
			this.label39.TabIndex = 12;
			this.label39.Text = "Translation reg.";
			// 
			// nud_aegir_rot_p
			// 
			this.nud_aegir_rot_p.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_rot_p.Location = new System.Drawing.Point(171, 370);
			this.nud_aegir_rot_p.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_aegir_rot_p.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_aegir_rot_p.Name = "nud_aegir_rot_p";
			this.nud_aegir_rot_p.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_rot_p.TabIndex = 11;
			this.nud_aegir_rot_p.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.nud_aegir_rot_p.ValueChanged += new System.EventHandler(this.nud_aegir_rot_p_ValueChanged);
			// 
			// nud_aegir_rot_i
			// 
			this.nud_aegir_rot_i.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_rot_i.Location = new System.Drawing.Point(227, 370);
			this.nud_aegir_rot_i.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_aegir_rot_i.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_aegir_rot_i.Name = "nud_aegir_rot_i";
			this.nud_aegir_rot_i.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_rot_i.TabIndex = 10;
			this.nud_aegir_rot_i.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.nud_aegir_rot_i.ValueChanged += new System.EventHandler(this.nud_aegir_rot_i_ValueChanged);
			// 
			// nud_aegir_rot_d
			// 
			this.nud_aegir_rot_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_rot_d.Location = new System.Drawing.Point(283, 370);
			this.nud_aegir_rot_d.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_aegir_rot_d.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_aegir_rot_d.Name = "nud_aegir_rot_d";
			this.nud_aegir_rot_d.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_rot_d.TabIndex = 9;
			this.nud_aegir_rot_d.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nud_aegir_rot_d.ValueChanged += new System.EventHandler(this.nud_aegir_rot_d_ValueChanged);
			// 
			// nud_aegir_trans_p
			// 
			this.nud_aegir_trans_p.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_trans_p.Location = new System.Drawing.Point(171, 341);
			this.nud_aegir_trans_p.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_aegir_trans_p.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_aegir_trans_p.Name = "nud_aegir_trans_p";
			this.nud_aegir_trans_p.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_trans_p.TabIndex = 8;
			this.nud_aegir_trans_p.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
			this.nud_aegir_trans_p.ValueChanged += new System.EventHandler(this.nud_aegir_trans_p_ValueChanged);
			// 
			// nud_aegir_trans_i
			// 
			this.nud_aegir_trans_i.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_trans_i.Location = new System.Drawing.Point(227, 341);
			this.nud_aegir_trans_i.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_aegir_trans_i.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_aegir_trans_i.Name = "nud_aegir_trans_i";
			this.nud_aegir_trans_i.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_trans_i.TabIndex = 7;
			this.nud_aegir_trans_i.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nud_aegir_trans_i.ValueChanged += new System.EventHandler(this.nud_aegir_trans_i_ValueChanged);
			// 
			// nud_aegir_trans_d
			// 
			this.nud_aegir_trans_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_trans_d.Location = new System.Drawing.Point(283, 341);
			this.nud_aegir_trans_d.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_aegir_trans_d.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_aegir_trans_d.Name = "nud_aegir_trans_d";
			this.nud_aegir_trans_d.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_trans_d.TabIndex = 6;
			this.nud_aegir_trans_d.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nud_aegir_trans_d.ValueChanged += new System.EventHandler(this.nud_aegir_trans_d_ValueChanged);
			// 
			// btn_aegir_RegAuto
			// 
			this.btn_aegir_RegAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_aegir_RegAuto.Location = new System.Drawing.Point(19, 276);
			this.btn_aegir_RegAuto.Name = "btn_aegir_RegAuto";
			this.btn_aegir_RegAuto.Size = new System.Drawing.Size(313, 39);
			this.btn_aegir_RegAuto.TabIndex = 5;
			this.btn_aegir_RegAuto.Text = "Possition control [Auto]";
			this.btn_aegir_RegAuto.UseVisualStyleBackColor = true;
			this.btn_aegir_RegAuto.Click += new System.EventHandler(this.btn_aegir_RegAuto_Click);
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(182, 151);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(95, 17);
			this.label37.TabIndex = 4;
			this.label37.Text = "Light dimming";
			// 
			// btn_aegir_coolingfan
			// 
			this.btn_aegir_coolingfan.Location = new System.Drawing.Point(20, 185);
			this.btn_aegir_coolingfan.Name = "btn_aegir_coolingfan";
			this.btn_aegir_coolingfan.Size = new System.Drawing.Size(139, 39);
			this.btn_aegir_coolingfan.TabIndex = 3;
			this.btn_aegir_coolingfan.Text = "Coolingfan [Off]";
			this.btn_aegir_coolingfan.UseVisualStyleBackColor = true;
			this.btn_aegir_coolingfan.Click += new System.EventHandler(this.btn_aegir_coolingfan_Click);
			// 
			// btn_aegir_armmotors
			// 
			this.btn_aegir_armmotors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_aegir_armmotors.Location = new System.Drawing.Point(20, 51);
			this.btn_aegir_armmotors.Name = "btn_aegir_armmotors";
			this.btn_aegir_armmotors.Size = new System.Drawing.Size(313, 39);
			this.btn_aegir_armmotors.TabIndex = 2;
			this.btn_aegir_armmotors.Text = "Arm motors [Disarmed]";
			this.btn_aegir_armmotors.UseVisualStyleBackColor = true;
			this.btn_aegir_armmotors.Click += new System.EventHandler(this.btn_aegir_armmotors_Click);
			// 
			// nud_aegir_lightdim
			// 
			this.nud_aegir_lightdim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_aegir_lightdim.Location = new System.Drawing.Point(283, 149);
			this.nud_aegir_lightdim.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nud_aegir_lightdim.Name = "nud_aegir_lightdim";
			this.nud_aegir_lightdim.Size = new System.Drawing.Size(50, 23);
			this.nud_aegir_lightdim.TabIndex = 1;
			this.nud_aegir_lightdim.ValueChanged += new System.EventHandler(this.nud_aegir_lightdim_ValueChanged);
			// 
			// btn_aegir_light
			// 
			this.btn_aegir_light.Location = new System.Drawing.Point(20, 140);
			this.btn_aegir_light.Name = "btn_aegir_light";
			this.btn_aegir_light.Size = new System.Drawing.Size(139, 39);
			this.btn_aegir_light.TabIndex = 0;
			this.btn_aegir_light.Text = "Light [Off]";
			this.btn_aegir_light.UseVisualStyleBackColor = true;
			this.btn_aegir_light.Click += new System.EventHandler(this.btn_aegir_light_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Controls.Add(this.tableLayoutPanel1);
			this.tabPage3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage3.Size = new System.Drawing.Size(1392, 600);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Connection";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.rdb_comm_status_bytes);
			this.groupBox3.Controls.Add(this.rdb_comm_status_hex);
			this.groupBox3.Controls.Add(this.rdb_comm_status_dec);
			this.groupBox3.Controls.Add(this.label28);
			this.groupBox3.Controls.Add(this.nud_comm_transfreq);
			this.groupBox3.Controls.Add(this.btn_startTransmission);
			this.groupBox3.Controls.Add(this.lbl_heartBeat_ms);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.pbr_heartBeat);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.txt_con_messageSendt);
			this.groupBox3.Controls.Add(this.txt_con_messageRecieved);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox3.Location = new System.Drawing.Point(19, 422);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Size = new System.Drawing.Size(1355, 153);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Status";
			// 
			// rdb_comm_status_bytes
			// 
			this.rdb_comm_status_bytes.AutoSize = true;
			this.rdb_comm_status_bytes.Location = new System.Drawing.Point(230, 98);
			this.rdb_comm_status_bytes.Name = "rdb_comm_status_bytes";
			this.rdb_comm_status_bytes.Size = new System.Drawing.Size(61, 21);
			this.rdb_comm_status_bytes.TabIndex = 24;
			this.rdb_comm_status_bytes.Text = "Bytes";
			this.rdb_comm_status_bytes.UseVisualStyleBackColor = true;
			this.rdb_comm_status_bytes.CheckedChanged += new System.EventHandler(this.rdb_comm_status_CheckedChanged);
			// 
			// rdb_comm_status_hex
			// 
			this.rdb_comm_status_hex.AutoSize = true;
			this.rdb_comm_status_hex.Location = new System.Drawing.Point(297, 98);
			this.rdb_comm_status_hex.Name = "rdb_comm_status_hex";
			this.rdb_comm_status_hex.Size = new System.Drawing.Size(50, 21);
			this.rdb_comm_status_hex.TabIndex = 23;
			this.rdb_comm_status_hex.Text = "Hex";
			this.rdb_comm_status_hex.UseVisualStyleBackColor = true;
			this.rdb_comm_status_hex.CheckedChanged += new System.EventHandler(this.rdb_comm_status_CheckedChanged);
			// 
			// rdb_comm_status_dec
			// 
			this.rdb_comm_status_dec.AutoSize = true;
			this.rdb_comm_status_dec.Checked = true;
			this.rdb_comm_status_dec.Location = new System.Drawing.Point(148, 98);
			this.rdb_comm_status_dec.Name = "rdb_comm_status_dec";
			this.rdb_comm_status_dec.Size = new System.Drawing.Size(76, 21);
			this.rdb_comm_status_dec.TabIndex = 22;
			this.rdb_comm_status_dec.TabStop = true;
			this.rdb_comm_status_dec.Text = "Decimal";
			this.rdb_comm_status_dec.UseVisualStyleBackColor = true;
			this.rdb_comm_status_dec.CheckedChanged += new System.EventHandler(this.rdb_comm_status_CheckedChanged);
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(1200, 31);
			this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(118, 17);
			this.label28.TabIndex = 21;
			this.label28.Text = "Transmision freq.";
			// 
			// nud_comm_transfreq
			// 
			this.nud_comm_transfreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_comm_transfreq.Location = new System.Drawing.Point(1203, 52);
			this.nud_comm_transfreq.Name = "nud_comm_transfreq";
			this.nud_comm_transfreq.Size = new System.Drawing.Size(133, 23);
			this.nud_comm_transfreq.TabIndex = 20;
			this.nud_comm_transfreq.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// btn_startTransmission
			// 
			this.btn_startTransmission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_startTransmission.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.btn_startTransmission.Location = new System.Drawing.Point(1203, 87);
			this.btn_startTransmission.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_startTransmission.Name = "btn_startTransmission";
			this.btn_startTransmission.Size = new System.Drawing.Size(133, 42);
			this.btn_startTransmission.TabIndex = 13;
			this.btn_startTransmission.Text = "Start transmision";
			this.btn_startTransmission.UseVisualStyleBackColor = true;
			this.btn_startTransmission.Click += new System.EventHandler(this.btn_startTransmission_Click);
			// 
			// lbl_heartBeat_ms
			// 
			this.lbl_heartBeat_ms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_heartBeat_ms.AutoSize = true;
			this.lbl_heartBeat_ms.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbl_heartBeat_ms.Location = new System.Drawing.Point(580, 58);
			this.lbl_heartBeat_ms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_heartBeat_ms.Name = "lbl_heartBeat_ms";
			this.lbl_heartBeat_ms.Size = new System.Drawing.Size(34, 17);
			this.lbl_heartBeat_ms.TabIndex = 19;
			this.lbl_heartBeat_ms.Text = "0ms";
			// 
			// label19
			// 
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(650, 31);
			this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(71, 17);
			this.label19.TabIndex = 18;
			this.label19.Text = "Heartbeat";
			this.label19.Click += new System.EventHandler(this.label19_Click);
			// 
			// pbr_heartBeat
			// 
			this.pbr_heartBeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbr_heartBeat.Location = new System.Drawing.Point(650, 55);
			this.pbr_heartBeat.Margin = new System.Windows.Forms.Padding(4);
			this.pbr_heartBeat.Name = "pbr_heartBeat";
			this.pbr_heartBeat.Size = new System.Drawing.Size(133, 28);
			this.pbr_heartBeat.Step = 1;
			this.pbr_heartBeat.TabIndex = 17;
			this.pbr_heartBeat.Value = 100;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label6.Location = new System.Drawing.Point(19, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 17);
			this.label6.TabIndex = 16;
			this.label6.Text = "Message recieved";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label7.Location = new System.Drawing.Point(19, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 17);
			this.label7.TabIndex = 15;
			this.label7.Text = "Message sendt";
			// 
			// txt_con_messageSendt
			// 
			this.txt_con_messageSendt.Enabled = false;
			this.txt_con_messageSendt.Location = new System.Drawing.Point(148, 32);
			this.txt_con_messageSendt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_con_messageSendt.Name = "txt_con_messageSendt";
			this.txt_con_messageSendt.Size = new System.Drawing.Size(217, 23);
			this.txt_con_messageSendt.TabIndex = 13;
			// 
			// txt_con_messageRecieved
			// 
			this.txt_con_messageRecieved.Location = new System.Drawing.Point(148, 60);
			this.txt_con_messageRecieved.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_con_messageRecieved.Name = "txt_con_messageRecieved";
			this.txt_con_messageRecieved.Size = new System.Drawing.Size(217, 23);
			this.txt_con_messageRecieved.TabIndex = 14;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 522F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox8, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox7, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox6, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 6);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1382, 411);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.groupBox1);
			this.groupBox8.Controls.Add(this.groupBox2);
			this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox8.Location = new System.Drawing.Point(13, 12);
			this.groupBox8.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.groupBox8.Size = new System.Drawing.Size(404, 387);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Serial connection";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.nud_con_serial_value);
			this.groupBox1.Controls.Add(this.nud_con_serial_index);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.btn_comm_serialSend);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox1.Location = new System.Drawing.Point(0, 222);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(404, 165);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Advanced";
			// 
			// nud_con_serial_value
			// 
			this.nud_con_serial_value.Location = new System.Drawing.Point(94, 61);
			this.nud_con_serial_value.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.nud_con_serial_value.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
			this.nud_con_serial_value.Name = "nud_con_serial_value";
			this.nud_con_serial_value.Size = new System.Drawing.Size(82, 23);
			this.nud_con_serial_value.TabIndex = 14;
			// 
			// nud_con_serial_index
			// 
			this.nud_con_serial_index.Location = new System.Drawing.Point(94, 32);
			this.nud_con_serial_index.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.nud_con_serial_index.Name = "nud_con_serial_index";
			this.nud_con_serial_index.Size = new System.Drawing.Size(82, 23);
			this.nud_con_serial_index.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label5.Location = new System.Drawing.Point(20, 61);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "Value";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label4.Location = new System.Drawing.Point(20, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "Index";
			// 
			// btn_comm_serialSend
			// 
			this.btn_comm_serialSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_comm_serialSend.Enabled = false;
			this.btn_comm_serialSend.Location = new System.Drawing.Point(268, 31);
			this.btn_comm_serialSend.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_serialSend.Name = "btn_comm_serialSend";
			this.btn_comm_serialSend.Size = new System.Drawing.Size(111, 50);
			this.btn_comm_serialSend.TabIndex = 6;
			this.btn_comm_serialSend.Text = "Send";
			this.btn_comm_serialSend.UseVisualStyleBackColor = true;
			this.btn_comm_serialSend.Click += new System.EventHandler(this.btn_send_serial_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cmb_comport);
			this.groupBox2.Controls.Add(this.btn_comm_serialConnect);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cmb_baudrate);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox2.Location = new System.Drawing.Point(0, 87);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(404, 144);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Connection";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label2.Location = new System.Drawing.Point(20, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// cmb_comport
			// 
			this.cmb_comport.FormattingEnabled = true;
			this.cmb_comport.Location = new System.Drawing.Point(94, 33);
			this.cmb_comport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmb_comport.Name = "cmb_comport";
			this.cmb_comport.Size = new System.Drawing.Size(82, 24);
			this.cmb_comport.TabIndex = 0;
			this.cmb_comport.Text = "COM5";
			this.cmb_comport.Click += new System.EventHandler(this.cmb_comport_Click);
			// 
			// btn_comm_serialConnect
			// 
			this.btn_comm_serialConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_comm_serialConnect.Location = new System.Drawing.Point(268, 33);
			this.btn_comm_serialConnect.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_serialConnect.Name = "btn_comm_serialConnect";
			this.btn_comm_serialConnect.Size = new System.Drawing.Size(111, 52);
			this.btn_comm_serialConnect.TabIndex = 5;
			this.btn_comm_serialConnect.Text = "Connect";
			this.btn_comm_serialConnect.UseVisualStyleBackColor = true;
			this.btn_comm_serialConnect.Click += new System.EventHandler(this.btn_connect_serial_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label3.Location = new System.Drawing.Point(20, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Baud rate";
			// 
			// cmb_baudrate
			// 
			this.cmb_baudrate.FormattingEnabled = true;
			this.cmb_baudrate.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cmb_baudrate.Location = new System.Drawing.Point(94, 61);
			this.cmb_baudrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmb_baudrate.Name = "cmb_baudrate";
			this.cmb_baudrate.Size = new System.Drawing.Size(82, 24);
			this.cmb_baudrate.TabIndex = 2;
			this.cmb_baudrate.Text = "9600";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.btn_comm_sendethernetmessage);
			this.groupBox7.Controls.Add(this.txt_comm_ethernetmessage);
			this.groupBox7.Controls.Add(this.lbx_comm_messages);
			this.groupBox7.Controls.Add(this.groupBox5);
			this.groupBox7.Controls.Add(this.groupBox9);
			this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox7.Location = new System.Drawing.Point(443, 12);
			this.groupBox7.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.groupBox7.Size = new System.Drawing.Size(404, 387);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Ethernet connection";
			// 
			// btn_comm_sendethernetmessage
			// 
			this.btn_comm_sendethernetmessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_comm_sendethernetmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_comm_sendethernetmessage.Location = new System.Drawing.Point(314, 332);
			this.btn_comm_sendethernetmessage.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_sendethernetmessage.Name = "btn_comm_sendethernetmessage";
			this.btn_comm_sendethernetmessage.Size = new System.Drawing.Size(90, 23);
			this.btn_comm_sendethernetmessage.TabIndex = 15;
			this.btn_comm_sendethernetmessage.Text = "Send";
			this.btn_comm_sendethernetmessage.UseVisualStyleBackColor = true;
			this.btn_comm_sendethernetmessage.Click += new System.EventHandler(this.btn_comm_sendethernetmessage_Click);
			// 
			// txt_comm_ethernetmessage
			// 
			this.txt_comm_ethernetmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_comm_ethernetmessage.Location = new System.Drawing.Point(1, 332);
			this.txt_comm_ethernetmessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_ethernetmessage.Name = "txt_comm_ethernetmessage";
			this.txt_comm_ethernetmessage.Size = new System.Drawing.Size(308, 23);
			this.txt_comm_ethernetmessage.TabIndex = 25;
			// 
			// lbx_comm_messages
			// 
			this.lbx_comm_messages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbx_comm_messages.FormattingEnabled = true;
			this.lbx_comm_messages.ItemHeight = 16;
			this.lbx_comm_messages.Location = new System.Drawing.Point(1, 243);
			this.lbx_comm_messages.Name = "lbx_comm_messages";
			this.lbx_comm_messages.Size = new System.Drawing.Size(404, 84);
			this.lbx_comm_messages.TabIndex = 51;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.txt_comm_clientport);
			this.groupBox5.Controls.Add(this.label30);
			this.groupBox5.Controls.Add(this.txt_comm_clientip);
			this.groupBox5.Controls.Add(this.label29);
			this.groupBox5.Controls.Add(this.btn_comm_ethernetConnect);
			this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox5.Location = new System.Drawing.Point(0, 139);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Size = new System.Drawing.Size(404, 108);
			this.groupBox5.TabIndex = 40;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Connection (as client)";
			// 
			// txt_comm_clientport
			// 
			this.txt_comm_clientport.Location = new System.Drawing.Point(102, 61);
			this.txt_comm_clientport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_clientport.Name = "txt_comm_clientport";
			this.txt_comm_clientport.Size = new System.Drawing.Size(103, 23);
			this.txt_comm_clientport.TabIndex = 27;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label30.Location = new System.Drawing.Point(20, 64);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(34, 17);
			this.label30.TabIndex = 26;
			this.label30.Text = "Port";
			// 
			// txt_comm_clientip
			// 
			this.txt_comm_clientip.Location = new System.Drawing.Point(102, 33);
			this.txt_comm_clientip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_clientip.Name = "txt_comm_clientip";
			this.txt_comm_clientip.Size = new System.Drawing.Size(103, 23);
			this.txt_comm_clientip.TabIndex = 25;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label29.Location = new System.Drawing.Point(20, 36);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(76, 17);
			this.label29.TabIndex = 3;
			this.label29.Text = "IP Address";
			// 
			// btn_comm_ethernetConnect
			// 
			this.btn_comm_ethernetConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_comm_ethernetConnect.Location = new System.Drawing.Point(268, 33);
			this.btn_comm_ethernetConnect.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_ethernetConnect.Name = "btn_comm_ethernetConnect";
			this.btn_comm_ethernetConnect.Size = new System.Drawing.Size(111, 52);
			this.btn_comm_ethernetConnect.TabIndex = 5;
			this.btn_comm_ethernetConnect.Text = "Connect";
			this.btn_comm_ethernetConnect.UseVisualStyleBackColor = true;
			this.btn_comm_ethernetConnect.Click += new System.EventHandler(this.btn_connect_ethernet_Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.txt_comm_serverport);
			this.groupBox9.Controls.Add(this.label31);
			this.groupBox9.Controls.Add(this.txt_comm_serverip);
			this.groupBox9.Controls.Add(this.label32);
			this.groupBox9.Controls.Add(this.btn_comm_startserver);
			this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox9.Location = new System.Drawing.Point(0, 40);
			this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox9.Size = new System.Drawing.Size(404, 104);
			this.groupBox9.TabIndex = 50;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Server";
			this.groupBox9.Visible = false;
			// 
			// txt_comm_serverport
			// 
			this.txt_comm_serverport.Location = new System.Drawing.Point(102, 61);
			this.txt_comm_serverport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_serverport.Name = "txt_comm_serverport";
			this.txt_comm_serverport.Size = new System.Drawing.Size(103, 23);
			this.txt_comm_serverport.TabIndex = 27;
			this.txt_comm_serverport.Text = "80";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label31.Location = new System.Drawing.Point(20, 64);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(34, 17);
			this.label31.TabIndex = 26;
			this.label31.Text = "Port";
			// 
			// txt_comm_serverip
			// 
			this.txt_comm_serverip.Enabled = false;
			this.txt_comm_serverip.Location = new System.Drawing.Point(102, 33);
			this.txt_comm_serverip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_serverip.Name = "txt_comm_serverip";
			this.txt_comm_serverip.Size = new System.Drawing.Size(103, 23);
			this.txt_comm_serverip.TabIndex = 25;
			this.txt_comm_serverip.Text = "192.168.1.10";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label32.Location = new System.Drawing.Point(20, 36);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(76, 17);
			this.label32.TabIndex = 3;
			this.label32.Text = "IP Address";
			// 
			// btn_comm_startserver
			// 
			this.btn_comm_startserver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_comm_startserver.Location = new System.Drawing.Point(268, 33);
			this.btn_comm_startserver.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_startserver.Name = "btn_comm_startserver";
			this.btn_comm_startserver.Size = new System.Drawing.Size(111, 52);
			this.btn_comm_startserver.TabIndex = 5;
			this.btn_comm_startserver.Text = "Start server";
			this.btn_comm_startserver.UseVisualStyleBackColor = true;
			this.btn_comm_startserver.Click += new System.EventHandler(this.btn_comm_startserver_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.label36);
			this.groupBox6.Controls.Add(this.txt_comm_CANreply);
			this.groupBox6.Controls.Add(this.label35);
			this.groupBox6.Controls.Add(this.btn_comm_CANsend);
			this.groupBox6.Controls.Add(this.groupBox10);
			this.groupBox6.Controls.Add(this.txt_comm_CANmessage);
			this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox6.Location = new System.Drawing.Point(873, 12);
			this.groupBox6.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.groupBox6.Size = new System.Drawing.Size(496, 387);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "CAN-bus connection";
			// 
			// label36
			// 
			this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label36.AutoSize = true;
			this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label36.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label36.Location = new System.Drawing.Point(20, 353);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(72, 17);
			this.label36.TabIndex = 54;
			this.label36.Text = "Response";
			// 
			// txt_comm_CANreply
			// 
			this.txt_comm_CANreply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txt_comm_CANreply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_comm_CANreply.Location = new System.Drawing.Point(102, 350);
			this.txt_comm_CANreply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_CANreply.Name = "txt_comm_CANreply";
			this.txt_comm_CANreply.Size = new System.Drawing.Size(229, 23);
			this.txt_comm_CANreply.TabIndex = 55;
			// 
			// label35
			// 
			this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label35.Location = new System.Drawing.Point(20, 326);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(65, 17);
			this.label35.TabIndex = 28;
			this.label35.Text = "Message";
			// 
			// btn_comm_CANsend
			// 
			this.btn_comm_CANsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_comm_CANsend.Enabled = false;
			this.btn_comm_CANsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_comm_CANsend.Location = new System.Drawing.Point(360, 319);
			this.btn_comm_CANsend.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_CANsend.Name = "btn_comm_CANsend";
			this.btn_comm_CANsend.Size = new System.Drawing.Size(111, 30);
			this.btn_comm_CANsend.TabIndex = 52;
			this.btn_comm_CANsend.Text = "Send";
			this.btn_comm_CANsend.UseVisualStyleBackColor = true;
			this.btn_comm_CANsend.Click += new System.EventHandler(this.btn_comm_CANsend_Click);
			// 
			// groupBox10
			// 
			this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox10.Controls.Add(this.txt_comm_CANport);
			this.groupBox10.Controls.Add(this.label33);
			this.groupBox10.Controls.Add(this.txt_comm_CANip);
			this.groupBox10.Controls.Add(this.label34);
			this.groupBox10.Controls.Add(this.btn_comm_CANconnect);
			this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox10.Location = new System.Drawing.Point(0, 87);
			this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox10.Size = new System.Drawing.Size(496, 108);
			this.groupBox10.TabIndex = 41;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Connection (as client)";
			// 
			// txt_comm_CANport
			// 
			this.txt_comm_CANport.Enabled = false;
			this.txt_comm_CANport.Location = new System.Drawing.Point(102, 61);
			this.txt_comm_CANport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_CANport.Name = "txt_comm_CANport";
			this.txt_comm_CANport.Size = new System.Drawing.Size(103, 23);
			this.txt_comm_CANport.TabIndex = 27;
			this.txt_comm_CANport.Text = "10001";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label33.Location = new System.Drawing.Point(20, 64);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(34, 17);
			this.label33.TabIndex = 26;
			this.label33.Text = "Port";
			// 
			// txt_comm_CANip
			// 
			this.txt_comm_CANip.Enabled = false;
			this.txt_comm_CANip.Location = new System.Drawing.Point(102, 33);
			this.txt_comm_CANip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_CANip.Name = "txt_comm_CANip";
			this.txt_comm_CANip.Size = new System.Drawing.Size(103, 23);
			this.txt_comm_CANip.TabIndex = 25;
			this.txt_comm_CANip.Text = "10.0.0.9";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label34.Location = new System.Drawing.Point(20, 36);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(76, 17);
			this.label34.TabIndex = 3;
			this.label34.Text = "IP Address";
			// 
			// btn_comm_CANconnect
			// 
			this.btn_comm_CANconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_comm_CANconnect.Location = new System.Drawing.Point(360, 33);
			this.btn_comm_CANconnect.Margin = new System.Windows.Forms.Padding(3, 2, 12, 2);
			this.btn_comm_CANconnect.Name = "btn_comm_CANconnect";
			this.btn_comm_CANconnect.Size = new System.Drawing.Size(111, 52);
			this.btn_comm_CANconnect.TabIndex = 5;
			this.btn_comm_CANconnect.Text = "Connect";
			this.btn_comm_CANconnect.UseVisualStyleBackColor = true;
			this.btn_comm_CANconnect.Click += new System.EventHandler(this.btn_comm_CANconnect_Click);
			// 
			// txt_comm_CANmessage
			// 
			this.txt_comm_CANmessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txt_comm_CANmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_comm_CANmessage.Location = new System.Drawing.Point(102, 323);
			this.txt_comm_CANmessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_comm_CANmessage.Name = "txt_comm_CANmessage";
			this.txt_comm_CANmessage.Size = new System.Drawing.Size(229, 23);
			this.txt_comm_CANmessage.TabIndex = 53;
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage4.Controls.Add(this.tbl_IndexSettings);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage4.Size = new System.Drawing.Size(1392, 600);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Index Settings";
			// 
			// tbl_IndexSettings
			// 
			this.tbl_IndexSettings.ColumnCount = 1;
			this.tbl_IndexSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tbl_IndexSettings.Controls.Add(this.flowLayoutPanel4, 0, 0);
			this.tbl_IndexSettings.Controls.Add(this.grp_IndexInstructions, 0, 3);
			this.tbl_IndexSettings.Controls.Add(this.panel_IndexSettings, 0, 2);
			this.tbl_IndexSettings.Controls.Add(this.flowLayoutPanel3, 0, 1);
			this.tbl_IndexSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbl_IndexSettings.Location = new System.Drawing.Point(4, 4);
			this.tbl_IndexSettings.Margin = new System.Windows.Forms.Padding(0);
			this.tbl_IndexSettings.Name = "tbl_IndexSettings";
			this.tbl_IndexSettings.RowCount = 4;
			this.tbl_IndexSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tbl_IndexSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tbl_IndexSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tbl_IndexSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tbl_IndexSettings.Size = new System.Drawing.Size(1384, 592);
			this.tbl_IndexSettings.TabIndex = 1;
			// 
			// flowLayoutPanel4
			// 
			this.flowLayoutPanel4.Controls.Add(this.btn_InsertIndexSetting);
			this.flowLayoutPanel4.Controls.Add(this.btn_Instructions);
			this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(1384, 40);
			this.flowLayoutPanel4.TabIndex = 0;
			// 
			// btn_InsertIndexSetting
			// 
			this.btn_InsertIndexSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_InsertIndexSetting.Location = new System.Drawing.Point(4, 4);
			this.btn_InsertIndexSetting.Margin = new System.Windows.Forms.Padding(4);
			this.btn_InsertIndexSetting.Name = "btn_InsertIndexSetting";
			this.btn_InsertIndexSetting.Size = new System.Drawing.Size(133, 32);
			this.btn_InsertIndexSetting.TabIndex = 0;
			this.btn_InsertIndexSetting.Text = "Insert New";
			this.btn_InsertIndexSetting.UseVisualStyleBackColor = true;
			this.btn_InsertIndexSetting.Click += new System.EventHandler(this.btn_InsertIndexSetting_Click);
			// 
			// btn_Instructions
			// 
			this.btn_Instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Instructions.Location = new System.Drawing.Point(145, 4);
			this.btn_Instructions.Margin = new System.Windows.Forms.Padding(4);
			this.btn_Instructions.Name = "btn_Instructions";
			this.btn_Instructions.Size = new System.Drawing.Size(133, 32);
			this.btn_Instructions.TabIndex = 2;
			this.btn_Instructions.Text = "Instructions";
			this.btn_Instructions.UseVisualStyleBackColor = true;
			this.btn_Instructions.Click += new System.EventHandler(this.grp_IndexInstructions_Enter);
			// 
			// grp_IndexInstructions
			// 
			this.grp_IndexInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_IndexInstructions.AutoSize = true;
			this.grp_IndexInstructions.Controls.Add(this.flowLayoutPanel2);
			this.grp_IndexInstructions.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.grp_IndexInstructions.Location = new System.Drawing.Point(0, 572);
			this.grp_IndexInstructions.Margin = new System.Windows.Forms.Padding(0, 0, 7, 6);
			this.grp_IndexInstructions.Name = "grp_IndexInstructions";
			this.grp_IndexInstructions.Padding = new System.Windows.Forms.Padding(4);
			this.grp_IndexInstructions.Size = new System.Drawing.Size(1377, 14);
			this.grp_IndexInstructions.TabIndex = 1;
			this.grp_IndexInstructions.TabStop = false;
			this.grp_IndexInstructions.Text = "Instructions";
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.Controls.Add(this.label8);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 20);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(1369, 119);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new System.Drawing.Point(4, 0);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(848, 119);
			this.label8.TabIndex = 0;
			this.label8.Text = resources.GetString("label8.Text");
			// 
			// panel_IndexSettings
			// 
			this.panel_IndexSettings.AutoScroll = true;
			this.panel_IndexSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_IndexSettings.Location = new System.Drawing.Point(0, 65);
			this.panel_IndexSettings.Margin = new System.Windows.Forms.Padding(0);
			this.panel_IndexSettings.Name = "panel_IndexSettings";
			this.panel_IndexSettings.Size = new System.Drawing.Size(1384, 507);
			this.panel_IndexSettings.TabIndex = 0;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.Controls.Add(this.label1);
			this.flowLayoutPanel3.Controls.Add(this.label20);
			this.flowLayoutPanel3.Controls.Add(this.label21);
			this.flowLayoutPanel3.Controls.Add(this.label26);
			this.flowLayoutPanel3.Controls.Add(this.label22);
			this.flowLayoutPanel3.Controls.Add(this.label23);
			this.flowLayoutPanel3.Controls.Add(this.label24);
			this.flowLayoutPanel3.Controls.Add(this.label25);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 43);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(1378, 19);
			this.flowLayoutPanel3.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label1.Location = new System.Drawing.Point(12, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 10, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Index";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label20.Location = new System.Drawing.Point(83, 0);
			this.label20.Margin = new System.Windows.Forms.Padding(20, 0, 172, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(45, 17);
			this.label20.TabIndex = 1;
			this.label20.Text = "Name";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label21.Location = new System.Drawing.Point(303, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(43, 17);
			this.label21.TabIndex = 2;
			this.label21.Text = "Digits";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label26.Location = new System.Drawing.Point(350, 0);
			this.label26.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(35, 17);
			this.label26.TabIndex = 7;
			this.label26.Text = "Size";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label22.Location = new System.Drawing.Point(413, 0);
			this.label22.Margin = new System.Windows.Forms.Padding(25, 0, 3, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(41, 17);
			this.label22.TabIndex = 3;
			this.label22.Text = "Color";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label23.Location = new System.Drawing.Point(492, 0);
			this.label23.Margin = new System.Windows.Forms.Padding(35, 0, 3, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(146, 17);
			this.label23.TabIndex = 4;
			this.label23.Text = "Value 1 (raw - scaled)";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label24.Location = new System.Drawing.Point(730, 0);
			this.label24.Margin = new System.Windows.Forms.Padding(89, 0, 3, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(146, 17);
			this.label24.TabIndex = 5;
			this.label24.Text = "Value 2 (raw - scaled)";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label25.Location = new System.Drawing.Point(967, 0);
			this.label25.Margin = new System.Windows.Forms.Padding(88, 0, 3, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(42, 17);
			this.label25.TabIndex = 6;
			this.label25.Text = "Suffix";
			// 
			// tabPage5
			// 
			this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage5.Controls.Add(this.picGraph);
			this.tabPage5.Controls.Add(this.flp_joysticksetting_buttons);
			this.tabPage5.Controls.Add(this.flp_joysticksetting_axis);
			this.tabPage5.Controls.Add(this.grp_JoystickInstructions);
			this.tabPage5.Controls.Add(this.btn_joystick_instruction);
			this.tabPage5.Controls.Add(this.flowLayoutPanel5);
			this.tabPage5.Controls.Add(this.label17);
			this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPage5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(1392, 600);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Joystick Settings";
			// 
			// picGraph
			// 
			this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picGraph.Location = new System.Drawing.Point(1103, 40);
			this.picGraph.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
			this.picGraph.Name = "picGraph";
			this.picGraph.Size = new System.Drawing.Size(256, 256);
			this.picGraph.TabIndex = 24;
			this.picGraph.TabStop = false;
			// 
			// flp_joysticksetting_buttons
			// 
			this.flp_joysticksetting_buttons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flp_joysticksetting_buttons.AutoScroll = true;
			this.flp_joysticksetting_buttons.Location = new System.Drawing.Point(7, 316);
			this.flp_joysticksetting_buttons.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.flp_joysticksetting_buttons.Name = "flp_joysticksetting_buttons";
			this.flp_joysticksetting_buttons.Size = new System.Drawing.Size(1374, 245);
			this.flp_joysticksetting_buttons.TabIndex = 26;
			// 
			// flp_joysticksetting_axis
			// 
			this.flp_joysticksetting_axis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flp_joysticksetting_axis.AutoScroll = true;
			this.flp_joysticksetting_axis.Location = new System.Drawing.Point(8, 40);
			this.flp_joysticksetting_axis.Name = "flp_joysticksetting_axis";
			this.flp_joysticksetting_axis.Size = new System.Drawing.Size(1374, 225);
			this.flp_joysticksetting_axis.TabIndex = 25;
			// 
			// grp_JoystickInstructions
			// 
			this.grp_JoystickInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_JoystickInstructions.Controls.Add(this.pictureBox2);
			this.grp_JoystickInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grp_JoystickInstructions.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.grp_JoystickInstructions.Location = new System.Drawing.Point(8, 574);
			this.grp_JoystickInstructions.Name = "grp_JoystickInstructions";
			this.grp_JoystickInstructions.Size = new System.Drawing.Size(1240, 22);
			this.grp_JoystickInstructions.TabIndex = 20;
			this.grp_JoystickInstructions.TabStop = false;
			this.grp_JoystickInstructions.Text = "Instructions";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.Image = global::ROVInterface.Properties.Resources.joystickscale_dark_test;
			this.pictureBox2.Location = new System.Drawing.Point(492, 49);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(369, 357);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 19;
			this.pictureBox2.TabStop = false;
			// 
			// btn_joystick_instruction
			// 
			this.btn_joystick_instruction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_joystick_instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_joystick_instruction.Location = new System.Drawing.Point(1255, 564);
			this.btn_joystick_instruction.Margin = new System.Windows.Forms.Padding(4);
			this.btn_joystick_instruction.Name = "btn_joystick_instruction";
			this.btn_joystick_instruction.Size = new System.Drawing.Size(133, 32);
			this.btn_joystick_instruction.TabIndex = 23;
			this.btn_joystick_instruction.Text = "Instructions";
			this.btn_joystick_instruction.UseVisualStyleBackColor = true;
			this.btn_joystick_instruction.Click += new System.EventHandler(this.grp_JoystickInstructions_Enter);
			// 
			// flowLayoutPanel5
			// 
			this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel5.Controls.Add(this.label27);
			this.flowLayoutPanel5.Controls.Add(this.label38);
			this.flowLayoutPanel5.Controls.Add(this.label9);
			this.flowLayoutPanel5.Controls.Add(this.label10);
			this.flowLayoutPanel5.Controls.Add(this.label11);
			this.flowLayoutPanel5.Controls.Add(this.label12);
			this.flowLayoutPanel5.Controls.Add(this.label16);
			this.flowLayoutPanel5.Controls.Add(this.label14);
			this.flowLayoutPanel5.Controls.Add(this.label13);
			this.flowLayoutPanel5.Controls.Add(this.label15);
			this.flowLayoutPanel5.Controls.Add(this.label45);
			this.flowLayoutPanel5.Controls.Add(this.label18);
			this.flowLayoutPanel5.Location = new System.Drawing.Point(8, 15);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Size = new System.Drawing.Size(1374, 19);
			this.flowLayoutPanel5.TabIndex = 22;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label27.Location = new System.Drawing.Point(15, 0);
			this.label27.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(80, 17);
			this.label27.TabIndex = 18;
			this.label27.Text = "Index/descr";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label38.Location = new System.Drawing.Point(140, 0);
			this.label38.Margin = new System.Windows.Forms.Padding(42, 0, 0, 0);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(71, 17);
			this.label38.TabIndex = 19;
			this.label38.Text = "Command";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(251, 0);
			this.label9.Margin = new System.Windows.Forms.Padding(40, 0, 3, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(58, 17);
			this.label9.TabIndex = 3;
			this.label9.Text = "Joystick";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(327, 0);
			this.label10.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(33, 17);
			this.label10.TabIndex = 4;
			this.label10.Text = "Axis";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(473, 0);
			this.label11.Margin = new System.Windows.Forms.Padding(110, 0, 3, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 17);
			this.label11.TabIndex = 7;
			this.label11.Text = "Value in";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(585, 0);
			this.label12.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(61, 17);
			this.label12.TabIndex = 9;
			this.label12.Text = "Reverse";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(656, 0);
			this.label16.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(39, 17);
			this.label16.TabIndex = 13;
			this.label16.Text = "Expo";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(701, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(74, 17);
			this.label14.TabIndex = 11;
			this.label14.Text = "Deadband";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(781, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(46, 17);
			this.label13.TabIndex = 10;
			this.label13.Text = "Offset";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(850, 0);
			this.label15.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(33, 17);
			this.label15.TabIndex = 12;
			this.label15.Text = "Max";
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label45.Location = new System.Drawing.Point(916, 0);
			this.label45.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(36, 17);
			this.label45.TabIndex = 20;
			this.label45.Text = "Trim";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(1035, 0);
			this.label18.Margin = new System.Windows.Forms.Padding(80, 0, 3, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(68, 17);
			this.label18.TabIndex = 17;
			this.label18.Text = "Value out";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(1480, 18);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(202, 17);
			this.label17.TabIndex = 19;
			this.label17.Text = "Function parameters explained";
			// 
			// tabPage6
			// 
			this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage6.Controls.Add(this.panel1);
			this.tabPage6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.tabPage6.Location = new System.Drawing.Point(4, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(1392, 600);
			this.tabPage6.TabIndex = 6;
			this.tabPage6.Text = "General Settings";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtbox_graphicsloaded);
			this.panel1.Controls.Add(this.txtbox_dllimported);
			this.panel1.Controls.Add(this.btn_graphicsloaded);
			this.panel1.Controls.Add(this.btn_loaddll);
			this.panel1.Controls.Add(this.lab_GraphicsLoaded);
			this.panel1.Controls.Add(this.lab_DLLimported);
			this.panel1.Controls.Add(this.btn_LoadSettings);
			this.panel1.Controls.Add(this.btn_ExportSettings);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1392, 600);
			this.panel1.TabIndex = 2;
			// 
			// txtbox_graphicsloaded
			// 
			this.txtbox_graphicsloaded.Location = new System.Drawing.Point(13, 196);
			this.txtbox_graphicsloaded.Name = "txtbox_graphicsloaded";
			this.txtbox_graphicsloaded.Size = new System.Drawing.Size(250, 23);
			this.txtbox_graphicsloaded.TabIndex = 7;
			// 
			// txtbox_dllimported
			// 
			this.txtbox_dllimported.Location = new System.Drawing.Point(13, 126);
			this.txtbox_dllimported.Name = "txtbox_dllimported";
			this.txtbox_dllimported.Size = new System.Drawing.Size(250, 23);
			this.txtbox_dllimported.TabIndex = 6;
			// 
			// btn_graphicsloaded
			// 
			this.btn_graphicsloaded.Location = new System.Drawing.Point(269, 196);
			this.btn_graphicsloaded.Name = "btn_graphicsloaded";
			this.btn_graphicsloaded.Size = new System.Drawing.Size(75, 23);
			this.btn_graphicsloaded.TabIndex = 5;
			this.btn_graphicsloaded.Text = "load";
			this.btn_graphicsloaded.UseVisualStyleBackColor = true;
			// 
			// btn_loaddll
			// 
			this.btn_loaddll.Location = new System.Drawing.Point(269, 126);
			this.btn_loaddll.Name = "btn_loaddll";
			this.btn_loaddll.Size = new System.Drawing.Size(75, 23);
			this.btn_loaddll.TabIndex = 4;
			this.btn_loaddll.Text = "load";
			this.btn_loaddll.UseVisualStyleBackColor = true;
			this.btn_loaddll.Click += new System.EventHandler(this.btn_loaddll_Click);
			// 
			// lab_GraphicsLoaded
			// 
			this.lab_GraphicsLoaded.AutoSize = true;
			this.lab_GraphicsLoaded.Location = new System.Drawing.Point(10, 222);
			this.lab_GraphicsLoaded.Name = "lab_GraphicsLoaded";
			this.lab_GraphicsLoaded.Size = new System.Drawing.Size(171, 17);
			this.lab_GraphicsLoaded.TabIndex = 3;
			this.lab_GraphicsLoaded.Text = "Graphics loaded: <name>";
			// 
			// lab_DLLimported
			// 
			this.lab_DLLimported.AutoSize = true;
			this.lab_DLLimported.Location = new System.Drawing.Point(10, 152);
			this.lab_DLLimported.Name = "lab_DLLimported";
			this.lab_DLLimported.Size = new System.Drawing.Size(152, 17);
			this.lab_DLLimported.TabIndex = 2;
			this.lab_DLLimported.Text = "DLL imported: <name>";
			// 
			// btn_LoadSettings
			// 
			this.btn_LoadSettings.Location = new System.Drawing.Point(13, 13);
			this.btn_LoadSettings.Name = "btn_LoadSettings";
			this.btn_LoadSettings.Size = new System.Drawing.Size(147, 37);
			this.btn_LoadSettings.TabIndex = 1;
			this.btn_LoadSettings.Text = "Load Settings";
			this.btn_LoadSettings.UseVisualStyleBackColor = true;
			this.btn_LoadSettings.Click += new System.EventHandler(this.btn_LoadSettings_Click);
			// 
			// btn_ExportSettings
			// 
			this.btn_ExportSettings.Location = new System.Drawing.Point(13, 56);
			this.btn_ExportSettings.Name = "btn_ExportSettings";
			this.btn_ExportSettings.Size = new System.Drawing.Size(147, 37);
			this.btn_ExportSettings.TabIndex = 0;
			this.btn_ExportSettings.Text = "Export Settings";
			this.btn_ExportSettings.UseVisualStyleBackColor = true;
			// 
			// tim_10ms_update
			// 
			this.tim_10ms_update.Enabled = true;
			this.tim_10ms_update.Interval = 10;
			this.tim_10ms_update.Tick += new System.EventHandler(this.tim_10ms_update_Tick);
			// 
			// panel_IndexStats
			// 
			this.panel_IndexStats.AutoScroll = true;
			this.panel_IndexStats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_IndexStats.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel_IndexStats.Location = new System.Drawing.Point(164, 0);
			this.panel_IndexStats.Margin = new System.Windows.Forms.Padding(0);
			this.panel_IndexStats.Name = "panel_IndexStats";
			this.panel_IndexStats.Size = new System.Drawing.Size(1228, 161);
			this.panel_IndexStats.TabIndex = 2;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btn_EditMode);
			this.flowLayoutPanel1.Controls.Add(this.btn_AddIndexStat);
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.flowLayoutPanel1.Controls.Add(this.nud_puls_on);
			this.flowLayoutPanel1.Controls.Add(this.nud_puls_off);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 153);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btn_EditMode
			// 
			this.btn_EditMode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_EditMode.Location = new System.Drawing.Point(4, 4);
			this.btn_EditMode.Margin = new System.Windows.Forms.Padding(4);
			this.btn_EditMode.Name = "btn_EditMode";
			this.btn_EditMode.Size = new System.Drawing.Size(147, 27);
			this.btn_EditMode.TabIndex = 0;
			this.btn_EditMode.Text = "Display Mode";
			this.btn_EditMode.UseVisualStyleBackColor = true;
			this.btn_EditMode.Click += new System.EventHandler(this.btn_EditMode_Click);
			// 
			// btn_AddIndexStat
			// 
			this.btn_AddIndexStat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_AddIndexStat.Location = new System.Drawing.Point(4, 39);
			this.btn_AddIndexStat.Margin = new System.Windows.Forms.Padding(4);
			this.btn_AddIndexStat.Name = "btn_AddIndexStat";
			this.btn_AddIndexStat.Size = new System.Drawing.Size(147, 23);
			this.btn_AddIndexStat.TabIndex = 1;
			this.btn_AddIndexStat.Text = "New";
			this.btn_AddIndexStat.UseVisualStyleBackColor = true;
			this.btn_AddIndexStat.Click += new System.EventHandler(this.btn_AddIndexStat_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 69);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Pulse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// nud_puls_on
			// 
			this.nud_puls_on.Location = new System.Drawing.Point(3, 98);
			this.nud_puls_on.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_puls_on.Name = "nud_puls_on";
			this.nud_puls_on.Size = new System.Drawing.Size(75, 23);
			this.nud_puls_on.TabIndex = 3;
			this.nud_puls_on.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_puls_on.ValueChanged += new System.EventHandler(this.nud_puls_interval_ValueChanged);
			// 
			// nud_puls_off
			// 
			this.nud_puls_off.Location = new System.Drawing.Point(3, 127);
			this.nud_puls_off.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_puls_off.Name = "nud_puls_off";
			this.nud_puls_off.Size = new System.Drawing.Size(75, 23);
			this.nud_puls_off.TabIndex = 4;
			this.nud_puls_off.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.tableLayoutPanel3);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox4.Location = new System.Drawing.Point(12, 647);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox4.Size = new System.Drawing.Size(1400, 185);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Index Stats";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.panel_IndexStats, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 20);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(1392, 161);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// tim_heartBeat
			// 
			this.tim_heartBeat.Interval = 1000;
			this.tim_heartBeat.Tick += new System.EventHandler(this.tim_heartBeat_Tick);
			// 
			// txt_error
			// 
			this.txt_error.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_error.BackColor = System.Drawing.SystemColors.ControlLight;
			this.txt_error.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_error.Location = new System.Drawing.Point(1, 837);
			this.txt_error.Margin = new System.Windows.Forms.Padding(0);
			this.txt_error.Name = "txt_error";
			this.txt_error.Size = new System.Drawing.Size(1422, 23);
			this.txt_error.TabIndex = 1;
			// 
			// tim_100ms_update
			// 
			this.tim_100ms_update.Enabled = true;
			this.tim_100ms_update.Tick += new System.EventHandler(this.tim_100ms_update_Tick);
			// 
			// tim_SendCommandsDelay
			// 
			this.tim_SendCommandsDelay.Tick += new System.EventHandler(this.tim_SendCommandsDelay_Tick);
			// 
			// bgw_ethernetMessageRecieveHandler
			// 
			this.bgw_ethernetMessageRecieveHandler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_ethernetMessageRecieveHandler_DoWork);
			// 
			// bgw_ethernetMessageSendHandler
			// 
			this.bgw_ethernetMessageSendHandler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_ethernetMessageSendHandler_DoWork);
			// 
			// bgw_aegirMessageRequest
			// 
			this.bgw_aegirMessageRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_aegirMessageRequest_DoWork);
			// 
			// rightclickMenu
			// 
			this.rightclickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_MenuReposition,
            this.btn_MenuSettings,
            this.toolStripSeparator1,
            this.btn_MenuDeleteControl});
			this.rightclickMenu.Name = "rightclickMenu";
			this.rightclickMenu.Size = new System.Drawing.Size(151, 76);
			// 
			// btn_MenuReposition
			// 
			this.btn_MenuReposition.Name = "btn_MenuReposition";
			this.btn_MenuReposition.Size = new System.Drawing.Size(150, 22);
			this.btn_MenuReposition.Text = "Reposition";
			// 
			// btn_MenuSettings
			// 
			this.btn_MenuSettings.Name = "btn_MenuSettings";
			this.btn_MenuSettings.Size = new System.Drawing.Size(150, 22);
			this.btn_MenuSettings.Text = "Settings";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
			// 
			// btn_MenuDeleteControl
			// 
			this.btn_MenuDeleteControl.Name = "btn_MenuDeleteControl";
			this.btn_MenuDeleteControl.Size = new System.Drawing.Size(150, 22);
			this.btn_MenuDeleteControl.Text = "Delete Control";
			// 
			// AegirMessageRequest
			// 
			this.AegirMessageRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AegirMessageRequest_DoWork);
			// 
			// tim_puls
			// 
			this.tim_puls.Tick += new System.EventHandler(this.tim_puls_Tick);
			// 
			// WindowStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(1424, 861);
			this.Controls.Add(this.txt_error);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.connectionTab);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "WindowStatus";
			this.Text = "Status";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.WindowStatus_Load);
			this.connectionTab.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_rolldiv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_pitchdiv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_rollindex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_heading_index)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_attitude_pitchindex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_depth_index)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_navigation_height_index)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.pan_graphicsCreator.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_gyro_calibration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_man_depth_SP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_zerodepth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_rot_p)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_rot_i)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_rot_d)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_trans_p)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_trans_i)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_trans_d)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_aegir_lightdim)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_comm_transfreq)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_con_serial_value)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_con_serial_index)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tbl_IndexSettings.ResumeLayout(false);
			this.tbl_IndexSettings.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.grp_IndexInstructions.ResumeLayout(false);
			this.grp_IndexInstructions.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
			this.grp_JoystickInstructions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowLayoutPanel5.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nud_puls_on)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_puls_off)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.rightclickMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmb_comport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_baudrate;
        private System.Windows.Forms.Button btn_comm_serialConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_comm_serialSend;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Timer tim_10ms_update;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.FlowLayoutPanel panel_IndexStats;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button btn_EditMode;
		private System.Windows.Forms.Button btn_AddIndexStat;
		public System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ProgressBar pbr_heartBeat;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Timer tim_heartBeat;
		private System.Windows.Forms.TextBox txt_error;
		private System.Windows.Forms.Label lbl_heartBeat_ms;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
	public System.Windows.Forms.TextBox txt_con_messageSendt;
	public System.Windows.Forms.TextBox txt_con_messageRecieved;
	public System.Windows.Forms.TabControl connectionTab;
	public System.Windows.Forms.GroupBox groupBox3;
	public System.Windows.Forms.ColorDialog colorDialog1;
	private System.Windows.Forms.TableLayoutPanel tbl_IndexSettings;
	private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
	private System.Windows.Forms.Button btn_InsertIndexSetting;
	private System.Windows.Forms.Button btn_Instructions;
	private System.Windows.Forms.GroupBox grp_IndexInstructions;
	private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.FlowLayoutPanel panel_IndexSettings;
	private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label20;
	private System.Windows.Forms.Label label21;
	private System.Windows.Forms.Label label26;
	private System.Windows.Forms.Label label22;
	private System.Windows.Forms.Label label23;
	private System.Windows.Forms.Label label24;
	private System.Windows.Forms.Label label25;
	private System.Windows.Forms.Button btn_startTransmission;
	private System.Windows.Forms.Timer tim_100ms_update;
	private System.Windows.Forms.GroupBox grp_JoystickInstructions;
	private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
	private System.Windows.Forms.Label label27;
	public System.Windows.Forms.Timer tim_SendCommandsDelay;
	private System.Windows.Forms.Label label28;
	private System.Windows.Forms.RadioButton rdb_comm_status_bytes;
	private System.Windows.Forms.RadioButton rdb_comm_status_hex;
	private System.Windows.Forms.RadioButton rdb_comm_status_dec;
	private System.Windows.Forms.NumericUpDown nud_con_serial_index;
	private System.Windows.Forms.NumericUpDown nud_con_serial_value;
	private System.Windows.Forms.Panel pan_graphicsCreator;
	private System.Windows.Forms.Button btn_joystick_instruction;
	private System.Windows.Forms.PictureBox pictureBox2;
	private System.Windows.Forms.GroupBox groupBox5;
	public System.Windows.Forms.TextBox txt_comm_clientip;
	private System.Windows.Forms.Label label29;
	private System.Windows.Forms.Button btn_comm_ethernetConnect;
	private System.Windows.Forms.GroupBox groupBox9;
	public System.Windows.Forms.TextBox txt_comm_serverport;
	private System.Windows.Forms.Label label31;
	public System.Windows.Forms.TextBox txt_comm_serverip;
	private System.Windows.Forms.Label label32;
	private System.Windows.Forms.Button btn_comm_startserver;
	public System.Windows.Forms.TextBox txt_comm_clientport;
	private System.Windows.Forms.Label label30;
	private System.Windows.Forms.Button btn_comm_sendethernetmessage;
	public System.Windows.Forms.TextBox txt_comm_ethernetmessage;
	private System.Windows.Forms.ListBox lbx_comm_messages;
	private System.ComponentModel.BackgroundWorker bgw_ethernetMessageRecieveHandler;
	private System.ComponentModel.BackgroundWorker bgw_ethernetMessageSendHandler;
	private System.Windows.Forms.Label label35;
	private System.Windows.Forms.Button btn_comm_CANsend;
	private System.Windows.Forms.GroupBox groupBox10;
	public System.Windows.Forms.TextBox txt_comm_CANport;
	private System.Windows.Forms.Label label33;
	public System.Windows.Forms.TextBox txt_comm_CANip;
	private System.Windows.Forms.Label label34;
	private System.Windows.Forms.Button btn_comm_CANconnect;
	public System.Windows.Forms.TextBox txt_comm_CANmessage;
	private System.Windows.Forms.Label label36;
	public System.Windows.Forms.TextBox txt_comm_CANreply;
	private System.Windows.Forms.GroupBox groupBox11;
	private System.Windows.Forms.NumericUpDown nud_aegir_lightdim;
	private System.Windows.Forms.Button btn_aegir_light;
	private System.Windows.Forms.Label label37;
	private System.Windows.Forms.Button btn_aegir_coolingfan;
	private System.Windows.Forms.Button btn_aegir_armmotors;
	private System.ComponentModel.BackgroundWorker bgw_aegirMessageRequest;
	private System.Windows.Forms.Button btn_aegir_RegAuto;
	private System.Windows.Forms.GroupBox groupBox12;
	private System.Windows.Forms.FlowLayoutPanel pan_graphicToolbox;
	private System.Windows.Forms.ContextMenuStrip rightclickMenu;
	private System.Windows.Forms.ToolStripMenuItem btn_MenuReposition;
	private System.Windows.Forms.ToolStripMenuItem btn_MenuSettings;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	private System.Windows.Forms.ToolStripMenuItem btn_MenuDeleteControl;
	private System.Windows.Forms.TabPage tabPage1;
	private Avionics.VerticalSpeedIndicatorInstrumentControl verticalSpeedIndicatorInstrumentControl1;
	private Avionics.HeadingIndicatorInstrumentControl hdi_navigation_heading_instrument;
	private Avionics.AttitudeIndicatorInstrumentControl aii_navigation_attitude_instrument;
	private Avionics.AltimeterInstrumentControl ali_navigation_height_instrument;
	private Avionics.AltimeterInstrumentControl ali_navigation_depth_instrument;
	private Avionics.AirSpeedIndicatorInstrumentControl airSpeedIndicatorInstrumentControl1;
	private System.Windows.Forms.NumericUpDown nud_navigation_attitude_rollindex;
	private System.Windows.Forms.NumericUpDown nud_navigation_heading_index;
	private System.Windows.Forms.NumericUpDown nud_navigation_attitude_pitchindex;
	private System.Windows.Forms.NumericUpDown nud_navigation_depth_index;
	private System.Windows.Forms.NumericUpDown nud_navigation_height_index;
	private System.Windows.Forms.TextBox textBox4;
	private System.Windows.Forms.TextBox textBox3;
	private System.Windows.Forms.TextBox textBox2;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.TabPage tabPage6;
	private AGaugeApp.AGauge aGauge1;
	private AGaugeApp.AGauge aGauge2;
	private System.Windows.Forms.NumericUpDown nud_navigation_attitude_rolldiv;
	private System.Windows.Forms.NumericUpDown nud_navigation_attitude_pitchdiv;
	private System.Windows.Forms.PictureBox picGraph;
	private System.Windows.Forms.Label label38;
    public System.Windows.Forms.NumericUpDown nud_comm_transfreq;
    private System.Windows.Forms.Button btn_ExportSettings;
    private System.Windows.Forms.Button btn_LoadSettings;
	private System.ComponentModel.BackgroundWorker AegirMessageRequest;
	private System.Windows.Forms.NumericUpDown nud_aegir_rot_p;
	private System.Windows.Forms.NumericUpDown nud_aegir_rot_i;
	private System.Windows.Forms.NumericUpDown nud_aegir_rot_d;
	private System.Windows.Forms.NumericUpDown nud_aegir_trans_p;
	private System.Windows.Forms.NumericUpDown nud_aegir_trans_i;
	private System.Windows.Forms.NumericUpDown nud_aegir_trans_d;
	private System.Windows.Forms.Label label44;
	private System.Windows.Forms.NumericUpDown nud_aegir_zerodepth;
	private System.Windows.Forms.Label label43;
	private System.Windows.Forms.Label label42;
	private System.Windows.Forms.Label label41;
	private System.Windows.Forms.Label label40;
	private System.Windows.Forms.Label label39;
	private System.Windows.Forms.Timer tim_puls;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.NumericUpDown nud_puls_on;
	private System.Windows.Forms.NumericUpDown nud_puls_off;
	private System.Windows.Forms.Label label45;
	public System.Windows.Forms.FlowLayoutPanel flp_joysticksetting_axis;
	public System.Windows.Forms.FlowLayoutPanel flp_joysticksetting_buttons;
	private System.Windows.Forms.Panel panel1;
	private System.Windows.Forms.Button btn_graphicsloaded;
	private System.Windows.Forms.Button btn_loaddll;
	public System.Windows.Forms.Label lab_GraphicsLoaded;
	public System.Windows.Forms.Label lab_DLLimported;
	public System.Windows.Forms.TextBox txtbox_graphicsloaded;
	public System.Windows.Forms.TextBox txtbox_dllimported;
	private System.Windows.Forms.Label label46;
	private System.Windows.Forms.NumericUpDown nud_aegir_man_depth_SP;
	private System.Windows.Forms.Label label47;
	private System.Windows.Forms.NumericUpDown nud_aegir_gyro_calibration;
}
