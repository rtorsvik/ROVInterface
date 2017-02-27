using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class IndexSettings {
	
	private FlowLayoutPanel panelIndexSettings;
	public List<Setting> allSettings;

	private static readonly string[] cmbprefixlist = { "m/s", "°C", "%", "‰" };

	public IndexSettings (FlowLayoutPanel pan) {
		panelIndexSettings = pan;
		allSettings = new List<Setting>();
	}

	public FlowLayoutPanel CreateElement() {
		return CreateElement(0, "", 2, 12, System.Drawing.Color.White, 0, 0, 100, 100, "");
	}

	public FlowLayoutPanel CreateElement(int index, string name, int digit, int size, System.Drawing.Color color, int v1raw, int v1scaled, int v2raw, int v2scaled, string suffix) {

		Setting setting = new Setting(this);

		// Panel handler
		FlowLayoutPanel temp = new FlowLayoutPanel();
		temp.Parent = panelIndexSettings;
		temp.Width = temp.Parent.Width - 30;
		temp.Height = 25;
		setting.panel = temp;
		
		// Index handler
		NumericUpDown nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateIndex;
		nud.Maximum = (int)Math.Pow(2, 15) - 1;
		nud.Value = index;
		nud.Width = 60;
		setting.index = nud;
		
		// Name handler
		TextBox txtbox = new TextBox();
		txtbox.Parent = temp;
		txtbox.Text = name;
		txtbox.TextChanged += setting.UpdateStats;
		txtbox.Width = 200;
		txtbox.Margin = new Padding(3, 3, 30, 3);
		setting.name = txtbox;
		
		// Digit handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		nud.Width = 40;
		nud.Minimum = 0;
		nud.Maximum = 12;
		nud.Value = digit;
		setting.digit = nud;
		
		// Size handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		nud.Width = 40;
		nud.Minimum = 8;
		nud.Maximum = 25;
		nud.Value = size;
		nud.Margin = new Padding(3, 3, 30, 3);
		setting.size = nud;
		
		// Color handler
		Button btn = new Button();
		btn.UseVisualStyleBackColor = true;
		btn.BackColor = color;
		btn.Parent = temp;
		btn.Text = "";
		btn.Size = new System.Drawing.Size(25, 25);
		btn.Margin = new Padding(2, 2, 29, 2);
		btn.Click += setting.OpenColorDialog;
		setting.color = btn;
		
		// Val1 handler raw
		nud = new NumericUpDown();
		nud.Value = nud.Minimum = int.MinValue;
		nud.Maximum = int.MaxValue;
		nud.Value = v1raw;
		nud.Width = 100;
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		setting.val1raw = nud;
		// Val1 handler scaled
		nud = new NumericUpDown();
		nud.Value = nud.Minimum = int.MinValue;
		nud.Maximum = int.MaxValue;
		nud.Value = v1scaled;
		nud.Width = 100;
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		nud.Margin = new Padding(3, 3, 30, 3);
		setting.val1scaled = nud;
		
		// Val2 handler raw
		nud = new NumericUpDown();
		nud.Value = nud.Minimum = int.MinValue;
		nud.Maximum = int.MaxValue;
		nud.Value = v2raw;
		nud.Width = 100;
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		setting.val2raw = nud;
		// Val2 handler scaled
		nud = new NumericUpDown();
		nud.Value = nud.Minimum = int.MinValue;
		nud.Maximum = int.MaxValue;
		nud.Value = v2scaled;
		nud.Width = 100;
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		nud.Margin = new Padding(3, 3, 30, 3);
		setting.val2scaled = nud;
		
		// Suffix handler
		ComboBox cmb = new ComboBox();
		cmb.Parent = temp;
		cmb.Width = 70;
		cmb.Text = suffix;
		cmb.Items.AddRange(cmbprefixlist);
		cmb.TextChanged += setting.UpdateStats;
		cmb.Margin = new Padding(3, 3, 30, 3);
		setting.suffix = cmb;

		// Delete handler
		btn = new Button();
		btn.UseVisualStyleBackColor = true;
		btn.Parent = temp;
		btn.Text = "X";
		btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btn.Size = new System.Drawing.Size(25, 25);
		btn.Margin = new Padding(2);
		btn.Click += setting.Delete;
		setting.delete = btn;

		allSettings.Add(setting);
		Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();
		return temp;
	}

	private Label CreateLabel(string name, Control parent) {
		Label lab = new Label();
		lab.Text = name;
		lab.Parent = parent;
		lab.ForeColor = System.Drawing.SystemColors.MenuHighlight;
		lab.AutoSize = true;
		lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
		lab.Margin = new Padding(2, 4, 2, 0);

		return lab;
	}

	public class Setting {

		public IndexSettings handler;
		public List<IndexStats.Stats> linkedStats;
		
		public FlowLayoutPanel panel;
		public NumericUpDown index;
		public TextBox name;
		public NumericUpDown digit;
		public NumericUpDown size;
		public Button color;
		public NumericUpDown val1raw;
		public NumericUpDown val1scaled;
		public NumericUpDown val2raw;
		public NumericUpDown val2scaled;
		public ComboBox suffix;
		public Button delete;

		public Setting(IndexSettings handler) {
			this.handler = handler;
			linkedStats = new List<IndexStats.Stats>();
		}

		public void Delete(object sender, EventArgs e) {
			// Remove a reference to this in the graphics index references
			foreach (GraphicsCreator.graphicPrototype.prototypeIndex p in Program.windowStatus.graphicsCreator.Prototype.indexes) {
				if (p.settingswithidx == this) {
					// If any of these p holds a refernce to this setting which shall be deleted
					p.settingswithidx = null;
				}
			}
			Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();

			handler.allSettings.Remove(this);

			Program.windowStatus.Controls.Remove(index);
			Program.windowStatus.Controls.Remove(name);
			Program.windowStatus.Controls.Remove(digit);
			Program.windowStatus.Controls.Remove(size);
			Program.windowStatus.Controls.Remove(color);
			Program.windowStatus.Controls.Remove(val1raw);
			Program.windowStatus.Controls.Remove(val1scaled);
			Program.windowStatus.Controls.Remove(val2raw);
			Program.windowStatus.Controls.Remove(val2scaled);
			Program.windowStatus.Controls.Remove(delete);
			Program.windowStatus.Controls.Remove(panel);

			index.Dispose();
			name.Dispose();
			digit.Dispose();
			size.Dispose();
			color.Dispose();
			val1raw.Dispose();
			val1scaled.Dispose();
			val2raw.Dispose();
			val2scaled.Dispose();
			delete.Dispose();
			panel.Dispose();

			for (int i = 0, j = linkedStats.Count; i < j; i++)
				linkedStats[i].Delete(null, null);
		}
		
		public void UpdateIndex(object sender, EventArgs e) {
			// Delete all stats which were using the old index
			for (int i = 0, j = linkedStats.Count; i < j; i++)
				linkedStats[i].Delete(null, null);

			Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();
		}

		public void UpdateStats(object sender, EventArgs e) {
			// Update all stats if there are any, with the new settings
			for (int i = 0, j = linkedStats.Count; i < j; i++)
				linkedStats[i].UpdateSettings();

			Program.windowStatus.graphicsCreator.Prototype.UpdateIdxSettingReference();
		}

		public void OpenColorDialog(object sender, EventArgs e) {
			if (Program.windowStatus.colorDialog1.ShowDialog() == DialogResult.OK) {
				this.color.BackColor = Program.windowStatus.colorDialog1.Color;
				UpdateStats(null, null);
			}
		}

		public override string ToString() {
			return "{" + index.Value.ToString() + "} " + name.Text;
		}
	}
}

