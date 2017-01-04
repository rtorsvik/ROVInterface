using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ST_register {

	private int[] value;
	private int[] command;

	/// <summary>
	/// 
	/// </summary>
	public ST_register() {
		value = new int[32768];
		command = new int[32768];
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="index">The index you want to set the value of</param>
	/// <param name="value">The value</param>
	public void set(int index, int value)
    {
        command[index] = value;
    }

}

