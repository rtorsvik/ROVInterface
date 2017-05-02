using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class DatabaseDeprecated {

	private static Timer timer;
	private static BackgroundWorker bgw;

	/// <summary>
	/// Initialize the Database class
	/// </summary>
	public static void Init() {
		timer = new Timer();
		timer.Tick += TimerSend;
		bgw = new BackgroundWorker();
		bgw.DoWork += bgwSend;
	}

	public static void LoadSettings() {


		// Try to connect after loading settings
		Connect();
	}

	public static void SetTimerDelayMS(int ms) {
		ms = (ms < 10 ? 10 : ms);
		timer.Interval = ms;
	}

	/// <summary>
	/// Connect to the database with the set up settings
	/// </summary>
	public static void Connect() {
		using (SqlConnection connection = new SqlConnection()) {
			connection.ConnectionString =	"server=127.0.0.1,3306;Integrated Security=false;User ID=root;Password=root;" +
											"Connection Timeout=5;";
			//connection.ConnectionString = "Server=tcp:(local), 3306;Database=rovinterface;UID=root;PWD=root;" +
			//								 "Connection Timeout=5;";
			// con.ConnectionString = "Server=127.0.0.1;Database=StudentTravelPlannerDB;Uid=STPUser;Pwd=CORRECT_PASSWORD;";

			try {
				Console.WriteLine(connection.ConnectionTimeout);
				connection.Open();
			} catch (Exception e) { Console.WriteLine(e); }

			Console.WriteLine("State: {0}", connection.State);
			Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);
		}
	}

	/// <summary>
	/// Disconnect from the connected database
	/// </summary>
	public static void Disconnect() {

	}

	/// <summary>
	/// Start the timer to start sending data
	/// </summary>
	public static void StartSending() {
		timer.Start();
	}

	/// <summary>
	/// Stop the timer to stop sending data
	/// </summary>
	public static void StopSending() {
		timer.Stop();
	}

	/// <summary>
	/// The timer event called from the timer
	/// </summary>
	private static void TimerSend(object sender, EventArgs e) {
		bgw.RunWorkerAsync();
	}

	/// <summary>
	/// The sending function ran by a backgroundworker
	/// </summary>
	private static void bgwSend(object sender, DoWorkEventArgs e) {

	}
}