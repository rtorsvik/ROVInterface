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
		streamerIpAddress = ipAddress;
		streamerPort = port;

		// TESTING STUFF

		// Send command to kill raspivid command
		SSHInitRaspivid("pi", "raspberry");

		// TESTING STUFF

		streamID = STREAMNUM;
		STREAMNUM++;

		pipeName = "pipe" + STREAMNUM;
		pipe = new NamedPipeServerStream(pipeName);

		

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

	private void SSHInitRaspivid(string sshUser, string sshPass) {
		SshClient client = new SshClient(streamerIpAddress, sshUser, sshPass);
		bool connected = false;
		try {
			client.Connect();
			connected = true;
		} catch (Exception e) { Console.WriteLine(e); }

		if (connected) {

			var terminalFindProcess = client.RunCommand("pgrep raspivid");
			if (terminalFindProcess.Result.CompareTo("") != 0) {
				var terminalKillProcess = client.RunCommand("pkill raspivid");
			}
			client.Disconnect();
		}
		client.Dispose();
	}

	//TEMP
	public void StartRaspividStream(string sshUser, string sshPass, int width, int height, int imageRotation)
	{
		Action runCommand = () =>
		{
			SshClient client = new SshClient(streamerIpAddress, sshUser, sshPass);
			try
			{
				bool connected = false;
				try
				{
					client.Connect();
					connected = true;
				}
				catch { }

				if (connected) {

					// Command to reset/fix rasperyvid
					//string command = "pkill raspivid";
					string command = "pgrep raspivid";
					command = "kill -s SIGUSR2 " + client.RunCommand(command).Result;
					var terminalpkill = client.RunCommand(command);

					// Command to start video stream
					command = "raspivid -o - -t 0";
					command += " -w " + width;
					command += " -h " + height;
					command += " -rot " + imageRotation;
					command += " -fps 25 | nc -l " + streamerPort; //+ " &";

					var terminal = client.RunCommand(command);
					//Program.errors.Add("Result: " + terminal.Result);

					//txtResult.Text = terminal.Result;
				}
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

