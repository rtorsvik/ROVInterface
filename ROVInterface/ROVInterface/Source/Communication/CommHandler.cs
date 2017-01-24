using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public static class CommHandler
{
	public enum ConnectionStatus { NotConnected, Connected, Disconnected }
	public static Port port;
	public static bool initialized;

	public static string messageSendt;
	public static string messageRecieved;



	//initialise a serial connection
	public static void InitSerial(string comPort, int baudRate)
	{
		port = new SerialConnection(comPort, baudRate);
		initialized = true;
	}



	//initialise an ethernet connection
	public static void InitEthernet(string comPort, int baudRate)
	{
		throw new NotImplementedException();
		initialized = true;
	}
    


	//initialise an ethernet connection
	public static void InitCAN(string comPort, int baudRate)
	{
		throw new NotImplementedException();
		initialized = true;
	}



	//initialise a connection against UIS Subsea ÆGIR ROV
	public static void InitAEGIR(string comPort, int baudRate)
	{
		throw new NotImplementedException();
		initialized = true;
	}


	/// <summary>
	/// Send single command
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
    /*public static void Send(int index, int value)
    {
		// ***** DEPRECATED *****************
        // Packet to be sent forward
        byte[] packet = new byte[6];
        bool fail = false;
		
		
        try {
            packet = AEgir.main.ConvertCommands((ushort)index, value);
        } catch (Exception e) {
            fail = true;
        }

		if (fail) {
            //deconstruct index part of message into bytes
            packet[0] = (byte)(index >> 8);
            packet[1] = (byte)(index >> 0);

            //deconstruct value part of message into bytes
            packet[2] = (byte)(value >> 24);
            packet[3] = (byte)(value >> 16);
            packet[4] = (byte)(value >> 8);
            packet[5] = (byte)(value >> 0);
        }

        port.Send(packet);
    }*/



	public static void Send(KeyValuePair<int, int>[] commands)
	{
		// Packet to be sent forward
		byte[] packet = new byte[0];
		bool fail = false;

		try {
			packet = AEgir.main.ConvertCommands(commands);
		} catch (Exception e) {
			fail = true;
		}

		if (fail) {
			packet = new byte[commands.Length * 6];
			for (int i = 0, j = commands.Length, cur; i < j; i++) {
				cur = i * 6;
				packet[cur + 0] = (byte)(commands[i].Key >> 8);
				packet[cur + 1] = (byte)(commands[i].Key >> 0);

				packet[cur + 2] = (byte)(commands[i].Value >> 24);
				packet[cur + 3] = (byte)(commands[i].Value >> 16);
				packet[cur + 4] = (byte)(commands[i].Value >> 8);
				packet[cur + 5] = (byte)(commands[i].Value >> 0);
			}
		} else if (packet == null || packet.Length == 0) {
			Program.windowStatus.tim_SendCommandsDelay.Start();
			return;
		}

		port.Send(packet);
	}

	


	private static void Recieve(byte[] package)
    {
		throw new NotImplementedException("Recieve-method is not implemented, an maybe shoukld not be eighter, remove this later if not.");
    }



	/// <summary>
	/// Converts the packet into a strong that represents each byte in the packet array
	/// </summary>
	/// <param name="packet">the packet containing the bytes of a message</param>
	/// <returns>Returns a string</returns>
	public static string PacketToByteString(byte[] packet)
	{
		int packet_length = 6;
		string s = "[";
		for (int i = 0; i < packet_length; i++)
		{
			s += packet[i];
			if (i != packet_length - 1)
				s += ", ";
		}
		s += "]";

		return s;
	}




	public static bool Open()
	{
		return port.Open();
	}

	public static bool Close()
	{
		return port.Close();
	}

	public static bool IsOpen()
	{
		return port.IsOpen();
	}

	public static ConnectionStatus GetConnectionStatus()
	{
		return port.GetConnectionStatus();
	}








	/// <summary>
	/// Converts the packet into a strong that represents each byte in the packet array
	/// </summary>
	/// <param name="packet">the packet containing the bytes of a message</param>
	/// <returns>Returns a string</returns>
	public static string PacketToHEXString(byte[] packet)
	{
		int packet_length = 6;
		StringBuilder s = new StringBuilder();
		s.Append("[");
		for (int i = 0; i < packet_length; i++)
		{
			s.AppendFormat("0x{0:x2}", packet[i]);
			if (i != packet_length - 1)
				s.Append(", ");
		}
		s.Append("]");

		return s.ToString();
	}



	/// <summary>
	/// Converts the packet into a string that represents the index and the value of a message
	/// </summary>
	/// <param name="packet">the packet containing the bytes of a message</param>
	/// <returns>Returns a string</returns>
	public static string PacketToString(byte[] packet)
	{
		int index;
		index = packet[0] << 8;
		index |= packet[1];

		int value;
		value = packet[2] << 24;
		value |= packet[3] << 16;
		value |= packet[4] << 8;
		value |= packet[5];

		return "[" + index + ", " + value + "]";
	}


}

