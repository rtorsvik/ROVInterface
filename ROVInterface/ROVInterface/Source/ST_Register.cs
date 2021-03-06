﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

/*
	ST_Register
	Used when setting values and sending them. And used when getting values from the robot.
*/

public static class ST_Register {

	public static ST_Array status;
	public static ST_Array commands;
	private static Stopwatch stopwatch;
	private static BackgroundWorker bgworker;
	
	public static void Init() {
		status = new ST_Array();
		commands = new ST_Array(new ST_Array());
		stopwatch = new Stopwatch();
		bgworker = new BackgroundWorker();
		bgworker.DoWork += new DoWorkEventHandler(_bgrSendCommands);
	}

	public static void SendCommands(object sender, EventArgs e) {
		Program.windowStatus.tim_SendCommandsDelay.Stop();
		//bgworker.RunWorkerAsync();
		_bgrSendCommands(null, null);
	}

	private static void _bgrSendCommands(object sender, DoWorkEventArgs e) {
		// Ignore this call if the port has not been assigned yet
		if (CommHandler.connection == null) {
			commands.ResetArray();
			Program.windowStatus.tim_SendCommandsDelay.Interval = (int)Program.windowStatus.nud_comm_transfreq.Value;
			Program.windowStatus.tim_SendCommandsDelay.Start();
			return;
		}

		ST_Array.arrelement[] data = commands.GetAllValuesAndReset();

		// Return if there are no elements to send
		if (data.Length == 0) {
			Program.windowStatus.tim_SendCommandsDelay.Interval = (int)Program.windowStatus.nud_comm_transfreq.Value;
			Program.windowStatus.tim_SendCommandsDelay.Start();
			return;
		}

		// Stop the timer for next update, to start again when finished with sending these commands
		stopwatch.Restart();

		// Send commands
		KeyValuePair<int, int>[] tosend = new KeyValuePair<int, int>[data.Length];
		for (int i = 0, j = data.Length; i < j; i++)
			tosend[i] = new KeyValuePair<int, int>(data[i].index, data[i].value);
		CommHandler.Send(tosend);

		// Set the delay to the next send of commands, based on time elapsed sending current commands and time till next frame
		stopwatch.Stop();
		int tick = (int)Program.windowStatus.nud_comm_transfreq.Value - (int)stopwatch.ElapsedMilliseconds;
		tick = tick < 1 ? 1 : tick;
		Program.windowStatus.tim_SendCommandsDelay.Interval = tick;
		Program.windowStatus.tim_SendCommandsDelay.Start();
	}
}