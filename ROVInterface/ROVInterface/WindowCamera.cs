using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxAXVLC;
using System.IO;

using jh = JoystickHandler;
using Renci.SshNet;

//using jh = JoystickHandler;

public partial class WindowCamera : Form
{
	//MJPEGStream stream

    public WindowCamera()
    {
        InitializeComponent();

        //Make this screen appear on primary or seconodary screen by setting scrn =
        //  0, primary screen
        //  1, secondary screen
        int scrn = 1;

		//Show window on screen scrn only if the computer has this many screens 
		if(scrn < Screen.AllScreens.Length)
			this.Location = Screen.AllScreens[scrn].WorkingArea.Location;

		

    }



    private void WindowCamera_Load(object sender, EventArgs e)
    {


    }



	private void timer1_Tick(object sender, EventArgs e)
	{

	

	}

	private void btn_debug_1_Click(object sender, EventArgs e)
	{
		//reinitialize joysticks
		jh.Init();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		webBrowser1.Url = new System.Uri("http://explore.org/live-cams/player/shark-cam", System.UriKind.Absolute);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=r9y_yW9snug", System.UriKind.Absolute);
	}

	private void btn_cam1_Click(object sender, EventArgs e)
	{
		

	}

	private void btnStart_Click(object sender, EventArgs e)
	{
		
		using (var client = new SshClient("10.0.0.12", "pi", ""))
		{
			System.Threading.Thread.Sleep(100);
			client.Connect();
			System.Threading.Thread.Sleep(100);
			//client.RunCommand("raspivid -o - -t 0 -h 540 -w 960 -fps 25 -pf 10 -b 5000000 | nc -l 1235 &");
			client.RunCommand("raspivid -o - -t 0 -h 540 -w 960 -fps 25 | nc -l 1235 &");
			client.Disconnect();
		}



		vlcPlayer.playlist.playItem(vlcPlayer.playlist.add("tcp/h264://10.0.0.12:1235"));
	}

	private void btnStop_Click(object sender, EventArgs e)
	{
		using (var client = new SshClient("10.0.0.12", "pi", ""))
		{
			System.Threading.Thread.Sleep(100);
			client.Connect();
			System.Threading.Thread.Sleep(100);
			client.RunCommand("kill $(ps -e | grep raspivid| awk '{print $1}') &");
			client.Disconnect(); 
		}
			vlcPlayer.playlist.stop();
	}
}

