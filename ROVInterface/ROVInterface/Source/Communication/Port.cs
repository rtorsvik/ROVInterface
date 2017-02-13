using System.IO.Ports;

public interface Port
{

	void Send(int index, int value);
	void Send(byte[] packet);
	void Recieve<T>(object sender, T e);
	void Recieve(byte[] packet);
	void Request(int index);

	bool IsOpen();
	bool Open();
	bool Close();

	CommHandler.ConnectionStatus GetConnectionStatus();

}