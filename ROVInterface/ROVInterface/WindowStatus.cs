using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using st = ST_Register;


public partial class WindowStatus : Form
{

	public IndexSettings indexSettings;
	public IndexStats indexStats;
	public GraphicsCreator graphicsCreator;
	public GraphicToolbox graphicToolbox;

	public JoystickSettings joystickSettings;

	//heartbeat
	public bool pulse;
	public int heartBeat = 1;
	public int heartBeat_prev = 0;
	public long heartBeat_ms;
	Stopwatch heartBeatTimer = new Stopwatch();
	//heartbeat


	//temp serialtesting
	bool sendHeartbeat;

	


	public WindowStatus()
    {
        InitializeComponent();
        //Make this screen appear on primary or seconodary screen by setting scrn =
        //  0, primary screen
        //  1, secondary screen
        int scrn = 0;

		this.Location = Screen.AllScreens[scrn].WorkingArea.Location;
    }

    private void WindowStatus_Load(object sender, EventArgs e)
    {
		indexSettings = new IndexSettings(panel_IndexSettings);
		indexStats = new IndexStats(indexSettings, panel_IndexStats, btn_EditMode);

		joystickSettings = new JoystickSettings();

			
		//add all available com port elements to com port combobox
		cmb_comport.Items.AddRange(SerialConnection.GetPortList());
		try { cmb_comport.SelectedIndex = 1; } catch { }				//load index 1 (COM5) as default

		//temp, initialize status[0]
		st.status[0] = 1;

		// Load all settings
		graphicsCreator = new GraphicsCreator(pan_graphicsCreator);
		graphicToolbox = new GraphicToolbox(pan_graphicsCreator, pan_graphicToolbox, rightclickMenu);
		ProgramSaverLoader.Load();

		// Start the st_register send timer
		tim_SendCommandsDelay.Tick += ST_Register.SendCommands;

		//load local IP address into communication tabs ethernet server settings
		txt_comm_serverip.Text = GetLocalIPAddress();
		txt_comm_serverport.Text = "80";
	}





	//tick updates all the elements in the window
	int ADFwebRequest;
	private void tim_10ms_update_Tick(object sender, EventArgs e)
	{
		//update values from joystick
		JoystickHandler.Update();

		//Update Joystick Status fields
		joystickSettings.Update();
		indexStats.UpdateAllValues();

		// Update graphics tab
		graphicsCreator.UpdateValues();

		//update hartbeat
		heartBeat = (int)st.status[0];
		if(heartBeat != heartBeat_prev)
		{
			pulse = true;
			heartBeat_ms = heartBeatTimer.ElapsedMilliseconds;
			lbl_heartBeat_ms.Text = heartBeat_ms + "ms";
			heartBeatTimer.Reset();
		}
		heartBeat_prev = heartBeat;

		if (pulse)
			pbr_heartBeat.Value = 100;
		else
			pbr_heartBeat.Value = 0;

		//TEMP request values from Ægir
		if (CommHandler.connectionType == CommHandler.ConnectionType.CANbus && transmit)
		{
			CommHandler.port.Request(ADFwebRequest++ % 72);
		}

		#region navigation window updates

		double pitch = Convert.ToDouble(ST_Register.status[(int)nud_navigation_attitude_pitchindex.Value]);		
		double roll = Convert.ToDouble(ST_Register.status[(int)nud_navigation_attitude_rollindex.Value]);

		if (pitch == null)
			pitch = 0;
		if (roll == null)
			roll = 0;

		aii_navigation_attitude_instrument.SetAttitudeIndicatorParameters(pitch / (float)nud_navigation_attitude_pitchdiv.Value, roll / (float)nud_navigation_attitude_pitchdiv.Value);



		int height = Convert.ToInt32(ST_Register.status[(int)nud_navigation_height_index.Value]);

		if (height == null)
			height = 0;

		ali_navigation_height_instrument.SetAlimeterParameters(height);



		int depth = Convert.ToInt32(ST_Register.status[(int)nud_navigation_depth_index.Value]);

		if (depth == null)
			depth = 0;

		ali_navigation_depth_instrument.SetAlimeterParameters(depth);



		int heading = Convert.ToInt32(ST_Register.status[(int)nud_navigation_heading_index.Value]);

		if (heading == null)
			heading = 0;

		hdi_navigation_heading_instrument.SetHeadingIndicatorParameters(heading);

		#endregion

	}



