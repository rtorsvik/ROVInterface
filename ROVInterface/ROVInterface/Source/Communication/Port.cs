using System.IO.Ports;

public interface Port
{

	void Send(int index, int value);
	void Recieve<T>(object sender, T e);

	bool IsOpen();
	bool Open();
	bool Close();

	CommHandler.ConnectionStatus GetConnectionStatus();

}