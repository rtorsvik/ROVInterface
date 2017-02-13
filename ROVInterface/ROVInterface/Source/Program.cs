using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using System.IO.Ports;



static class Program
{
	public static WindowStatus windowStatus;
	public static ErrorManager errors;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);



		//Program handlers and classes
		errors = new ErrorManager();
		JoystickHandler.Init();
		ST_Register.Init();
		ProgramSaverLoader.Init();
		CommHandler.InitDllImport();



		//Sandbox
		//#############################################################################
		


		//KeyValuePair<int, int>[] kvp = new KeyValuePair<int, int>[2] { new KeyValuePair<int, int>(400, 0x0001), new KeyValuePair<int, int>(401, 32767) };
		//CommHandler.Send(kvp);
		//#############################################################################




		new WindowCamera().Show();
		windowStatus = new WindowStatus();
		windowStatus.FormClosing += ProgramSaverLoader.Save;
		Application.Run(windowStatus);
		
			
    }
}

