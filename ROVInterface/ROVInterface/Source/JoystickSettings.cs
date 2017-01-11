using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class JoystickSettings
{
	AxisSetting s1;
	AxisSetting s2;

	public JoystickSettings()
	{
		s1 = new AxisSetting("TEST1");
		s2 = new AxisSetting("TEST2");
	}


	/// <summary>
	/// Setings for an axis on a joystick
	/// </summary>
	private class AxisSetting
	{
		private static int SNUM = 0;
		private const int SSPACE = 30;	//pixels, spacing between AxisSetting elements
		private const int SOFF = 50;    //pixels, offset from top

		public FlowLayoutPanel container;

		public Label description;

		public ComboBox joystick;
		public ComboBox axis;

		public ProgressBar inValue_bar;
		public TextBox inValue;

		public CheckBox reverse;
		public NumericUpDown expo;
		public NumericUpDown deadband;
		public NumericUpDown offset;
		public NumericUpDown max;

		public ProgressBar outValue_bar;
		public TextBox outValue;



		/// <summary>
		/// Create new set of settings for a joystick axis
		/// </summary>
		/// <param name="description">Description of what this joystick axis controls</param>
		public AxisSetting(string descr)
		{
			container = new FlowLayoutPanel();
			container.Size = new System.Drawing.Size(1500, 30);
			container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
			container.Location = new System.Drawing.Point(20, SNUM * SSPACE + SOFF);

			description = new Label();
			description.Text = descr;
			description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);

			joystick = new ComboBox();
			joystick.Size = new System.Drawing.Size(70, 24);
			joystick.Items.AddRange(JoystickHandler.joystick);

			axis = new ComboBox();
			axis.Size = new System.Drawing.Size(70, 24);
			axis.Items.AddRange(axies);

			inValue_bar = new ProgressBar();
			inValue_bar.Maximum = 65535;
			inValue_bar.Size = new System.Drawing.Size(100, 20);
			inValue_bar.Margin = new Padding(30, 3, 3, 3);

			inValue = new TextBox();
			inValue.Size = new System.Drawing.Size(50, 24);

			reverse = new CheckBox();
			reverse.Text = "";
			reverse.AutoSize = true;
			reverse.Margin = new Padding(30, 3, 3, 3);

			expo = new NumericUpDown();
			expo.DecimalPlaces = 1;
			expo.Increment = 0.1m;
			expo.Minimum = 1;
			expo.Maximum = 3;
			expo.Size = new System.Drawing.Size(40, 22);

			deadband = new NumericUpDown();
			deadband.Maximum = 100;
			deadband.Size = new System.Drawing.Size(50, 22);

			offset = new NumericUpDown();
			offset.Maximum = 100;
			offset.Size = new System.Drawing.Size(50, 22);

			max = new NumericUpDown();
			max.Maximum = 100;
			max.Size = new System.Drawing.Size(50, 22);

			outValue_bar = new ProgressBar();
			outValue_bar.Maximum = 65535;
			outValue_bar.Size = new System.Drawing.Size(100, 20);
			outValue_bar.Margin = new Padding(30, 3, 3, 3);

			outValue = new TextBox();
			outValue.Size = new System.Drawing.Size(50, 24);


			DrawItems();
			SNUM++;

		}

		private void DrawItems()
		{
			ROVInterface.WindowStatus window = ROVInterface.Program.windowStatus;
			TabPage page = window.tabPage5;


			container.Controls.Add(description);

			container.Controls.Add(joystick);
			container.Controls.Add(axis);

			container.Controls.Add(inValue_bar);
			container.Controls.Add(inValue);

			container.Controls.Add(reverse);
			container.Controls.Add(expo);
			container.Controls.Add(deadband);
			container.Controls.Add(offset);
			container.Controls.Add(max);

			container.Controls.Add(outValue_bar);
			container.Controls.Add(outValue);

			page.Controls.Add(container);
		}

		private string[] axies = {
			"ARx",	"ARy",	"ARz",
			"AX",	"AY",	"AZ",
			"FRx",	"FRy",	"FRz",
			"FX",	"FY",	"FZ",
			"RX",	"RY",	"RZ",
			"VRx",	"VRy",	"VRz",
			"VX",	"VY",	"VZ",
			"X",	"Y",	"Z"};


	}

}

