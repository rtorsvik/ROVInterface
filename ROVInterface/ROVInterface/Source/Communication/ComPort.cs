using System;
using System.IO.Ports;
using System.Windows.Forms;

class SerialConnection
{

    private SerialPort port;

    //Initialize a new serial connection with the given port number and baud rate
    //ref.: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
    public SerialConnection(string portName, int baudRate)
    {
        try
        {
            port = new SerialPort(portName, baudRate);
        }
        catch (Exception e)
        {
            //TODO
            //Write error messaage/dialog
            //ref.: https://msdn.microsoft.com/en-us/library/8bt1b81c(v=vs.110).aspx
            MessageBox.Show("The specified port could not be found or opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.Write(e);
        }   
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



    public bool send(int index, int value)
    {
		//packet to send
        byte[] packet = new byte[6];

		//index part of package
        packet[0] = (byte)((index & 0x00f0) >>  8);
        packet[1] = (byte)((index & 0x000f) >>  0);

		//value part of package
		packet[2] = (byte)((value & 0xf000) >> 24);
		packet[3] = (byte)((value & 0x0f00) >> 16);
		packet[4] = (byte)((value & 0x00f0) >>  8);
		packet[5] = (byte)((value & 0x000f) >>  0);

		Program.WindowStatus.tab

        port.Write(packet, 0, 6);

        return true;
    }

    private bool recieve()
    {
        return false;
    }



}