	private void tim_100ms_update_Tick(object sender, EventArgs e)
	{
		//serial connection
		if (CommHandler.initialized)
		{
			//the button to update
			Button btn;
			switch (CommHandler.connectionType)
			{
				case CommHandler.ConnectionType.Serial:
					btn = btn_comm_serialConnect;
					break;

				case CommHandler.ConnectionType.Ethernet:
					btn = btn_comm_ethernetConnect;
					break;

				case CommHandler.ConnectionType.CANbus:
					btn = btn_comm_CANconnect;
					break;

				default:
					btn = null;
					break;
			}

			//update connection button color
			if (CommHandler.GetConnectionStatus() == CommHandler.ConnectionStatus.Connected)
			{
				btn.BackColor = System.Drawing.Color.SpringGreen; //Darg green?, ForrestGreen? LimeGreen? SpringGreen?
																 //btn_connect_serial.ForeColor = System.Drawing.Color.White;
			}

			else if (CommHandler.GetConnectionStatus() == CommHandler.ConnectionStatus.NotConnected)
			{
				btn.UseVisualStyleBackColor = true;
				btn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			}

			else if (CommHandler.GetConnectionStatus() == CommHandler.ConnectionStatus.Disconnected)
			{
				btn.BackColor = System.Drawing.Color.Red; //Firebrick?
				btn.ForeColor = System.Drawing.Color.White;
			}


			if (CommHandler.newMessage)
			{
				if (rdb_comm_status_dec.Checked)
				{
					txt_con_messageSendt.Text = CommHandler.PacketToString(CommHandler.messageSendt);
					txt_con_messageRecieved.Text = CommHandler.PacketToString(CommHandler.messageRecieved);
				}
				else if (rdb_comm_status_hex.Checked)
				{
					txt_con_messageSendt.Text = CommHandler.PacketToHEXString(CommHandler.messageSendt);
					txt_con_messageRecieved.Text = CommHandler.PacketToHEXString(CommHandler.messageRecieved);
				}
				else if (rdb_comm_status_bytes.Checked)
				{
					txt_con_messageSendt.Text = CommHandler.PacketToByteString(CommHandler.messageSendt);
					txt_con_messageRecieved.Text = CommHandler.PacketToByteString(CommHandler.messageRecieved);
				}

				CommHandler.newMessage = false;
			}

			

		}



		//temp
		/*
		byte[] b = new byte[9] { 0xff, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		KeyValuePair<int, int>[] a;
		a = CommHandler.AegirConvertData(13, b);
		ST_Register.status[4] = a[0].Value;
		*/



		if (sendHeartbeat)
		{
			if (st.status[0] == 0)
			{
				//try { CommHandler.Send(0, 1); } catch { Program.errors.Add("No serial connection for heartbeat"); }
			}
			else if (st.status[0] > 0)
			{
				//try { CommHandler.Send(0, 0); } catch { Program.errors.Add("No serial connection for heartbeat"); }
			}

			sendHeartbeat = false;
		}


		//display error messages if they are updated
		if (Program.errors.HaveUpdated())
			txt_error.Text = Program.errors.ToString();


	}



	//tick sends heartbeat to monitor bus connection
	private void tim_heartBeat_Tick(object sender, EventArgs e)
	{
		pulse = false;
		heartBeatTimer.Start();
		heartBeat_prev = heartBeat;
		sendHeartbeat = true;

		try
		{
			if (CommHandler.connectionType == CommHandler.ConnectionType.CANbus) //TEMP disable heartbet for Ægir
				return;

			KeyValuePair<int, int> kvp;

			if (st.status[0] == 0)
				kvp = new KeyValuePair<int, int>(0, 1);

			else
				kvp = new KeyValuePair<int, int>(0, 0);

			CommHandler.Send(kvp);
		}
		catch
		{
			Console.Write("No connection for heartbeat");
		}

	}



