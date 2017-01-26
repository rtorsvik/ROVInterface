using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
	/*
	 * Class needs two functions and a name:
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


	
		//Identifyers
		private const int TOP_XBOX_CTRLS = 0x200;
		private const int TOP_XBOX_AXES = 0x201;
		private const int TOP_POWR_CTRL = 0x202;
		private const int TOP_REG_PARAM1 = 0x203;
		private const int TOP_REG_PARAM2 = 0x204;
		private const int TOP_SENS_CTRL = 0x205;

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
		private static byte[] TOP_REG_PARAM1_cache = new byte[6];
		private static byte[] TOP_REG_PARAM2_cache = new byte[5];




		/// <summary>
		/// Converts a set of commands into the right format before sending
		/// </summary>
		/// <param name="commands">Set of commands</param>
		/// <returns>byte array in the right format</returns>
		public static byte[] ConvertCommands(KeyValuePair<int, int>[] commands)
		{
			Dictionary<int, byte[]> message = new Dictionary<int, byte[]>(); //messages to send, key representing identifyer and value reperenting the bytes

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
				switch (p.Key)
				{
					case 1: //surge

						//If the message is not alreadu created by another command, create a new message with the cached commands
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;

						//Overwrite message and replace cached values with the new ones
						message[TOP_XBOX_CTRLS][0] = TOP_XBOX_CTRLS_cache[0] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][1] = TOP_XBOX_CTRLS_cache[1] = (byte)(p.Value << 8);

						break;

					case 2: //sway
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;
						message[TOP_XBOX_CTRLS][2] = TOP_XBOX_CTRLS_cache[2] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][3] = TOP_XBOX_CTRLS_cache[3] = (byte)(p.Value << 8);
						break;
					case 3: //heave
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;
						message[TOP_XBOX_CTRLS][4] = TOP_XBOX_CTRLS_cache[4] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][5] = TOP_XBOX_CTRLS_cache[5] = (byte)(p.Value << 8);
						break;
					case 4: //pitch
						if (!message.ContainsKey(TOP_XBOX_CTRLS))
							message[TOP_XBOX_CTRLS] = TOP_XBOX_CTRLS_cache;
						message[TOP_XBOX_CTRLS][6] = TOP_XBOX_CTRLS_cache[6] = (byte)p.Value; 
						message[TOP_XBOX_CTRLS][7] = TOP_XBOX_CTRLS_cache[7] = (byte)(p.Value << 8);
						break;
					case 5: //roll
						if (!message.ContainsKey(TOP_XBOX_AXES))
							message[TOP_XBOX_AXES] = TOP_XBOX_AXES_cache;
						message[TOP_XBOX_AXES][0] = TOP_XBOX_AXES_cache[0] = (byte)p.Value; 
						message[TOP_XBOX_AXES][1] = TOP_XBOX_AXES_cache[1] = (byte)(p.Value << 8);
						break;
					case 6: //yaw
						if (!message.ContainsKey(TOP_XBOX_AXES))
							message[TOP_XBOX_AXES] = TOP_XBOX_AXES_cache;
						message[TOP_XBOX_AXES][2] = TOP_XBOX_AXES_cache[2] = (byte)p.Value; 
						message[TOP_XBOX_AXES][3] = TOP_XBOX_AXES_cache[3] = (byte)(p.Value << 8);
						break;
					case 100: //Set motors and coolingfan in auto or manual mode (turn them on or off)
						if (!message.ContainsKey(TOP_POWR_CTRL))
							message[TOP_POWR_CTRL] = TOP_POWR_CTRL_cache;
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] += (byte)(p.Value & 0x1);
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] += (byte)(p.Value & 0x4);
						break;
					case 400: //Turn light on
						if (!message.ContainsKey(TOP_POWR_CTRL))
							message[TOP_POWR_CTRL] = TOP_POWR_CTRL_cache;
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] += (byte)((p.Value & 0x1) << 1);
						break;
					case 401: //Turn light on
						if (!message.ContainsKey(TOP_POWR_CTRL))
							message[TOP_POWR_CTRL] = TOP_POWR_CTRL_cache;
						byte intensity = (byte)((p.Value + 32768) * 10 / 65535f);
						message[TOP_POWR_CTRL][0] = TOP_POWR_CTRL_cache[0] += (byte)(intensity << 3);
						break;
					default:
						break;
				}

			}

			

			return null;

			

		}



		/// <summary>
		/// Converts a set of recieved data to the right format before accepting them  
		/// </summary>
		/// <param name="b">recieved data</param>
		/// <returns>KeyValuePair containing recieved data in the right format</returns>
		public static KeyValuePair<int, int>[] ConvertData(byte[] b)
		{

			return null;
        }
	}
}