using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using st = ST_Register;


public partial class WindowStatus : Form
{

	public IndexSettings indexSettings;
	public IndexStats indexStats;
	public GraphicsCreator graphicsCreator;

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
		graphicsCreator = new GraphicsCreator(pan_graphicsCreator, btn_EditMode);
		ProgramSaverLoader.Load();

		// Start the st_register send timer
		tim_SendCommandsDelay.Tick += ST_Register.SendCommands;
	}

	



	//tick updates all the elements in the window
	private void tim_10ms_update_Tick(object sender, EventArgs e)
	{
		//update values from joystick
		JoystickHandler.Update();

		//Update Joystick Status fields
		joystickSettings.Update();
		indexStats.UpdateAllValues();

		// Update values in the graphics
		graphicsCreator.UpdateValues();

		//update hartbeat
		heartBeat = st.status[0];
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

	}



	private void tim_100ms_update_Tick(object sender, EventArgs e)
	{
		//serial connection
		if (CommHandler.initialized)
		{
			//update connection button color
			if (CommHandler.GetConnectionStatus() == CommHandler.ConnectionStatus.Connected)
			{
				btn_connect_serial.BackColor = System.Drawing.Color.SpringGreen; //Darg green?, ForrestGreen? LimeGreen? SpringGreen?
																				 //btn_connect_serial.ForeColor = System.Drawing.Color.White;
			}

			else if (CommHandler.GetConnectionStatus() == CommHandler.ConnectionStatus.NotConnected)
			{
				btn_connect_serial.UseVisualStyleBackColor = true;
				btn_connect_serial.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			}

			else if (CommHandler.GetConnectionStatus() == CommHandler.ConnectionStatus.Disconnected)
			{
				btn_connect_serial.BackColor = System.Drawing.Color.Red; //Firebrick?
				btn_connect_serial.ForeColor = System.Drawing.Color.White;
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

	private void btn_connect_serial_Click(object sender, EventArgs e)
	{
		if (!CommHandler.initialized)
			CommHandler.InitSerial(cmb_comport.SelectedItem.ToString(), int.Parse(cmb_baudrate.SelectedItem.ToString()));

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

	private void button1_Click(object sender, EventArgs e)
	{
		tim_SendCommandsDelay.Interval = (int)(1000 / (float)nud_comm_transfreq.Value);

		if (tim_SendCommandsDelay.Enabled)
		{
			//tim_SendCommandsDelay.Stop();
			tim_SendCommandsDelay.Enabled = false;
			tim_heartBeat.Enabled = false;
			btn_startTransmition.UseVisualStyleBackColor = true;


		}
		else
		{
			
			tim_SendCommandsDelay.Enabled = true;
			tim_heartBeat.Enabled = true;
			btn_startTransmition.BackColor = System.Drawing.Color.SpringGreen;
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

	private void btn_connect_ethernet_Click(object sender, EventArgs e)
	{

		IPAddress ipAddress = null;
		//parse ip address
		try
		{
			ipAddress = IPAddress.Parse(txt_ipaddress.Text);
		}
		catch (Exception ipe) { Console.WriteLine(ipe.ToString()); }



		if (!CommHandler.initialized)
			CommHandler.InitEthernet(ipAddress);

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
	}
}