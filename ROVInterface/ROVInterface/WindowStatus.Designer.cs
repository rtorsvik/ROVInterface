namespace ROVInterface
{
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmb_comport = new System.Windows.Forms.ComboBox();
			this.btn_connect_serial = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmb_baudrate = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_serial_value = new System.Windows.Forms.TextBox();
			this.btn_send_serial = new System.Windows.Forms.Button();
			this.txt_serial_index = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.panel_IndexSettings = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_InsertIndexSetting = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel_IndexStats = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.btn_AddIndexStat = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.panel_IndexSettings.SuspendLayout();
			this.panel_IndexStats.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.ItemSize = new System.Drawing.Size(72, 21);
			this.tabControl1.Location = new System.Drawing.Point(9, 10);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1408, 611);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage1.Size = new System.Drawing.Size(1400, 582);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(1400, 582);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage3.Controls.Add(this.tableLayoutPanel1);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage3.Size = new System.Drawing.Size(1400, 582);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Connection";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 448F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 5);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1394, 578);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(469, 574);
			this.panel1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox3.Location = new System.Drawing.Point(8, 446);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(446, 124);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Status";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label6.Location = new System.Drawing.Point(14, 63);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(94, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Message recieved";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label7.Location = new System.Drawing.Point(14, 26);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Message sendt";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(16, 42);
			this.textBox2.Margin = new System.Windows.Forms.Padding(2);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(194, 20);
			this.textBox2.TabIndex = 13;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 79);
			this.textBox1.Margin = new System.Windows.Forms.Padding(2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(194, 20);
			this.textBox1.TabIndex = 14;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cmb_comport);
			this.groupBox2.Controls.Add(this.btn_connect_serial);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cmb_baudrate);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox2.Location = new System.Drawing.Point(8, 68);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(446, 177);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Connection";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label2.Location = new System.Drawing.Point(14, 29);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// cmb_comport
			// 
			this.cmb_comport.FormattingEnabled = true;
			this.cmb_comport.Location = new System.Drawing.Point(16, 46);
			this.cmb_comport.Margin = new System.Windows.Forms.Padding(2);
			this.cmb_comport.Name = "cmb_comport";
			this.cmb_comport.Size = new System.Drawing.Size(92, 21);
			this.cmb_comport.TabIndex = 0;
			this.cmb_comport.Text = "COM port";
			// 
			// btn_connect_serial
			// 
			this.btn_connect_serial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_connect_serial.Location = new System.Drawing.Point(344, 46);
			this.btn_connect_serial.Margin = new System.Windows.Forms.Padding(2, 2, 9, 2);
			this.btn_connect_serial.Name = "btn_connect_serial";
			this.btn_connect_serial.Size = new System.Drawing.Size(91, 46);
			this.btn_connect_serial.TabIndex = 5;
			this.btn_connect_serial.Text = "Connect";
			this.btn_connect_serial.UseVisualStyleBackColor = true;
			this.btn_connect_serial.Click += new System.EventHandler(this.btn_connect_serial_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label3.Location = new System.Drawing.Point(120, 29);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Baud rate";
			// 
			// cmb_baudrate
			// 
			this.cmb_baudrate.FormattingEnabled = true;
			this.cmb_baudrate.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cmb_baudrate.Location = new System.Drawing.Point(122, 46);
			this.cmb_baudrate.Margin = new System.Windows.Forms.Padding(2);
			this.cmb_baudrate.Name = "cmb_baudrate";
			this.cmb_baudrate.Size = new System.Drawing.Size(92, 21);
			this.cmb_baudrate.TabIndex = 2;
			this.cmb_baudrate.Text = "Baud rate";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txt_serial_value);
			this.groupBox1.Controls.Add(this.btn_send_serial);
			this.groupBox1.Controls.Add(this.txt_serial_index);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox1.Location = new System.Drawing.Point(8, 250);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(446, 191);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Advanced";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label5.Location = new System.Drawing.Point(120, 25);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Value";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label4.Location = new System.Drawing.Point(14, 25);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Index";
			// 
			// txt_serial_value
			// 
			this.txt_serial_value.Location = new System.Drawing.Point(122, 41);
			this.txt_serial_value.Margin = new System.Windows.Forms.Padding(2);
			this.txt_serial_value.Name = "txt_serial_value";
			this.txt_serial_value.Size = new System.Drawing.Size(88, 20);
			this.txt_serial_value.TabIndex = 10;
			// 
			// btn_send_serial
			// 
			this.btn_send_serial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_send_serial.Location = new System.Drawing.Point(344, 41);
			this.btn_send_serial.Margin = new System.Windows.Forms.Padding(2, 2, 9, 2);
			this.btn_send_serial.Name = "btn_send_serial";
			this.btn_send_serial.Size = new System.Drawing.Size(91, 34);
			this.btn_send_serial.TabIndex = 6;
			this.btn_send_serial.Text = "Send";
			this.btn_send_serial.UseVisualStyleBackColor = true;
			// 
			// txt_serial_index
			// 
			this.txt_serial_index.Location = new System.Drawing.Point(16, 41);
			this.txt_serial_index.Margin = new System.Windows.Forms.Padding(2);
			this.txt_serial_index.Name = "txt_serial_index";
			this.txt_serial_index.Size = new System.Drawing.Size(88, 20);
			this.txt_serial_index.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(262, 37);
			this.label1.TabIndex = 1;
			this.label1.Text = "Serial connection";
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage4.Controls.Add(this.panel_IndexSettings);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1400, 582);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Index Settings";
			// 
			// panel_IndexSettings
			// 
			this.panel_IndexSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_IndexSettings.AutoScroll = true;
			this.panel_IndexSettings.Controls.Add(this.btn_InsertIndexSetting);
			this.panel_IndexSettings.Controls.Add(this.comboBox1);
			this.panel_IndexSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.panel_IndexSettings.Location = new System.Drawing.Point(6, 6);
			this.panel_IndexSettings.Name = "panel_IndexSettings";
			this.panel_IndexSettings.Size = new System.Drawing.Size(1388, 570);
			this.panel_IndexSettings.TabIndex = 0;
			// 
			// btn_InsertIndexSetting
			// 
			this.btn_InsertIndexSetting.Location = new System.Drawing.Point(3, 3);
			this.btn_InsertIndexSetting.Name = "btn_InsertIndexSetting";
			this.btn_InsertIndexSetting.Size = new System.Drawing.Size(75, 23);
			this.btn_InsertIndexSetting.TabIndex = 0;
			this.btn_InsertIndexSetting.Text = "button1";
			this.btn_InsertIndexSetting.UseVisualStyleBackColor = true;
			this.btn_InsertIndexSetting.Click += new System.EventHandler(this.btn_InsertIndexSetting_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel_IndexStats
			// 
			this.panel_IndexStats.Controls.Add(this.flowLayoutPanel1);
			this.panel_IndexStats.Location = new System.Drawing.Point(13, 626);
			this.panel_IndexStats.Name = "panel_IndexStats";
			this.panel_IndexStats.Size = new System.Drawing.Size(1398, 136);
			this.panel_IndexStats.TabIndex = 2;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.flowLayoutPanel1.Controls.Add(this.btn_AddIndexStat);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1391, 28);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Edit Mode";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btn_AddIndexStat
			// 
			this.btn_AddIndexStat.Location = new System.Drawing.Point(84, 3);
			this.btn_AddIndexStat.Name = "btn_AddIndexStat";
			this.btn_AddIndexStat.Size = new System.Drawing.Size(75, 23);
			this.btn_AddIndexStat.TabIndex = 1;
			this.btn_AddIndexStat.Text = "New";
			this.btn_AddIndexStat.UseVisualStyleBackColor = true;
			this.btn_AddIndexStat.Click += new System.EventHandler(this.btn_AddIndexStat_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(3, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// WindowStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(1426, 774);
			this.Controls.Add(this.panel_IndexStats);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "WindowStatus";
			this.Text = "Status";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.WindowStatus_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.panel_IndexSettings.ResumeLayout(false);
			this.panel_IndexStats.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_comport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_baudrate;
        private System.Windows.Forms.Button btn_connect_serial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_serial_value;
        private System.Windows.Forms.Button btn_send_serial;
        private System.Windows.Forms.TextBox txt_serial_index;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.FlowLayoutPanel panel_IndexSettings;
		private System.Windows.Forms.Button btn_InsertIndexSetting;
		private System.Windows.Forms.FlowLayoutPanel panel_IndexStats;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btn_AddIndexStat;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}