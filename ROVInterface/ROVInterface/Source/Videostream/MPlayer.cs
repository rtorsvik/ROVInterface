using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class MPlayer
{
	Process mplayer; //prosess to tun mplayer

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="pipeName">The name of the NamedPipeServerStream pipe between the process that recieves videostream and the mplayer process</param>
	/// <param name="videoConrol">The control to output the videostrem, e.g. a panel control</param>
	public MPlayer(string pipeName, Control videoControl)
	{
		String args = ""; //arguments to send to the mplayer process

		mplayer = new Process();
		mplayer.StartInfo.UseShellExecute = false;
		mplayer.StartInfo.RedirectStandardInput = true;
		mplayer.StartInfo.CreateNoWindow = true;
		mplayer.StartInfo.FileName = Application.StartupPath + "/MPlayer/mplayer.exe";

		args = @"\\.\pipe\" + pipeName + " -demuxer +h264es -fps 120 -nosound -cache 512";
		args += " -nofs -noquiet -identify -slave ";
		args += " -nomouseinput -sub-fuzziness 1 ";
		args += " -vo direct3d, -ao dsound  -wid ";
		args += (int)videoControl.Handle;

		mplayer.StartInfo.Arguments = args;

	}

	public MPlayer(string pipeName, Control videoControl, bool USB)
	{
		String args = ""; //arguments to send to the mplayer process

		mplayer = new Process();
		mplayer.StartInfo.UseShellExecute = false;
		mplayer.StartInfo.RedirectStandardInput = true;
		mplayer.StartInfo.CreateNoWindow = true;
		mplayer.StartInfo.FileName = Application.StartupPath + "/MPlayer/mplayer.exe";

		args = @"\\.\pipe\" + pipeName + " -demuxer rawvideo -fps 60 -nosound -cache 512";
		args += " -nofs -noquiet -identify -slave ";
		args += " -nomouseinput -sub-fuzziness 1 ";
		args += " -vo direct3d, -ao dsound  -wid ";
		args += (int)videoControl.Handle;

		mplayer.StartInfo.Arguments = args;

	}

	public void Start()
	{
		//if a process is already running, kill it and start a new one
		/*
		if (!mplayer.HasExited)
			mplayer.Kill();
			*/

		//start the process (thus runs mplayer.exe and sends output to the selected control)
		mplayer.Start();

	}

	public void Stop()
	{
		//Stop the mplayer process
		mplayer.Kill();
	}

	public void SendCommand(string command)
	{
		if(!mplayer.HasExited)
		{
			mplayer.StandardInput.Write(command + "/n");
		}
	}

}

