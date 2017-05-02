using System;
using System.Collections;
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


public class JoystickSettings
{
	private static int SNUM = 0;	//Setting number
	private const int SSPACE = 30;  //pixels, spacing between AxisSetting elements
	private const int SOFF = 40;    //pixels, offset from top

	public AxisSetting[] axisSetting;
	public string[] axisLabels = new string[12] { "Forward/backward", "Left/right", "Up/Down", "Pitch", "Roll", "Yaw", "<spare>", "<spare>", "<spare>", "<spare>", "<spare>", "<spare>" };
	public int[] prevOutA = new int[12];

	public ButtonSetting[] buttonSetting;
	public string[] buttonLabels = new string[15] { "Arm motors", "pitch", "pitch", "roll", "roll", "grab", "release", "rot cw", "rot ccw", "<spare>", "<spare>", "<spare>", "<spare>", "<spare>", "<spare>" };
	public bool[] prevOutB = new bool[15];



	public JoystickSettings()
	{
		axisSetting = new AxisSetting[axisLabels.Length];
		buttonSetting = new ButtonSetting[buttonLabels.Length];

		for (int i = 0; i < axisLabels.Length; i++)
		{
			axisSetting[i] = new AxisSetting(axisLabels[i]);
		}

		for (int i = 0; i < buttonLabels.Length; i++)
		{
			buttonSetting[i] = new ButtonSetting(buttonLabels[i]);
		}
	}



	public void Update()
	{
		// Update axes
		for (int i = 0; i < axisLabels.Length; i++)
		{
			axisSetting[i].Update();

			//TEMP: finn ut sammen med terje hvor disse egentlig skal kalles hen
			if (axisSetting[i].outValue != prevOutA[i])
				ST_Register.commands[i + 1] = axisSetting[i].outValue;
			prevOutA[i] = axisSetting[i].outValue;
		}

		// Update buttons
		for (int i = 0; i < buttonLabels.Length; i++)
		{
			buttonSetting[i].Update();

			//TEMP: finn ut sammen med terje hvor disse egentlig skal kalles hen
			if (buttonSetting[i].outValueBool != prevOutB[i])
			{
				if (ST_Register.commands[buttonSetting[i].index] == null)
					ST_Register.commands[buttonSetting[i].index] = 0;

				//if bitnumber is set to -1, dont set a bit, but write a value to the whole index instead
				if (buttonSetting[i].bitnr == -1) 
				{
					ST_Register.commands[buttonSetting[i].index] = buttonSetting[i].outValueInt;
				}
				
				//else, set a bit in the command to the value of the button	
				else
					ST_Register.commands[buttonSetting[i].index] = ST_Register.commands[buttonSetting[i].index] & ~(1 << buttonSetting[i].bitnr) | (Convert.ToInt32(buttonSetting[i].outValueBool) << buttonSetting[i].bitnr);
				
			}
			
			prevOutB[i] = buttonSetting[i].outValueBool;
		}

	}



	public void LoadConnectedJoysticks()
	{
		for (int i = 0; i < axisLabels.Length; i++)
		{
			axisSetting[i].LoadConnectedJoysticks();
		}
	}



	/// <summary>
	/// Setings for an axis on a joystick
	/// </summary>
	public class AxisSetting
	{
		//Controls
		private FlowLayoutPanel c_container;

		private Label c_description;

		private NumericUpDown c_index;

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
		private NumericUpDown c_trim;

		private ProgressBar c_outValue_bar;
		private TextBox c_outValue;

		//Settings
		public int index;		//index of the command to control with the axis

		public int joystick;	//index of the selected joystick
		public int axis;        //index of the selected axis

		public int inValue;     //Value of the axis on the joystick

		public bool reverse;    //outValue reversed when true
		public float expo;		//curvature of outValue
		public int deadband;	//how much does inValue have to travel from midpoint before outValue starts to change [%]
		public int offset;      //offset, at which value does outValue start when inValue exceeds deadband [%]
		public int max;         //maximum value of output [%]
		public int trim;         //maximum value of output [%]

