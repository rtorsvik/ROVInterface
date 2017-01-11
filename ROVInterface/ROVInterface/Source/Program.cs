using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using System.IO.Ports;

namespace ROVInterface
{
    static class Program
    {
		public static WindowStatus windowStatus;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.Write("Red five, standing by\n");


            //Test field
            //#############################################################################
            String[] sl = SerialConnection.GetPortList();
			foreach (string s in sl)
			{
				Console.Write(s);
			}

			JoystickHandler.Init();
            //#############################################################################

            new WindowCamera().Show();
            Application.Run(windowStatus = new WindowStatus());

        }
    }
}
