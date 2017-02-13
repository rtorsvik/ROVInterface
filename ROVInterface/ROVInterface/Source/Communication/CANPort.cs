using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

//ref.: https://msdn.microsoft.com/en-us/library/ctd56yay(v=vs.110).aspx
public class CANPort : Port
{

	private TcpClient client;
	private NetworkStream stream;
	private string _hostname;
	private int _port;

	private CommHandler.ConnectionStatus connectionStatus;
	private bool connectionEstablished;


	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="ipAddress"></param>
	/// <param name="ipPort"></param>
	public CANPort(string hostname, int port)
	{
		_hostname = hostname;
		_port = port;

		// Create a TcpClient.
		// Note, for this client to work you need to have a TcpServer 
		// connected to the same address as specified by the server, port
		// combination.
		client = new TcpClient(_hostname, _port);

		// Get a client stream for reading and writing.
		stream = client.GetStream();

		connectionEstablished = true;
	}

	

	/// <summary>
	/// Open the connection agaist initialized hostname and port number
	/// </summary>
	/// <returns>Returns true if connection is established</returns>
	public bool Open()
	{
		try
		{
			client.Connect(_hostname, _port);

			connectionEstablished = true;
			connectionStatus = CommHandler.ConnectionStatus.Connected;
		}
		catch (Exception CANConnectException)
		{
			Console.WriteLine("Could not open CAN bus connection\n\n Exception: " + CANConnectException.ToString());
		}

		// Get a client stream for reading and writing.
		stream = client.GetStream();

		//return true if the port managed to open
		return IsOpen();
	}



	/// <summary>
	/// Close establiched connection
	/// </summary>
	/// <returns></returns>
	public bool Close()
	{
		client.Close();
		stream.Close();

		connectionEstablished = false;
		connectionStatus = CommHandler.ConnectionStatus.NotConnected;

		//return true if the port has closed
		return !IsOpen();
	}



	/// <summary>
	/// Check if port is opened
	/// </summary>
	/// <returns>Returns true if the port is open, connection is established</returns>
	public bool IsOpen()
	{
		return client.Connected;
	}



	/// <summary>
	/// Get informetion on the status of the connection
	/// </summary>
	/// <returns></returns>
	public CommHandler.ConnectionStatus GetConnectionStatus()
	{
		if (connectionEstablished && IsOpen())
			connectionStatus = CommHandler.ConnectionStatus.Connected;

		else if (connectionEstablished && !IsOpen())
			connectionStatus = CommHandler.ConnectionStatus.Disconnected;

		else if (!connectionEstablished && !IsOpen())
			connectionStatus = CommHandler.ConnectionStatus.NotConnected;

		return connectionStatus;
	}



	public void Recieve<T>(object sender, T e)
	{
		throw new NotImplementedException();
	}



	/// <summary>
	/// Request a sertain value from the remote vehicle
	/// </summary>
	/// <param name="index"></param>
	public void Request(int index)
	{
		if (index == 10)
			Console.WriteLine("reading depth_temp");

		byte readIdentifyer = 0x01;

		byte startAddressHi = (byte)(index >> 8);
		byte startAddressLo = (byte)(index);

		byte numBytesHi = 0;
		byte numBytesLo = 8;

		byte[] packet = { readIdentifyer, startAddressHi, startAddressLo, numBytesHi, numBytesLo };

		// Send the message to the connected TcpServer. 
		stream.Write(packet, 0, packet.Length);

		//TEMP read response
		// Buffer to store the response bytes.
		byte[] response = new byte[9];

		//TEMP Read the first batch of the TcpServer response bytes.
		int numRecieved = stream.Read(response, 0, response.Length);

		KeyValuePair<int, int>[] status;
		status = CommHandler.AegirConvertData(index, response);

		foreach(KeyValuePair<int, int> s in status)
		{
			ST_Register.status[s.Key] = s.Value;
		}	
	}


	/// <summary>
	/// Send a message
	/// </summary>
	/// <param name="packet"></param>
	public void Send(byte[] packet)
	{
		// Send the message to the connected TcpServer. 
		stream.Write(packet, 0, packet.Length);

		//TEMP read response
		// Buffer to store the response bytes.
		byte[] response = new byte[255];

		//TEMP Read the first batch of the TcpServer response bytes.
		int numRecieved = stream.Read(response, 0, response.Length);

		string responseString = "{ ";
		for (int i = 0; i < numRecieved; i++)
		{
			responseString += response[i];
			if (i < numRecieved - 1)
				responseString += ", ";		
		}
		responseString += " }";
		Program.windowStatus.txt_comm_CANreply.Text = responseString;
	}



	public void Send(int index, int value)
	{
		throw new NotImplementedException();
	}

	public void Recieve(byte[] packet)
	{
		throw new NotImplementedException();
	}
}