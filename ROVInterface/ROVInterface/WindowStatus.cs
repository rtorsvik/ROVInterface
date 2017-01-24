using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using st = ST_Register;


public partial class WindowStatus : Form
{

	public IndexSettings indexSettings;
	public IndexStats indexStats;

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
		ProgramSaverLoader.Load();
	}

	



	//tick updates all the elements in the window
	private void tim_10ms_update_Tick(object sender, EventArgs e)
	{
		//update values from joystick
		JoystickHandler.Update();

		//Update Joystick Status fields
		joystickSettings.Update();
		indexStats.UpdateAllValues();

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

			txt_con_messageSendt.Text = CommHandler.messageSendt;
			txt_con_messageRecieved.Text = CommHandler.messageRecieved;
		}



		//TEMP: send some joystick values to the serialconn
		//try { CommHandler.Send(1, joystickSettings.as0.outValue); } catch { }
		//try { CommHandler.Send(2, joystickSettings.as1.outValue); } catch { }
		//try { CommHandler.Send(3, joystickSettings.as2.outValue); } catch { }
		//try { CommHandler.Send(4, joystickSettings.as3.outValue); } catch { }

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


		//display error messages
		string statusMessage = "";
		foreach (string s in Program.errors)
		{
			statusMessage += s + ", ";
		}
		//statusMessage -= ", "; implement equivalent this in some way
		txt_error.Text = statusMessage;
	}



	//tick sends heartbeat to monitor bus connection
	private void tim_heartBeat_Tick(object sender, EventArgs e)
	{
		pulse = false;
		heartBeatTimer.Start();
		heartBeat_prev = heartBeat;
		sendHeartbeat = true;		
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
		int index = Int32.Parse(txt_serial_index.Text);
		int value = Int32.Parse(txt_serial_value.Text);
		//CommHandler.Send(index, value);
	}

	private void btn_connect_serial_Click(object sender, EventArgs e)
	{
		//temp, should be replaced with comm handler later
		if (!CommHandler.initialized)
			CommHandler.InitSerial(cmb_comport.SelectedItem.ToString(), int.Parse(cmb_baudrate.SelectedItem.ToString()));

		if (CommHandler.IsOpen())
		{
			CommHandler.Close();
		}
		else
		{
			CommHandler.Open();
		}

	}

	private bool shownInstructions = false;

	private void grp_IndexInstructions_Enter(object sender, EventArgs e) {
		shownInstructions = !shownInstructions;

		if (shownInstructions) {
			tbl_IndexSettings.RowStyles[3].SizeType = SizeType.AutoSize;
		} else {
			tbl_IndexSettings.RowStyles[3].SizeType = SizeType.Absolute;
			tbl_IndexSettings.RowStyles[3].Height = 20;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (tim_heartBeat.Enabled)
		{
			tim_heartBeat.Enabled = false;
			button1.UseVisualStyleBackColor = true;
			
		}
		else
		{
			tim_heartBeat.Enabled = true;
			button1.BackColor = System.Drawing.Color.SpringGreen;
		}
			
	}

	private void grp_joysticksettings_instructions_Enter(object sender, EventArgs e)
	{
		grp_joysticksettings_instructions.Size = new System.Drawing.Size(400, 300);

		throw new NotImplementedException("resize joystickiinstructions not implemented");
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
}
