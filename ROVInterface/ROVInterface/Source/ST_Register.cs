using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	ST_Register
	Used when setting values and sending them. And used when getting values from the robot.
*/

class ST_Register {

	private ST_Array values;
	private ST_Array commands;

	/// <summary>
	/// 
	/// </summary>
	public ST_Register() {
		values = new ST_Array();
		commands = new ST_Array();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="index">The index you want to set the value of</param>
	/// <param name="value">The value</param>
	public void set(int index, int value) {
        commands[index] = value;
    }
}