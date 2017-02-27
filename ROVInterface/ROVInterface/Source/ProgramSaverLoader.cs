using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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

		dataHolder.Clear();
		dataHolder = null;
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
					else {
						pos = LoadPositionGraphics.gGraphics;
						dataHolder.cur_graphicSetting = new DataHolder.graphics_Object();

						if (string.Compare(next, 0, "<Graphics img=\"", 0, 15) == 0 && next[next.Length - 1] == '>' && next[next.Length - 2] == '"') { // If start with that string, and ends with '">'
							dataHolder.cur_graphicSetting.image = next.Substring(15, next.Length - 17);
						} else
							throw new Exception("Did not find root tag '<Graphics>' or '<Graphics img=\"%%\">'.");
					}
					break;
				case LoadPositionGraphics.gGraphics:
					switch (next) {
						case "<Index>":
							pos = LoadPositionGraphics.gIndex;
							dataHolder.cur_graphicSetting.Insert(next);
							break;
						case "<Index hidden>":
							pos = LoadPositionGraphics.gIndex;
							dataHolder.cur_graphicSetting.Insert(next);
							break;
						case "</Graphics>":
							fin = true;
							break;
						default:
							throw new Exception("Did not find correct next tag, of either '<Index>', '<Index hidden>' or '</Object>'.");
					}
					break;
				case LoadPositionGraphics.gIndex:
					dataHolder.cur_graphicSetting.Insert(next);
					if (next == "</Index>")
						pos = LoadPositionGraphics.gGraphics;
					break;
				default:
					break;
			}
		}

		int l = dataHolder.cur_graphicSetting.indexes.Count;
		GraphicsCreator.graphicPrototype.prototypeIndex[] ix = new GraphicsCreator.graphicPrototype.prototypeIndex[l];
		DataHolder.graphics_Object o = dataHolder.cur_graphicSetting;
		for (int k = 0; k < l; k++)
			ix[k] = new GraphicsCreator.graphicPrototype.prototypeIndex(o.indexes[k].hidden, o.indexes[k].x, o.indexes[k].y, o.indexes[k].ll, o.indexes[k].l, o.indexes[k].h, o.indexes[k].hh);

		GraphicsCreator.graphicPrototype p = new GraphicsCreator.graphicPrototype(o.image, ix);

		Program.windowStatus.graphicsCreator.SetPrototype(p);
	}

	private static void _Load() {
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
						case "<GraphicSettings>":
							pos = LoadPosition.GraphicSettings;
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
							dataHolder.joystickSettings = null;
							pos = FindNextAfterError(next, out fin);
							break;
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
						if (sj != next) {
							dataHolder.joystickSettings = null;
							pos = FindNextAfterError(next, out fin);
						}
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
							dataHolder.indexSettings = null;
							pos = FindNextAfterError(next, out fin);
							break;
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
						if (s != next) {
							dataHolder.indexSettings = null;
							pos = FindNextAfterError(next, out fin);
						}
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
							dataHolder.indexStats = null;
							pos = FindNextAfterError(next, out fin);
							break;
					}
					break;
				case LoadPosition.IndexStatsChild:
					dataHolder.indexStats.Add(int.Parse(next));
					if ((next = reader.ReadNext()) != "</Stats>") {
						dataHolder.indexStats = null;
						pos = FindNextAfterError(next, out fin);
						break;
					}
					pos = LoadPosition.IndexStats;
					break;
				case LoadPosition.GraphicSettings:
					if (next == "</GraphicSettings>") {
						pos = LoadPosition.Settings;
						break;
					}

					// Try to convert x0,x1,x2,...,xn to a list<int>
					dataHolder.graphicSettings = new List<int>();
					string cur = "";
					for (int i = 0, j = next.Length; i < j; i++) {
						if (next[i] == ',' || next[i] == ';') {
							if (cur == "")
								dataHolder.graphicSettings.Add(0);
							else
								dataHolder.graphicSettings.Add(int.Parse(cur));
							cur = "";

							if (next[i] == ';')
								break;
						} else
							cur += next[i];
					}

					break;
			}
		}

		// If succesfully loaded joystickSettings
		if (dataHolder.joystickSettings != null) {
			JoystickSettings js = Program.windowStatus.joystickSettings;
			JoystickSettings.AxisSetting[] axiss = js.axisSetting;
			for (int i = 0, j = dataHolder.joystickSettings.Count; i < j; i++) {
				DataHolder.joystickSettings_Setting d = dataHolder.joystickSettings[i];
				axiss[i].SetSettings(d.jindex, d.aindex, d.reverse, (decimal)d.expo, d.deadband, d.offset, d.max);
			}
		}

		// If succesfully loaded indexSettings
		if (dataHolder.indexSettings != null) {
			for (int i = 0, j = dataHolder.indexSettings.Count; i < j; i++) {
				DataHolder.indexSettings_Setting d = dataHolder.indexSettings[i];
				Program.windowStatus.indexSettings.CreateElement(d.index, d.name, d.digit, d.size, d.color, d.v1raw, d.v1scaled, d.v2raw, d.v2scaled, d.suffix);
			}
		}

		// If succesfully loaded indexStats
		if (dataHolder.indexStats != null) {
			for (int i = 0, j = dataHolder.indexStats.Count; i < j; i++) {
				int e = dataHolder.indexStats[i];
				Program.windowStatus.indexStats.CreateElement(e);
			}
		}

		// If succesfully loaded graphicSettings
		if (dataHolder.graphicSettings != null) {
			for (int i = 0, j = dataHolder.graphicSettings.Count; i < j; i++)
				Program.windowStatus.graphicsCreator.Prototype.indexes[i]._idx = dataHolder.graphicSettings[i];
		}
		Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();
	}

	private static LoadPosition FindNextAfterError(string next, out bool fin) {

		LoadPosition pos = LoadPosition.Start;
		fin = false;

		while(next != EOF) {
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
				case "<GraphicSettings>":
					pos = LoadPosition.GraphicSettings;
					break;
				case "</Settings>":
					pos = LoadPosition.Settings;
					fin = true;
					break;
			}

			if (pos != LoadPosition.Start)
				break;

			next = reader.ReadNext();
		}

		return pos;
	}

	public static void Save(object sender, EventArgs e) {
		string src = "";
		src += "<Settings>\n";

		// Loop through and add JoystickSettings
		src += "\t<JoystickSettings>\n";
		JoystickSettings js = Program.windowStatus.joystickSettings;
		JoystickSettings.AxisSetting[] axiss = js.axisSetting;
		for (int i = 0, j = 6; i < j; i++) {
			src += "\t\t<Setting>\n";
			src += "\t\t\t<jindex>" + axiss[i].joystick + "</jindex><aindex>" + axiss[i].axis + "</aindex><reverse>" + axiss[i].reverse.ToString() + "</reverse><expo>" + axiss[i].expo + 
				"</expo><deadband>" + axiss[i].deadband + "</deadband><offset>" + axiss[i].offset + "</offset><max>" + axiss[i].max + "</max>\n";
			src += "\t\t</Setting>\n";
		}
		src += "\t</JoystickSettings>\n";

		// Loop through and add IndexSettings
		src += "\t<IndexSettings>\n";
		List<IndexSettings.Setting> li = Program.windowStatus.indexSettings.allSettings;
		for (int i = 0, j = li.Count; i < j; i++) {
			src += "\t\t<Setting>\n\t\t\t<index>" +
				li[i].index.Value + "</index><name>" + li[i].name.Text + "</name><digit>" + li[i].digit.Value +
				"</digit><size>" + li[i].size.Value + "</size><color>" + li[i].color.BackColor.ToArgb() + "</color><raw>" + li[i].val1raw.Value +
				"</raw><scaled>" + li[i].val1scaled.Value + "</scaled><raw>" + li[i].val2raw.Value + "</raw><scaled>" + li[i].val2scaled.Value +
				"</scaled><suffix>" + li[i].suffix.Text + "</suffix>\n\t\t</Setting>\n";
		}
		src += "\t</IndexSettings>\n";

		// Loop through and add IndexStats
		src += "	<IndexStats>\n";
		List<IndexStats.Stats> ls = Program.windowStatus.indexStats.allStats;
		for (int i = 0, j = ls.Count; i < j; i++) {
			src += "		<Stats>" + ((IndexSettings.Setting)ls[i].index.SelectedItem).index.Value + "</Stats>\n";
		}
		src += "\t</IndexStats>\n";

		// Loop through and add GraphicSettings
		src += "\t<GraphicSettings>\n\t\t";
		GraphicsCreator.graphicPrototype.prototypeIndex[] pi = Program.windowStatus.graphicsCreator.Prototype.indexes;
		for (int i = 0, j = pi.Length; i < j; i++) {
			src += pi[i]._idx;
			if (i + 1 != j)
				src += ",";
			else
				src += ";";
		}
		src += "\n	</GraphicSettings>\n";
		/*
		// Loop through and add ToolboxSettings
		src += "\t<ToolboxSettings>\n";
		List< KeyValuePair<Control, GraphicToolbox.ToolboxControl> > at = Program.windowStatus.graphicToolbox.allControls;
		for (int i = 0, j = at.Count; i < j; i++) {
			if (at[i].Value.GetType() == typeof(GraphicToolbox.ToolboxSimpleButton)) {
				// Save <SimpleButton>
				GraphicToolbox.ToolboxSimpleButton o = (GraphicToolbox.ToolboxSimpleButton)at[i].Value;
				src += "\t\t<SimpleButton>\n";
				src += "\t\t\t<name>" + o.name + "</name>\n\t\t\t<x>" + o.posx + "</x>\n\t\t\t<y>" + o.posy + "</y>\n\t\t\t<msg_index>" +
						o.msg_index + "</msg_index>\n\t\t\t<msg_value>" + o.msg_value + "</msg_value>\n";
				src += "\t\t</SimpleButton>\n";
			} else if (at[i].Value.GetType() == typeof(GraphicToolbox.ToolboxOnOffButton)) {
				// Save <OnOffButton Delay>
				GraphicToolbox.ToolboxOnOffButton o = (GraphicToolbox.ToolboxOnOffButton)at[i].Value;
				src += "\t\t<OnOffButton" + (o.ifdelay ? "Delay" : "") + ">\n";
				src += "\t\t\t<name>" + o.name + "</name>\n\t\t\t<x>" + o.posx + "</x>\n\t\t\t<y>" + o.posy + "</y>\n\t\t\t<msg1_index>" +
						o.msg1_index + "</msg1_index>\n\t\t\t<msg1_value>" + o.msg1_value + "</msg1_value>\n\t\t\t<msg2_index>" +
						o.msg2_index + "</msg2_index>\n\t\t\t<msg2_value>" + o.msg2_value + "</msg2_value>\n\t\t\t<delay>" + o.delayms + "</delay>\n";
				src += "\t\t</OnOffButton>\n";
			} else if (at[i].Value.GetType() == typeof(GraphicToolbox.ToolboxSlider)) {
				// Save <Slider Cont>
				GraphicToolbox.ToolboxSlider o = (GraphicToolbox.ToolboxSlider)at[i].Value;
				src += "\t\t<Slider" + (o.ifcont ? "Cont" : "") + ">\n";
				src += "\t\t\t<name>" + o.name + "</name>\n\t\t\t<x>" + o.posx + "</x>\n\t\t\t<y>" + o.posy + "</y>\n\t\t\t<index>" + o.index + "</index>\n\t\t\t<interval>" +
						o.interval + "</interval>\n\t\t\t<min>" + o.min + "</min>\n\t\t\t<max>" + o.max + "</max>\n";
				src += "\t\t</Slider>\n";
			}
		}
		src += "\t</ToolboxSettings>\n";
		*/

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
		public graphics_Object cur_graphicSetting;
		public List<joystickSettings_Setting> joystickSettings;
		public joystickSettings_Setting cur_joystickSetting;
		public List<indexSettings_Setting> indexSettings;
		public indexSettings_Setting cur_indexSetting;
		public List<int> indexStats;
		public List<int> graphicSettings;

		public DataHolder() {
			cur_graphicSetting = new graphics_Object();
			cur_joystickSetting = new joystickSettings_Setting();
			joystickSettings = new List<joystickSettings_Setting>();
			cur_indexSetting = new indexSettings_Setting();
			indexSettings = new List<indexSettings_Setting>();
			indexStats = new List<int>();
		}

		public void Clear() {
			// Clear all data
			cur_graphicSetting = null;
			cur_joystickSetting = null;
			cur_indexSetting = null;

			joystickSettings.Clear();
			indexSettings.Clear();
			indexStats.Clear();
			graphicSettings.Clear();
			joystickSettings = null;
			indexSettings = null;
			indexStats = null;
			graphicSettings = null;
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
					cur = new graphics_ObjectIndex(false);
				} else if (s == "<Index hidden>") {
					cur = new graphics_ObjectIndex(true);
				} else if (s == "</Index>") {
					indexes.Add(cur);
				} else
					cur.Insert(s);
			}

			public class graphics_ObjectIndex {

				public bool hidden = false;
				public int x;
				public int y;
				public int? ll = null;		// critical low
				public int? l = null;		// low
				public int? h = null;		// high
				public int? hh = null;		// critical high

				private int readindex = -1;
				private readonly string[] req = { "<x>", "</x>", "<y>", "</y>", "<ll>", "</ll>", "<l>", "</l>", "<h>", "</h>", "<hh>", "</hh>" };

				public graphics_ObjectIndex(bool hidden) {
					this.hidden = hidden;
				}

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
								case 4:
									ll = int.Parse(s);
									break;
								case 6:
									l = int.Parse(s);
									break;
								case 8:
									h = int.Parse(s);
									break;
								case 10:
									hh = int.Parse(s);
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
		gIndex = 2
	}

	private enum LoadPosition {
		Start = 0,
		Settings = 1,
		JoystickSettings = 2,
		JoystickSettingsChild = 3,
		IndexSettings = 4,
		IndexSettingsChild = 5,
		IndexStats = 6,
		IndexStatsChild = 7,
		GraphicSettings = 8
	}
}