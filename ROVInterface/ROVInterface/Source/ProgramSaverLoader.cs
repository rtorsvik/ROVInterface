using System;
using System.IO;

public static class ProgramSaverLoader {

	private static Reader reader;
	private const string path = ".\\Settings.xml";

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
		reader.Print();
	}

	public static void Save(object sender, EventArgs e) {
		
	}

	private class Reader {
		private string path;
		private string file;

		public Reader(string path) {
			this.path = path;
		}

		public bool FindFileFromPath() {
			bool foundfile = false;
			try {

				if ((file = File.ReadAllText(path)) == null)
					foundfile = false;
				else
					foundfile = true;
			} catch (Exception e) { foundfile = false; Console.Write(e); }

			return foundfile;
		}

		public void Print() {
			Console.Write(file);
		}
	}
}