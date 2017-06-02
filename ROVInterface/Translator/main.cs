using System;
using System.Collections;
using System.Collections.Generic;

namespace Translator
{
	/*
	 * Class needs to implement two functions and a name:
	 * 
	 * public static byte[] ConvertCommands(KeyValuePair<int, int>[]);	Converts a set of commands into the right format before sending
	 * public static Pair<int,int>[] ConvertData(byte[]);				Converts a set of recieved data to the right format before accepting them  
	 * public const string TRANSLATORNAME = "Your translator name";		Spesifies the name of the translator
     */


	/// <summary>
	/// Class functions as translator between this application and an external unit that doesnt use the same data format.
	/// </summary>
	public static class main
	{

		/// <summary>
		/// The name of this translator
		/// </summary>
		public const string TRANSLATORNAME = "UIS Subsea ÆGIR translator";


	
		//CAN bus Identifyers
		private const int TOP_XBOX_CTRLS = 0x200;
		private const int TOP_XBOX_AXES = 0x201;
		private const int TOP_POWR_CTRL = 0x202;
		private const int TOP_REG_PARAM1 = 0x203;
		private const int TOP_REG_PARAM2 = 0x204;
		private const int TOP_SENS_CTRL = 0x205;
		private const int TOP_XBOX_CTRLS_2 = 0x206;
		private const int TOP_XBOX_AXES_2 = 0x207;

		private const int SENSOR_AN_RAW = 0x300;
		private const int SENSOR_PROCESSED_DATA = 0x301;
		private const int SENSOR_ACCELERATION = 0x302;
		private const int SENSOR_DEPTH_TEMP = 0x303;
		private const int SENSOR_LEAKAGE_ALARM = 0x304;
		private const int SENSOR_AHRS_QUATERNION = 0x305;
		private const int SENSOR_ALIVE = 0x306;
		private const int SENSOR_AHRS = 0x307;
		private const int SENSOR_TEMP = 0x309;
		private const int SENSOR_MAGNETIC_FIELD = 0x30A;
		private const int SENSOR_ANGULAR_VELOCITY = 0x30B;
		private const int SENSOR_THRUSTER_DUTY = 0x30C;
		private const int SENSOR_DEPTH_SETPOINT = 0x30D;

		private const int POWR_THR_CURRENT = 0x400;
		private const int POWR_MAN_CURRENT = 0x401;
		private const int POWR_ALIVE = 0x402;

		private const int VESC_X_CURRENT = 0x500; //0x500: Current through VESC nr. 0, 0x501: Current through VESC nr. 1 and so on
		private const int VESC_X_RPM = 0x510; //0x510: Temperature and voltage through VESC nr. 0, 0x501: Temperature and voltage through VESC nr. 1 and so on
		private const int VESC_X_TEMP_VOLT = 0x520; //0x510: Voltage through VESC nr. 0, 0x501: Voltage through VESC nr. 1 and so on

		private const int ENC_POS = 0x600;



		//cached commands
		private static byte[] TOP_XBOX_CTRLS_cache = new byte[8];
		private static byte[] TOP_XBOX_AXES_cache = new byte[8];
		private static byte[] TOP_POWR_CTRL_cache = new byte[1];
		private static byte[] TOP_REG_PARAM1_cache = new byte[7];
		private static byte[] TOP_REG_PARAM2_cache = new byte[6];
		private static byte[] TOP_SENS_CTRL_cache = new byte[6];
		private static byte[] TOP_XBOX_CTRLS_2_cache = new byte[8];
		private static byte[] TOP_XBOX_AXES_2_cache = new byte[8];



		//ADFWeb identifyers
		private const byte readidentifier = 0x01;
		private const byte writeidentifier = 0x02;


