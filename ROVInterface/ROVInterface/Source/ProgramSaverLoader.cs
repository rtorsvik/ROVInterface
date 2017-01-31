using System;
using System.Collections.Generic;
using System.IO;

public static class ProgramSaverLoader {

	private static Reader reader;
	private static DataHolder dataHolder;
	private const string path = ".\\Settings.xml";
	private const string EOF = "\0";

	public static void Init() {
		reader = new Reader(path);
	}

	public static void Load() {

		dataHolder = new DataHolder();

		try { _LoadGraphicsPrototype(); }
		catch (Exception e) {
			Console.WriteLine(e);
			Program.errors.Add("Failed to load Graphics Prototype.");
		}

		try { _Load(); }
		catch (Exception e) {
			Console.WriteLine(e);
			Program.errors.Add("Failed to load settings.");
		}
	}

	private static void _LoadGraphicsPrototype() {
		Reader r = new Reader(".\\Graphics\\Graphics.xml");
		if (!r.FindFileFromPath()) {
			throw new FileNotFoundException();
		}
		bool fin = false;
		LoadPositionGraphics pos = LoadPositionGraphics.gStart;

		while (!r.IsEmpty() && !fin) {
			string next = r.ReadNext();
			switch (pos) {
				case LoadPositionGraphics.gStart:
					if (next == "<Graphics>")
						pos = LoadPositionGraphics.gGraphics;
					else
						throw new Exception("Did not find root tag '<Graphics>'");
					break;
				case LoadPositionGraphics.gGraphics:
					switch(next) {
						case "<Object>":
							pos = LoadPositionGraphics.gObject;
							dataHolder.cur_graphicSetting = new DataHolder.graphics_Object();
							break;
						case "</Graphics>":
							fin = true;
							break;
						default:
							pos = LoadPositionGraphics.gObject;
							dataHolder.cur_graphicSetting = new DataHolder.graphics_Object();

							if (string.Compare(next, 0, "<Object img=\"", 0, 13) == 0 && next[next.Length-1] == '>' && next[next.Length-2] == '"') { // If start with that string, and ends with '">'
								dataHolder.cur_graphicSetting.image = next.Substring(13, next.Length - 15);
							} else
								throw new Exception("Did not find '<Object>', '<Objects img=\"%%\">' or '</Graphics>' tag.");
							break;
					}
					break;
				case LoadPositionGraphics.gObject:
					switch(next) {
						case "<Index>":
							pos = LoadPositionGraphics.gIndex;
							dataHolder.cur_graphicSetting.Insert(next);
							break;
						case "</Object>":
							pos = LoadPositionGraphics.gGraphics;
							dataHolder.graphicSettings.Add(dataHolder.cur_graphicSetting);
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '<Index>' or '</Object>'.");
					}
					break;
				case LoadPositionGraphics.gIndex:
					dataHolder.cur_graphicSetting.Insert(next);
					if (next == "</Index>")
						pos = LoadPositionGraphics.gObject;
					break;
				default:
					break;
			}
		}
		int j = dataHolder.graphicSettings.Count;
		GraphicsCreator.graphicPrototype[] ps = new GraphicsCreator.graphicPrototype[j];

		for (int i = 0; i < j; i++) {
			int l = dataHolder.graphicSettings[i].indexes.Count;
			GraphicsCreator.graphicPrototype.prototypeIndex[] ix = new GraphicsCreator.graphicPrototype.prototypeIndex[l];
			DataHolder.graphics_Object o = dataHolder.graphicSettings[i];
			for (int k = 0; k < l; k++)
				ix[k] = new GraphicsCreator.graphicPrototype.prototypeIndex(o.indexes[k].x, o.indexes[k].y);
			ps[i] = new GraphicsCreator.graphicPrototype(o.image, ix);
		}

		Program.windowStatus.graphicsCreator.SetAllPrototypes(ps);
	}

