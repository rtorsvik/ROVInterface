using System;

public class CANPort : Port
{
	public CANPort()
	{
		throw new NotImplementedException();
	}

	public bool Close()
	{
		throw new NotImplementedException();
	}

	public CommHandler.ConnectionStatus GetConnectionStatus()
	{
		throw new NotImplementedException();
	}

	public bool IsOpen()
	{
		throw new NotImplementedException();
	}

	public bool Open()
	{
		throw new NotImplementedException();
	}

	public void Recieve<T>(object sender, T e)
	{
		throw new NotImplementedException();
	}

	public void Send(byte[] packet)
	{
		throw new NotImplementedException();
	}

	public void Send(int index, int value)
	{
		throw new NotImplementedException();
	}
}