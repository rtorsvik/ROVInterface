using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using jh = JoystickHandler;

//BUG FIXES
//make autodetect functions to a separate thread so that it does not frees the entire program
//autodetect removes already detected selected axis if a new axis is not detected, might not be a problem


class JoystickSettings
{
	private static int SNUM = 0;	//Setting number
	private const int SSPACE = 30;  //pixels, spacing between AxisSetting elements
	private const int SOFF = 40;    //pixels, offset from top


	AxisSetting as0;
	AxisSetting as1;
	AxisSetting as2;
	AxisSetting as3;
	AxisSetting as4;
	AxisSetting as5;

	ButtonSetting bs6;

	public JoystickSettings()
	{
		as0 = new AxisSetting("Forward/backward");
		as1 = new AxisSetting("Left/right");
		as2 = new AxisSetting("Up/Down");
		as3 = new AxisSetting("Pitch");
		as4 = new AxisSetting("Roll");
		as5 = new AxisSetting("Yaw");

		bs6 = new ButtonSetting("Lights on/off");
	}

	public void Update()
	{
		as0.Update();
		as1.Update();
		as2.Update();
		as3.Update();
		as4.Update();
		as5.Update();

		bs6.Update();
	}


	/// <summary>
	/// Setings for an axis on a joystick
	/// </summary>
	private class AxisSetting
	{
		//Controls
		private FlowLayoutPanel c_container;

		private Label c_description;

		private ComboBox c_joystick;
		private ComboBox c_axis;

		private Button c_autoDetect;

		private ProgressBar c_inValue_bar;
		private TextBox c_inValue;

		private CheckBox c_reverse;
		private NumericUpDown c_expo;
		private NumericUpDown c_deadband;
		private NumericUpDown c_offset;
		private NumericUpDown c_max;

		private ProgressBar c_outValue_bar;
		private TextBox c_outValue;

		//Settings
		public int joystick;	//index of the selected joystick
		public int axis;        //index of the selected axis

		public int inValue;     //Value of the axis on the joystick

		public int reverse;     //(-1) if reversed, otherwise (1)
		public float expo;		//curvature of outValue
		public int deadband;	//how much does inValue have to travel from midpoint before outValue starts to change [%]
		public int offset;      //offset, at which value does outValue start when inValue exceeds deadband [%]
		public int max;			//maximum value of output [%]

		public int outValue;	//calculated output value  


		/// <summary>
		/// Create new set of settings for a joystick axis
		/// </summary>
		/// <param name="description">Description of what this joystick axis controls</param>
		public AxisSetting(string descr)
		{
			c_container = new FlowLayoutPanel();
			c_container.Size = new System.Drawing.Size(1500, 30);
			c_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
			c_container.Location = new System.Drawing.Point(20, SNUM * SSPACE + SOFF);

			c_description = new Label();
			c_description.Text = descr;
			c_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			c_description.Size = new System.Drawing.Size(130, 24);

			c_joystick = new ComboBox();
			c_joystick.DropDownStyle = ComboBoxStyle.DropDownList;
			c_joystick.Size = new System.Drawing.Size(70, 24);
			c_joystick.Items.AddRange(JoystickHandler.joystick);

			c_axis = new ComboBox();
			c_axis.DropDownStyle = ComboBoxStyle.DropDownList;
			c_axis.Size = new System.Drawing.Size(50, 24);
			c_axis.Items.AddRange(axes_list);

			c_inValue_bar = new ProgressBar();
			c_inValue_bar.Maximum = 65535;
			c_inValue_bar.Size = new System.Drawing.Size(100, 20);
			c_inValue_bar.Margin = new Padding(30, 3, 3, 3);

			c_inValue = new TextBox();
			c_inValue.Size = new System.Drawing.Size(50, 24);

			c_reverse = new CheckBox();
			c_reverse.Text = "";
			c_reverse.AutoSize = true;
			c_reverse.Margin = new Padding(30, 3, 30, 3);

			c_expo = new NumericUpDown();
			c_expo.DecimalPlaces = 1;
			c_expo.Increment = 0.1m;
			c_expo.Minimum = 1;
			c_expo.Maximum = 3;
			c_expo.Size = new System.Drawing.Size(40, 22);
			c_expo.Margin = new Padding(8, 3, 8, 3);

			c_deadband = new NumericUpDown();
			c_deadband.Maximum = 100;
			c_deadband.Size = new System.Drawing.Size(50, 22);
			c_deadband.Margin = new Padding(8, 3, 8, 3);

			c_offset = new NumericUpDown();
			c_offset.Maximum = 100;
			c_offset.Size = new System.Drawing.Size(50, 22);
			c_offset.Margin = new Padding(8, 3, 8, 3);

			c_max = new NumericUpDown();
			c_max.Value = 100;
			c_max.Maximum = 100;
			c_max.Size = new System.Drawing.Size(50, 22);
			c_max.Margin = new Padding(8, 3, 8, 3);

			c_outValue_bar = new ProgressBar();
			c_outValue_bar.Maximum = 65535;
			c_outValue_bar.Size = new System.Drawing.Size(100, 20);
			c_outValue_bar.Margin = new Padding(30, 3, 3, 3);

			c_outValue = new TextBox();
			c_outValue.Size = new System.Drawing.Size(50, 24);

			c_autoDetect = new Button();
			c_autoDetect.Click += this.AutoDetect;
			c_autoDetect.Text = "A";
			c_autoDetect.Size = new System.Drawing.Size(24, 24);

			DrawItems();
			SNUM++;

		}