	private void btn_InsertIndexSetting_Click(object sender, EventArgs e) {
		indexSettings.CreateElement();
	}

	private void btn_AddIndexStat_Click(object sender, EventArgs e) {
		indexStats.CreateElement();
	}

	private void btn_EditMode_Click(object sender, EventArgs e) {
		indexStats.ChangeEditMode();
	}

	private void btn_send_serial_Click(object sender, EventArgs e)
	{
		int index = (int)nud_con_serial_index.Value;
		int value = (int)nud_con_serial_value.Value;

		CommHandler.Send(new KeyValuePair<int, int>(index, value));
	}



	/// <summary>
	/// Start a serial connection
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btn_connect_serial_Click(object sender, EventArgs e)
	{
		//If communication port is not initialized yet, initialize
		if (!CommHandler.initialized)
			CommHandler.InitSerial(cmb_comport.SelectedItem.ToString(), int.Parse(cmb_baudrate.SelectedItem.ToString()));

		// If port is open, close it. Else, open the port.
		if (CommHandler.IsOpen())
		{
			if(CommHandler.Close())
			{
				btn_comm_serialSend.Enabled = false;
				btn_comm_CANconnect.Enabled = true;
			}
		}
		else
		{
			if(CommHandler.Open())
			{
				btn_comm_serialSend.Enabled = true;
				btn_comm_CANconnect.Enabled = false;
			}
		}

	}

	private bool shownIndexInstructions = false;
	private void grp_IndexInstructions_Enter(object sender, EventArgs e) {
		shownIndexInstructions = !shownIndexInstructions;

		if (shownIndexInstructions) {
			tbl_IndexSettings.RowStyles[3].SizeType = SizeType.AutoSize;
		} else {
			tbl_IndexSettings.RowStyles[3].SizeType = SizeType.Absolute;
			tbl_IndexSettings.RowStyles[3].Height = 22;
		}
	}

	private bool shownJoystickInstructions = false;
	private void grp_JoystickInstructions_Enter(object sender, EventArgs e)
	{
		shownJoystickInstructions = !shownJoystickInstructions;

		if (shownJoystickInstructions)
		{
			grp_JoystickInstructions.AutoSize = true;
		}
		else
		{
			grp_JoystickInstructions.AutoSize = false;
			grp_JoystickInstructions.Height = 22;
		}
	}

	bool transmit;
	private void btn_startTransmission_Click(object sender, EventArgs e)
	{
		tim_SendCommandsDelay.Interval = (int)(1000 / (float)nud_comm_transfreq.Value);

		if (tim_SendCommandsDelay.Enabled)
		{
			//tim_SendCommandsDelay.Stop();
			transmit = false;
			tim_SendCommandsDelay.Enabled = false;
			tim_heartBeat.Enabled = false;
			btn_startTransmission.UseVisualStyleBackColor = true;
		}
		else
		{
			transmit = true;
			tim_SendCommandsDelay.Enabled = true;
			tim_heartBeat.Enabled = true;
			btn_startTransmission.BackColor = System.Drawing.Color.SpringGreen;
			//tim_SendCommandsDelay.Start();
		}
	}

	private void grp_joysticksettings_instructions_Enter(object sender, EventArgs e)
	{

	}

	private void cmb_comport_Click(object sender, EventArgs e)
	{
		//add all available com port elements to com port combobox
		cmb_comport.Items.Clear();
		cmb_comport.Items.AddRange(SerialConnection.GetPortList());
	}

	private void button2_Click(object sender, EventArgs e)
	{
		joystickSettings.LoadConnectedJoysticks();
	}