		/// <summary>
		/// Converts a set of commands into the right format before sending
		/// </summary>
		/// <param name="commands">Set of commands</param>
		/// <returns>byte array in the right format</returns>
		public static byte[] ConvertCommands(KeyValuePair<int, int>[] commands)
		{
			Dictionary<int, byte[]> message = new Dictionary<int, byte[]>();    //messages to send, key representing identifyer and value reperenting the bytes
			List<byte> package = new List<byte>();                              //contains the bytes to send

			//"Write" identifyer
			package.Add(writeidentifier);



			foreach (KeyValuePair<int, int> p in commands)
			{
				/*
				 * check the key to determine how to handle this specific command
				 * 
				 * Each message to send (saved in Dictionary<int, byte[]> message) contains an identifier (key) and a byte array (value) of size 1 to 8.
				 * Some messages might have to contain some more commands than are available in KeyValuePair<int, int>[] commands, in this case, send cached commands.
				 * So, for each command, if the message is not alreadu created by another command, create a new message with the cached commands, and
				 * then overwrite and replace these cached values with the new ones from KeyValuePair<int, int>[] commands.
				 */
				byte bitmask;
				switch (p.Key)
				{
					case 1: //surge

						//If the message is not alreadu created by another command, create a new message with the cached commands
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;

						//Overwrite message and replace cached values with the new ones
						message[TOP_XBOX_CTRLS][2] = TOP_XBOX_CTRLS_cache[2] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][3] = TOP_XBOX_CTRLS_cache[3] = (byte)(p.Value >> 8);

						break;

					case 2: //sway
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;
						message[TOP_XBOX_CTRLS][0] = TOP_XBOX_CTRLS_cache[0] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][1] = TOP_XBOX_CTRLS_cache[1] = (byte)(p.Value >> 8);
						break;
					case 3: //heave
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;
						message[TOP_XBOX_CTRLS][4] = TOP_XBOX_CTRLS_cache[4] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][5] = TOP_XBOX_CTRLS_cache[5] = (byte)(p.Value >> 8);
						break;
					case 4: //pitch
						if (!message.ContainsKey(TOP_XBOX_AXES))
							message[TOP_XBOX_AXES] = TOP_XBOX_AXES_cache;
						message[TOP_XBOX_AXES][0] = TOP_XBOX_AXES_cache[0] = (byte)p.Value;
						message[TOP_XBOX_AXES][1] = TOP_XBOX_AXES_cache[1] = (byte)(p.Value >> 8);
						break;
					case 5: //roll
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;
						message[TOP_XBOX_CTRLS][6] = TOP_XBOX_CTRLS_cache[6] = (byte)p.Value;
						message[TOP_XBOX_CTRLS][7] = TOP_XBOX_CTRLS_cache[7] = (byte)(p.Value >> 8);
						break;
					case 6: //yaw
						if (!message.ContainsKey(TOP_XBOX_AXES))
							message[TOP_XBOX_AXES] = TOP_XBOX_AXES_cache;
						message[TOP_XBOX_AXES][2] = TOP_XBOX_AXES_cache[2] = (byte)p.Value;
						message[TOP_XBOX_AXES][3] = TOP_XBOX_AXES_cache[3] = (byte)(p.Value >> 8);
						break;
					case 53: //zero depth
						if (!message.ContainsKey(TOP_SENS_CTRL))
							message[TOP_SENS_CTRL] = TOP_SENS_CTRL_cache;
						message[TOP_SENS_CTRL][1] = TOP_SENS_CTRL_cache[1] = (byte)p.Value;
						break;
					case 69: //gyrosvope calibration
						if (!message.ContainsKey(TOP_SENS_CTRL))
							message[TOP_SENS_CTRL] = TOP_SENS_CTRL_cache;
						message[TOP_SENS_CTRL][0] = TOP_SENS_CTRL_cache[0] = (byte)p.Value;
						break;
					case 98: //TEMP pulse rotate left/right and regulate depth
						if (!message.ContainsKey(TOP_XBOX_AXES))
							message[TOP_XBOX_AXES] = TOP_XBOX_AXES_cache;
						message[TOP_XBOX_AXES][4] = TOP_XBOX_AXES_cache[4] = (byte)p.Value;
						//message[TOP_XBOX_AXES][4] = TOP_XBOX_AXES_cache[4] = (byte)(TOP_XBOX_AXES_cache[4] & ~0xDF | p.Value);
						break;
					case 99: //TEMP control arm, close, open, rotate
						if (!message.ContainsKey(TOP_XBOX_AXES_2))
							message[TOP_XBOX_AXES_2] = TOP_XBOX_AXES_2_cache;
						message[TOP_XBOX_AXES_2][4] = TOP_XBOX_AXES_2_cache[4] = (byte)p.Value;
						message[TOP_XBOX_AXES_2][5] = TOP_XBOX_AXES_2_cache[5] = (byte)(p.Value >> 8);
						break;
					case 100: //Set motors and coolingfan in auto or manual mode (turn them on or off)
						if (!message.ContainsKey(TOP_POWR_CTRL))
							message[TOP_POWR_CTRL] = TOP_POWR_CTRL_cache;
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] = (byte)(TOP_POWR_CTRL_cache[0] & ~0x1 | p.Value);
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] = (byte)(TOP_POWR_CTRL_cache[0] & ~0x4 | p.Value);
						break;
					case 400: //Turn light on
						if (!message.ContainsKey(TOP_POWR_CTRL))
							message[TOP_POWR_CTRL] = TOP_POWR_CTRL_cache;
						bitmask = 0xfd;
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] = (byte)(TOP_POWR_CTRL_cache[0] & bitmask | ((p.Value & 0x1) << 1));
						break;
					case 401: //Turn light on
						if (!message.ContainsKey(TOP_POWR_CTRL))
							message[TOP_POWR_CTRL] = TOP_POWR_CTRL_cache;
						byte intensity = (byte)p.Value;
						bitmask = 0x87;
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] = (byte)(TOP_POWR_CTRL_cache[0] & bitmask | (intensity << 3));
						break;
					case 800: //reg-sys Auto/Man
						if (!message.ContainsKey(TOP_REG_PARAM1))
							message[TOP_REG_PARAM1] = TOP_REG_PARAM1_cache;
						message[TOP_REG_PARAM1][6] = TOP_REG_PARAM1_cache[6] = (byte)(p.Value & 0x1);
						break;
					/*
					case 801: //manual depth SP
						if (!message.ContainsKey(TOP_XBOX_AXES))
							message[TOP_XBOX_AXES] = TOP_XBOX_AXES_cache;
						message[TOP_XBOX_AXES][6] = TOP_XBOX_AXES_cache[6] = (byte)(p.Value);
						message[TOP_XBOX_AXES][7] = TOP_XBOX_AXES_cache[7] = (byte)(p.Value >> 8);
						break;
						*/
					case 804: //regparam P (x10) Trans
						if (!message.ContainsKey(TOP_REG_PARAM1))
							message[TOP_REG_PARAM1] = TOP_REG_PARAM1_cache;
						message[TOP_REG_PARAM1][0] = TOP_REG_PARAM1_cache[0] = (byte)p.Value;
						message[TOP_REG_PARAM1][1] = TOP_REG_PARAM1_cache[1] = (byte)(p.Value >> 8);
						break;
					case 805: //regparam I (x10) Trans
						if (!message.ContainsKey(TOP_REG_PARAM1))
							message[TOP_REG_PARAM1] = TOP_REG_PARAM1_cache;
						message[TOP_REG_PARAM1][2] = TOP_REG_PARAM1_cache[2] = (byte)p.Value;
						message[TOP_REG_PARAM1][3] = TOP_REG_PARAM1_cache[3] = (byte)(p.Value >> 8);
						break;
					case 806: //regparam D (x10) Trans
						if (!message.ContainsKey(TOP_REG_PARAM1))
							message[TOP_REG_PARAM1] = TOP_REG_PARAM1_cache;
						message[TOP_REG_PARAM1][4] = TOP_REG_PARAM1_cache[4] = (byte)p.Value;
						message[TOP_REG_PARAM1][5] = TOP_REG_PARAM1_cache[5] = (byte)(p.Value >> 8);
						break;
					case 813: //regparam P (x10) Rot
						if (!message.ContainsKey(TOP_REG_PARAM2))
							message[TOP_REG_PARAM2] = TOP_REG_PARAM2_cache;
						message[TOP_REG_PARAM2][0] = TOP_REG_PARAM2_cache[0] = (byte)p.Value;
						message[TOP_REG_PARAM2][1] = TOP_REG_PARAM2_cache[1] = (byte)(p.Value >> 8);
						break;
					case 814: //regparam I (x10) Rot
						if (!message.ContainsKey(TOP_REG_PARAM2))
							message[TOP_REG_PARAM2] = TOP_REG_PARAM2_cache;
						message[TOP_REG_PARAM2][2] = TOP_REG_PARAM2_cache[2] = (byte)p.Value;
						message[TOP_REG_PARAM2][3] = TOP_REG_PARAM2_cache[3] = (byte)(p.Value >> 8);
						break;
					case 815: //regparam D (x10) Rot
						if (!message.ContainsKey(TOP_REG_PARAM2))
							message[TOP_REG_PARAM2] = TOP_REG_PARAM2_cache;
						message[TOP_REG_PARAM2][4] = TOP_REG_PARAM2_cache[4] = (byte)p.Value;
						message[TOP_REG_PARAM2][5] = TOP_REG_PARAM2_cache[5] = (byte)(p.Value >> 8);
						break;
					default: //unknown data should not be sendt
						break;
				}

			}



			//number of frames to send (with a maximum of 19 frames)
			if (message.Count > 19)
				throw new Exception("To many frames to send send to ADFWeb CAN/Ethernet converter");

			package.Add((byte)message.Count);



			//add data to package
			foreach(KeyValuePair<int, byte[]> m in message)
			{
				//Cob_ID
				byte[] Cob_ID = BitConverter.GetBytes(m.Key);
				Array.Reverse(Cob_ID);
				package.AddRange(Cob_ID);

				//number of bytes
				byte numBytes = (byte)m.Value.Length;
				package.Add(numBytes);

				//data
				package.AddRange(m.Value);

				//if number of bytes is less than 8, fill rest of frame with zeros
				byte[] rest = new byte[8 - numBytes];
				package.AddRange(rest);
			}

			return package.ToArray();

		}



		/// <summary>
		/// Converts a set of recieved data to the right format before accepting them  
		/// </summary>
		/// <param name="b">recieved data</param>
		/// <returns>KeyValuePair containing recieved data in the right format</returns>
		public static KeyValuePair<int, int>[] ConvertData(Byte[] b)
		{
			List<KeyValuePair<int, int>> message = new List<KeyValuePair<int, int>>();

			//find identifyer and data in some way
			int identifyer = 0;
			byte[] data = null;

			switch (identifyer)
			{
				case SENSOR_ACCELERATION: //acceleration in x, y and z 
					int accel_x;
					accel_x = data[0];
					accel_x |= data[1] << 8;
					message.Add(new KeyValuePair<int, int>(13, accel_x));
					int accel_y;
					accel_y = data[2];
					accel_y |= data[3] << 8;
					message.Add(new KeyValuePair<int, int>(14, accel_y));
					int accel_z;
					accel_z = data[4];
					accel_z |= data[5] << 8;
					message.Add(new KeyValuePair<int, int>(15, accel_z));
					break;
				case SENSOR_DEPTH_TEMP: //depth [mm] and temp [*C]
					int depth;
					depth = data[0] << 24;
					depth |= data[1] << 16;
					depth |= data[2] << 8;
					depth |= data[3];
					message.Add(new KeyValuePair<int, int>(52, depth));
					int temp;
					temp = data[4] << 8;
					temp = data[5];
					message.Add(new KeyValuePair<int, int>(54, temp));
					break;
				case SENSOR_LEAKAGE_ALARM://Leakage detection valeu [ohm]
					int ohm;
					ohm = data[0];
					message.Add(new KeyValuePair<int, int>(62, ohm));
					break;
				case SENSOR_ALIVE://alive counter, increments every 1 second
					int cnt;
					cnt = data[0];
					message.Add(new KeyValuePair<int, int>(64, cnt));
					break;
				case SENSOR_AHRS: //pitch roll yaw and heading
					int pitch;
					pitch = data[0] << 8;
					pitch |= data[1];
					message.Add(new KeyValuePair<int, int>(4, pitch));
					int roll;
					roll = data[2] << 8;
					roll |= data[3];
					message.Add(new KeyValuePair<int, int>(5, roll));
					int yaw;
					yaw = data[4] << 8;
					yaw |= data[5];
					message.Add(new KeyValuePair<int, int>(6, yaw));
					int heading;
					heading = data[6] << 8;
					heading |= data[7];
					message.Add(new KeyValuePair<int, int>(37, heading));
					break;
				case SENSOR_TEMP: //internal, external and DCDC temperature [*C]
					int inn_temp;
					inn_temp = data[0] << 8;
					inn_temp |= data[1];
					message.Add(new KeyValuePair<int, int>(501, inn_temp));
					int out_temp;
					out_temp = data[2] << 8;
					out_temp |= data[3];
					message.Add(new KeyValuePair<int, int>(502, out_temp));
					int DCDC_temp;
					DCDC_temp = data[4] << 8;
					DCDC_temp |= data[5];
					message.Add(new KeyValuePair<int, int>(503, DCDC_temp));
					break;
				case SENSOR_ANGULAR_VELOCITY: // degrees/s
					int av_x;
					av_x = data[0];
					av_x |= data[1] << 8;
					message.Add(new KeyValuePair<int, int>(10, av_x));
					int av_y;
					av_y = data[2];
					av_y |= data[3] << 8;
					message.Add(new KeyValuePair<int, int>(11, av_y));
					int av_z;
					av_z = data[4];
					av_z |= data[5] << 8;
					message.Add(new KeyValuePair<int, int>(12, av_z));
					break;
				case SENSOR_THRUSTER_DUTY: // power to motors -100...100 [%]
					Console.WriteLine(data[0]);
					message.Add(new KeyValuePair<int, int>(101, (sbyte)data[0])); //th1
					message.Add(new KeyValuePair<int, int>(102, (sbyte)data[1])); //th2
					message.Add(new KeyValuePair<int, int>(103, (sbyte)data[2])); //and so on...
					message.Add(new KeyValuePair<int, int>(104, (sbyte)data[3]));
					message.Add(new KeyValuePair<int, int>(105, (sbyte)data[4]));
					message.Add(new KeyValuePair<int, int>(106, (sbyte)data[5]));
					message.Add(new KeyValuePair<int, int>(107, (sbyte)data[6]));
					message.Add(new KeyValuePair<int, int>(108, (sbyte)data[7]));
					break;
				case SENSOR_DEPTH_SETPOINT: // [mm]
					int depth_SP;
					depth_SP = data[0];
					depth_SP |= data[1] << 8;
					message.Add(new KeyValuePair<int, int>(801, depth_SP));
					break;
					/*
				case POWR_THR_CURRENT: // current to motors [x100 mA] 
					message.Add(new KeyValuePair<int, int>(121, data[0])); //th1
					message.Add(new KeyValuePair<int, int>(122, data[1])); //th2
					message.Add(new KeyValuePair<int, int>(123, data[2])); //and so on...
					message.Add(new KeyValuePair<int, int>(124, data[3]));
					message.Add(new KeyValuePair<int, int>(125, data[4]));
					message.Add(new KeyValuePair<int, int>(126, data[5]));
					message.Add(new KeyValuePair<int, int>(127, data[6]));
					message.Add(new KeyValuePair<int, int>(128, data[7]));
					break;
					*/
				case POWR_ALIVE: // alive counter (+1/s)
					message.Add(new KeyValuePair<int, int>(0, data[0]));
					break;
				case VESC_X_CURRENT + 0x0: // current for vesc speed controller [mA]
					int I;
					I  = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] <<  8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(121, I));
					break;
				case VESC_X_CURRENT + 0x1: // current for vesc speed controller [mA]
					I  = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(122, I));
					break;
				case VESC_X_CURRENT + 0x2: // current for vesc speed controller [mA]
					I = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(123, I));
					break;
				case VESC_X_CURRENT + 0x3: // current for vesc speed controller [mA]
					I = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(124, I));
					break;
				case VESC_X_CURRENT + 0x4: // current for vesc speed controller [mA]
					I = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(125, I));
					break;
				case VESC_X_CURRENT + 0x5: // current for vesc speed controller [mA]
					I = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(126, I));
					break;
				case VESC_X_CURRENT + 0x6: // current for vesc speed controller [mA]
					I = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(127, I));
					break;
				case VESC_X_CURRENT + 0x7: // current for vesc speed controller [mA]
					I = data[0] << 24;
					I |= data[1] << 16;
					I |= data[2] << 8;
					I |= data[3];
					message.Add(new KeyValuePair<int, int>(128, I));
					break;
				case VESC_X_RPM + 0x0: // RPM for vesc speed controller [mA]
					int rpm;
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(141, rpm));
					break;
				case VESC_X_RPM + 0x1: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(142, rpm));
					break;
				case VESC_X_RPM + 0x2: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(143, rpm));
					break;
				case VESC_X_RPM + 0x3: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(144, rpm));
					break;
				case VESC_X_RPM + 0x4: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(145, rpm));
					break;
				case VESC_X_RPM + 0x5: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(146, rpm));
					break;
				case VESC_X_RPM + 0x6: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(147, rpm));
					break;
				case VESC_X_RPM + 0x7: // RPM for vesc speed controller [mA]
					rpm = data[0] << 24;
					rpm |= data[1] << 16;
					rpm |= data[2] << 8;
					rpm |= data[3];
					message.Add(new KeyValuePair<int, int>(148, rpm));
					break;
				case VESC_X_TEMP_VOLT + 0x0: // current for vesc speed controller [mA]
					int T;
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(511, T));
					int V;
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(111, V));
					break;
				case VESC_X_TEMP_VOLT + 0x1: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(512, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(112, V));
					break;
				case VESC_X_TEMP_VOLT + 0x2: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(513, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(113, V));
					break;
				case VESC_X_TEMP_VOLT + 0x3: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(514, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(114, V));
					break;
				case VESC_X_TEMP_VOLT + 0x4: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(515, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(115, V));
					break;
				case VESC_X_TEMP_VOLT + 0x5: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(516, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(116, V));
					break;
				case VESC_X_TEMP_VOLT + 0x6: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(517, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(117, V));
					break;
				case VESC_X_TEMP_VOLT + 0x7: // current for vesc speed controller [mA]
					T = data[0] << 24;
					T |= data[1] << 16;
					T |= data[2] << 8;
					T |= data[3];
					message.Add(new KeyValuePair<int, int>(518, T));
					V = data[4] << 24;
					V |= data[5] << 16;
					V |= data[6] << 8;
					V |= data[7];
					message.Add(new KeyValuePair<int, int>(118, V));
					break;
				default:
					Console.WriteLine("Recieved data from Ægir that is not handled");
					break;
			}


			KeyValuePair<int, int>[] test = new KeyValuePair<int, int>[3] { new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(2, 2), new KeyValuePair<int, int>(3, 3) };

			return test;
        }
	}
}