		private void DrawItems()
		{
			ROVInterface.WindowStatus window = ROVInterface.Program.windowStatus;
			TabPage page = window.tabPage5;

			c_container.Controls.Add(c_description);

			c_container.Controls.Add(c_joystick);
			c_container.Controls.Add(c_axis);

			c_container.Controls.Add(c_autoDetect);

			c_container.Controls.Add(c_inValue_bar);
			c_container.Controls.Add(c_inValue);

			c_container.Controls.Add(c_reverse);
			c_container.Controls.Add(c_expo);
			c_container.Controls.Add(c_deadband);
			c_container.Controls.Add(c_offset);
			c_container.Controls.Add(c_max);

			c_container.Controls.Add(c_outValue_bar);
			c_container.Controls.Add(c_outValue);

			

			page.Controls.Add(c_container);
		}



		/// <summary>
		/// Update values in 
		/// </summary>
		public void Update()
		{
			try
			{
				joystick = c_joystick.SelectedIndex;
				axis = c_axis.SelectedIndex;
				
				reverse = c_reverse.Checked ? -1 : 1;
				expo = (float)c_expo.Value;
				deadband = (int)c_deadband.Value;
				offset = (int)c_offset.Value;
				max = (int)c_max.Value;

				if (offset > max)   //offset can't be greater than max
				{
					offset = max;
					c_offset.Value = c_max.Value;
				}

				if (joystick == -1 || axis == -1)
					return;

				inValue = jh.joystick[joystick].axis[axis];

				c_inValue_bar.Value = inValue + 32768;
				c_inValue.Text = inValue.ToString();

				outValue = (int)Rescale(inValue);

				c_outValue_bar.Value = outValue + 32768;
				c_outValue.Text = outValue.ToString();

			} catch (Exception e) { }
		}



		/// <summary>
		/// rescale the input value
		/// </summary>
		/// <returns></returns>
		public double Rescale(double x)
		{
			//Do math
			double x0 = 32767 * (deadband / 100d);
			double y0 = 32767 * (offset / 100d);

			double x1 = 32767;
			double y1 = 32767 * (max / 100d);

			double e = expo;

			//in the "dead" zone of the deadband, y = 0, else, calculate y value
			double y;
			if (-x0 < x && x < x0)
			{
				y = 0;
			}
			else
			{
				//Function might not have real solutins for negative values of x, 
				//so calculate only for asolute values of x, and convert later
				y = (reverse * (Math.Pow((Math.Abs(x) - x0), e)) * (y1 - y0) / (Math.Pow((x1 - x0), e)) + y0);
			}

			//for negative values of x, invert y value 
			if (x < 0)
				y = -y;
			
			return y;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="joystickIndex"></param>
		/// <param name="axisIndex"></param>
		/// <param name="reverse">{-1,1} -1 when reversed</param>
		/// <param name="expo">1,0...3,0</param>
		/// <param name="deadband">0...100</param>
		/// <param name="offset">0...100</param>
		/// <param name="max">0...100</param>
		public void SetSettings(int joystickIndex, int axisIndex, int reverse, decimal expo, int deadband, int offset, int max)
		{
			c_joystick.SelectedIndex = joystickIndex;
			c_axis.SelectedIndex = axisIndex;

			if (reverse == -1)
				c_reverse.Checked = true;

			c_expo.Value = expo;
			c_deadband.Value = deadband;
			c_offset.Value = offset;
			c_max.Value = max;
		}



		/// <summary>
		/// Autodetect axis
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AutoDetect(object sender, EventArgs e) //(object sender, EventArgs e) ??? make this function run when hitting button
		{
			//if there is no joystick selected, sop auto detecting
			if (this.joystick == -1)
				return;

			TJoystick joystick = jh.joystick[this.joystick];

			int index = -1;
			int axisValue = 0;

			//Change color of button to indicate that autotedect is running
			System.Drawing.Color originalColor = c_autoDetect.BackColor;
			c_autoDetect.BackColor = System.Drawing.Color.Aquamarine;
			c_autoDetect.Update();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			//if none of the axes changes enough within 3 seconds, stop this autodetect processs and use -1 as index
			while (stopWatch.ElapsedMilliseconds < 3000 && index == -1)
			{
				jh.update();

				for (int i = 0; i < joystick.axis.Length; i++)
				{
					axisValue = joystick.axis[i];
					if (axisValue < -32767 * 0.5 || axisValue > 32767 * 0.5)
						index = i;
				}

			}

			c_axis.SelectedIndex = index;
			c_autoDetect.BackColor = originalColor;
			c_autoDetect.Update();

		}



		private string[] axes_list = {
			"ARx",	"ARy",	"ARz",
			"AX",	"AY",	"AZ",
			"FRx",	"FRy",	"FRz",
			"FX",	"FY",	"FZ",
			"RX",	"RY",	"RZ",
			"VRx",	"VRy",	"VRz",
			"VX",	"VY",	"VZ",
			"X",	"Y",	"Z"};


	}



