using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public static class ProgramSaverLoader {

	private static Reader reader;
	private static DataHolder dataHolder;
	private const string path =       ".\\Settings.xml";
    public  const string pathexport = ".\\Settings.export.xml";
	private const string EOF = "\0";

	public static void Init() {
		reader = new Reader(path);
	}

	public static void Load() {

		dataHolder = new DataHolder();
		// Set up failproof values if the load fails
		Program.windowStatus.graphicsCreator.SetPrototype(new GraphicsCreator.graphicPrototype("", new GraphicsCreator.graphicPrototype.prototypeIndex[0]));

		try {
            _Load();
            _InsertDataToProgram();
        } catch (Exception e) {
			Console.WriteLine(e);
			Program.errors.Add("Failed to load settings.");
		}

		Program.windowStatus.txtbox_dllimported.Text = CommHandler.dllpath;
		CommHandler.InitDllImport();

		dataHolder.Clear();
		dataHolder = null;
	}

    public static bool Reload() {

        bool succ = true;
		dataHolder = new DataHolder();
		reader.Restart();

        try {
            _Load();
            
            // Reset all the items to be reloaded, (not failed to load)
			if (dataHolder.cur_graphicSetting != null)
				Program.windowStatus.graphicsCreator.Prototype.Dispose();

			if (dataHolder.indexSettings != null)
				Program.windowStatus.indexSettings.Dispose();

			if (dataHolder.indexStats != null)
				Program.windowStatus.indexStats.Dispose();

            _InsertDataToProgram();

			// Fix up some stuff, loose ends
			Program.windowStatus.indexStats.CheckAllLinks();
			Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();

		} catch {
            succ = false;
        }

		Program.windowStatus.txtbox_dllimported.Text = CommHandler.dllpath;
		CommHandler.InitDllImport();

		dataHolder.Clear();
		dataHolder = null;

		return succ;
    }

	private static void _Load() {
		if (!reader.FindFileFromPath()) {
			throw new FileNotFoundException();
		}
		LoadPosition pos = LoadPosition.Start;
		bool fin = false;
		bool temp = true;

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
						case "<General>":
							pos = LoadPosition.General;
							break;
						case "<JoystickSettings>":
							pos = LoadPosition.JoystickSettings;
							break;
						case "<JoystickButtonSettings>":
							pos = LoadPosition.JoystickButtonSettings;
							break;
						case "<IndexSettings>":
							pos = LoadPosition.IndexSettings;
							break;
						case "<IndexStats>":
							pos = LoadPosition.IndexStats;
							break;
						case "<GraphicSettings>":
							pos = LoadPosition.GraphicSettings;
							dataHolder.cur_graphicSetting = new DataHolder.graphics_Object();
							dataHolder.cur_graphicSetting.image = ""; // will make the image never be loaded with empty path
							break;
						case "<ToolboxSettings>":
							pos = LoadPosition.ToolboxSettings;
							break;
						case "</Settings>":
							fin = true;
							break;
						default:
							pos = LoadPosition.GraphicSettings;
							dataHolder.cur_graphicSetting = new DataHolder.graphics_Object();
							break;
					}
					break;
				case LoadPosition.General:
					switch (next) {
						case "<DllPath>":
							pos = LoadPosition.GeneralDllPath;
							temp = true;
							break;
						case "<GraphicPath>":
							pos = LoadPosition.GeneralGraphicPath;
							temp = true;
							break;
                        case "</General>":
                            pos = LoadPosition.Settings;
                            break;
						default:
							FindNextAfterError(next, out fin);
							break;
					}
					break;
				case LoadPosition.GeneralDllPath:
					if (next == "</DllPath>") {
						pos = LoadPosition.General;
						if (temp)
							dataHolder.generalDllPath = "";
					} else if (temp) {
                        dataHolder.generalDllPath = next;
                        temp = false;
					} else {
                        FindNextAfterError(next, out fin);
					}
					break;
                case LoadPosition.GeneralGraphicPath:
                    if (next == "</GraphicPath>") {
                        pos = LoadPosition.General;
                        if (temp)
                            dataHolder.generalGraphicPath = "";
                    } else if (temp) {
                        dataHolder.generalGraphicPath = next;
                        temp = false;
                    } else {
                        FindNextAfterError(next, out fin);
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
				case LoadPosition.JoystickButtonSettings:
					switch (next)
					{
						case "</JoystickButtonSettings>":
							pos = LoadPosition.Settings;
							break;
						case "<Setting>":
							pos = LoadPosition.JoystickButtonSettingsChild;
							dataHolder.cur_joystickButtonSetting = new DataHolder.joystickButtonSettings_Setting();
							break;
						default:
							dataHolder.joystickButtonSettings = null;
							pos = FindNextAfterError(next, out fin);
							break;
					}
					break;
				case LoadPosition.JoystickButtonSettingsChild:
					string sb = dataHolder.cur_joystickButtonSetting.NextData();
					if (sb == EOF)
					{
						// If a new object needs to be created
						dataHolder.joystickButtonSettings.Add(dataHolder.cur_joystickButtonSetting);
						//dataHolder.cur_indexSetting = null;
						pos = LoadPosition.JoystickButtonSettings;
					}
					else if (sb == "")
					{
						// If a value needs to be inserted into dataholder
						dataHolder.cur_joystickButtonSetting.Insert(next);
					}
					else
					{
						// If a tag is needed to be compared
						if (sb != next)
						{
							dataHolder.joystickButtonSettings = null;
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
					switch (next) {
						case "<Index>":
							pos = LoadPosition.GraphicSettingsChild;
							dataHolder.cur_graphicSetting.Insert(next);
							break;
						case "<Index hidden>":
							pos = LoadPosition.GraphicSettingsChild;
							dataHolder.cur_graphicSetting.Insert(next);
							break;
						case "</GraphicSettings>":
							pos = LoadPosition.Settings;
							break;
						default:
							dataHolder.cur_graphicSetting = null;
							pos = FindNextAfterError(next, out fin);
							break;
					}
					break;
				case LoadPosition.GraphicSettingsChild:
					dataHolder.cur_graphicSetting.Insert(next);
					if (next == "</Index>")
						pos = LoadPosition.GraphicSettings;
					break;
				case LoadPosition.ToolboxSettings:
					switch (next) {
						case "<SimpleButton>":
							dataHolder.cur_toolboxSetting = new DataHolder.toolboxSettings_Control(DataHolder.toolboxSettings_Control.controltype.SimpleButton, false);
							pos = LoadPosition.ToolboxSettingsChild;
							break;
						case "<OnOffButton>":
							dataHolder.cur_toolboxSetting = new DataHolder.toolboxSettings_Control(DataHolder.toolboxSettings_Control.controltype.OnOffButton, false);
							pos = LoadPosition.ToolboxSettingsChild;
							break;
						case "<OnOffButton Delay>":
							dataHolder.cur_toolboxSetting = new DataHolder.toolboxSettings_Control(DataHolder.toolboxSettings_Control.controltype.OnOffButton, true);
							pos = LoadPosition.ToolboxSettingsChild;
							break;
						case "<Slider>":
							dataHolder.cur_toolboxSetting = new DataHolder.toolboxSettings_Control(DataHolder.toolboxSettings_Control.controltype.Slider, false);
							pos = LoadPosition.ToolboxSettingsChild;
							break;
						case "<Slider Cont>":
							dataHolder.cur_toolboxSetting = new DataHolder.toolboxSettings_Control(DataHolder.toolboxSettings_Control.controltype.Slider, true);
							pos = LoadPosition.ToolboxSettingsChild;
							break;
						case "</ToolboxSettings>":
							pos = LoadPosition.Settings;
							break;
						default:
							dataHolder.toolboxSettings = null;
							pos = FindNextAfterError(next, out fin);
							break;
					}
					break;
				case LoadPosition.ToolboxSettingsChild:
					switch (next) {
						case "</SimpleButton>":
							dataHolder.toolboxSettings.Add(dataHolder.cur_toolboxSetting);
							pos = LoadPosition.ToolboxSettings;
							break;
						case "</OnOffButton>":
							dataHolder.toolboxSettings.Add(dataHolder.cur_toolboxSetting);
							pos = LoadPosition.ToolboxSettings;
							break;
						case "</Slider>":
							dataHolder.toolboxSettings.Add(dataHolder.cur_toolboxSetting);
							pos = LoadPosition.ToolboxSettings;
							break;
						default:
							dataHolder.cur_toolboxSetting.Insert(next);
							break;
					}
					break;
			}
		}
	}

    private static void _InsertDataToProgram() {

        // If succesfully loaded joystickSettings
        if (dataHolder.joystickSettings != null) {
            JoystickSettings.AxisSetting[] axiss = Program.windowStatus.joystickSettings.axisSetting;
            for (int i = 0, j = dataHolder.joystickSettings.Count; i < j; i++) {
                DataHolder.joystickSettings_Setting d = dataHolder.joystickSettings[i];
				axiss[i].SetSettings(d.index, d.jindex, d.aindex, d.reverse, d.expo, d.deadband, d.offset, d.max);
			}
        } else
            Program.errors.Add("Failed to load <JoystickSettings>");

		// if succesfully loaded joystickButtonSettings
		if (dataHolder.joystickButtonSettings != null) {
			JoystickSettings.ButtonSetting[] btns = Program.windowStatus.joystickSettings.buttonSetting;
			for (int i = 0, j = dataHolder.joystickButtonSettings.Count; i < j; i++) {
				DataHolder.joystickButtonSettings_Setting d = dataHolder.joystickButtonSettings[i];
				btns[i].SetSetting(d.index, d.bitnr, d.joystick_idx, d.button_idx, d.togglePush, d.offValue, d.onValue);
			}
		} else
			Program.errors.Add("Failed to load <JoystickButtonSettings>");

		// If succesfully loaded graphicSettings
		if (dataHolder.cur_graphicSetting != null) {
			List<DataHolder.graphics_Object.graphics_ObjectIndex> d = dataHolder.cur_graphicSetting.indexes;
			GraphicsCreator.graphicPrototype.prototypeIndex[] li = new GraphicsCreator.graphicPrototype.prototypeIndex[d.Count];
			for (int i = 0, j = dataHolder.cur_graphicSetting.indexes.Count; i < j; i++)
				li[i] = new GraphicsCreator.graphicPrototype.prototypeIndex(d[i].hidden, d[i].x, d[i].y, d[i].ll, d[i].l, d[i].h, d[i].hh, d[i].index);
			Program.windowStatus.graphicsCreator.SetPrototype(new GraphicsCreator.graphicPrototype(dataHolder.generalGraphicPath, li));
			Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();
			Program.windowStatus.txtbox_graphicsloaded.Text = dataHolder.generalGraphicPath;
		} else {
			// Create temp prototype if the prototype cannot be loaded
			Program.windowStatus.graphicsCreator.SetPrototype(new GraphicsCreator.graphicPrototype(dataHolder.generalGraphicPath, new GraphicsCreator.graphicPrototype.prototypeIndex[0]));
			Program.windowStatus.txtbox_graphicsloaded.Text = "";
			Program.errors.Add("Failed to load <GraphicSettings>");
		}

		// If succesfully loaded indexSettings
		if (dataHolder.indexSettings != null) {
			for (int i = 0, j = dataHolder.indexSettings.Count; i < j; i++) {
				DataHolder.indexSettings_Setting dd = dataHolder.indexSettings[i];
				Program.windowStatus.indexSettings.CreateElement(dd.index, dd.name, dd.digit, dd.size, dd.color, dd.v1raw, dd.v1scaled, dd.v2raw, dd.v2scaled, dd.suffix);
			}
		} else
			Program.errors.Add("Failed to load <IndexSettings>");

		// If succesfully loaded indexStats
		if (dataHolder.indexStats != null) {
            for (int i = 0, j = dataHolder.indexStats.Count; i < j; i++) {
                int e = dataHolder.indexStats[i];
                Program.windowStatus.indexStats.CreateElement(e);
            }
        } else
            Program.errors.Add("Failed to load <IndexStats>");

        // If succesfully loaded toolboxSettings
        if (dataHolder.toolboxSettings != null) {
            for (int i = 0; i < dataHolder.toolboxSettings.Count; i++) {
                DataHolder.toolboxSettings_Control d = dataHolder.toolboxSettings[i];
                switch (d.type) {
                    case DataHolder.toolboxSettings_Control.controltype.SimpleButton:
                        Program.windowStatus.graphicToolbox.Create_SimpleButton(new GraphicToolbox.ToolboxSimpleButton(d.x, d.y, d.name, d.msg1_index, d.msg1_value));
                        break;
                    case DataHolder.toolboxSettings_Control.controltype.OnOffButton:
                        Program.windowStatus.graphicToolbox.Create_OnOffButton(new GraphicToolbox.ToolboxOnOffButton(d.x, d.y, d.name, d.msg1_index, d.msg1_value, d.pam, d.delayms, d.msg2_index, d.msg2_value));
                        break;
                    case DataHolder.toolboxSettings_Control.controltype.Slider:
                        Program.windowStatus.graphicToolbox.Create_Slider(d.delayms, new GraphicToolbox.ToolboxSlider(d.x, d.y, d.name, d.msg1_index, d.msg1_value, d.msg2_index, d.msg2_value, d.pam));
                        break;
                }

            }
        } else
            Program.errors.Add("Failed to load <ToolboxSettings>");

        // Try to load dll
        CommHandler.dllpath = dataHolder.generalDllPath;
    }

	private static LoadPosition FindNextAfterError(string next, out bool fin) {

		LoadPosition pos = LoadPosition.Start;
		fin = false;

		while(next != EOF) {
			switch (next) {
				case "<General>":
					pos = LoadPosition.General;
					break;
				case "<JoystickSettings>":
					pos = LoadPosition.JoystickSettings;
					break;
				case "<JoystickButtonSettings>":
					pos = LoadPosition.JoystickButtonSettings;
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
				case "<ToolboxSettings>":
					pos = LoadPosition.ToolboxSettings;
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
        Save(path);
	}

    public static void Export() {
        Save(pathexport);
    }

    private static void Save(string path) {
        string src = "";
        src += "<Settings>\n";

		// Add general settings
		src += "\t<General>\n\t\t<DllPath>" + CommHandler.dllpath + "</DllPath>\n\t\t<GraphicPath>" + Program.windowStatus.graphicsCreator.Prototype.path + "</GraphicPath>\n\t</General>\n";

        // Loop through and add JoystickSettings
        src += "\t<JoystickSettings>\n";
        JoystickSettings.AxisSetting[] axiss = Program.windowStatus.joystickSettings.axisSetting;
        for (int i = 0, j = axiss.Length; i < j; i++) {
            src += "\t\t<Setting>\n";
            src += "\t\t\t<index>" + axiss[i].index + "</index><jindex>" + (axiss[i].joystick == -1 ? axiss[i].joystickloaded : axiss[i].joystick) + "</jindex><aindex>" + axiss[i].axis + "</aindex><reverse>" + axiss[i].reverse.ToString() +
				"</reverse><expo>" + axiss[i].expo + "</expo><deadband>" + axiss[i].deadband + "</deadband><offset>" + axiss[i].offset + "</offset><max>" + axiss[i].max + "</max>\n";
            src += "\t\t</Setting>\n";
        }
        src += "\t</JoystickSettings>\n";

		// Loop through and add JoystickButtonSettings
		src += "\t<JoystickButtonSettings>\n";
		JoystickSettings.ButtonSetting[] btns = Program.windowStatus.joystickSettings.buttonSetting;
		for (int i = 0, j = btns.Length; i < j; i++) {
			src += "\t\t<Setting>\n";
			src += "\t\t\t<index>" + btns[i].index + "</index><bitnr>" + btns[i].bitnr + "</bitnr><jindex>" + (btns[i].joystick_idx == -1 ? btns[i].joystickloaded_idx : btns[i].joystick_idx) + "</jindex><bindex>" + btns[i].button_idx +
				"</bindex><togglepush>" + btns[i].toggle_push + "</togglepush><offvalue>" + btns[i].offValue + "</offvalue><onvalue>" + btns[i].onValue + "</onvalue>\n";
			src += "\t\t</Setting>\n";
		}
		src += "\t</JoystickButtonSettings>";

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
        src += "\t<IndexStats>\n";
        List<IndexStats.Stats> ls = Program.windowStatus.indexStats.allStats;
        for (int i = 0, j = ls.Count; i < j; i++) {
            src += "\t\t<Stats>" + ((IndexSettings.Setting)ls[i].index.SelectedItem).index.Value + "</Stats>\n";
        }
        src += "\t</IndexStats>\n";

        // Loop through and add GraphicSettings
        src += "\t<GraphicSettings>\n";
        GraphicsCreator.graphicPrototype.prototypeIndex[] pi = Program.windowStatus.graphicsCreator.Prototype.indexes;
        for (int i = 0; i < pi.Length; i++) {
            src += "\t\t<Index" + (pi[i].hidden ? " hidden" : "") + ">\n\t\t\t<x>" + pi[i].posx + "</x>\n\t\t\t<y>" + pi[i].posy + "</y>\n";
            if (pi[i].ll != null)
                src += "\t\t\t<ll>" + pi[i].ll.Value + "</ll>\n";
            if (pi[i].l != null)
                src += "\t\t\t<l>" + pi[i].l.Value + "</l>\n";
            if (pi[i].h != null)
                src += "\t\t\t<h>" + pi[i].h.Value + "</h>\n";
            if (pi[i].hh != null)
                src += "\t\t\t<hh>" + pi[i].hh.Value + "</hh>\n";
            src += "\t\t\t<index>" + pi[i]._idx + "</index>\n\t\t</Index>\n";
        }
        src += "\t</GraphicSettings>\n";

        // Loop through and add ToolboxSettings
        src += "\t<ToolboxSettings>\n";
        List<KeyValuePair<Control, GraphicToolbox.ToolboxControl>> at = Program.windowStatus.graphicToolbox.allControls;
        for (int i = 0, j = at.Count; i < j; i++) {
            if (at[i].Value.GetType() == typeof(GraphicToolbox.ToolboxSimpleButton)) {
                // Save <SimpleButton>
                GraphicToolbox.ToolboxSimpleButton o = (GraphicToolbox.ToolboxSimpleButton)at[i].Value;
                src += "\t\t<SimpleButton>\n";
                src += "\t\t\t<name>" + o.name + "</name>\n\t\t\t<x>" + o.posx + "</x>\n\t\t\t<y>" + o.posy + "</y>\n\t\t\t<msg1_index>" +
                        o.msg_index + "</msg1_index>\n\t\t\t<msg1_value>" + o.msg_value + "</msg1_value>\n";
                src += "\t\t</SimpleButton>\n";
            } else if (at[i].Value.GetType() == typeof(GraphicToolbox.ToolboxOnOffButton)) {
                // Save <OnOffButton Delay>
                GraphicToolbox.ToolboxOnOffButton o = (GraphicToolbox.ToolboxOnOffButton)at[i].Value;
                src += "\t\t<OnOffButton" + (o.ifdelay ? " Delay" : "") + ">\n";
                src += "\t\t\t<name>" + o.name + "</name>\n\t\t\t<x>" + o.posx + "</x>\n\t\t\t<y>" + o.posy + "</y>\n\t\t\t<msg1_index>" +
                        o.msg1_index + "</msg1_index>\n\t\t\t<msg1_value>" + o.msg1_value + "</msg1_value>\n\t\t\t<msg2_index>" +
                        o.msg2_index + "</msg2_index>\n\t\t\t<msg2_value>" + o.msg2_value + "</msg2_value>\n\t\t\t<delay>" + o.delayms + "</delay>\n";
                src += "\t\t</OnOffButton>\n";
            } else if (at[i].Value.GetType() == typeof(GraphicToolbox.ToolboxSlider)) {
                // Save <Slider Cont>
                GraphicToolbox.ToolboxSlider o = (GraphicToolbox.ToolboxSlider)at[i].Value;
                src += "\t\t<Slider" + (o.ifcont ? " Cont" : "") + ">\n";
                src += "\t\t\t<name>" + o.name + "</name>\n\t\t\t<x>" + o.posx + "</x>\n\t\t\t<y>" + o.posy + "</y>\n\t\t\t<index>" + o.index + "</index>\n\t\t\t<interval>" +
                        o.interval + "</interval>\n\t\t\t<min>" + o.min + "</min>\n\t\t\t<max>" + o.max + "</max>\n\t\t\t<curvalue>" + ((TrackBar)o.control).Value + "</curvalue>\n";
                src += "\t\t</Slider>\n";
            }
        }
        src += "\t</ToolboxSettings>\n";


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

		public string generalDllPath = "";
		public string generalGraphicPath = "";

		public graphics_Object cur_graphicSetting;
		public List<joystickSettings_Setting> joystickSettings;
		public joystickSettings_Setting cur_joystickSetting;
		public List<joystickButtonSettings_Setting> joystickButtonSettings;
		public joystickButtonSettings_Setting cur_joystickButtonSetting;
		public List<indexSettings_Setting> indexSettings;
		public indexSettings_Setting cur_indexSetting;
		public List<int> indexStats;
		public toolboxSettings_Control cur_toolboxSetting;
		public List<toolboxSettings_Control> toolboxSettings;

		public DataHolder() {
			cur_graphicSetting = new graphics_Object();
			cur_joystickSetting = new joystickSettings_Setting();
			joystickSettings = new List<joystickSettings_Setting>();
			cur_joystickButtonSetting = new joystickButtonSettings_Setting();
			joystickButtonSettings = new List<joystickButtonSettings_Setting>();
			cur_indexSetting = new indexSettings_Setting();
			indexSettings = new List<indexSettings_Setting>();
			indexStats = new List<int>();
			toolboxSettings = new List<toolboxSettings_Control>();
		}

		public void Clear() {
			// Clear all data
			cur_graphicSetting = null;
			cur_joystickSetting = null;
			cur_joystickButtonSetting = null;
			cur_indexSetting = null;

			if (joystickSettings != null)
				joystickSettings.Clear();
			if (joystickButtonSettings != null)
				joystickButtonSettings.Clear();
			if (indexSettings != null)
				indexSettings.Clear();
			if (indexStats != null)
				indexStats.Clear();
			joystickSettings = null;
			joystickButtonSettings = null;
			indexSettings = null;
			indexStats = null;
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
				public float? ll = null;	// critical low
				public float? l = null;		// low
				public float? h = null;		// high
				public float? hh = null;	// critical high
				public int index;

				private int readindex = -1;
				private static readonly string[] req = { "<x>", "</x>", "<y>", "</y>", "<ll>", "</ll>", "<l>", "</l>", "<h>", "</h>", "<hh>", "</hh>", "<index>", "</index>" };

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
								case 0: x = int.Parse(s); break;
								case 2: y = int.Parse(s); break;
								case 4: ll = float.Parse(s); break;
								case 6: l = float.Parse(s); break;
								case 8: h = float.Parse(s); break;
								case 10: hh = float.Parse(s); break;
								case 12: index = int.Parse(s); break;
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
			private static readonly string[] req = { "<index>", "</index>", "<name>", "</name>", "<digit>", "</digit>", "<size>", "</size>", "<color>", "</color>",
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
			public decimal expo;
			public decimal deadband;
			public decimal offset;
			public decimal max;
			public int index = -1;

			private bool waitforval = false;
			private int readindex = 0;
			private static readonly string[] req = { "<index>", "</index>", "<jindex>", "</jindex>", "<aindex>", "</aindex>", "<reverse>", "</reverse>", "<expo>", "</expo>",
											  "<deadband>", "</deadband>", "<offset>", "</offset>", "<max>", "</max>"};

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
					case 3: jindex = int.Parse(s); break;
					case 5: aindex = int.Parse(s); break;
					case 7: reverse = bool.Parse(s); break;
					case 9: expo = ParseDecimalFromString(s); break;
					case 11: deadband = ParseDecimalFromString(s); break;
					case 13: offset = ParseDecimalFromString(s); break;
					case 15: max = ParseDecimalFromString(s); break;

				}
			}
		}

		private static decimal ParseDecimalFromString(string s)
		{
			return decimal.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture);
		}

		public class joystickButtonSettings_Setting : DataHolderTemplate
		{
			public int index;
			public int bitnr;

			public int joystick_idx;
			public int button_idx;

			public bool togglePush;

			public int offValue;
			public int onValue;

			private bool waitforval = false;
			private int readindex = 0;
			private static readonly string[] req = { "<index>", "</index>", "<bitnr>", "</bitnr>", "<jindex>", "</jindex>",
				"<bindex>", "</bindex>", "<togglepush>", "</togglepush>", "<offvalue>", "</offvalue>", "<onvalue>", "</onvalue>" };

			public string NextData()
			{
				if (readindex == req.Length)
					return EOF;

				if (waitforval)
				{
					waitforval = false;
					return "";
				}
				waitforval = (readindex % 2 == 0 ? true : false);
				return req[readindex++];
			}

			public void Insert(string s)
			{
				if (s == req[readindex])
				{
					NextData();
					return;
				}

				switch (readindex)
				{
					case 1: index = int.Parse(s); break;
					case 3: bitnr = int.Parse(s); break;
					case 5: joystick_idx = int.Parse(s); break;
					case 7: button_idx = int.Parse(s); break;
					case 9: togglePush = bool.Parse(s); break;
					case 11: offValue = int.Parse(s); break;
					case 13: onValue = int.Parse(s); break;

				}
			}
		}

		public class toolboxSettings_Control {

			public controltype type;

			public string name;
			public int x;
			public int y;
			public bool pam = false; // set for OnOffButton == Delay, Slider == Cont
			public int msg1_index;
			public int msg1_value; // interval for slider
			public int msg2_index; // min for slider
			public int msg2_value; // max slider
			public int delayms;    // curvalue slider

			private int readindex = -1;
			private static readonly string[] req = { "<name>", "</name>", "<x>", "</x>", "<y>", "</y>", "<msg1_index>", "</msg1_index>", "<msg1_value>", "</msg1_value>",
											  "<msg2_index>", "</msg2_index>", "<msg2_value>", "</msg2_value>", "<delay>", "</delay>", "<index>", "</index>",
											  "<interval>", "</interval>", "<min>", "</min>", "<max>", "</max>", "<curvalue>", "</curvalue>" };

			public toolboxSettings_Control (controltype type, bool pam) {
				this.type = type;
				this.pam = pam;
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
						throw new Exception("Did not find a correct open tag.");

					readindex = found;
					return;
				} else {
					if (readindex % 2 == 0) { // If last looked at was an open tag, look for a value

						// Check if the value was empty, which then the closing tag was read instead
						if (s == req[readindex])
							readindex = -1;
						else {
							switch (readindex) {
								case 0: name = s; break;
								case 2: x = int.Parse(s); break;
								case 4: y = int.Parse(s); break;
								case 6: msg1_index = int.Parse(s); break;
								case 8: msg1_value = int.Parse(s); break;
								case 10: msg2_index = int.Parse(s); break;
								case 12: msg2_value = int.Parse(s); break;
								case 14: delayms = int.Parse(s); break;
								case 16: msg1_index = int.Parse(s); break; // for <index>
								case 18: msg1_value = int.Parse(s); break; // for <interval>
								case 20: msg2_index = int.Parse(s); break; // for <min>
								case 22: msg2_value = int.Parse(s); break; // for <max>
								case 24: delayms = int.Parse(s); break;    // for <curvalue>
							}

							readindex++;
						}
					} else { // If last looked at was a value, look for closing tag
						if (s == req[readindex])
							readindex = -1;
						else
							throw new Exception("Did not find a correct closing tag.");
					}
				}
			}

			public enum controltype {
				SimpleButton,
				OnOffButton,
				Slider
			}
		}
	}

	private enum LoadPosition {
		Start = 0,
		Settings = 1,
		JoystickSettings = 2,
		JoystickSettingsChild = 3,
		JoystickButtonSettings = 15,
		JoystickButtonSettingsChild = 16,
		IndexSettings = 4,
		IndexSettingsChild = 5,
		IndexStats = 6,
		IndexStatsChild = 7,
		GraphicSettings = 8,
		GraphicSettingsChild = 9,
		ToolboxSettings = 10,
		ToolboxSettingsChild = 11,
		General = 12,
		GeneralDllPath = 13,
		GeneralGraphicPath = 14,
	}
}