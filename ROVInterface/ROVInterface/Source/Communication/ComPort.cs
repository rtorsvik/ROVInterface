using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

using st_reg = ST_Register;

class SerialConnection
{

    private SerialPort port;

	public string messageSendt;
	public string messageRecieved;

	public byte[] buffer;
	public int idx = 0;

	/// <summary> 
	/// Holds data received until we get a terminator. 
	/// </summary> 
	private string tString = string.Empty;
	/// <summary> 
	/// End of transmition byte in this case EOT (ASCII 4). 
	/// </summary> 
	private byte _terminator = 0x4;



	//Initialize a new serial connection with the given port number and baud rate
	//ref.: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
	public SerialConnection(string portName, int baudRate)
    {
        try
        {
            port = new SerialPort(portName, baudRate);
			port.DataReceived += new SerialDataReceivedEventHandler(recieve);
        }
        catch (Exception e)
        {
            //TODO
            //Write error messaage/dialog
            //ref.: https://msdn.microsoft.com/en-us/library/8bt1b81c(v=vs.110).aspx
            MessageBox.Show("The specified port could not be found or opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.Write(e);
        }

		buffer = new byte[6];
    }


    public bool Open()
    {
		try
		{
			port.Open();
		}
		catch (UnauthorizedAccessException e)
		{
			Program.errors.Add("Cannot access com port. Comport might already be in use by another application");
		}

        return false;
    }


    public bool Close()
    {
		port.Close();
        return false;
    }

    public bool IsOpen()
    {
        return port.IsOpen;
    }





    public String GetPortName()
    {
        return port.PortName;
    }



    //Returns a list of all the available com ports with their names
    //ref.: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.getportnames(v=vs.110).aspx
    public static string[] GetPortList()
    {
        String[] list = SerialPort.GetPortNames();
        return list;
    }



    public void send(int index, int value)
    {
		//packet to send
        byte[] packet = new byte[6];

		//index part of package
        packet[0] = (byte)(index >>  8);
        packet[1] = (byte)(index >>  0);

		//value part of package
		packet[2] = (byte)(value >> 24);
		packet[3] = (byte)(value >> 16);
		packet[4] = (byte)(value >>  8);
		packet[5] = (byte)(value >>  0);

		//save latest message that was sendt
		messageSendt = PacketToString(packet);

		port.Write(packet, 0, 6);

    }

	//ref.: https://code.msdn.microsoft.com/windowsdesktop/SerialPort-brief-Example-ac0d5004
	private void recieve(object sender, SerialDataReceivedEventArgs e)
    {
		//Initialize a buffer to hold the received data 
		byte[] packet = new byte[port.ReadBufferSize];
		//byte[] packet = new byte[6];

		//There is no accurate method for checking how many bytes are read 
		//unless you check the return from the Read method 
		int bytesRead = port.Read(packet, 0, packet.Length);
		Console.WriteLine(bytesRead);


		//add read bytes to buffer
		for (int i = 0; i < bytesRead; i++)
		{
			buffer[idx++] = packet[i];
		}

		//if all the bytes are read
		if (idx >= 6)
		{
			idx = 0;

			//save latest message that was sendt
			messageRecieved = PacketToString(buffer);
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


		/*
		//For the example assume the data we are received is ASCII data. 
		tString += Encoding.ASCII.GetString(packet, 0, bytesRead);
		//Check if string contains the terminator  
		if (tString.IndexOf((char)_terminator) > -1)
		{
			//If tString does contain terminator we cannot assume that it is the last character received 
			string workingString = tString.Substring(0, tString.IndexOf((char)_terminator));
			
			//Remove the data up to the terminator from tString 
			tString = tString.Substring(tString.IndexOf((char)_terminator));
			
			//Do something with workingString 
			Console.WriteLine(workingString);
		}

		*/



	}



	private string PacketToString(byte[] packet)
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
}