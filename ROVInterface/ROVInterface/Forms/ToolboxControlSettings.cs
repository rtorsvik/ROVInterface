using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class ToolboxControlSettings : Form {
	public ToolboxControlSettings(string title) {
		InitializeComponent();
		this.Text = title;
	}

	public Control[] allControls;
	private GraphicToolbox.ToolboxControl toolboxcontrol;

	private const string btnifdelayText_OnDelay   = "\"Message 2\" on delay";
	private const string btnifdelayText_OnRelease = "\"Message 2\" on mouse release";
	private const string grpbox2Text_OnDelay = "Message 2 on delay";
	private const string grpbox2Text_OnRelease = "Message 2 on release";
	public  const string btnifcontText_OnCont     = "Message continuously";
	public  const string btnifcontText_OnRelease  = "Message on mouse release";

	public void SetControl(GraphicToolbox.ToolboxControl control) {
		toolboxcontrol = control;
	}

	public void CreateSimpleButton() {
		allControls = new Control[2];

		GroupBox grpbox = new GroupBox();
		Label labindex = new Label();
		NumericUpDown nudindex = new NumericUpDown();
		Label labvalue = new Label();
		NumericUpDown nudvalue = new NumericUpDown();
		allControls[0] = nudindex;
		allControls[1] = nudvalue;

		pan_MainSettings.Controls.Add(grpbox);
		grpbox.Controls.Add(labindex);
		grpbox.Controls.Add(nudindex);
		grpbox.Controls.Add(labvalue);
		grpbox.Controls.Add(nudvalue);

		grpbox.Parent = pan_MainSettings;
		grpbox.Text = "Message on click";
		grpbox.ForeColor = SystemColors.MenuHighlight;
		grpbox.Margin = new Padding(3, 3, 3, 3);
		grpbox.Location = new Point(3, 0);
		grpbox.Size = new Size(grpbox.Parent.Width - grpbox.Margin.Horizontal, 46 + 6 + 4);

		labindex.Text = "Index:";
		labvalue.Text = "Value:";

		labindex.AutoSize = labvalue.AutoSize = true;

		labindex.Location = new Point(3, 23+2);
		nudindex.Location = new Point(labindex.Margin.Horizontal + labindex.Size.Width + labindex.Location.X, 23);
		labvalue.Location = new Point(nudindex.Margin.Horizontal + nudindex.Size.Width + nudindex.Location.X, 23+2);
		nudvalue.Location = new Point(labvalue.Margin.Horizontal + labvalue.Size.Width + labvalue.Location.X, 23);

		nudindex.Minimum = nudvalue.Minimum = int.MinValue;
		nudindex.Maximum = nudvalue.Maximum = int.MaxValue;
		
	}

	public void CreateOnOffButton() {
		// 0 == msg1_index, 1 == msg1_value
		// 2 == ifdelay,    3 == delay
		// 4 == msg2_index, 5 == msg2_value
		// 6 == grpbox2
		allControls = new Control[7];

		#region Set up first message
		GroupBox grpbox1 = new GroupBox();
		Label labindex1 = new Label();
		NumericUpDown nudindex1 = new NumericUpDown();
		Label labvalue1 = new Label();
		NumericUpDown nudvalue1 = new NumericUpDown();
		allControls[0] = nudindex1;
		allControls[1] = nudvalue1;

		pan_MainSettings.Controls.Add(grpbox1);
		grpbox1.Controls.Add(labindex1);
		grpbox1.Controls.Add(nudindex1);
		grpbox1.Controls.Add(labvalue1);
		grpbox1.Controls.Add(nudvalue1);

		grpbox1.Parent = pan_MainSettings;
		grpbox1.Text = "Message 1 on click";
		grpbox1.ForeColor = SystemColors.MenuHighlight;
		grpbox1.Margin = new Padding(3, 3, 3, 3);
		grpbox1.Location = new Point(3, 0);
		grpbox1.Size = new Size(grpbox1.Parent.Width - grpbox1.Margin.Horizontal, 46 + 6 + 4);

		labindex1.Text = "Index:";
		labvalue1.Text = "Value:";

		labindex1.AutoSize = labvalue1.AutoSize = true;

		labindex1.Location = new Point(3, 23 + 2);
		nudindex1.Location = new Point(labindex1.Margin.Horizontal + labindex1.Size.Width + labindex1.Location.X, 23);
		labvalue1.Location = new Point(nudindex1.Margin.Horizontal + nudindex1.Size.Width + nudindex1.Location.X, 23 + 2);
		nudvalue1.Location = new Point(labvalue1.Margin.Horizontal + labvalue1.Size.Width + labvalue1.Location.X, 23);

		nudindex1.Minimum = nudvalue1.Minimum = int.MinValue;
		nudindex1.Maximum = nudvalue1.Maximum = int.MaxValue;
		#endregion


		#region Set up delay
		Button btnifdelay = new Button();
		Label labdelay = new Label();
		NumericUpDown nuddelay = new NumericUpDown();
		allControls[2] = btnifdelay;
		allControls[3] = nuddelay;

		pan_MainSettings.Controls.Add(btnifdelay);
		pan_MainSettings.Controls.Add(labdelay);
		pan_MainSettings.Controls.Add(nuddelay);

		btnifdelay.Text = "";
		labdelay.Text = "Delay:";
		labdelay.AutoSize = true;
		nuddelay.Minimum = 0;
		nuddelay.Maximum = int.MaxValue;

		btnifdelay.UseVisualStyleBackColor = true;
		btnifdelay.ForeColor = SystemColors.ControlText;
		btnifdelay.Size = new Size(250, 37);

		btnifdelay.Location = new Point(3, 3 + groupBox1.Height);
		labdelay.Location = new Point(3, 6 + btnifdelay.Location.Y + btnifdelay.Height);
		nuddelay.Location = new Point(labdelay.Width + labdelay.Location.X, labdelay.Location.Y - 3);

		btnifdelay.Click += Btnifdelay_Click;
		btnifdelay.DoubleClick += Btnifdelay_Click;
		#endregion


		#region Set up second message
		GroupBox grpbox2 = new GroupBox();
		Label labindex2 = new Label();
		NumericUpDown nudindex2 = new NumericUpDown();
		Label labvalue2 = new Label();
		NumericUpDown nudvalue2 = new NumericUpDown();
		allControls[4] = nudindex2;
		allControls[5] = nudvalue2;
		allControls[6] = grpbox2;

		pan_MainSettings.Controls.Add(grpbox2);
		grpbox2.Controls.Add(labindex2);
		grpbox2.Controls.Add(nudindex2);
		grpbox2.Controls.Add(labvalue2);
		grpbox2.Controls.Add(nudvalue2);

		grpbox2.Parent = pan_MainSettings;
		grpbox2.Text = "Message on click";
		grpbox2.ForeColor = SystemColors.MenuHighlight;
		grpbox2.Margin = new Padding(3, 3, 3, 3);
		grpbox2.Location = new Point(3, labdelay.Height + labdelay.Location.Y + 3);
		grpbox2.Size = new Size(grpbox2.Parent.Width - grpbox2.Margin.Horizontal, 46 + 6 + 4);

		labindex2.Text = "Index:";
		labvalue2.Text = "Value:";

		labindex2.AutoSize = labvalue2.AutoSize = true;

		labindex2.Location = new Point(3, 23 + 2);
		nudindex2.Location = new Point(labindex2.Margin.Horizontal + labindex2.Size.Width + labindex2.Location.X, 23);
		labvalue2.Location = new Point(nudindex2.Margin.Horizontal + nudindex2.Size.Width + nudindex2.Location.X, 23 + 2);
		nudvalue2.Location = new Point(labvalue2.Margin.Horizontal + labvalue2.Size.Width + labvalue2.Location.X, 23);

		nudindex2.Minimum = nudvalue2.Minimum = int.MinValue;
		nudindex2.Maximum = nudvalue2.Maximum = int.MaxValue;
		#endregion
		
	}

	public void CreateSlider() {
		// 0 == msg_index, 1 == interval
		// 2 == min,       3 == max
		// 4 == ifcont
		allControls = new Control[5];

		TableLayoutPanel panel = new TableLayoutPanel();
		pan_MainSettings.Controls.Add(panel);
		panel.Size = new Size(pan_MainSettings.Width, 0);
		panel.AutoSize = true;
		panel.Location = new Point(0, 0);
		panel.RowCount = 4;
		panel.ColumnCount = 2;
		panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
		panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

		string[] labnames = { "Index:", "Interval:", "Minimum:", "Maximum:" };
		for (int i = 0; i < 4; i++) {
			panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			Label lab = new Label();
			NumericUpDown nud = new NumericUpDown();
			panel.Controls.Add(lab, 0, i);
			panel.Controls.Add(nud, 1, i);

			lab.AutoSize = true;
			lab.Text = labnames[i];

			nud.Minimum = int.MinValue;
			nud.Maximum = int.MaxValue;

			allControls[i] = nud;
		}

		((NumericUpDown)allControls[0]).Minimum = 0;

		Button btnifcont = new Button();
		pan_MainSettings.Controls.Add(btnifcont);
		allControls[4] = btnifcont;

		btnifcont.UseVisualStyleBackColor = true;
		btnifcont.ForeColor = SystemColors.ControlText;
		btnifcont.Size = new Size(250, 37);
		btnifcont.Location = new Point(3, 3 + panel.Location.X + panel.Height);

		btnifcont.Click += Btnifcont_Click;
		btnifcont.DoubleClick += Btnifcont_Click;
	}

	public void SetIfDelay(bool ifdelay) {
		allControls[2].Text = (ifdelay ? btnifdelayText_OnDelay : btnifdelayText_OnRelease);
		allControls[3].Enabled = ifdelay;
		allControls[6].Text = (ifdelay ? grpbox2Text_OnDelay : grpbox2Text_OnRelease);
	}

	private void Btnifdelay_Click(object sender, EventArgs e) {
		if (allControls[2].Text.CompareTo(btnifdelayText_OnRelease) == 0) {
			allControls[2].Text = btnifdelayText_OnDelay;
			allControls[3].Enabled = true;
			allControls[6].Text = grpbox2Text_OnDelay;
		} else {
			allControls[2].Text = btnifdelayText_OnRelease;
			allControls[3].Enabled = false;
			allControls[6].Text = grpbox2Text_OnRelease;
		}
	}

	private void Btnifcont_Click(object sender, EventArgs e) {
		if (allControls[4].Text.CompareTo(btnifcontText_OnCont) == 0) {
			allControls[4].Text = btnifcontText_OnRelease;
		} else {
			allControls[4].Text = btnifcontText_OnCont;
		}
	}

	private void btn_Accept_Click(object sender, EventArgs e) {
		// Set the settings for the control
		toolboxcontrol.SetSettings(this);
		Close();
	}

	private void btn_Cancel_Click(object sender, EventArgs e) {
		// Reset the settings for the control
		toolboxcontrol.ResetControlPosition();
		Close();
	}

	private void btn_Delete_Click(object sender, EventArgs e) {
		// Add in a check here to actually delete it
		Program.windowStatus.graphicToolbox.DeleteControl(toolboxcontrol);
		Close();
	}

	private void nud_Pos_ValueChanged(object sender, EventArgs e) {
		// Move the control at toolbox
		toolboxcontrol.control.Location = new Point((int)nud_PosX.Value, (int)nud_PosY.Value);
	}

	private void ToolboxControlSettings_FormClosing(object sender, FormClosingEventArgs e) {
		toolboxcontrol.ResetControlPosition();
	}
}