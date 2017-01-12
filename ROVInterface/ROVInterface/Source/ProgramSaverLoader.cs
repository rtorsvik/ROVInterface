using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ProgramSaverLoader {

	private static Reader reader;
	private const string path = "";

	public static void Init() {
		reader = new Reader(path);
	}

	public static void Load() {
		Console.WriteLine("Test write line");
		if (!reader.FindFileFromPath()) {
			// If the file was not found, print out a message and quit loading
			return;
		}

		// The file exists, read it and insert the read data into settings

	}

	public static void Save(object sender, EventArgs e) {
		
	}

	private class Reader {
		private string path;


		public Reader(string path) {
			this.path = path;
		}

		public bool FindFileFromPath() {

			return false;
		}
	}
}