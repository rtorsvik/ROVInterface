using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class CommHandler
{
	public enum ConnectionStatus { NotConnected, Connected, Disconnected }
	private static Port port;



	//initialise a serial connection
	public static void InitSerial(string comPort, int baudRate)
	{
		port = new SerialConnection(comPort, baudRate);
	}



	//initialise an ethernet connection
	public static void InitEthernet(string comPort, int baudRate)
	{
		throw new NotImplementedException();
	}



	//initialise an ethernet connection
	public static void InitCAN(string comPort, int baudRate)
	{
		throw new NotImplementedException();
	}



	//initialise a connection against UIS Subsea ÆGIR ROV
	public static void InitAEGIR(string comPort, int baudRate)
	{
		throw new NotImplementedException();
	}



	public static void Send(int index, int value)
    {
		port.Send(index, value);
    }



    private static void Recieve()
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

