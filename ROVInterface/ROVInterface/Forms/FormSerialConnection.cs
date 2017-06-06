using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class FormSerialConnection : Form {
	public FormSerialConnection() {
		InitializeComponent();

		//add all available com port elements to com port combobox
		cmb_port.Items.AddRange(SerialConnection.GetPortList());
		try { cmb_port.SelectedIndex = 1; } catch { }   //load index 1 as default

		cmb_endline.SelectedIndex = 0;
		btn_Connect.BackColor = colorClosed;

		timerbuffer = new Timer();
		timerbuffer.Tick += Timerbuffer_Tick;
		timerbuffer.Interval = 100;
	}

	private void Timerbuffer_Tick(object sender, EventArgs e)
	{
		if (havebuffer)
		{
			if (chb_autoScroll.Checked)
				txt_output.AppendText(buffer);
			else
			{
				int i = txt_output.SelectionStart;
				txt_output.Text += buffer;
				txt_output.SelectionStart = i;
				txt_output.ScrollToCaret();
			}

			buffer = "";
			havebuffer = false;
		}
	}

	private SerialConnection port;

	private Color colorOpen = Color.Green;
	private Color colorClosed = Color.White;

	private Timer timerbuffer;
	private bool havebuffer = false;
	private string buffer = "";

	// Connect to the serial port
	private void btn_Connect_Click(object sender, EventArgs e) {
		if (port == null) {
			// Port is closed
			
			int baudrate = -1;
			try {
				baudrate = int.Parse(cmb_baudRate.Text);
			} catch { }

			if (baudrate < 0) {
				btn_Connect.BackColor = colorClosed;
				Program.errors.Add("Faulty baud rate.");
			} else {
				btn_Connect.BackColor = colorOpen;
				port = new SerialConnection(cmb_port.Text, baudrate, this);
				port.Open();
				timerbuffer.Start();
			}
		} else {
			// Port is open
			btn_Connect.BackColor = colorClosed;
			if (port.IsOpen())
				port.Close();
			timerbuffer.Stop();
		}
	}

	// Clear the log field
	private void btn_clear_Click(object sender, EventArgs e) {
		txt_output.Text = "";
	}

	// Send a message through to the serial port
	private void btn_send_Click(object sender, EventArgs e) {
		string s = txt_message.Text;
		txt_message.Text = "";
		txt_message.Focus();

		switch (cmb_endline.SelectedIndex) {
			case (0): // no end
				break;
			case (1): // '\r'
				s += "\r";
				break;
			case (2): // '\n'
				s += "\n";
				break;
			case (3): // '\r\n'
				s += "\r\n";
				break;
		}

		// Send out through the serial port
		//txt_output.Text += s;

		if (port != null && port.IsOpen()) {
			// Character size
			byte[] package = new byte[s.Length];
			for (int i = 0, j = s.Length; i < j; i++) {
				// Test if these are the correct order
				package[i + 0] = (byte)(s[i] >> 0);
			}

			port.Send(package);
		} else {
			// Tried to send through a closed port, maybe send a error message
		}
		
	}

	// This converts a byte array from the serial connection and sends it to the logger
	public void ConvertAndLog(byte[] b) {
		string s = "";
		for (int i = 0, j = b.Length; i < j; i++)
			s += (char)b[i];

		buffer += s;
		havebuffer = true;
	}

	private void txt_message_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter)
			btn_send_Click(null, null);
	}
}