	private class ButtonSetting
	{
		//Controls
		private FlowLayoutPanel c_container;

		private Label c_description;

		private ComboBox c_joystick;
		private NumericUpDown c_button;

		private Button c_autoDetect;

		private CheckBox c_inValue;

		//Settings
		public int joystick;    //index of the selected joystick
		public int button;        //index of the selected axis

		public bool inValue;     //Value of the axis on the joystick

		public bool outValue;     //Value of the axis on the joystick

		/// <summary>
		/// Create new set of settings for a joystick button
		/// </summary>
		/// <param name="description">Description of what this joystick axis controls</param>
		public ButtonSetting(string descr)
		{
			c_container = new FlowLayoutPanel();
			c_container.Size = new System.Drawing.Size(1500, 30);
			c_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
			c_container.Location = new System.Drawing.Point(20, SNUM * SSPACE + SOFF);

			c_description = new Label();
			c_description.Text = descr;
			c_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			c_description.Size = new System.Drawing.Size(130, 24);

			c_joystick = new ComboBox();
			c_joystick.DropDownStyle = ComboBoxStyle.DropDownList;
			c_joystick.Size = new System.Drawing.Size(70, 24);
			c_joystick.Items.AddRange(JoystickHandler.joystick);

			c_button = new NumericUpDown();
			c_button.Minimum = 0;
			c_button.Maximum = 127;
			c_button.Size = new System.Drawing.Size(50, 24);

			c_autoDetect = new Button();
			c_autoDetect.Click += this.AutoDetect;
			c_autoDetect.Text = "A";
			c_autoDetect.Size = new System.Drawing.Size(24, 24);

			c_inValue = new CheckBox();
			c_inValue.Text = "";
			c_inValue.AutoSize = true;
			c_inValue.Margin = new Padding(30, 3, 30, 3);

			DrawItems();
			SNUM++;
		}

		private void DrawItems()
		{
			ROVInterface.WindowStatus window = ROVInterface.Program.windowStatus;
			TabPage page = window.tabPage5;

			c_container.Controls.Add(c_description);

			c_container.Controls.Add(c_joystick);
			c_container.Controls.Add(c_button);

			c_container.Controls.Add(c_autoDetect);

			c_container.Controls.Add(c_inValue);

			page.Controls.Add(c_container);
		}

		/// <summary>
		/// Update values in 
		/// </summary>
		public void Update()
		{
			try
			{
				joystick = c_joystick.SelectedIndex;
				button = (int)c_button.Value;

				if (joystick == -1 || button == -1)
					return;

				inValue = jh.joystick[joystick].button[button];

				c_inValue.Checked = inValue;

				outValue = inValue;
			}
			catch (Exception e) { }
		}

		/// <summary>
		/// Autodetect axis
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AutoDetect(object sender, EventArgs e) //(object sender, EventArgs e) ??? make this function run when hitting button
		{
			//if there is no joystick selected, sop auto detecting
			if (this.joystick == -1)
				return;

			TJoystick joystick = jh.joystick[this.joystick];

			int index = -1;
			bool buttonValue = false;

			//Change color of button to indicate that autotedect is running
			System.Drawing.Color originalColor = c_autoDetect.BackColor;
			c_autoDetect.BackColor = System.Drawing.Color.Aquamarine;
			c_autoDetect.Update();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			//if none of the axes changes enough within 3 seconds, stop this autodetect processs and use -1 as index
			while (stopWatch.ElapsedMilliseconds < 3000 && index == -1)
			{
				jh.update();

				for (int i = 0; i < joystick.axis.Length; i++)
				{
					buttonValue = joystick.button[i];
					if (buttonValue)
						index = i;
				}

			}

			if (index == -1) index = 0;

			c_button.Value = index;
			c_autoDetect.BackColor = originalColor;
			c_autoDetect.Update();

		}

	}

}

