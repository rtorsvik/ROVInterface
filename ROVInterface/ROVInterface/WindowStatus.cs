﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROVInterface
{
    public partial class WindowStatus : Form
    {
        public WindowStatus()
        {
            InitializeComponent();

            //Make this screen appear on primary or seconodary screen by setting scrn =
            //  0, primary screen
            //  1, secondary screen
            int scrn = 0;

            this.Location = Screen.AllScreens[scrn].WorkingArea.Location;
        }

        private void WindowStatus_Load(object sender, EventArgs e)
        {


            //Test
            //add elements to com port combobox
            cmb_comport.Items.AddRange(SerialConnection.GetPortList());

        }

		private void btn_connect_serial_Click(object sender, EventArgs e)
		{
			//temp, should be replaced with comm handler later
			SerialConnection serialConnection = new SerialConnection(cmb_comport.SelectedItem.ToString(), int.Parse(cmb_baudrate.SelectedItem.ToString()));
			serialConnection.Open();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

		}
	}
}