public class IndexStats {

	private FlowLayoutPanel flowLayoutPanel;
	private Button btnEditMode;
	private IndexSettings indexSettings;
	private bool editMode = true;
	public List<Stats> allStats;

	public IndexStats (IndexSettings s, FlowLayoutPanel pan, Button btnEditMode) {
		indexSettings = s;
		flowLayoutPanel = pan;
		this.btnEditMode = btnEditMode;
		allStats = new List<Stats>();
		ChangeEditMode();
	}

	public void ChangeEditMode() {
		editMode = !editMode;

		if (editMode) {
			btnEditMode.Text = "Display Mode";
			foreach(Stats s in allStats) {
				s.index.Visible = true;
				s.delete.Visible = true;
				s.name.Visible = false;
			}
		} else {
			btnEditMode.Text = "Edit Mode";
			foreach (Stats s in allStats) {
				s.index.Visible = false;
				s.delete.Visible = false;
				s.name.Visible = true;
			}
		}
	}

	public void UpdateAllValues() {
		Stats[] ss = allStats.ToArray();
		for (int i = 0, j = ss.Length; i < j; i++)
			ss[i].UpdateValue();
	}

	public void CreateElement() {
		CreateElement(-1);
	}

	public void CreateElement(int index) {
		Stats stats = new Stats(indexSettings);
		allStats.Add(stats);

		FlowLayoutPanel panel = new FlowLayoutPanel();
		panel.Parent = flowLayoutPanel;
		panel.AutoSize = true;
		stats.panel = panel;

		ComboBox cmb = new ComboBox();
		cmb.Click += stats.UpdateIndexList;
		cmb.SelectedValueChanged += stats.UpdateIndex;
		cmb.Parent = panel;
		cmb.Width = 200;
		cmb.DropDownStyle = ComboBoxStyle.DropDownList;
		stats.index = cmb;

		Label lab = new Label();
		lab.Parent = panel;
		lab.AutoSize = true;
		lab.ForeColor = System.Drawing.SystemColors.MenuHighlight;
		stats.name = lab;

		Button btn = new Button();
		btn.Parent = panel;
		btn.BackColor = System.Drawing.Color.White;
		btn.Text = "X";
		btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btn.Size = new System.Drawing.Size(25, 25);
		stats.delete = btn;
		btn.Click += stats.Delete;

		stats.Init();
		if (index >= 0) {
			IndexSettings.Setting found = null;
			foreach (IndexSettings.Setting o in stats.index.Items) {
				if (o.index.Value == index) {
					found = o;
					break;
				}
			}
			stats.index.SelectedItem = found;
		}

		if (editMode) {
			stats.index.Visible = true;
			stats.delete.Visible = true;
			stats.name.Visible = false;

		} else {
			stats.index.Visible = false;
			stats.delete.Visible = false;
			stats.name.Visible = true;
		}
	}

