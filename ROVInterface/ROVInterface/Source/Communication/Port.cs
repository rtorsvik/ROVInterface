using System.IO.Ports;

public interface Connection
{

	void Send(int index, int value);
	void Send(byte[] packet);
	void Recieve<T>(object sender, T e);
	void Recieve(byte[] packet);
	void Request(int index);

	
	bool Open();
	bool Close();

	bool IsOpen();
	CommHandler.ConnectionStatus GetConnectionStatus();

}