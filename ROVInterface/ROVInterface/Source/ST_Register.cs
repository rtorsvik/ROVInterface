using System;
using System.Collections.Generic;

/*
	ST_Register
	Used when setting values and sending them. And used when getting values from the robot.
*/

public static class ST_Register {

	public static ST_Array status;
	public static ST_Array commands;

	/// <summary>
	/// 
	/// </summary>
	public static void Init() {
		status = new ST_Array();
		commands = new ST_Array(new ST_Array());
	}

	public static void SendCommands(object sender, EventArgs e) {
		// Ignore this call if the port has not been assigned yet
		if (CommHandler.port == null) {
			commands.ResetArray();
			return;
		}

		ST_Array.arrelement[] data = commands.GetAllValues();

		// Return if there are no elements to send
		if (data.Length == 0)
			return;

		// Stop the timer for next update, to start again when finished with sending these commands
		Program.windowStatus.tim_SendCommandsDelay.Stop();

		// Send commands
		KeyValuePair<int, int>[] tosend = new KeyValuePair<int, int>[data.Length];
		for (int i = 0, j = data.Length; i < j; i++)
			tosend[i] = new KeyValuePair<int, int>(data[i].index, data[i].value);
		CommHandler.Send(tosend);
		Program.windowStatus.tim_SendCommandsDelay.Start();

		// Reset the command array
		commands.ResetArray();
	}

	/* NOT IN USE
	public static void SendSingleCommand(ST_Array.arrelement data) {
		CommHandler.Send(data.index, data.value);
	}*/
}