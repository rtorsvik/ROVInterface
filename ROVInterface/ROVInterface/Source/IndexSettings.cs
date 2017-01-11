﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

// FIX DELETION IN FOREACH WITH USING A FOR LOOP

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
		temp.Height = 20;
		setting.panel = temp;

		setting.labels[0] = CreateLabel("Index:", temp);
		// Index handler
		NumericUpDown nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateIndex;
		setting.index = nud;

		setting.labels[1] = CreateLabel("Name:", temp);
		// Name handler
		TextBox txtbox = new TextBox();
		txtbox.Parent = temp;
		txtbox.TextChanged += setting.UpdateStats;
		setting.name = txtbox;

		setting.labels[2] = CreateLabel("Digits:", temp);
		// Digit handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		setting.digit = nud;

		setting.labels[3] = CreateLabel("Size:", temp);
		// Size handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		setting.size = nud;

		// Color handler
		// DUNNO

		// Delete handler
		Button btn = new Button();
		btn.BackColor = System.Drawing.Color.White;
		btn.Parent = temp;
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

			foreach (IndexStats.Stats s in linkedStats)
				s.Delete(null, null);
		}
		
		public void UpdateIndex(object sender, EventArgs e) {
			// Delete all stats which were using the old index
			foreach (IndexStats.Stats s in linkedStats)
				s.Delete(null, null);
		}

		public void UpdateStats(object sender, EventArgs e) {
			// Update all stats if there are any, with the new settings
			foreach (IndexStats.Stats s in linkedStats)
				s.Update();
		}

		public override string ToString() {
			return "{" + index.Value.ToString() + "} " + name.Text;
		}
	}
}

public class IndexStats {

	private FlowLayoutPanel flowLayoutPanel;
	private IndexSettings indexSettings;

	public IndexStats (IndexSettings s, FlowLayoutPanel pan) {
		indexSettings = s;
		flowLayoutPanel = pan;
	}

	public void CreateElement() {
		Stats stats = new Stats(indexSettings);

		FlowLayoutPanel panel = new FlowLayoutPanel();
		panel.Parent = flowLayoutPanel;
		stats.panel = panel;

		ComboBox cmb = new ComboBox();
		cmb.Click += stats.UpdateIndexList;
		cmb.TextChanged += stats.UpdateIndex;
		cmb.Parent = panel;
		stats.index = cmb;

		Label lab = new Label();
		lab.Parent = panel;
		stats.name = lab;

		Button btn = new Button();
		btn.Parent = panel;
		stats.delete = btn;
		btn.Click += stats.Delete;
	}

	public class Stats {
		public FlowLayoutPanel panel;
		public ComboBox index;
		public Label name;
		public Button delete;
		public IndexSettings.Setting setting { get { return _setting; } set { SetSettings(value); } }
		private IndexSettings.Setting _setting;
		public IndexSettings indexSettings;

		public Stats (IndexSettings s) {
			indexSettings = s;
			_setting = null;
		}

		private void SetSettings(IndexSettings.Setting s) {
			// Remove link to old settings
			if (_setting != null)
				_setting.linkedStats.Remove(this);

			// Add link to new settings
			_setting = s;
			_setting.linkedStats.Add(this);
		}

		public void Update() {
			// Update everything from settings
		}

		public void Delete(object sender, EventArgs e) {
			// Remove link to settings
			if (_setting != null)
				_setting.linkedStats.Remove(this);

			index.Click -= this.UpdateIndexList;
			index.TextChanged -= this.UpdateIndex;
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
			index.Items.Clear();
			foreach (IndexSettings.Setting s in indexSettings.allSettings)
				index.Items.Add(s);
		}

		public void UpdateIndex(object sender, EventArgs e) {
			setting = (IndexSettings.Setting)index.SelectedItem;
		}
	}
}