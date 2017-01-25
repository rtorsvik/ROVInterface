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
	public static List<string> errors;

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
		errors = new List<string>();

		//#############################################################################





		
		//Program handlers and classes
		JoystickHandler.Init();
		ST_Register.Init();
		ProgramSaverLoader.Init();
		CommHandler.InitDllImport();
            

        new WindowCamera().Show();
		windowStatus = new WindowStatus();
		windowStatus.FormClosing += ProgramSaverLoader.Save;
		Application.Run(windowStatus);
		
			
    }
}

