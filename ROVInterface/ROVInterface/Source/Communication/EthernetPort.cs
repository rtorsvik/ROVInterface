using System;
using System.Net;
using System.Net.Sockets;

public class EthernetPort : Port
{






	public EthernetPort(IPAddress ip)
	{
		try
		{
			// Create one SocketPermission for socket access restrictions  
			SocketPermission permission = new SocketPermission(
				NetworkAccess.Connect,    // Connection permission  
				TransportType.Tcp,        // Defines transport types  
				"",                       // Gets the IP addresses  
				SocketPermission.AllPorts // All ports  
				);

			// Ensures the code to have permission to access a Socket  
			permission.Demand();

			// Resolves a host name to an IPHostEntry instance             
			IPHostEntry ipHost = Dns.GetHostEntry("");

			// Gets first IP address associated with a localhost  
			IPAddress ipAddr = ipHost.AddressList[0];

			// Creates a network endpoint  
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 4510);

			// Create one Socket object to setup Tcp connection  
			Socket senderSock = new Socket(
				ipAddr.AddressFamily,// Specifies the addressing scheme  
				SocketType.Stream,   // The type of socket   
				ProtocolType.Tcp     // Specifies the protocols   
				);

			senderSock.NoDelay = false;   // Using the Nagle algorithm  

			// Establishes a connection to a remote host  
			senderSock.Connect(ipEndPoint);
			Console.WriteLine("Socket connected to " + senderSock.RemoteEndPoint.ToString());
		}
		catch (Exception exc) { Console.WriteLine(exc.ToString()); }
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

		/*
		try
		{
			// Sending message  
			//<Client Quit> is the sign for end of data  
			string theMessageToSend = tbMsg.Text;
			byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + "<Client Quit>");/// 

			// Sends data to a connected Socket.  
			int bytesSend = senderSock.Send(msg);

			ReceiveDataFromServer();
		}
		catch (Exception exc) { MessageBox.Show(exc.ToString()); }
		*/
	}

	public void Send(int index, int value)
	{
		throw new NotImplementedException();
	}
}