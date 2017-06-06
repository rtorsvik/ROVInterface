partial class FormSerialConnection {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_Connect = new System.Windows.Forms.Button();
			this.cmb_baudRate = new System.Windows.Forms.ComboBox();
			this.cmb_port = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btn_send = new System.Windows.Forms.Button();
			this.cmb_endline = new System.Windows.Forms.ComboBox();
			this.txt_message = new System.Windows.Forms.TextBox();
			this.btn_clear = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txt_output = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.chb_autoScroll = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Port";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Baud rate";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_Connect);
			this.groupBox1.Controls.Add(this.cmb_baudRate);
			this.groupBox1.Controls.Add(this.cmb_port);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(355, 103);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection";
			// 
			// btn_Connect
			// 
			this.btn_Connect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Connect.Location = new System.Drawing.Point(228, 33);
			this.btn_Connect.Name = "btn_Connect";
			this.btn_Connect.Size = new System.Drawing.Size(111, 54);
			this.btn_Connect.TabIndex = 4;
			this.btn_Connect.Text = "Connect";
			this.btn_Connect.UseVisualStyleBackColor = true;
			this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
			// 
			// cmb_baudRate
			// 
			this.cmb_baudRate.FormattingEnabled = true;
			this.cmb_baudRate.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cmb_baudRate.Location = new System.Drawing.Point(96, 63);
			this.cmb_baudRate.Name = "cmb_baudRate";
			this.cmb_baudRate.Size = new System.Drawing.Size(82, 24);
			this.cmb_baudRate.TabIndex = 3;
			this.cmb_baudRate.Text = "9600";
			// 
			// cmb_port
			// 
			this.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_port.FormattingEnabled = true;
			this.cmb_port.Location = new System.Drawing.Point(96, 33);
			this.cmb_port.Name = "cmb_port";
			this.cmb_port.Size = new System.Drawing.Size(82, 24);
			this.cmb_port.TabIndex = 2;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.groupBox2.Location = new System.Drawing.Point(3, 113);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(355, 222);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 200);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
			this.tableLayoutPanel2.Controls.Add(this.btn_send, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.cmb_endline, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.txt_message, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(349, 31);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// btn_send
			// 
			this.btn_send.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_send.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_send.Location = new System.Drawing.Point(275, 3);
			this.btn_send.Name = "btn_send";
			this.btn_send.Size = new System.Drawing.Size(71, 25);
			this.btn_send.TabIndex = 3;
			this.btn_send.Text = "Send";
			this.btn_send.UseVisualStyleBackColor = true;
			this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
			// 
			// cmb_endline
			// 
			this.cmb_endline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_endline.FormattingEnabled = true;
			this.cmb_endline.Items.AddRange(new object[] {
            "no end",
            "\\r",
            "\\n",
            "\\r\\n"});
			this.cmb_endline.Location = new System.Drawing.Point(198, 3);
			this.cmb_endline.Name = "cmb_endline";
			this.cmb_endline.Size = new System.Drawing.Size(71, 24);
			this.cmb_endline.TabIndex = 2;
			// 
			// txt_message
			// 
			this.txt_message.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txt_message.Location = new System.Drawing.Point(3, 3);
			this.txt_message.Name = "txt_message";
			this.txt_message.Size = new System.Drawing.Size(189, 23);
			this.txt_message.TabIndex = 1;
			this.txt_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_message_KeyDown);
			// 
			// btn_clear
			// 
			this.btn_clear.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_clear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_clear.Location = new System.Drawing.Point(3, 3);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(71, 25);
			this.btn_clear.TabIndex = 4;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.txt_output);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(343, 132);
			this.panel1.TabIndex = 1;
			// 
			// txt_output
			// 
			this.txt_output.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txt_output.Location = new System.Drawing.Point(0, 0);
			this.txt_output.Multiline = true;
			this.txt_output.Name = "txt_output";
			this.txt_output.ReadOnly = true;
			this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txt_output.Size = new System.Drawing.Size(343, 132);
			this.txt_output.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(361, 338);
			this.tableLayoutPanel3.TabIndex = 4;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.btn_clear, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.chb_autoScroll, 1, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 169);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(349, 31);
			this.tableLayoutPanel4.TabIndex = 2;
			// 
			// chb_autoScroll
			// 
			this.chb_autoScroll.AutoSize = true;
			this.chb_autoScroll.Checked = true;
			this.chb_autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chb_autoScroll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chb_autoScroll.Location = new System.Drawing.Point(80, 3);
			this.chb_autoScroll.Name = "chb_autoScroll";
			this.chb_autoScroll.Size = new System.Drawing.Size(266, 25);
			this.chb_autoScroll.TabIndex = 5;
			this.chb_autoScroll.Text = "Auto Scroll";
			this.chb_autoScroll.UseVisualStyleBackColor = true;
			// 
			// FormSerialConnection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(361, 338);
			this.Controls.Add(this.tableLayoutPanel3);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(377, 377);
			this.Name = "FormSerialConnection";
			this.ShowInTaskbar = false;
			this.Text = "Serial Connection";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.ComboBox cmb_baudRate;
	private System.Windows.Forms.ComboBox cmb_port;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.Button btn_Connect;
	private System.Windows.Forms.Button btn_send;
	private System.Windows.Forms.ComboBox cmb_endline;
	private System.Windows.Forms.TextBox txt_message;
	private System.Windows.Forms.TextBox txt_output;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	private System.Windows.Forms.Panel panel1;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
	private System.Windows.Forms.Button btn_clear;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
	private System.Windows.Forms.CheckBox chb_autoScroll;
}