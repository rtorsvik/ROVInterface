using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using jh = JoystickHandler;

//using jh = JoystickHandler;

namespace ROVInterface
{
    public partial class WindowCamera : Form
    {
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

			//Update debug field
			//JoystickHandler jh = Program.jh;
			jh.update();

			//try { txt_debug_1.Text = "Joystick 0, axis 23: " + jh.joystick[0].axis[23]; } catch { }
			//try { txt_debug_2.Text = "Joystick 1, axis 23: " + jh.joystick[1].axis[23]; } catch { }
			//try { txt_debug_3.Text = "Joystick 1, button 1: " + jh.joystick[1].button[0]; } catch { }

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
	}
}
