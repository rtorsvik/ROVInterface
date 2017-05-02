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
	private int streamID;

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
		streamID = STREAMNUM;
		STREAMNUM++;

		pipeName = "pipe" + STREAMNUM;
		pipe = new NamedPipeServerStream(pipeName);

		streamerIpAddress = ipAddress;
		streamerPort = port;

		streamer = new TcpClient();
	}

	/// <summary>
	/// write summary
	/// </summary>
	/// <returns></returns>
	public string GetPipeName()
	{
		return pipeName;
	}

	
	//TEMP
	public void StartRaspividStream(string sshUser, string sshPass, int width, int height, int imageRotation)
	{
		Action runCommand = () =>
		{
			SshClient client = new SshClient(streamerIpAddress, sshUser, sshPass);
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
		StreamWriter streamWriter = new StreamWriter(pipe);
		streamWriter.AutoFlush = true;

		streamer.Connect(streamerIpAddress, streamerPort);
		NetworkStream stream = streamer.GetStream();

		int read = 0;
		byte[] bytes = new byte[streamer.ReceiveBufferSize];
		while (streamer.Connected)
		{
			try
			{
				read = stream.Read(bytes, 0, streamer.ReceiveBufferSize);
				if (read > 0)
					pipe.Write(bytes, 0, read);
			}
			catch { }
		}
	}





}

