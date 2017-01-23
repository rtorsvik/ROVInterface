using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class AEGIRConnection : Port
{
	//Identifyers
	private const int TOP_XBOX_CTRLS	= 0x200;
	private const int TOP_XBOX_AXES		= 0x201;
	private const int TOP_POWR_CTRL		= 0x202;
	private const int TOP_REG_PARAM1	= 0x203;
	private const int TOP_REG_PARAM2	= 0x204;
	private const int TOP_SENS_CTRL		= 0x205;

	private const int SENSOR_AN_RAW		= 0x300;
	private const int SENSOR_PROCESSED_DATA	= 0x301;
	private const int SENSOR_ACCELERATION	= 0x302;
	private const int SENSOR_DEPTH_TEMP		= 0x303;
	private const int SENSOR_LEAKAGE_ALARM	= 0x304;
	private const int SENSOR_AHRS_QUATERNION= 0x305;
	private const int SENSOR_ALIVE		= 0x306;
	private const int SENSOR_AHRS		= 0x307;
	private const int SENSOR_TEMP		= 0x309;
	private const int SENSOR_MAGNETIC_FIELD	= 0x30A;
	private const int SENSOR_ANGULAR_VELOCITY = 0x30B;
	private const int SENSOR_THRUSTER_DUTY	= 0x30C;
	private const int SENSOR_DEPTH_SETPOINT	= 0x30D;

	private const int POWR_MAN_CURRENT		= 0x401;
	private const int POWR_ALIVE			= 0x402;

	private const int VESC_X_CURRENT	= 0x500; //0x500: Current through VESC nr. 0, 0x501: Current through VESC nr. 1 and so on
	private const int VESC_X_RPM		= 0x510; //0x510: Temperature and voltage through VESC nr. 0, 0x501: Temperature and voltage through VESC nr. 1 and so on
	private const int VESC_X_TEMP_VOLT	= 0x520; //0x510: Voltage through VESC nr. 0, 0x501: Voltage through VESC nr. 1 and so on

	private const int ENC_POS			= 0x600;


	/// <summary>
	/// Specific class for communication with UIS Subsea's ÆGIR ROV over CAN buss
	/// </summary>
	public AEGIRConnection()
	{
		throw new NotImplementedException();
	}

	public void Send(int identifyer, byte[] message)
	{
		throw new NotImplementedException();
	}

	public void Send(int index, int value)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Method for recieveing data, method checks the identifier from the CAN buss and saves the value to the ST_Register accordingly
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public void Recieve<T>(object sender, T e)
	{
		throw new NotImplementedException();

		int readIdentifyer = TOP_XBOX_CTRLS; //TEMP, replace this with the read identifyer
		byte[] readValues = { 0, 0, 0, 0, 0, 0, 0, 0 };

		switch (readIdentifyer)
		{
			case SENSOR_AN_RAW:
			case SENSOR_PROCESSED_DATA:
			case SENSOR_ACCELERATION:
			case SENSOR_DEPTH_TEMP:
			case SENSOR_LEAKAGE_ALARM:
			case SENSOR_AHRS_QUATERNION:
			case SENSOR_ALIVE:
			case SENSOR_AHRS:
				SaveSensorAHRS(readValues);
				break;
			case SENSOR_TEMP:
			case SENSOR_MAGNETIC_FIELD:
			case SENSOR_ANGULAR_VELOCITY:
			case SENSOR_THRUSTER_DUTY:
			case SENSOR_DEPTH_SETPOINT:
			case POWR_MAN_CURRENT:
			case POWR_ALIVE:
			case VESC_X_CURRENT:
			case VESC_X_TEMP_VOLT:
			case ENC_POS:
		}

	}



	public void SendJoystickControls()
	{
		byte[] package = new byte[8];

		/*
		 *			 ^ Y
		 *			 |
		 *    // _________ \\
		 *      /O       O\
		 *     |     x Z   |   ---> X
		 *      \O_______O/  
		 *    \\           //
		 *			 
		 *           
		 */

		int trans_x = ST_Register.commands[1];	//surge
		int trans_y = ST_Register.commands[2];	//sway
		int trans_z = ST_Register.commands[3];	//heave
		int rot_x = ST_Register.commands[4];	//pitch
		int rot_y = ST_Register.commands[5];	//roll
		int rot_z = ST_Register.commands[6];    //yaw/heading

		//int buttons = ST_Register.commands[100]; //TEMP
		int buttons = 0;

		//First four axes of joystick
		package[0] = (byte)(trans_x);
		package[1] = (byte)(trans_x >> 8);
		package[2] = (byte)(trans_y);
		package[3] = (byte)(trans_y >> 8);
		package[4] = (byte)(trans_z);
		package[5] = (byte)(trans_z >> 8);
		package[6] = (byte)(rot_x);
		package[7] = (byte)(rot_x >> 8);

		//Send
		Send(TOP_XBOX_CTRLS, package);

		//Second two axes of joystick + buttons
		package[0] = (byte)(rot_y >> 8);
		package[1] = (byte)(rot_y);
		package[2] = (byte)(rot_z >> 8);
		package[3] = (byte)(rot_z);
		package[4] = (byte)(buttons >> 8);
		package[5] = (byte)(buttons);
		package[6] = (byte)(0);
		package[7] = (byte)(0);

		//Send
		Send(TOP_XBOX_AXES, package);
	}



	private void SaveSensorAHRS(byte[] readValues)
	{
		int pitch;		//x0.1 degrees
		int roll;		//x0.1 degrees
		int yaw;		//x0.1 degrees
		int heading;    //x0.1 degrees

		pitch = readValues[0] << 8;
		pitch |= readValues[1];

		roll = readValues[2] << 8;
		roll |= readValues[3];

		yaw = readValues[4] << 8;
		yaw |= readValues[5];

		heading = readValues[6] << 8;
		heading |= readValues[7];

		//ST_Register[4] = pitch;
		//ST_Register[5] = roll;
		//and so on


	}







}