		public int outValue;	//calculated output value  


		/// <summary>
		/// Create new set of settings for a joystick axis
		/// </summary>
		/// <param name="description">Description of what this joystick axis controls</param>
		public AxisSetting(string descr)
		{
			c_container = new FlowLayoutPanel();
			c_container.Size = new System.Drawing.Size(1300, 30);
			c_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
			//c_container.Location = new System.Drawing.Point(20, SNUM * SSPACE + SOFF);

			c_description = new Label();
			c_description.Text = descr;
			c_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			c_description.Size = new System.Drawing.Size(130, 24);

			c_index = new NumericUpDown();
			c_index.Minimum = 0;
			c_index.Maximum = 32767;
			c_index.Value = SNUM;
			c_index.Size = new System.Drawing.Size(50, 24);

			c_joystick = new ComboBox();
			c_joystick.DropDownStyle = ComboBoxStyle.DropDownList;
			c_joystick.Size = new System.Drawing.Size(70, 24);
			c_joystick.Margin = new Padding(44, 3, 3, 3);
			c_joystick.Items.AddRange(JoystickHandler.joystick);

			c_axis = new ComboBox();
			c_axis.DropDownStyle = ComboBoxStyle.DropDownList;
			c_axis.Size = new System.Drawing.Size(50, 24);
			c_axis.Items.AddRange(axes_list);

			c_inValue_bar = new ProgressBar();
			c_inValue_bar.Maximum = 65535;
			c_inValue_bar.Size = new System.Drawing.Size(80, 20);
			c_inValue_bar.Margin = new Padding(30, 3, 3, 3);

			c_inValue = new TextBox();
			c_inValue.Size = new System.Drawing.Size(50, 24);

			c_reverse = new CheckBox();
			c_reverse.Text = "";
			c_reverse.AutoSize = true;
			c_reverse.Margin = new Padding(30, 3, 30, 3);
			c_reverse.CheckedChanged += this.UpdateGraph;

			c_expo = new NumericUpDown();
			c_expo.DecimalPlaces = 1;
			c_expo.Increment = 0.1m;
			c_expo.Minimum = 1;
			c_expo.Maximum = 3;
			c_expo.Size = new System.Drawing.Size(40, 22);
			c_expo.Margin = new Padding(8, 3, 8, 3);
			c_expo.ValueChanged += this.UpdateGraph;

			c_deadband = new NumericUpDown();
			c_deadband.Maximum = 100;
			c_deadband.Size = new System.Drawing.Size(50, 22);
			c_deadband.Margin = new Padding(8, 3, 8, 3);
			c_deadband.ValueChanged += this.UpdateGraph;

			c_offset = new NumericUpDown();
			c_offset.Maximum = 100;
			c_offset.Size = new System.Drawing.Size(50, 22);
			c_offset.Margin = new Padding(8, 3, 8, 3);
			c_offset.ValueChanged += this.UpdateGraph;

			c_max = new NumericUpDown();
			c_max.Value = 100;
			c_max.Maximum = 100;
			c_max.Size = new System.Drawing.Size(50, 22);
			c_max.Margin = new Padding(8, 3, 8, 3);
			c_max.ValueChanged += this.UpdateGraph;

			c_trim = new NumericUpDown();
			c_trim.Value = 0;
			c_trim.Minimum = -32767;
			c_trim.Maximum = 32767;
			c_trim.Size = new System.Drawing.Size(50, 22);
			c_trim.Margin = new Padding(8, 3, 8, 3);

			c_outValue_bar = new ProgressBar();
			c_outValue_bar.Maximum = 65535;
			c_outValue_bar.Size = new System.Drawing.Size(80, 20);
			c_outValue_bar.Margin = new Padding(30, 3, 3, 3);

			c_outValue = new TextBox();
			c_outValue.Size = new System.Drawing.Size(50, 24);

			c_autoDetect = new Button();
			c_autoDetect.Click += this.AutoDetect2;
			c_autoDetect.Text = "A";
			c_autoDetect.Size = new System.Drawing.Size(23, 23);
			c_autoDetect.Margin = new Padding(3, 2, 3, 3);
			c_autoDetect.UseVisualStyleBackColor = true;

			DrawItems();
			SNUM++;

		}

