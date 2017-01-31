using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ErrorManager {

	private int cursize = 0;
	private int maxsize = 8;
	private message[] errors;
	private bool updated;
	private bool runningtimer = false;
	private System.Windows.Forms.Timer timer;
	private const int decayTime = 10000;			// The minimum time a messeage is in the list
	private const int decayCooldownTime = 3000;	// The time between two messages to be allowed to be decayed

	public ErrorManager() {
		cursize = 0;
		errors = new message[maxsize];
		updated = true;
		timer = new System.Windows.Forms.Timer();
		timer.Stop();
		timer.Tick += Decay;
	}

	public bool HaveUpdated() {
		if (updated) {
			updated = false;
			return true;
		}
		return false;
	}

	public void Add(string s) {

		updated = false;

		for (int i = 0; i < cursize; i++) {
			if (errors[i].CompareString(s)) {
				for (int j = i; j < cursize - 1; j++)
					errors[j] = errors[j + 1];
				errors[cursize - 1] = new message(s);
				updated = true;
				break;
			}
		}

		// If no message got updated
		if (!updated) {
			if (cursize == maxsize) {
				// Update the size of the array if its full
				maxsize *= 2;
				message[] temp = new message[maxsize];
				for (int i = 0; i < cursize; i++)
					temp[i] = errors[i];
				errors = temp;
				temp = null;
			}
			cursize++;
			errors[cursize - 1] = new message(s);
		}

		updated = true;
		if (runningtimer)
			return;
		int ms = errors[0].timeleft;
		if (ms <= decayCooldownTime)
			timer.Interval = decayCooldownTime;
		else
			timer.Interval = ms;
		timer.Start();
		runningtimer = true;
	}

	public override string ToString() {
		string s = "";
		for (int i = 0; i < cursize-1; i++)
			s += "    " + errors[i].ToString() + "    |";
		if (cursize > 0)
			s += "    " + errors[cursize-1];
		return s;
	}

	private void Decay(object sender, EventArgs e) {
		timer.Stop();
		runningtimer = false;

		for (int i = 0; i < cursize; i++)
			errors[i].Decay(timer.Interval);

		// The first element have always fully decayed
		errors[0] = null;
		for (int i = 1; i < cursize; i++)
			errors[i - 1] = errors[i];
		cursize--;
		
		updated = true;
		if (cursize == 0)
			return;
		
		int ms = errors[0].timeleft;
		if (ms <= decayCooldownTime)
			timer.Interval = decayCooldownTime;
		else
			timer.Interval = ms;
		timer.Start();
		runningtimer = true;
	}

	private class message {

		private string msg;
		private int _timeleft;
		public int timeleft { get { return _timeleft; } }

		public message(string s) {
			msg = s;
			_timeleft = decayTime;
		}
		
		public void Decay(int ms) {
			_timeleft -= ms;
		}

		public bool CompareString(string s) {
			return (msg.CompareTo(s) == 0);
		}

		public override string ToString() {
			return msg;
		}
	}
}