	/// <summary>
	/// Update format of message sent and message recieved if radiobuttons changes
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void rdb_comm_status_CheckedChanged(object sender, EventArgs e)
	{
		if (rdb_comm_status_dec.Checked)
		{
			txt_con_messageSendt.Text = CommHandler.PacketToString(CommHandler.messageSendt);
			txt_con_messageRecieved.Text = CommHandler.PacketToString(CommHandler.messageRecieved);
		}
		else if (rdb_comm_status_hex.Checked)
		{
			txt_con_messageSendt.Text = CommHandler.PacketToHEXString(CommHandler.messageSendt);
			txt_con_messageRecieved.Text = CommHandler.PacketToHEXString(CommHandler.messageRecieved);
		}
		else if (rdb_comm_status_bytes.Checked)
		{
			txt_con_messageSendt.Text = CommHandler.PacketToByteString(CommHandler.messageSendt);
			txt_con_messageRecieved.Text = CommHandler.PacketToByteString(CommHandler.messageRecieved);
		}
	}


	private TcpClient client;
	public StreamReader STR;
	public StreamWriter STW;
	public string sendMessage;
	public string recieveMessage;
	/// <summary>
	/// Function is called when ethernet connect buttin is clicked. Function initialises commHandler with an ethernet connection.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btn_connect_ethernet_Click(object sender, EventArgs e)
	{

		IPAddress ipAddress;
		Int32 ipPort;
		
		//parse ip address and port
		try
		{
			ipAddress = IPAddress.Parse(txt_comm_clientip.Text);
			ipPort = Int32.Parse(txt_comm_clientport.Text);
		}
		catch (Exception initEthernetException)
		{
			MessageBox.Show("Please enter a valid IP address and port number!\n\n" + initEthernetException.ToString());
			return;
		}

		client = new TcpClient();
		IPEndPoint clientEndPoint = new IPEndPoint(ipAddress, ipPort);

		try
		{
			client.Connect(clientEndPoint);
			if (client.Connected)
			{
				
				STW = new StreamWriter(client.GetStream());
				STR = new StreamReader(client.GetStream());

				STW.AutoFlush = true;

				bgw_ethernetMessageRecieveHandler.RunWorkerAsync();                //start recieving data in background
				bgw_ethernetMessageSendHandler.WorkerSupportsCancellation = true;  //ability to cancel this thread

				//update graphics
				btn_comm_ethernetConnect.BackColor = System.Drawing.Color.Aquamarine;
				btn_comm_ethernetConnect.Text = "Connected";

				btn_comm_startserver.Enabled = false;

				txt_comm_ethernetmessage.Focus();
				btn_comm_sendethernetmessage.Enabled = true;

			}
		}
		catch (Exception e4)
		{
			MessageBox.Show("Could not establish client connection\n\n" + e4.ToString());
			return;
		}

		/*
		if (!CommHandler.initialized)
			CommHandler.InitEthernet(ipAddress, ipPort);

		if (CommHandler.IsOpen())
		{
			CommHandler.Close();
			btn_send_serial.Enabled = false;
		}
		else
		{
			CommHandler.Open();
			btn_send_serial.Enabled = true;
		}
		*/




		
	}


	TcpListener listener;
	/// <summary>
	/// Functon is called when communication tab start server buttion is clicked.
	/// The initializes a server for ethernet communication
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btn_comm_startserver_Click(object sender, EventArgs e)
	{
		IPAddress ipAddress;
		Int32 ipPort;

		//parse ip address and port
		try
		{
			ipAddress = IPAddress.Any;
			ipPort = Int32.Parse(txt_comm_serverport.Text);
		}
		catch (Exception initEthernetException)
		{
			MessageBox.Show("Please enter a valid IP address and port number!\n\n" + initEthernetException.ToString());
			return;
		}

		listener = new TcpListener(ipAddress, ipPort);
		listener.Start();



		bgw_ethernetMessageRecieveHandler.RunWorkerAsync();                //start recieving data in background
		bgw_ethernetMessageSendHandler.WorkerSupportsCancellation = true;  //ability to cancel this thread


		//update graphics
		btn_comm_startserver.BackColor = System.Drawing.Color.Aquamarine;
		btn_comm_ethernetConnect.Enabled = false;
		txt_comm_ethernetmessage.Focus();
		
	}



