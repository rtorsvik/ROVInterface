using System;
using System.Windows.Forms;

public class IndexSettings {
	
	private FlowLayoutPanel panelIndexSettings;

	public IndexSettings (FlowLayoutPanel pan) {
		panelIndexSettings = pan;
	}

	public FlowLayoutPanel CreateElement() {
		Setting setting = new Setting();

		// Panel handler
		FlowLayoutPanel temp = new FlowLayoutPanel();
		temp.Parent = panelIndexSettings;
		temp.Width = temp.Parent.Width - 6;
		temp.Height = 20;
		setting.panel = temp;

		// Index handler
		NumericUpDown nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateIndex;
		setting.index = nud;

		// Name handler
		TextBox txtbox = new TextBox();
		txtbox.Parent = temp;
		txtbox.TextChanged += setting.UpdateStats;
		setting.name = txtbox;

		// Digit handler
		nud = new NumericUpDown();
		nud.Parent = temp;
		nud.ValueChanged += setting.UpdateStats;
		setting.digit = nud;

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

		return temp;
	}

	public class Setting {

		public FlowLayoutPanel panel;
		public NumericUpDown index;
		public TextBox name;
		public NumericUpDown digit;
		public NumericUpDown size;
		public Button delete;

		public void Delete(object sender, EventArgs e) {
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
			panel.Dispose();
		}
		
		public void UpdateIndex(object sender, EventArgs e) {
			// Delete all stats which were using the old index
		}

		public void UpdateStats(object sender, EventArgs e) {
			// Update all stats if there are any, with the new settings
		}
	}
}