		private void DrawItems()
		{
			WindowStatus window = Program.windowStatus;
			TabPage page = window.tabPage5;

			c_container.Controls.Add(c_description);

			c_container.Controls.Add(c_index);

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
			c_container.Controls.Add(c_trim);

			c_container.Controls.Add(c_outValue_bar);
			c_container.Controls.Add(c_outValue);



			//page.Controls.Add(c_container);
			window.flp_joysticksetting_axis.Controls.Add(c_container);
		}

		/// <summary>
		/// Update values in 
		/// </summary>
		public void Update()
		{
			try
			{
				index = (int)c_index.Value;

				joystick = c_joystick.SelectedIndex;
				axis = c_axis.SelectedIndex;

				reverse = c_reverse.Checked;
				expo = (float)c_expo.Value;
				deadband = (int)c_deadband.Value;
				offset = (int)c_offset.Value;
				max = (int)c_max.Value;
				trim = (int)c_trim.Value;

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

			double t = trim;

			int r = reverse ? -1 : 1;

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
				y = r * ((Math.Pow((Math.Abs(x) - x0), e)) * (y1 - y0) / (Math.Pow((x1 - x0), e)) + y0);
			}

			//for negative values of x, invert y value 
			if (x < 0)
				y = -y;
			
			return y + t;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="joystickIndex"></param>
		/// <param name="axisIndex"></param>
		/// <param name="reverse">true when reversed</param>
		/// <param name="expo">1,0...3,0</param>
		/// <param name="deadband">0...100</param>
		/// <param name="offset">0...100</param>
		/// <param name="max">0...100</param>
		public void SetSettings(int joystickIndex, int axisIndex, bool reverse, decimal expo, int deadband, int offset, int max)
		{
			try {
				c_joystick.SelectedIndex = joystickIndex;
			} catch {
				c_joystick.SelectedIndex = -1;
			}
			c_axis.SelectedIndex = axisIndex;

			if (reverse)
				c_reverse.Checked = true;

			c_expo.Value = expo;
			c_deadband.Value = deadband;
			c_offset.Value = offset;
			c_max.Value = max;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="joystickIndex"></param>
		/// <param name="axisIndex"></param>
		/// <param name="reverse">true when reversed</param>
		/// <param name="expo">1,0...3,0</param>
		/// <param name="deadband">0...100</param>
		/// <param name="offset">0...100</param>
		/// <param name="max">0...100</param>
		public void SetSettings(int index, int joystickIndex, int axisIndex, bool reverse, decimal expo, int deadband, int offset, int max)
		{
			SetSettings(joystickIndex, axisIndex, reverse, expo, deadband, offset, max);
			this.index = index;
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
			c_autoDetect.BackColor = System.Drawing.Color.Aquamarine;
			c_autoDetect.Update();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			//if none of the axes changes enough within 3 seconds, stop this autodetect processs and use -1 as index
			while (stopWatch.ElapsedMilliseconds < 3000 && index == -1)
			{
				jh.Update();

				for (int i = 0; i < joystick.axis.Length; i++)
				{
					axisValue = joystick.axis[i];
					if (axisValue < -32767 * 0.5 || axisValue > 32767 * 0.5)
						index = i;
				}

			}

			c_axis.SelectedIndex = index;
			c_autoDetect.UseVisualStyleBackColor = true;
			c_autoDetect.Update();

		}

		/// <summary>
		/// Autodetect axis and joystick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AutoDetect2(object sender, EventArgs e) //(object sender, EventArgs e) ??? make this function run when hitting button
		{
			//detection threshold
			float dth = 255;

			//Change color of button to indicate that autotedect is running
			c_autoDetect.BackColor = System.Drawing.Color.Aquamarine;
			c_autoDetect.Update();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			//if none of the axes changes enough within 3 seconds, stop this autodetect processs and use -1 as index and joystick
			int joystickIndex = -1;
			int axisIndex = -1;
			while (stopWatch.ElapsedMilliseconds < 3000 && axisIndex == -1)
			{
				jh.Update();

				//for each joystick, check each axis
				for (int ji = 0; ji < jh.joystick.Length; ji++)
				{
					TJoystick joystick = jh.joystick[ji];

					for (int ai = 0; ai < joystick.axis.Length; ai++)
					{
						int axisValue = joystick.axis[ai];
						int oldAxisValue = joystick.axisPrev[ai];

						//if the value of the axis is over a sertain value, save thisjoystick and axis as the detected axis
						if (axisValue < oldAxisValue - dth || axisValue > oldAxisValue + dth)
						{
							joystickIndex = ji;
							axisIndex = ai;

						}
							
					}

				}	

			}

			c_joystick.SelectedIndex = joystickIndex;
			c_axis.SelectedIndex = axisIndex;
			c_autoDetect.UseVisualStyleBackColor = true;
			c_autoDetect.Update();

		}

		public void UpdateGraph(object sender, EventArgs e)
		{
			Update();
			Program.windowStatus.DrawGraph(deadband, offset, max, expo, reverse);
		}

		/// <summary>
		/// Update the select joystick combobox control
		/// </summary>
		public void LoadConnectedJoysticks()
		{
			c_joystick.Items.Clear();
			c_joystick.Items.AddRange(JoystickHandler.GetSticks());
		}



		private string[] axes_list = {
			"ARx",	"ARy",	"ARz",
			"AX",	"AY",	"AZ",
			"FRx",	"FRy",	"FRz",
			"FX",	"FY",	"FZ",
			"RX",	"RY",	"RZ",
			"VRx",	"VRy",	"VRz",
			"VX",	"VY",	"VZ",
			"X",	"Y",	"Z",
			"ASlider0", "ASlider1",
			"FSlider0", "FSlider0",
			"VSlider0", "VSlider1",
			"Slider0",  "Slider1"};


	}

	

	public class ButtonSetting
	{
		//Controls
		private FlowLayoutPanel c_container;

		private Label c_description;
		private NumericUpDown c_index;
		private NumericUpDown c_bitnr;

		private ComboBox c_joystick;
		private NumericUpDown c_button;

		private Button c_autoDetect;

		private CheckBox c_inValue;

		private RadioButton c_toggle;
		private RadioButton c_push;

		private NumericUpDown c_offValue;
		private NumericUpDown c_onValue;

		private TextBox c_outValue;

		//Settings
		public int index;			//ST_Register command index
		public int bitnr;			//Which bit to set/reset

		public int joystick_idx;	//index of the selected joystick
		public int button_idx;      //index of the selected axis

		public bool inValue;		//Value of the axis on the joystick

		public bool toggle_push;	//If button is a toggle or pushbutton

		public int offValue;        //The value to send when button is off
		public int onValue;         //The value to send when button is on

		public bool outValueBool;   //Value of the axis on the joystick
		public int outValueInt;		//Value of the axis on the joystick

		/// <summary>
		/// Create new set of settings for a joystick button
		/// </summary>
		/// <param name="description">Description of what this joystick axis controls</param>
		public ButtonSetting(string descr)
		{
			c_container = new FlowLayoutPanel();
			c_container.Size = new System.Drawing.Size(1300, 30);
			c_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
			//c_container.Location = new System.Drawing.Point(20, SNUM * SSPACE + SOFF);

			c_description = new Label();
			c_description.Text = descr;
			c_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			c_description.Size = new System.Drawing.Size(130, 24);

			c_index = new NumericUpDown();
			c_index.Minimum = 0;
			c_index.Maximum = 32767;
			c_index.Size = new System.Drawing.Size(50, 24);

			c_bitnr = new NumericUpDown();
			c_bitnr.Minimum = -1;
			c_bitnr.Maximum = 31;
			c_bitnr.Value = 0;
			c_bitnr.Size = new System.Drawing.Size(35, 24);

			c_joystick = new ComboBox();
			c_joystick.DropDownStyle = ComboBoxStyle.DropDownList;
			c_joystick.Size = new System.Drawing.Size(70, 24);
			c_joystick.Items.AddRange(JoystickHandler.joystick);

			c_button = new NumericUpDown();
			c_button.Minimum = 0;
			c_button.Maximum = 159;
			c_button.Size = new System.Drawing.Size(50, 24);

			c_autoDetect = new Button();
			c_autoDetect.Click += this.AutoDetect2;
			c_autoDetect.Text = "A";
			c_autoDetect.Size = new System.Drawing.Size(23, 23);
			c_autoDetect.Margin = new Padding(3, 2, 3, 3);
			c_autoDetect.UseVisualStyleBackColor = true;

			c_inValue = new CheckBox();
			c_inValue.Text = "";
			c_inValue.AutoSize = true;
			c_inValue.Margin = new Padding(30, 3, 30, 3);

			c_toggle = new RadioButton();
			c_toggle.Text = "Toggle";
			c_toggle.AutoSize = true;
			c_toggle.Margin = new Padding(189, 3, 0, 3);

			c_push = new RadioButton();
			c_push.Text = "Pushbutton";
			c_push.AutoSize = true;
			c_push.Margin = new Padding(0, 3, 0, 3);
			c_push.Checked = true;

			c_offValue = new NumericUpDown();
			c_offValue.Minimum = int.MinValue;
			c_offValue.Maximum = int.MaxValue;
			c_offValue.Size = new System.Drawing.Size(50, 24);

			c_onValue = new NumericUpDown();
			c_onValue.Minimum = int.MinValue;
			c_onValue.Maximum = int.MaxValue;
			c_onValue.Value = 1;
			c_onValue.Size = new System.Drawing.Size(50, 24);

			c_outValue = new TextBox();
			c_outValue.Margin = new Padding(141, 3, 30, 3);
			c_outValue.Size = new System.Drawing.Size(50, 24);

			DrawItems();
			SNUM++;
		}

		private void DrawItems()
		{
			WindowStatus window = Program.windowStatus;
			TabPage page = window.tabPage5;

			c_container.Controls.Add(c_description);

			c_container.Controls.Add(c_index);
			c_container.Controls.Add(c_bitnr);

			c_container.Controls.Add(c_joystick);
			c_container.Controls.Add(c_button);

			c_container.Controls.Add(c_autoDetect);

			c_container.Controls.Add(c_inValue);

			c_container.Controls.Add(c_toggle);
			c_container.Controls.Add(c_push);

			c_container.Controls.Add(c_offValue);
			c_container.Controls.Add(c_onValue);

			c_container.Controls.Add(c_outValue);

			//page.Controls.Add(c_container);
			window.flp_joysticksetting_buttons.Controls.Add(c_container);
		}

		/// <summary>
		/// Set settings on startup
		/// </summary>
		/// <param name="index"></param>
		/// <param name="bitnr"></param>
		/// <param name="joystick_idx"></param>
		/// <param name="button_idx"></param>
		/// <param name="toggle_push"></param>
		/// <param name="offValue"></param>
		/// <param name="onValue"></param>
		public void SetSetting(int index, int bitnr, int joystick_idx, int button_idx, bool toggle_push, int offValue, int onValue)
		{
			c_index.Value = index;
			c_bitnr.Value = bitnr;

			try
			{
				c_joystick.SelectedIndex = joystick_idx;
			}
			catch
			{
				c_joystick.SelectedIndex = -1;
			}
			c_button.Value = button_idx;

			c_toggle.Checked = toggle_push;
			c_push.Checked = !toggle_push;

			c_offValue.Value = offValue;
			c_onValue.Value = onValue;
		}

		/// <summary>
		/// Update values in 
		/// </summary>
		private bool toggled = false;
		private bool buttonDown = false;
		public void Update()
		{
			try
			{
				index = (int)c_index.Value;
				bitnr = (int)c_bitnr.Value;

				joystick_idx = c_joystick.SelectedIndex;
				button_idx = (int)c_button.Value;

				if (joystick_idx == -1 || button_idx == -1)
					return;

				inValue = jh.joystick[joystick_idx].button[button_idx];
				c_inValue.Checked = inValue;

				toggle_push = c_toggle.Checked;

				offValue = (int)c_offValue.Value;
				onValue = (int)c_onValue.Value;

				if (toggle_push)
				{
					if (jh.joystick[joystick_idx].button[button_idx])
					{
						if(!buttonDown)
							toggled = !toggled;

						buttonDown = true;
					}
					else
					{
						buttonDown = false;
					}

					outValueBool = toggled;
					outValueInt = toggled ? onValue : offValue;
				}

				else
				{
					outValueBool = inValue;
					outValueInt = inValue ? onValue : offValue;
				}

				c_outValue.Text = outValueInt.ToString();

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
			if (this.joystick_idx == -1)
				return;

			TJoystick joystick = jh.joystick[this.joystick_idx];

			int index = -1;
			bool buttonValue = false;

			//Change color of button to indicate that autotedect is running
			c_autoDetect.BackColor = System.Drawing.Color.Aquamarine;
			c_autoDetect.Update();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			//if none of the axes changes enough within 3 seconds, stop this autodetect processs and use -1 as index
			while (stopWatch.ElapsedMilliseconds < 3000 && index == -1)
			{
				jh.Update();

				for (int i = 0; i < joystick.button.Length; i++)
				{
					buttonValue = joystick.button[i];
					if (buttonValue)
						index = i;
				}

			}

			if (index == -1) index = 0;

			c_button.Value = index;
			c_autoDetect.UseVisualStyleBackColor = true;
			c_autoDetect.Update();

		}

		/// <summary>
		/// Autodetect button and joystick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AutoDetect2(object sender, EventArgs e) //(object sender, EventArgs e) ??? make this function run when hitting button
		{
			//Change color of button to indicate that autotedect is running
			c_autoDetect.BackColor = System.Drawing.Color.Aquamarine;
			c_autoDetect.Update();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			//if none of the axes changes enough within 3 seconds, stop this autodetect processs and use -1 as index and joystick
			int joystickIndex = -1;
			int buttonIndex = -1;
			while (stopWatch.ElapsedMilliseconds < 3000 && buttonIndex == -1)
			{
				jh.Update();

				//for each joystick, check each axis
				for (int ji = 0; ji < jh.joystick.Length; ji++)
				{
					TJoystick joystick = jh.joystick[ji];

					for (int bi = 0; bi < joystick.button.Length; bi++)
					{
						bool buttonValue = joystick.button[bi];
						bool oldButtonValue = joystick.buttonPrev[bi];

						//if a button is pressed, set this as the button to use
						if (buttonValue != oldButtonValue)
						{
							joystickIndex = ji;
							buttonIndex = bi;
						}

					}

				}

			}

			if (buttonIndex != -1) //if a button was detected, save this as the button to use
			{
				c_joystick.SelectedIndex = joystickIndex;
				c_button.Value = buttonIndex;
			}
			
			c_autoDetect.UseVisualStyleBackColor = true;
			c_autoDetect.Update();

		}

	}

}

