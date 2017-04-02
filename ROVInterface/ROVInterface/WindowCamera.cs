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

		//handle key press events
		this.KeyPreview = true;
		this.KeyUp += new KeyEventHandler(KeyPressEvent);

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
		webBrowser1.Visible = true;
		webBrowser1.Url = new System.Uri("http://explore.org/live-cams/player/shark-cam", System.UriKind.Absolute);

		pnl_video1.Location = new Point(12, 710);
		pnl_video2.Location = new Point(143, 710);
		pnl_video3.Location = new Point(274, 710);
		pnl_video4.Location = new Point(405, 710);
		pnl_video1.Size = small;
		pnl_video2.Size = small;
		pnl_video3.Size = small;
		pnl_video4.Size = small;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		webBrowser1.Visible = true;
		webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=r9y_yW9snug", System.UriKind.Absolute);

		pnl_video1.Location = new Point(12, 710);
		pnl_video2.Location = new Point(143, 710);
		pnl_video3.Location = new Point(274, 710);
		pnl_video4.Location = new Point(405, 710);
		pnl_video1.Size = small;
		pnl_video2.Size = small;
		pnl_video3.Size = small;
		pnl_video4.Size = small;
	}





	StreamHandler streamHandler1;
	MPlayer video1;
	private void btn_startCam1_Click(object sender, EventArgs e)
	{
		//TEMP ip and port of raspberry pi camera
		string ipAddress1 = "10.0.0.12";
		int port1 = 1235;

		streamHandler1 = new StreamHandler(ipAddress1, port1);
		video1 = new MPlayer(streamHandler1.GetPipeName(), pnl_video1);

		streamHandler1.StartRaspividStream2(960, 540, 270);
		video1.Start();
		if (!bgw_video1.IsBusy)
			bgw_video1.RunWorkerAsync();
	}

	StreamHandler streamHandler2;
	MPlayer video2;
	private void btn_startCam2_Click(object sender, EventArgs e)
	{
		//TEMP ip and port of raspberry pi camera
		string ipAddress2 = "10.0.0.13";
		int port2 = 1236;

		streamHandler2 = new StreamHandler(ipAddress2, port2);
		video2 = new MPlayer(streamHandler2.GetPipeName(), pnl_video2);

		streamHandler2.StartRaspividStream2(960, 540, 90);
		video2.Start();
		if (!bgw_video2.IsBusy)
			bgw_video2.RunWorkerAsync();
	}

	StreamHandler streamHandler3;
	MPlayer video3;
	private void btn_startCam3_Click(object sender, EventArgs e)
	{
		//TEMP ip and port of raspberry pi USB webcamera
		string ipAddress3 = "10.0.0.12";
		int port3 = 1237;

		streamHandler3 = new StreamHandler(ipAddress3, port3);
		video3 = new MPlayer(streamHandler3.GetPipeName(), pnl_video3, true);

		streamHandler3.StartRaspividStream2(960, 540, 0);
		video3.Start();
		if (!bgw_video3.IsBusy)
			bgw_video3.RunWorkerAsync();
	}

	private void bgw_video1_DoWork(object sender, DoWorkEventArgs e)
	{
		streamHandler1.StartPiping();
	}

	private void bgw_video2_DoWork(object sender, DoWorkEventArgs e)
	{
		streamHandler2.StartPiping();
	}

	private void bgw_video3_DoWork(object sender, DoWorkEventArgs e)
	{
		streamHandler3.StartPiping();
	}


	Size small = new Size(125, 90);
	Size large = new Size(1400, 692);
	private void pnl_video1_Click(object sender, EventArgs e)
	{
		enlargeVideo1();
	}

	private void pnl_video2_Click(object sender, EventArgs e)
	{
		enlargeVideo2();
	}

	private void pnl_video3_Click(object sender, EventArgs e)
	{
		enlargeVideo3();
	}

	private void pnl_video4_Click(object sender, EventArgs e)
	{
		enlargeVideo4();
	}

	private void enlargeVideo1()
	{
		pnl_video1.Location = new Point(12, 12);
		pnl_video2.Location = new Point(143, 710);
		pnl_video3.Location = new Point(274, 710);
		pnl_video4.Location = new Point(405, 710);

		pnl_video1.Size = large;
		pnl_video2.Size = small;
		pnl_video3.Size = small;
		pnl_video4.Size = small;
	}

	private void enlargeVideo2()
	{
		pnl_video1.Location = new Point(12, 710);
		pnl_video2.Location = new Point(12, 12);
		pnl_video3.Location = new Point(274, 710);
		pnl_video4.Location = new Point(405, 710);

		pnl_video1.Size = small;
		pnl_video2.Size = large;
		pnl_video3.Size = small;
		pnl_video4.Size = small;
	}

	private void enlargeVideo3()
	{
		pnl_video1.Location = new Point(12, 710);
		pnl_video2.Location = new Point(143, 710);
		pnl_video3.Location = new Point(12, 12);
		pnl_video4.Location = new Point(405, 710);

		pnl_video1.Size = small;
		pnl_video2.Size = small;
		pnl_video3.Size = large;
		pnl_video4.Size = small;
	}

	private void enlargeVideo4()
	{
		pnl_video1.Location = new Point(12, 710);
		pnl_video2.Location = new Point(143, 710);
		pnl_video3.Location = new Point(274, 710);
		pnl_video4.Location = new Point(12, 12);

		pnl_video1.Size = small;
		pnl_video2.Size = small;
		pnl_video3.Size = small;
		pnl_video4.Size = large;
	}

	void KeyPressEvent(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
			case Keys.F1:
				enlargeVideo1();
				break;

			case Keys.F2:
				enlargeVideo2();
				break;

			case Keys.F3:
				enlargeVideo3();
				break;

			case Keys.F4:
				enlargeVideo4();
				break;
		}

		
	}

	
}

