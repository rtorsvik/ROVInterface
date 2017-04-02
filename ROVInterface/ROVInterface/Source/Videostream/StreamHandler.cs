using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class StreamHandler
{
	private static int STREAMNUM = 0; //Number of stream handlers constructed

	private string streamerIpAddress;
	private int streamerPort;

	private NamedPipeServerStream pipe;
	private string pipeName;
	private TcpClient streamer;
	private SshClient streamerCMD;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="ipAddress">IP address of streamer</param>
	/// <param name="port">On which port the stram is sendt</param>
	public StreamHandler(string ipAddress, int port)
	{
		pipeName = "pipe" + STREAMNUM;
		pipe = new NamedPipeServerStream(pipeName);

		streamerIpAddress = ipAddress;
		streamerPort = port;

		STREAMNUM++;
	}

	/// <summary>
	/// write summary
	/// </summary>
	/// <returns></returns>
	public string GetPipeName()
	{
		return pipeName;
	}

	/// <summary>
	/// write summary
	/// </summary>
	public void StartRaspividStream(int width, int height, int imageRotation)
	{
		string username = "pi";
		string password = "";
		streamerCMD = new SshClient(streamerIpAddress, username, password);
		streamerCMD.Connect();

		if (imageRotation < 0 || imageRotation > 359)
			throw new ArgumentOutOfRangeException(imageRotation + " was not a valid input for imagreRotation, value should be from 0...359");

		string command = "raspivid -o - -t 0";
		command += " -w " + width;
		command += " -h " + height;
		command += " -rot " + imageRotation;
		command += " -fps 25 | nc -l " + streamerPort; //+ " &";

		System.Threading.Thread.Sleep(1000);
		streamerCMD.RunCommand(command);
		streamerCMD.Disconnect();
	}

	//TEMP
	public void StartRaspividStream2(int width, int height, int imageRotation)
	{
		Action runCommand = () =>
		{
			string username = "pi";
			string password = "";
			SshClient client = new SshClient(streamerIpAddress, username, password);
			try
			{
				client.Connect();

				string command = "raspivid -o - -t 0";
				command += " -w " + width;
				command += " -h " + height;
				command += " -rot " + imageRotation;
				command += " -fps 25 | nc -l " + streamerPort; //+ " &";

				var terminal = client.RunCommand(command);

				//txtResult.Text = terminal.Result;
			}
			finally
			{
				client.Disconnect();
				client.Dispose();
			}
		};
		ThreadPool.QueueUserWorkItem(x => runCommand());
	}


	/// <summary>
	/// write summary DOES NOT WORK
	/// </summary>
	public void StartRapberryWebCamStream()
	{
		Action runCommand = () =>
		{
			string username = "pi";
			string password = "";
			SshClient client = new SshClient(streamerIpAddress, username, password);
			try
			{
				client.Connect();

				string command = "./ capturevideo - o - f - d / dev / video0 | nc - l ";
				command += streamerPort;

				var terminal = client.RunCommand(command);

				//txtResult.Text = terminal.Result;
			}
			finally
			{
				client.Disconnect();
				client.Dispose();
			}
		};
		ThreadPool.QueueUserWorkItem(x => runCommand());

	}

	/// <summary>
	/// Starts a connection to a streamer and continue to feed stream into pipe until streamer disconnects
	/// </summary>
	public void StartPiping()
	{
		pipe.WaitForConnection();
		StreamWriter sw = new StreamWriter(pipe);
		sw.AutoFlush = true;

		streamer = new TcpClient();
		streamer.Connect(streamerIpAddress, streamerPort);
		NetworkStream stream = streamer.GetStream();

		int read = 0;
		byte[] bytes = new byte[streamer.ReceiveBufferSize];
		while (streamer.Connected)
		{
			read = stream.Read(bytes, 0, streamer.ReceiveBufferSize);
			if (read > 0)
				pipe.Write(bytes, 0, read);
		}
	}





}

