using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
	}

	private SerialConnection port;

	private Color colorOpen = Color.Green;
	private Color colorClosed = Color.White;

	// Connect to the serial port
	private void btn_Connect_Click(object sender, EventArgs e) {
		if (port == null) {
			// Port is closed
			btn_Connect.BackColor = colorOpen;
			int baudrate = -1;
			try {
				baudrate = int.Parse(cmb_baudRate.Text);
			} catch { }

			if (baudrate < 0) {
				Program.errors.Add("Faulty baud rate.");
			} else {
				port = new SerialConnection(cmb_port.Text, baudrate);
				port.Open();
			}
		} else {
			// Port is open
			btn_Connect.BackColor = colorClosed;
			if (port.IsOpen())
				port.Close();
			port = null;
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
		txt_output.Text += s;

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
	private void ConvertAndLog(byte[] b) {
		string s = "";
		for (int i = 0, j = b.Length; i < j; i++)
			s += (char)b[i];

		txt_output.Text += s;
	}

	private void txt_message_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter)
			btn_send_Click(null, null);
	}
}