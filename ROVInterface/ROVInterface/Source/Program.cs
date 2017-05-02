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

        Console.WriteLine(Application.StartupPath);

		//Program handlers and classes
		errors = new ErrorManager();
		JoystickHandler.Init();
		ST_Register.Init();
		ProgramSaverLoader.Init();
		//Database.Init();
		
		// TEST FUNCTION, only when here, normally ran from loading settings
		//Database.Connect();
		
		// Will run when loading settings, or never if the settings load fails
		//CommHandler.InitDllImport();



		//Sandbox
		//#############################################################################
		Avionics.HeadingIndicatorInstrumentControl h = new Avionics.HeadingIndicatorInstrumentControl();


		//KeyValuePair<int, int>[] kvp = new KeyValuePair<int, int>[2] { new KeyValuePair<int, int>(400, 0x0001), new KeyValuePair<int, int>(401, 32767) };
		//CommHandler.Send(kvp);
		//#############################################################################




		new WindowCamera().Show();
		windowStatus = new WindowStatus();
		windowStatus.FormClosing += ProgramSaverLoader.Save;
		Application.Run(windowStatus);
		
			
    }

	[System.Runtime.InteropServices.DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

	private const int WM_SETREDRAW = 11;

	public static void SuspendDrawing(Form form, bool shown) {
		if (!shown)
			return;
		SendMessage(form.Handle, WM_SETREDRAW, false, 0);
	}

	public static void ResumeDrawing(Form form, bool shown) {
		if (!shown)
			return;
		SendMessage(form.Handle, WM_SETREDRAW, true, 0);
		form.Refresh();
	}

	public static void MutexLock(bool LOCK) {
		while (LOCK) ;

		LOCK = true;
		return;
	}

	public static void MutexUnlock(bool LOCK) {
		LOCK = false;
		return;
	}
}