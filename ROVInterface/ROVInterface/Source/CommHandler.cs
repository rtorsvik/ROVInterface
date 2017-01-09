using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class CommHandler
{

	private static SerialConnection serialConnection;

	public static void Init(string comPort, int baudRate)
	{
		serialConnection = new SerialConnection(comPort, baudRate);
	}
	

    public static bool Send(int index, float value)
    {
		//TODO
		//Send value according to which port/output channel to use
		serialConnection.send(index, value);


		return true;
    }

    private static bool Recieve()
    {
        return true;
    }



}