	private static void _Load() {
		Console.WriteLine("Test write line");
		if (!reader.FindFileFromPath()) {
			throw new FileNotFoundException();
		}
		LoadPosition pos = LoadPosition.Start;
		bool fin = false;

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
						case "<Setting>":
							pos = LoadPosition.JoystickSettingsChild;
							dataHolder.cur_joystickSetting = new DataHolder.joystickSettings_Setting();
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '</JoystickSettings>'.");
					}
					break;
				case LoadPosition.JoystickSettingsChild:
					string sj = dataHolder.cur_joystickSetting.NextData();
					if (sj == EOF) {
						// If a new object needs to be created
						dataHolder.joystickSettings.Add(dataHolder.cur_joystickSetting);
						//dataHolder.cur_indexSetting = null;
						pos = LoadPosition.JoystickSettings;
					} else if (sj == "") {
						// If a value needs to be inserted into dataholder
						dataHolder.cur_joystickSetting.Insert(next);
					} else {
						// If a tag is needed to be compared
						if (sj != next)
							throw new Exception("Did not find expected tag.");
					}
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

		JoystickSettings js = Program.windowStatus.joystickSettings;
		JoystickSettings.AxisSetting[] axiss = js.axisSetting;
		for (int i = 0, j = dataHolder.joystickSettings.Count; i < j; i++) {
			DataHolder.joystickSettings_Setting d = dataHolder.joystickSettings[i];
			axiss[i].SetSettings(d.jindex, d.aindex, d.reverse, (decimal)d.expo, d.deadband, d.offset, d.max);
		}


		for (int i = 0, j = dataHolder.indexSettings.Count; i < j; i++) {
			DataHolder.indexSettings_Setting d = dataHolder.indexSettings[i];
			Program.windowStatus.indexSettings.CreateElement(d.index, d.name, d.digit, d.size, d.color, d.v1raw, d.v1scaled, d.v2raw, d.v2scaled, d.suffix);
		}
		for (int i = 0, j = dataHolder.indexStats.Count; i < j; i++) {
			int e = dataHolder.indexStats[i];
			Program.windowStatus.indexStats.CreateElement(e);
		}

