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
		commands = new ST_Array();
	}

	public static void SendCommands(object sender, EventArgs e) {
		// Stop the timer for next update, to start again when finished with sending these commands
		Program.windowStatus.tim_SendCommandsDelay.Stop();

		ST_Array.arrelement[] data = commands.GetAllValues();
		KeyValuePair<int, int>[] tosend = new KeyValuePair<int, int>[data.Length];
		for (int i = 0, j = data.Length; i < j; i++)
			tosend[i] = new KeyValuePair<int, int>(data[i].index, data[i].value);
		CommHandler.Send(tosend);
		/*for (int i = 0, j = data.Length; i < j; i++)
			CommHandler.Send(data[i].index, data[i].value);
		*/
		// Reset the command array
		commands.ResetArray();
	}

	/* NOT IN USE
	public static void SendSingleCommand(ST_Array.arrelement data) {
		CommHandler.Send(data.index, data.value);
	}*/
}