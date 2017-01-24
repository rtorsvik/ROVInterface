using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

using st_reg = ST_Register;

class SerialConnection : Port
{

    private SerialPort port;

	private bool connectionOpened;
	private CommHandler.ConnectionStatus connectionStatus;

	private byte[] buffer;
	private int idx = 0;


	//Returns a list of all the available com ports with their names
	//ref.: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.getportnames(v=vs.110).aspx
	public static string[] GetPortList()
	{
		String[] list = SerialPort.GetPortNames();
		return list;
	}



	//Initialize a new serial connection with the given port number and baud rate
	//ref.: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
	public SerialConnection(string portName, int baudRate)
    {
        try
        {
            port = new SerialPort(portName, baudRate);
			port.DataReceived += new SerialDataReceivedEventHandler(Recieve);
        }
        catch (Exception e)
        {
            //ref.: https://msdn.microsoft.com/en-us/library/8bt1b81c(v=vs.110).aspx
            MessageBox.Show("The specified port could not be found or opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Program.errors.Add("The specified port could not be found or opened");
        }

		buffer = new byte[6];
    }



	/// <summary>
	/// Open the serial connection
	/// </summary>
    public bool Open()
    {
		try
		{
			connectionOpened = true;
			port.Open();
			
			connectionStatus = CommHandler.ConnectionStatus.Connected;
		}
		catch (UnauthorizedAccessException e)
		{
			Program.errors.Add("Cannot access com port. Comport might already be in use by another application");
		}
		catch (IOException)
		{
			Program.errors.Add("Cannot open com port. Spesified port might not exist");
		}

		//return true if the port managed to open
		return IsOpen();
				
    }



	/// <summary>
	/// Close the serial connection
	/// </summary>
	/// <returns>Returns true if the port was closed</returns>
    public bool Close()
    {
		port.Close();
		connectionOpened = false;
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
        return port.IsOpen;
    }



	/// <summary>
	/// Get informetion on the status of the connection
	/// </summary>
	/// <returns></returns>
	public CommHandler.ConnectionStatus GetConnectionStatus()
	{
		if(connectionOpened && IsOpen())
			connectionStatus = CommHandler.ConnectionStatus.Connected;

		else if (connectionOpened && !IsOpen())
			connectionStatus = CommHandler.ConnectionStatus.Disconnected;

		else if (!connectionOpened && !IsOpen())
			connectionStatus = CommHandler.ConnectionStatus.NotConnected;

		return connectionStatus;
	}


	/*
	/// <summary>
	/// Get com port name
	/// </summary>
	/// <returns>Returns the name of the port used</returns>
    public String GetPortName()
    {
        return port.PortName;
    }
	*/



	/// <summary>
	/// Send a message of 6 bytes. First two bytes represent index of the value, the next 4 bytes represent the value itself
	/// </summary>
	/// <param name="index">The index of the value to send</param>
	/// <param name="value">The value to send</param>
    public void Send(int index, int value)
    {
		//packet to send
        byte[] packet = new byte[6];

		//deconstruct index part of message into bytes
        packet[0] = (byte)(index >>  8);
        packet[1] = (byte)(index >>  0);

		//deconstruct value part of message into bytes
		packet[2] = (byte)(value >> 24);
		packet[3] = (byte)(value >> 16);
		packet[4] = (byte)(value >>  8);
		packet[5] = (byte)(value >>  0);

		//save latest message that was sendt
		CommHandler.messageSendt = CommHandler.PacketToByteString(packet);

		port.Write(packet, 0, 6);
		Program.windowStatus.tim_SendCommandsDelay.Start();
	}

	public void Send(byte[] packet)
	{
		//throw new NotImplementedException();

		//save latest message that was sendt
		CommHandler.messageSendt = CommHandler.PacketToByteString(packet);

		port.Write(packet, 0 , packet.Length);

	}



	/// <summary>
	/// Recieve message on event
	/// </summary>
	/// <typeparam name="SerialDataReceivedEventArgs"></typeparam>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	//ref.: https://code.msdn.microsoft.com/windowsdesktop/SerialPort-brief-Example-ac0d5004
	public void Recieve<SerialDataReceivedEventArgs>(object sender, SerialDataReceivedEventArgs e)
    {
		//Initialize a buffer to hold the received data 
		byte[] packet = new byte[port.ReadBufferSize];
		//byte[] packet = new byte[6];

		//There is no accurate method for checking how many bytes are read 
		//unless you check the return from the Read method 
		int bytesRead = port.Read(packet, 0, packet.Length);

		//add read bytes to buffer
		for (int i = 0; i < bytesRead; i++)
		{
			if (idx > 6) { idx = 0; Console.WriteLine("A - error in packet index"); return; }
			try
			{
				buffer[idx++] = packet[i];
			}
			catch (IndexOutOfRangeException)
			{
				Program.errors.Add("Serial recieve index error");
				Console.WriteLine("B - error in packet index");
			}
		}

		//if all the bytes are read
		if (idx >= 6)
		{
			idx = 0;

			//save latest message that was sendt
			CommHandler.messageRecieved = CommHandler.PacketToByteString(buffer);
		}



		//Save the recieved value to st_register
		//reconstruct index 
		int index;
		index = buffer[0] << 8; //index MSB
		index |= buffer[1]; //index LSB

		//reconstruct value
		int value;
		value = buffer[2] << 24;
		value |= buffer[3] << 16;
		value |= buffer[4] << 8;
		value |= buffer[5];

		st_reg.status[index] = value;

	}

	
}