	public class Stats {
		public FlowLayoutPanel panel;
		public ComboBox index;
		public Label name;
		public Button delete;
		public IndexSettings.Setting setting { get { return _setting; } set { SetSettings(value); } }
		private IndexSettings.Setting _setting;
		public IndexSettings indexSettings;

		private int value;
		public float scale;
		public float offset;
		private BindingSource bind;

		public Stats (IndexSettings s) {
			indexSettings = s;
			_setting = null;
			value = int.MinValue;
			scale = 1f;
			offset = 0f;
		}

		public void Init() {
			bind = new BindingSource();
			bind.DataSource = indexSettings.allSettings;
			index.DataSource = bind;
		}

		private void SetSettings(IndexSettings.Setting s) {
			// Remove link to old settings
			if (_setting != null)
				_setting.linkedStats.Remove(this);

			// If no setting selected
			if (s == null)
				return;

			// Add link to new settings
			_setting = s;
			_setting.linkedStats.Add(this);
		}

		public void UpdateSettings() {
			// If no setting has yet been selected
			if (_setting == null)
				return;

			// Update everything from settings
			name.Font = new System.Drawing.Font("Microsoft Sans Serif", (int)_setting.size.Value);
			name.ForeColor = _setting.color.BackColor;
			bind.ResetCurrentItem();
			// Update the value
			resetval = true; // Force reset of the value
			// Fix the scale and offset
			if (_setting == null) {
				offset = 0f;
				scale = 1f;
			} else {
				if (_setting.val2raw.Value - _setting.val1raw.Value == 0) {
					scale = 0f;
					offset = (float)(_setting.val1scaled.Value + _setting.val2scaled.Value) / 2f;
				} else {
					scale = (float)(_setting.val2scaled.Value - _setting.val1scaled.Value) / (float)(_setting.val2raw.Value - _setting.val1raw.Value);
					offset = scale * (float)_setting.val1raw.Value - (float)_setting.val1scaled.Value;
				}
			}
			UpdateValue();
		}

		private bool resetval = true;
		public void UpdateValue() {
			if (_setting == null)
				return;
			// Find new value
			int v = 0;
			bool found = true;
			if (found = (ST_Register.status[(int)_setting.index.Value] != null))
				v = (int)ST_Register.status[(int)_setting.index.Value];

			if (found || resetval) {
				if (value != v || resetval) {
					value = v;
					name.Text = _setting.ToString() + ": " + (value * scale + offset).ToString("N" + _setting.digit.Value) + " " + _setting.suffix.Text;
					resetval = false;
				}
			} else
				name.Text = _setting.ToString() + ": " + "NaN " + _setting.suffix.Text;
		}

		public void Delete(object sender, EventArgs e) {
			// Remove link to settings
			if (_setting != null)
				_setting.linkedStats.Remove(this);
			Program.windowStatus.indexStats.allStats.Remove(this);

			Program.windowStatus.Controls.Remove(index);
			Program.windowStatus.Controls.Remove(name);
			Program.windowStatus.Controls.Remove(delete);
			Program.windowStatus.Controls.Remove(panel);

			index.Dispose();
			name.Dispose();
			delete.Dispose();
			panel.Dispose();
		}

		public void UpdateIndexList(object sender, EventArgs e) {
			// Update the combobox showing all the index settings
			bind.ResetBindings(true);
		}

		private bool skip = false;
		public void UpdateIndex(object sender, EventArgs e) {
			if (skip) {
				skip = false;
				return;
			}
			skip = true;
			setting = (IndexSettings.Setting)index.SelectedItem;
			UpdateSettings();
		}
	}
}