		dataHolder.Clear();
	}

	public static void Save(object sender, EventArgs e) {
		string src = "";
		src += "<Settings>\n";

		// Loop through and add JoystickSettings
		src += "	<JoystickSettings>\n";
		JoystickSettings js = Program.windowStatus.joystickSettings;
		JoystickSettings.AxisSetting[] axiss = js.axisSetting;
		for (int i = 0, j = 6; i < j; i++) {
			src += "		<Setting>\n";
			src += "			<jindex>" + axiss[i].joystick + "</jindex><aindex>" + axiss[i].axis + "</aindex><reverse>" + axiss[i].reverse.ToString() + "</reverse><expo>" + axiss[i].expo + 
				"</expo><deadband>" + axiss[i].deadband + "</deadband><offset>" + axiss[i].offset + "</offset><max>" + axiss[i].max + "</max>\n";
			src += "		</Setting>\n";
		}
		src += "	</JoystickSettings>\n";

		// Loop through and add IndexSettings
		src += "	<IndexSettings>\n";
		List<IndexSettings.Setting> li = Program.windowStatus.indexSettings.allSettings;
		for (int i = 0, j = li.Count; i < j; i++) {
			src += "		<Setting>\n			<index>" +
				li[i].index.Value + "</index><name>" + li[i].name.Text + "</name><digit>" + li[i].digit.Value +
				"</digit><size>" + li[i].size.Value + "</size><color>" + li[i].color.BackColor.ToArgb() + "</color><raw>" + li[i].val1raw.Value +
				"</raw><scaled>" + li[i].val1scaled.Value + "</scaled><raw>" + li[i].val2raw.Value + "</raw><scaled>" + li[i].val2scaled.Value +
				"</scaled><suffix>" + li[i].suffix.Text + "</suffix>\n		</Setting>\n";
		}
		src += "	</IndexSettings>\n";

		// Loop through and add IndexStats
		src += "	<IndexStats>\n";
		List<IndexStats.Stats> ls = Program.windowStatus.indexStats.allStats;
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
		/// Reads the first element or tag and returns it.
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
		public List<graphics_Object> graphicSettings;
		public graphics_Object cur_graphicSetting;
		public List<joystickSettings_Setting> joystickSettings;
		public joystickSettings_Setting cur_joystickSetting;
		public List<indexSettings_Setting> indexSettings;
		public indexSettings_Setting cur_indexSetting;
		public List<int> indexStats;

		public DataHolder() {
			cur_graphicSetting = new graphics_Object();
			graphicSettings = new List<graphics_Object>();
			cur_joystickSetting = new joystickSettings_Setting();
			joystickSettings = new List<joystickSettings_Setting>();
			cur_indexSetting = new indexSettings_Setting();
			indexSettings = new List<indexSettings_Setting>();
			indexStats = new List<int>();
		}

		public void Clear() {
			// Clear all data -- TODO
		}

		public interface DataHolderTemplate {
			string NextData();
			void Insert(string s);
		}

		public class graphics_Object {
			public string image;
			public List<graphics_ObjectIndex> indexes;
			private graphics_ObjectIndex cur;
			

			public graphics_Object() {
				indexes = new List<graphics_ObjectIndex>();
				image = "";
			}

			public void Insert(string s) {
				if (s == "<Index>") {
					cur = new graphics_ObjectIndex();
				} else if (s == "</Index>") {
					indexes.Add(cur);
				} else
					cur.Insert(s);
			}

			public class graphics_ObjectIndex {

				public int x;
				public int y;

				private int readindex = -1;
				private readonly string[] req = { "<x>", "</x>", "<y>", "</y>" };

				public void Insert(string s) {
					if (readindex == -1) { // Waiting for a open tag
						int found = -1;
						for (int i = 0, j = req.Length; i < j; i += 2) {
							if (s == req[i]) {
								found = i;
								break;
							}
						}
						// If no tags required were correct, give an error
						if (found == -1)
							throw new Exception("Did not find a correct open tag in an <Index>.");

						readindex = found;
						return;
					} else {
						if (readindex % 2 == 0) { // If last looked at was an open tag, look for a value

							switch(readindex) {
								case 0:
									x = int.Parse(s);
									break;
								case 2:
									y = int.Parse(s);
									break;
							}

							readindex++;
						} else { // If last looked at was a value, look for closing tag
							if (s == req[readindex])
								readindex = -1;
							else
								throw new Exception("Did not find a correct closing tag in an <Index>.");
						}
					}
				}
			}
		}

		public class indexSettings_Setting : DataHolderTemplate {
			public int index;
			public string name;
			public int digit;
			public int size;
			public System.Drawing.Color color;
			public int v1raw;
			public int v1scaled;
			public int v2raw;
			public int v2scaled;
			public string suffix;

			private bool waitforval = false;
			private int readindex = 0;
			private readonly string[] req = { "<index>", "</index>", "<name>", "</name>", "<digit>", "</digit>", "<size>", "</size>", "<color>", "</color>",
											  "<raw>", "</raw>", "<scaled>", "</scaled>", "<raw>", "</raw>", "<scaled>", "</scaled>", "<suffix>", "</suffix>" };

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
				if (s == req[readindex]) {
					NextData();
					return;
				}
				
				switch (readindex) {
					case 1: index = int.Parse(s); break;
					case 3: name = s; break;
					case 5: digit = int.Parse(s); break;
					case 7: size = int.Parse(s); break;
					case 9: color = System.Drawing.Color.FromArgb(int.Parse(s)); break;
					case 11: v1raw = int.Parse(s); break;
					case 13: v1scaled = int.Parse(s); break;
					case 15: v2raw = int.Parse(s); break;
					case 17: v2scaled = int.Parse(s); break;
					case 19: suffix = s; break;
				}
			}
		}

		public class joystickSettings_Setting : DataHolderTemplate {
			public int jindex;
			public int aindex;
			public bool reverse;
			public float expo;
			public int deadband;
			public int offset;
			public int max;

			private bool waitforval = false;
			private int readindex = 0;
			private readonly string[] req = { "<jindex>", "</jindex>", "<aindex>", "</aindex>", "<reverse>", "</reverse>", "<expo>", "</expo>",
											  "<deadband>", "</deadband>", "<offset>", "</offset>", "<max>", "</max>" };

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
				if (s == req[readindex]) {
					NextData();
					return;
				}

				switch (readindex) {
					case 1: jindex = int.Parse(s); break;
					case 3: aindex = int.Parse(s); break;
					case 5: reverse = bool.Parse(s); break;
					case 7: expo = float.Parse(s); break;
					case 9: deadband = int.Parse(s); break;
					case 11: offset = int.Parse(s); break;
					case 13: max = int.Parse(s); break;
				}
			}
		}
	}

	private enum LoadPositionGraphics {
		gStart = 0,
		gGraphics = 1,
		gObject = 2,
		gIndex = 3
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