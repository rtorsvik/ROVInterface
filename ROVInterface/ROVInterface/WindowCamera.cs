using System;
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
    public partial class WindowCamera : Form
    {
        public WindowCamera()
        {
            InitializeComponent();

            //Make this screen appear on primary or seconodary screen by setting scrn =
            //  0, primary screen
            //  1, secondary screen
            int scrn = 1;

            this.Location = Screen.AllScreens[scrn].WorkingArea.Location;

        }

        private void WindowCamera_Load(object sender, EventArgs e)
        {

        }
    }
}
