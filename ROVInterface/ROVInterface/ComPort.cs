using System;
using System.IO.Ports;


class SerialConnection
{




    private SeriaPort port;

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
            MessageBox.Show("The specified port could not be found or opened", "Error", MessageBoxIcon.Error);
            Console.Write(e);
        }   
    }


    public bool Open()
    {
        port.Open();
    }


    public bool Close()
    {
        //TODO
        //close com port
    }


    public bool IsOpen()
    {
        return port.IsOpen();
    }





    public String GetPortName()
    {
        return port.PortName();
    }



    //Returns a list of all the available com ports with their names
    //ref.: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.getportnames(v=vs.110).aspx
    public static string[] GetPortList()
    {
        String[] list = SerialPort.GetPortNames();
    }



    public bool send(int intdex, float value)
    {
        //TODO
        //Send value according to which port/output channel to use 
        byte i1 = (index & 0x00f0) >> 8;
        byte i0 = (index & 0x000f) >> 0;
        
        byte v3 = (value & 0xf000) >> 24;
        byte v2 = (value & 0x0f00) >> 16;
        byte v1 = (value & 0x00f0) >> 8;
        byte v0 = (value & 0x000f) >> 0;

        port.Write([i1,i0,v3,v2,v1,v0], 0, 6);

        return true;
    }

    private bool recieve()
    {
        return true;
    }



}