﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class IndexSettings {
	
	private FlowLayoutPanel panelIndexSettings;
	public List<Setting> allSettings;

	public IndexSettings (FlowLayoutPanel pan) {
		panelIndexSettings = pan;
		allSettings = new List<Setting>();
	}

	public FlowLayoutPanel CreateElement() {
		Setting setting = new Setting(this);
		setting.labels = new Label[4];

		// Panel handler
		FlowLayoutPanel temp = new FlowLayoutPanel();
		temp.Parent = panelIndexSettings;
		temp.Width = temp.Parent.Width - 6;
		temp.Height = 22;
		setting.panel = temp;

		setting.labels[0] = CreateLabel("Index:", temp);
		// Index handler
		NumericUpDown nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateIndex;
		nud.Width = 70;
		nud.Maximum = (int)Math.Pow(2, 15) - 1;
		setting.index = nud;

		setting.labels[1] = CreateLabel("Name:", temp);
		// Name handler
		TextBox txtbox = new TextBox();
		txtbox.Parent = temp;
		txtbox.TextChanged += setting.UpdateStats;
		txtbox.Width = 200;
		setting.name = txtbox;

		setting.labels[2] = CreateLabel("Digits:", temp);
		// Digit handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		nud.Width = 40;
		nud.Minimum = 0;
		nud.Maximum = 12;
		nud.Value = 2;
		setting.digit = nud;

		setting.labels[3] = CreateLabel("Size:", temp);
		// Size handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		nud.Width = 40;
		nud.Minimum = 8;
		nud.Maximum = 25;
		nud.Value = 12;
		setting.size = nud;

		// Color handler
		// DUNNO

		// Delete handler
		Button btn = new Button();
		btn.BackColor = System.Drawing.Color.White;
		btn.Parent = temp;
		btn.Text = "X";
		btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btn.Size = new System.Drawing.Size(22, 22);
		btn.Margin = new Padding(2);
		btn.Click += setting.Delete;
		setting.delete = btn;

		allSettings.Add(setting);
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
		lab.Margin = new Padding(2, 2, 2, 0);

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
		public Button delete;
		public Label[] labels;

		public Setting(IndexSettings handler) {
			this.handler = handler;
			linkedStats = new List<IndexStats.Stats>();
		}

		public void Delete(object sender, EventArgs e) {
			handler.allSettings.Remove(this);

			index.ValueChanged -= this.UpdateIndex;
			name.TextChanged -= this.UpdateStats;
			digit.ValueChanged -= this.UpdateStats;
			size.ValueChanged -= this.UpdateStats;
			delete.Click -= this.Delete;

			ROVInterface.Program.windowStatus.Controls.Remove(index);
			ROVInterface.Program.windowStatus.Controls.Remove(name);
			ROVInterface.Program.windowStatus.Controls.Remove(digit);
			ROVInterface.Program.windowStatus.Controls.Remove(size);
			ROVInterface.Program.windowStatus.Controls.Remove(delete);
			ROVInterface.Program.windowStatus.Controls.Remove(panel);

			index.Dispose();
			name.Dispose();
			digit.Dispose();
			size.Dispose();
			delete.Dispose();
			for (int i = 0, j = labels.Length; i < j; i++)
				labels[i].Dispose();
			panel.Dispose();

			for (int i = 0, j = linkedStats.Count; i < j; i++)
				linkedStats[i].Delete(null, null);
		}
		
		public void UpdateIndex(object sender, EventArgs e) {
			// Delete all stats which were using the old index
			for (int i = 0, j = linkedStats.Count; i < j; i++)
				linkedStats[i].Delete(null, null);
		}

		public void UpdateStats(object sender, EventArgs e) {
			// Update all stats if there are any, with the new settings
			for (int i = 0, j = linkedStats.Count; i < j; i++)
				linkedStats[i].UpdateSettings();
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
	private List<Stats> allStats;

	public IndexStats (IndexSettings s, FlowLayoutPanel pan, Button btnEditMode) {
		indexSettings = s;
		flowLayoutPanel = pan;
		this.btnEditMode = btnEditMode;
		allStats = new List<Stats>();
	}

	public void ChangeEditMode() {
		editMode = !editMode;

		if (editMode) {
			btnEditMode.Text = "Edit Mode";
			foreach(Stats s in allStats) {
				s.index.Visible = true;
				s.delete.Visible = true;
				s.name.Visible = false;
			}
		} else {
			btnEditMode.Text = "Display Mode";
			foreach (Stats s in allStats) {
				s.index.Visible = false;
				s.delete.Visible = false;
				s.name.Visible = true;
			}
		}
	}

	public void UpdateAllValues() {
		foreach (Stats s in allStats)
			s.UpdateValue();
	}

	public void CreateElement() {
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
		btn.Size = new System.Drawing.Size(22, 22);
		stats.delete = btn;
		btn.Click += stats.Delete;

		stats.Init();

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

		private float value;
		private BindingSource bind;

		public Stats (IndexSettings s) {
			indexSettings = s;
			_setting = null;
			value = float.MinValue;
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

			// Add link to new settings
			_setting = s;
			_setting.linkedStats.Add(this);
		}

		public void UpdateSettings() {
			// Update everything from settings
			name.Font = new System.Drawing.Font("Microsoft Sans Serif", (int)_setting.size.Value);
			bind.ResetCurrentItem();
			// Update the value
			UpdateValue();
		}

		public void UpdateValue() {
			if (_setting == null)
				return;
			// Find new value
			bool found = true;
			float v = 0.0f;
			try { value = ST_Register.status[(int)_setting.index.Value]; }
			catch (Exception e) { found = false; }

			if (found) {
				if (value != v) {
					value = v;
					name.Text = _setting.ToString() + ": " + value;
				}
			} else
				name.Text = _setting.ToString() + ": " + "NaN";
		}

		public void Delete(object sender, EventArgs e) {
			// Remove link to settings
			if (_setting != null)
				_setting.linkedStats.Remove(this);

			index.Click -= this.UpdateIndexList;
			index.SelectedValueChanged -= this.UpdateIndex;
			delete.Click -= this.Delete;

			ROVInterface.Program.windowStatus.Controls.Remove(index);
			ROVInterface.Program.windowStatus.Controls.Remove(name);
			ROVInterface.Program.windowStatus.Controls.Remove(delete);
			ROVInterface.Program.windowStatus.Controls.Remove(panel);

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