	/// <summary>
	/// Function is callse when communication tab send ethernet message button is clicked
	/// Sends a message 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btn_comm_sendethernetmessage_Click(object sender, EventArgs e)
	{
		if (txt_comm_ethernetmessage.Text != "")
		{
			sendMessage = txt_comm_ethernetmessage.Text;
			bgw_ethernetMessageSendHandler.RunWorkerAsync();
			txt_comm_ethernetmessage.Clear();
		}
		
	}



	/// <summary>
	/// Get the IP address of this computer
	/// </summary>
	/// <returns>Returns IP address if in netwirk, else return "127.0.0.1"</returns>
	private string GetLocalIPAddress()
	{
		IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

		foreach (IPAddress ipAddress in host.AddressList)
		{
			if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
				return ipAddress.ToString();
		}

		return "127.0.0.1";
	}



	/// <summary>
	/// Send ethernet message thread
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void bgw_ethernetMessageSendHandler_DoWork(object sender, DoWorkEventArgs e)
	{
		if (client.Connected)
		{
			//if first character is a bracket, assume rest of message is informat [x1, x2, ... , xn] and send message as bytes
			if(sendMessage[0] == '[')
			{
				char[] splits = new char[] { '[', ',', ']' };
				
				string[] byteStrings = sendMessage.Split(splits);

				List<byte> package = new List<byte>();
				foreach (string s in byteStrings)
				{
					if (s == "") continue;
					package.Add(byte.Parse(s));
				}

				byte[] package2 = package.ToArray();

				STW.Write(package2);
			}
			else
			{
				STW.WriteLine(sendMessage);
			}

			this.lbx_comm_messages.Invoke(new MethodInvoker(delegate () { lbx_comm_messages.Items.Add("You: " + sendMessage); }));
		}
		else
		{
			MessageBox.Show("Send failed");
		}
		bgw_ethernetMessageSendHandler.CancelAsync();
	}

	/// <summary>
	/// Recieve ethernet message thread
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void bgw_ethernetMessageRecieveHandler_DoWork(object sender, DoWorkEventArgs e)
	{
		while (client == null || client.Connected)
		{
			if(client == null)
			{

				client = listener.AcceptTcpClient();

				STR = new StreamReader(client.GetStream());
				STW = new StreamWriter(client.GetStream());

				STW.AutoFlush = true;

				this.lbx_comm_messages.Invoke(new MethodInvoker(delegate () { lbx_comm_messages.Items.Add("Client connected"); }));
			}

			try
			{
				recieveMessage = STR.ReadLine();
				this.lbx_comm_messages.Invoke(new MethodInvoker(delegate () { lbx_comm_messages.Items.Add("Other: " + recieveMessage); }));
			}
			catch (Exception e5)
			{
				MessageBox.Show(e5.ToString());
			}
		}
	}

