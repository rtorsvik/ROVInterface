using System;
using System.Collections.Generic;
using System.IO;

/*
	Need to implement loading of JoystickSettings, and other buttons etc coming later.
	Need to implement saving of JoystickSettings, and other buttons etc coming later.
*/

public static class ProgramSaverLoader {

	private static Reader reader;
	private static DataHolder dataHolder;
	private const string path = ".\\Settings.xml";
	private const string EOF = "\0";

	public static void Init() {
		reader = new Reader(path);
	}

	public static void Load() {

		try { _Load(); }
		catch (Exception e) {
			Console.WriteLine(e);
			// Do something when the settings can't be loaded
		}
	}

	private static void _Load() {
		Console.WriteLine("Test write line");
		if (!reader.FindFileFromPath()) {
			// If the file was not found, print out a message and quit loading
			throw new FileNotFoundException();
		}
		dataHolder = new DataHolder();
		LoadPosition pos = LoadPosition.Start;
		bool fin = false;

		System.Threading.Thread.Sleep(10);

		// The file exists, read it and insert the read data into settings
		while (!reader.IsEmpty() && !fin) {
			//Console.WriteLine(reader.ReadNext());
			string next = reader.ReadNext();
			switch (pos) {
				case LoadPosition.Start:
					if (next == "<Settings>")
						pos = LoadPosition.Settings;
					else
						throw new Exception("Did not find root tag '<Settings>'.");
					break;
				case LoadPosition.Settings:
					switch (next) {
						case "<JoystickSettings>":
							pos = LoadPosition.JoystickSettings;
							break;
						case "<IndexSettings>":
							pos = LoadPosition.IndexSettings;
							break;
						case "<IndexStats>":
							pos = LoadPosition.IndexStats;
							break;
						case "</Settings>":
							fin = true;
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '<JoystickSettings>', '<IndexSettings>', '<IndexStats>' or '</Settings>'.");
					}
					break;
				case LoadPosition.JoystickSettings:
					switch (next) {
						case "</JoystickSettings>":
							pos = LoadPosition.Settings;
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '</JoystickSettings>'.");
					}
					break;
				case LoadPosition.JoystickSettingsChild:
					// Dunno yet
					break;
				case LoadPosition.IndexSettings:
					switch (next) {
						case "</IndexSettings>":
							pos = LoadPosition.Settings;
							break;
						case "<Setting>":
							pos = LoadPosition.IndexSettingsChild;
							dataHolder.cur_indexSetting = new DataHolder.indexSettings_Setting();
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '</IndexSettings>' or <Setting>.");
					}
					break;
				case LoadPosition.IndexSettingsChild:
					string s = dataHolder.cur_indexSetting.NextData();
					if (s == EOF) {
						// If a new object needs to be created
						dataHolder.indexSettings.Add(dataHolder.cur_indexSetting);
						//dataHolder.cur_indexSetting = null;
						pos = LoadPosition.IndexSettings;
					} else if (s == "") {
						// If a value needs to be inserted into dataholder
						dataHolder.cur_indexSetting.Insert(next);
					} else {
						// If a tag is needed to be compared
						if (s != next)
							throw new Exception("Did not find expected tag.");
					}
					break;
				case LoadPosition.IndexStats:
					switch (next) {
						case "</IndexStats>":
							pos = LoadPosition.Settings;
							break;
						case "<Stats>":
							pos = LoadPosition.IndexStatsChild;
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '</IndexStats>' or <Stats>.");
					}
					break;
				case LoadPosition.IndexStatsChild:
					dataHolder.indexStats.Add(int.Parse(next));
					if ((next = reader.ReadNext()) != "</Stats>")
						throw new Exception("Did not find correct closing tag, of '</Stats>'");
					pos = LoadPosition.IndexStats;
					break;
			}
		}

		Console.Write("Fin");

		for (int i = 0, j = dataHolder.indexSettings.Count; i < j; i++) {
			DataHolder.indexSettings_Setting d = dataHolder.indexSettings[i];
			ROVInterface.Program.windowStatus.indexSettings.CreateElement(d.index, d.name, d.digit, d.size);
		}
		for (int i = 0, j = dataHolder.indexStats.Count; i < j; i++) {
			int e = dataHolder.indexStats[i];
			ROVInterface.Program.windowStatus.indexStats.CreateElement(e);
		}
	}

