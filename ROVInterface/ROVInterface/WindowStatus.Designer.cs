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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmb_baudrate = new System.Windows.Forms.ComboBox();
			this.cmb_comport = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_connect_serial = new System.Windows.Forms.Button();
			this.btn_send_serial = new System.Windows.Forms.Button();
			this.txt_serial_index = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_serial_value = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.ItemSize = new System.Drawing.Size(72, 21);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1878, 752);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1870, 723);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1870, 723);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.tabPage3.Controls.Add(this.tableLayoutPanel1);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1870, 723);
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
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 595F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1858, 711);
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
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(625, 705);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label3.Location = new System.Drawing.Point(160, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Baud rate";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label2.Location = new System.Drawing.Point(19, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// cmb_baudrate
			// 
			this.cmb_baudrate.FormattingEnabled = true;
			this.cmb_baudrate.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cmb_baudrate.Location = new System.Drawing.Point(163, 56);
			this.cmb_baudrate.Name = "cmb_baudrate";
			this.cmb_baudrate.Size = new System.Drawing.Size(121, 24);
			this.cmb_baudrate.TabIndex = 2;
			this.cmb_baudrate.Text = "Baud rate";
			// 
			// cmb_comport
			// 
			this.cmb_comport.FormattingEnabled = true;
			this.cmb_comport.Location = new System.Drawing.Point(22, 56);
			this.cmb_comport.Name = "cmb_comport";
			this.cmb_comport.Size = new System.Drawing.Size(121, 24);
			this.cmb_comport.TabIndex = 0;
			this.cmb_comport.Text = "COM port";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(329, 46);
			this.label1.TabIndex = 1;
			this.label1.Text = "Serial connection";
			// 
			// btn_connect_serial
			// 
			this.btn_connect_serial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_connect_serial.Location = new System.Drawing.Point(458, 56);
			this.btn_connect_serial.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
			this.btn_connect_serial.Name = "btn_connect_serial";
			this.btn_connect_serial.Size = new System.Drawing.Size(121, 56);
			this.btn_connect_serial.TabIndex = 5;
			this.btn_connect_serial.Text = "Connect";
			this.btn_connect_serial.UseVisualStyleBackColor = true;
			this.btn_connect_serial.Click += new System.EventHandler(this.btn_connect_serial_Click);
			// 
			// btn_send_serial
			// 
			this.btn_send_serial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_send_serial.Location = new System.Drawing.Point(458, 51);
			this.btn_send_serial.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
			this.btn_send_serial.Name = "btn_send_serial";
			this.btn_send_serial.Size = new System.Drawing.Size(121, 42);
			this.btn_send_serial.TabIndex = 6;
			this.btn_send_serial.Text = "Send";
			this.btn_send_serial.UseVisualStyleBackColor = true;
			// 
			// txt_serial_index
			// 
			this.txt_serial_index.Location = new System.Drawing.Point(22, 51);
			this.txt_serial_index.Name = "txt_serial_index";
			this.txt_serial_index.Size = new System.Drawing.Size(116, 22);
			this.txt_serial_index.TabIndex = 9;
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Location = new System.Drawing.Point(0, 931);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1902, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txt_serial_value);
			this.groupBox1.Controls.Add(this.btn_send_serial);
			this.groupBox1.Controls.Add(this.txt_serial_index);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox1.Location = new System.Drawing.Point(11, 308);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(594, 235);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Advanced";
			// 
			// txt_serial_value
			// 
			this.txt_serial_value.Location = new System.Drawing.Point(163, 51);
			this.txt_serial_value.Name = "txt_serial_value";
			this.txt_serial_value.Size = new System.Drawing.Size(116, 22);
			this.txt_serial_value.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label4.Location = new System.Drawing.Point(19, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "Index";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label5.Location = new System.Drawing.Point(160, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "Value";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cmb_comport);
			this.groupBox2.Controls.Add(this.btn_connect_serial);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cmb_baudrate);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox2.Location = new System.Drawing.Point(11, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(594, 218);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Connection";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox3.Location = new System.Drawing.Point(11, 549);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(594, 153);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Status";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label6.Location = new System.Drawing.Point(19, 77);
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
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 97);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(257, 22);
			this.textBox1.TabIndex = 14;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(22, 52);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(257, 22);
			this.textBox2.TabIndex = 13;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// WindowStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(1902, 953);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tabControl1);
			this.Name = "WindowStatus";
			this.Text = "Status";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.WindowStatus_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

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
        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Timer timer1;
	}
}