	/// <summary>
	/// Start a CAN buss connection
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btn_comm_CANconnect_Click(object sender, EventArgs e)
	{
		//If communication port is not initialized yet, initialize
		if (!CommHandler.initialized)
		{
			string ip;
			int port;

			try
			{
				ip = IPAddress.Parse(txt_comm_CANip.Text).ToString();
				port = Int32.Parse(txt_comm_CANport.Text);
			}
			catch(Exception CANConnectExeption)
			{
				MessageBox.Show("Please enter a valid IP address and port number", "caption", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			CommHandler.InitCAN(ip, port);
		}

		// If port is open, close it. Else, open the port.
		if (CommHandler.IsOpen())
		{
			if (CommHandler.Close())
			{
				btn_comm_CANsend.Enabled = false;
				btn_comm_serialConnect.Enabled = true;
			}
		}

		else
		{
			if (CommHandler.Open())
			{
				btn_comm_CANsend.Enabled = true;
				btn_comm_serialConnect.Enabled = false;
			}
		}

		//bgw_aegirMessageRequest.RunWorkerAsync();
	}

	private void btn_comm_CANsend_Click(object sender, EventArgs e)
	{
		char[] splits = new char[] { ' ', '[', ',', ']' };
		string[] byteStrings = txt_comm_CANmessage.Text.Split(splits);

		List<byte> bytesToSend = new List<byte>();
		foreach (string s in byteStrings)
		{
			if (s == "") continue;
			bytesToSend.Add(byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
		}

		byte[] package = bytesToSend.ToArray();

		CommHandler.port.Send(package);
	}



	//TEMP Ægir############################################################################################################################
	bool aegirLightOn = false;
	private void btn_aegir_light_Click(object sender, EventArgs e)
	{
		if(aegirLightOn)
		{
			aegirLightOn = false;
			btn_aegir_light.Text = "Light [Off]";
			btn_aegir_light.UseVisualStyleBackColor = true;
		}
		else
		{
			aegirLightOn = true;
			btn_aegir_light.Text = "Light [On]";
			btn_aegir_light.BackColor = System.Drawing.Color.Aquamarine;
		}

		ST_Register.commands[400] = Convert.ToInt32(aegirLightOn);
	}

	private void nud_aegir_lightdim_ValueChanged(object sender, EventArgs e)
	{
		ST_Register.commands[401] = (int)nud_aegir_lightdim.Value;
	}

	int aegirMotorcommandCache;
	bool aegirCoolingfanOn = false;
	private void btn_aegir_coolingfan_Click(object sender, EventArgs e)
	{
		if (aegirCoolingfanOn)
		{
			aegirCoolingfanOn = false;
			btn_aegir_coolingfan.Text = "Coolingfan [Off]";
			btn_aegir_coolingfan.UseVisualStyleBackColor = true;
		}
		else
		{
			aegirCoolingfanOn = true;
			btn_aegir_coolingfan.Text = "Coolingfan [On]";
			btn_aegir_coolingfan.BackColor = System.Drawing.Color.Aquamarine;
		}

		ST_Register.commands[100] = aegirMotorcommandCache = aegirMotorcommandCache & ~0x4 | Convert.ToInt32(aegirCoolingfanOn) << 2;
	}

	bool aegirArmmotorsOn = false;
	private void btn_aegir_armmotors_Click(object sender, EventArgs e)
	{
		if (aegirArmmotorsOn)
		{
			aegirArmmotorsOn = false;
			btn_aegir_armmotors.Text = "Arm motors [Disarmed]";
			btn_aegir_armmotors.UseVisualStyleBackColor = true;
		}
		else
		{
			aegirArmmotorsOn = true;
			btn_aegir_armmotors.Text = "Arm motors [Armed]";
			btn_aegir_armmotors.BackColor = System.Drawing.Color.Aquamarine;
		}

		ST_Register.commands[100] = aegirMotorcommandCache = aegirMotorcommandCache & ~0x1 | Convert.ToInt32(aegirArmmotorsOn);
	}

	bool aegirRegAuto = false;
	private void btn_aegir_RegAuto_Click(object sender, EventArgs e)
	{
		if (aegirRegAuto)
		{
			aegirRegAuto = false;
			btn_aegir_RegAuto.Text = "Possition control [Auto]";
			btn_aegir_RegAuto.UseVisualStyleBackColor = true;
		}
		else
		{
			aegirRegAuto = true;
			btn_aegir_RegAuto.Text = "Possition control [Manual]";
			btn_aegir_RegAuto.BackColor = System.Drawing.Color.Aquamarine;
		}

		ST_Register.commands[800] = aegirMotorcommandCache = aegirMotorcommandCache & ~0x1 | Convert.ToInt32(aegirRegAuto);
	}



	/// <summary>
	/// Backgroundworker to request values from ADFweb ethernet/CAN transformer
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void bgw_aegirMessageRequest_DoWork(object sender, DoWorkEventArgs e)
	{
		/*
		while (true)
		{
			//Ask for the Cob_IDs from ADFweb ethernet/CAN transformer
			for (int i = 1; i < 73; i++)
			{
				CommHandler.port.Request(i);
			}
		}
		*/
	}

	// Function to open the edit indexes for the graphic tab
	private void pan_graphicsCreator_DoubleClick(object sender, EventArgs e) {
		graphicsCreator.ChangeEditMode(sender, e);
	}

	private void pan_graphicsCreator_Paint(object sender, PaintEventArgs e) {
		graphicsCreator.DrawBackgroundImage(e);
		base.OnPaint(e);
	}

	//TEMP
	private void tim_SendCommandsDelay_Tick(object sender, EventArgs e)
	{
		
	}

	private void tabPage1_Click(object sender, EventArgs e)
	{

	}












	public void DrawGraph(int deadband, int offset, int max, double expo, bool reverse)
	{

		// The bounds to draw.
		float xmin = -32767;
		float xmax = 32767;
		float ymin = -32767;
		float ymax = 32767;

		// Make the Bitmap.
		int wid = picGraph.ClientSize.Width;
		int hgt = picGraph.ClientSize.Height;

		Bitmap bmp = new Bitmap(new Bitmap("./Graphics/Grid.png"), wid, hgt);

		using (Graphics gr = Graphics.FromImage(bmp))
		{
			gr.SmoothingMode = SmoothingMode.AntiAlias;

			// Transform to map the graph bounds to the Bitmap.
			RectangleF rect = new RectangleF(
				xmin, ymin, xmax - xmin, ymax - ymin);
			PointF[] pts =
					{
					new PointF(0, hgt),
					new PointF(wid, hgt),
					new PointF(0, 0),
				};
			gr.Transform = new Matrix(rect, pts);

			// Draw the graph.
			using (Pen graph_pen = new Pen(System.Drawing.SystemColors.MenuHighlight, 3))
			{
				// See how big 1 pixel is horizontally.
				Matrix inverse = gr.Transform;
				inverse.Invert();
				PointF[] pixel_pts =
					{
						new PointF(0, 0),
						new PointF(1, 0)
					};
				inverse.TransformPoints(pixel_pts);
				float dx = pixel_pts[1].X - pixel_pts[0].X;
				dx /= 2;

				// Loop over x values to generate points.
				List<PointF> points = new List<PointF>();
				for (float x = xmin; x <= xmax; x += dx)
				{
					bool valid_point = false;
					try
					{
						// Get the next point.
						float y = F(x, deadband, offset, max, expo, reverse);

						// If the slope is reasonable,
						// this is a valid point.
						if (points.Count == 0) valid_point = true;
						else
						{
							float dy = y - points[points.Count - 1].Y;
							if (Math.Abs(dy / dx) < 1000)
								valid_point = true;
						}
						if (valid_point) points.Add(new PointF(x, y));
					}
					catch
					{
					}

					// If the new point is invalid, draw
					// the points in the latest batch.
					if (!valid_point)
					{
						if (points.Count > 1)
							gr.DrawLines(graph_pen, points.ToArray());
						points.Clear();
					}

				}

				// Draw the last batch of points.
				if (points.Count > 1)
					gr.DrawLines(graph_pen, points.ToArray());
			}
		}

		// Display the result.
		picGraph.Image = bmp;
	}

	// The function to graph.
	private float F(float x, int deadband, int offset, int max, double expo, bool reverse)
	{
		

		//Do math
		double x0 = 32767 * (deadband / 100d);
		double y0 = 32767 * (offset / 100d);

		double x1 = 32767;
		double y1 = 32767 * (max / 100d);

		double e = expo;

		int r = reverse ? -1 : 1;

		//in the "dead" zone of the deadband, y = 0, else, calculate y value
		float y;
		if (-x0 < x && x < x0)
		{
			y = 0;
		}
		else
		{
			//Function might not have real solutins for negative values of x, 
			//so calculate only for asolute values of x, and convert later
			y = (float)(r * (Math.Pow((Math.Abs(x) - x0), e)) * (y1 - y0) / (Math.Pow((x1 - x0), e)) + y0);
		}

		//for negative values of x, invert y value 
		if (x < 0)
			y = -y;

		return y;
	}


}