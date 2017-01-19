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
	public bool pulse = true;
	public int heartBeat = 1;
	public int heartBeat_prev = 0;
	public long heartBeat_ms;
	Stopwatch heartBeatTimer = new Stopwatch();
	//heartbeat


	//temp serialtesting
	SerialConnection serialConnection;


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

		//temp, initialize status[0]
		st.status[0] = 1;

		// Load all settings
		ProgramSaverLoader.Load();
	}

	private void btn_connect_serial_Click(object sender, EventArgs e)
	{
		//temp, should be replaced with comm handler later
		if(serialConnection == null)
		{
			try
			{
				serialConnection = new SerialConnection(cmb_comport.SelectedItem.ToString(), int.Parse(cmb_baudrate.SelectedItem.ToString()));

			}
			catch (NullReferenceException)
			{
				Program.errors.Add("No com port or baud rate selected");
				return;
			}
		}

		if (serialConnection.IsOpen())
		{
			serialConnection.Close();
		}
		else
		{
			serialConnection.Open();
		}
			
	}



	//tick updates all the elements in the window
	private void tim_update_Tick(object sender, EventArgs e)
	{
		//Update Joystick Status fields
		joystickSettings.Update();
		indexStats.UpdateAllValues();

		//serial connection
		if (serialConnection != null && serialConnection.IsOpen())
		{
			btn_connect_serial.BackColor = System.Drawing.Color.SpringGreen;
		}
		else
		{
			btn_connect_serial.UseVisualStyleBackColor = true;
		}

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
			pbr_heartBeat.Value = 1;
		else
			pbr_heartBeat.Value = 0;

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
		if (st.status[0] == 0)
			try { serialConnection.send(0, 1); } catch { Program.errors.Add("No serial connection for heartbeat"); }
		else if (st.status[0] == 1)
			try { serialConnection.send(0, 0); } catch { Program.errors.Add("No serial connection for heartbeat"); }
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
		serialConnection.send(index, value);
	}
}