	public static void Save(object sender, EventArgs e) {
		string src = "";
		src += "<Settings>\n";

		// Loop through and add JoystickSettings
		src += "	<JoystickSettings>\n";
			
		src += "	</JoystickSettings>\n";

		// Loop through and add IndexSettings
		src += "	<IndexSettings>\n";
		List<IndexSettings.Setting> li = ROVInterface.Program.windowStatus.indexSettings.allSettings;
		for (int i = 0, j = li.Count; i < j; i++) {
			src += "		<Setting>\n			<index>" + 
				li[i].index.Value + "</index><name>" + li[i].name.Text + "</name><digit>" + li[i].digit.Value + 
				"</digit><size>" + li[i].size.Value + "</size>\n		</Setting>\n";
		}
		src += "	</IndexSettings>\n";

		// Loop through and add IndexStats
		src += "	<IndexStats>\n";
		List<IndexStats.Stats> ls = ROVInterface.Program.windowStatus.indexStats.allStats;
		for (int i = 0, j = ls.Count; i < j; i++) {
			src += "		<Stats>" + ((IndexSettings.Setting)ls[i].index.SelectedItem).index.Value + "</Stats>\n";
		}
		src += "	</IndexStats>\n";

		src += "</Settings>";

		File.WriteAllText(path, src);
	}

	private class Reader {
		private string path;
		private string file;

		private int index = 0;
		private int filesize;

		/// <summary>
		/// Creating the reader with a path to its file to be read.
		/// </summary>
		public Reader(string path) {
			this.path = path;
			index = 0;
		}

		/// <summary>
		/// Opens the file and loads it into memory.
		/// </summary>
		public bool FindFileFromPath() {
			file = null;
			bool foundfile = false;
			try {

				if ((file = File.ReadAllText(path)) == null)
					foundfile = false;
				else {
					foundfile = true;
					filesize = file.Length;
				}
			} catch (Exception e) { foundfile = false; Console.Write(e); }

			return foundfile;
		}
		/// <summary>
		/// Reads the first element or tag, and returns it.
		/// </summary>
		public string ReadNext() {

			string f = "";
			bool fail = false;
			bool started = false;
			bool istag = false;

			while (true) {
				if (index == filesize)
					break;

				char c = file[index];

				if (!started) {
					// Has not yet started, skip past all empty spaces
					if (c == ' ' || c == '\t' || c == '\r' || c == '\n')
						index++;
					else {
						// Found the start of the next element
						if (c == '<')
							istag = true;
						f += c;
						index++;
						started = true;
					}
				} else {

					if (istag) {
						f += c;
						index++;
						if (c == '>')
							break;
					} else {
						if (c == '<')
							break;
						f += c;
						index++;
					}
				}
			}

			return (fail ? "" : f);
		}

		/// <summary>
		/// Restarts the reader, so that the next read is from the start
		/// </summary>
		public void Restart() {
			index = 0;
		}

		/// <summary>
		/// Returns if the file is read to the end.
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty() {
			return (index == filesize ? true : false);
		}

		/// <summary>
		/// Closes the file so it stops hogging memory.
		/// </summary>
		public void CloseFile() {
			file = null;
			GC.Collect();
		}
		
		public void Print() {
			Console.Write(file);
		}
	}

	private class DataHolder {
		private List<int> joystickSettings;
		public List<indexSettings_Setting> indexSettings;
		public indexSettings_Setting cur_indexSetting;
		public List<int> indexStats;

		public DataHolder() {
			cur_indexSetting = new indexSettings_Setting();
			indexSettings = new List<indexSettings_Setting>();
			indexStats = new List<int>();
		}

		public class indexSettings_Setting {
			public int index;
			public string name;
			public int digit;
			public int size;

			private bool waitforval = false;
			private int readindex = 0;
			private readonly string[] req = { "<index>", "</index>", "<name>", "</name>", "<digit>", "</digit>", "<size>", "</size>" };

			public string NextData() {
				if (readindex == req.Length)
					return EOF;

				if (waitforval) {
					waitforval = false;
					return "";
				}
				waitforval = (readindex % 2 == 0 ? true : false);
				return req[readindex++];
			}

			public void Insert(string s) {
				switch (readindex) {
					case 1:
						index = int.Parse(s);
						break;
					case 3:
						name = s;
						break;
					case 5:
						digit = int.Parse(s);
						break;
					case 7:
						size = int.Parse(s);
						break;
				}
			}
		}
	}

	private enum LoadPosition {
		Start = 0,
		Settings = 1,
		JoystickSettings = 2,
		JoystickSettingsChild = 3,
		IndexSettings = 4,
		IndexSettingsChild = 5,
		IndexStats = 6,
		IndexStatsChild = 7
	}
}