using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class GraphicToolbox {

	// Holders
	private Control parentGraphic;
	private Control parentToolbox;
	private ContextMenuStrip rightclickMenu;
	private Label labSimpleButton;
	private Label labOnOffButton;
	private Label labSlider;

	// Variables
	private Label selectedControl = null;
	private ToolboxControl clickedControl = null;
	public  List< KeyValuePair<Control, ToolboxControl> > allControls;
	private bool repositionControl = false;
	private static Queue<Timer> timerPool = new Queue<Timer>();

	// Constants
	private static readonly Color colorIdle = Color.FromArgb(230, 230, 230);
	private static readonly Color colorIdleHover = Color.FromArgb(230, 230, 255);
	private static readonly Color colorSelected = Color.FromArgb(175, 225, 175);
	private static readonly Color colorSelectedHover = Color.FromArgb(175, 225, 200);
	private static readonly Font font = new Font("Serif", 10);

	// Static settings forms
	private static ToolboxControlSettings formSimpleButton;
	private static ToolboxControlSettings formOnOffButton;
	private static ToolboxControlSettings formSlider;

	public GraphicToolbox(Control parentGraphic, FlowLayoutPanel parentToolbox, ContextMenuStrip rightclickMenu) {
		this.parentGraphic = parentGraphic;
		this.parentToolbox = parentToolbox;
		this.rightclickMenu = rightclickMenu;
		this.rightclickMenu.Items[0].Click += rightclick_RepositionClick;
		this.rightclickMenu.Items[1].Click += rightclick_SettingsClick;
		this.rightclickMenu.Items[3].Click += rightclick_DeleteControlClick;


		this.parentGraphic.MouseClick += ParentGraphic_MouseClick;

		allControls = new List<KeyValuePair<Control, ToolboxControl>>();

		// Create the toolbox items
		CreateToolbox();

		// Create the setting forms
		formSimpleButton = new ToolboxControlSettings("Settings - Simple Button");
		formSimpleButton.CreateSimpleButton();
		formOnOffButton = new ToolboxControlSettings("Settings - OnOff Button");
		formOnOffButton.CreateOnOffButton();
		formSlider = new ToolboxControlSettings("Settings - Slider");
		formSlider.CreateSlider();
	}

	private void rightclick_RepositionClick(object sender, EventArgs e) {
		clickedControl.control.BackColor = colorSelected;
		repositionControl = true;
	}

	private void rightclick_SettingsClick(object sender, EventArgs e) {
		clickedControl.ShowForm();
	}

	private void rightclick_DeleteControlClick(object sender, EventArgs e) {
		for (int i = 0, j = allControls.Count; i < j; i++) {
			if (clickedControl.Equals(allControls[i].Value)) {
				parentGraphic.Controls.Remove(allControls[i].Key);
				allControls[i].Key.Dispose();
				allControls.RemoveAt(i);
				return;
			}
		}
	}

	public void DeleteControl(ToolboxControl todelete) {
		clickedControl = todelete;
		rightclick_DeleteControlClick(null, null);
	}

	// When the Parent tab control gets clicked, move or create selected control, if any is selected, at correct place
	private void ParentGraphic_MouseClick(object sender, MouseEventArgs e) {

		if (e.Button != MouseButtons.Left) {
			// If not a left click
			if (selectedControl == null)
				return; // If the right click was for no reason, not on any control
			repositionControl = false;
			selectedControl.BackColor = colorIdle;
			selectedControl = null;
		}

		// If reposition command has been issued
		if (repositionControl) {
			repositionControl = false;

			clickedControl.control.BackColor = colorIdle;
			clickedControl.control.Location = e.Location;
			clickedControl.SetPosition();

			return;
		}

		// If no control is to be created
		if (selectedControl == null)
			return;

		// Create the control at mouse position
		if (selectedControl.Equals(labSimpleButton)) {

			Create_SimpleButton(new ToolboxSimpleButton(e.Location.X, e.Location.Y, "Simple Button", 0, 0));

		} else if (selectedControl.Equals(labOnOffButton)) {

			Create_OnOffButton(new ToolboxOnOffButton(e.Location.X, e.Location.Y, "OnOff Button", 0, 0, true, 100, 0, 0));

		} else if (selectedControl.Equals(labSlider)) {

			Create_Slider(0, new ToolboxSlider(e.Location.X, e.Location.Y, "Slider", 0, 1, -100, 100, true));
			
		} else {
			throw new Exception("Not implemented toolbox selected control.");
		}

		selectedControl.BackColor = colorIdle;
		selectedControl = null;
	}

	public void Create_SimpleButton(ToolboxSimpleButton tsb) {
		Button btn = setDefaultSettingsOnGraphicControls(new Button(), tsb) as Button;
		btn.UseVisualStyleBackColor = true;
		btn.Font = font;
	}
	public void Create_OnOffButton(ToolboxOnOffButton toob) {
		Button btn = setDefaultSettingsOnGraphicControls(new Button(), toob) as Button;
		btn.UseVisualStyleBackColor = true;
		btn.Font = font;
	}
	public void Create_Slider(int slidervalue, ToolboxSlider ts) {
		TrackBar pan = setDefaultSettingsOnGraphicControls(new TrackBar(), ts) as TrackBar;
		pan.TickFrequency = ts.interval;
		pan.Minimum = ts.min;
		pan.Maximum = ts.max;
		pan.Value = slidervalue;
	}

	private Control setDefaultSettingsOnGraphicControls(Control control, ToolboxControl ctrl) {
		parentGraphic.Controls.Add(control);
		control.Size = new Size(200, 50);
		control.BackColor = colorIdle;
		control.ForeColor = SystemColors.ControlText;
		control.MouseDown += Control_MouseClick;

		ctrl.control = control;
		allControls.Add(new KeyValuePair<Control, ToolboxControl>(control, ctrl));

		control.Text = ctrl.name;
		control.Location = new Point(ctrl.posx, ctrl.posy);

		return control;
	}

	// Happens when any created control is clicked
	private void Control_MouseClick(object sender, MouseEventArgs e) {
		if (e.Button == MouseButtons.Right) {

			// If a control is already selected to reposition, undo it
			if (repositionControl) {
				repositionControl = false;
				clickedControl.control.BackColor = colorIdle;
			}

			// Find the ToolboxControl class belonging to this object sender
			clickedControl = null;
			foreach (KeyValuePair<Control, ToolboxControl> k in allControls) {
				if (k.Key.Equals(sender)) {
					clickedControl = k.Value;
					break;
				}
			}

			if (clickedControl == null)
				throw new Exception("Did not find the object which must exist.");

			// Show the right click menu
			rightclickMenu.Show(clickedControl.control, e.Location);

		} else if (e.Button == MouseButtons.Left) {
			// Use the button

			// TEMP
			ToolboxControl c = null;
			foreach (KeyValuePair<Control, ToolboxControl> k in allControls) {
				if (k.Key.Equals(sender)) {
					c = k.Value;
					break;
				}
			}

			if (c == null)
				throw new Exception("Did not find the object which must exist.");

			c.Send();
		}
	}

	#region Toolbox creation and its label events and definitions
	private void CreateToolbox() {
		labSimpleButton = createLabelForToolbox("Simple Button");
		labOnOffButton = createLabelForToolbox("OnOff Button");
		labSlider = createLabelForToolbox("Slider");
	}

	private Label createLabelForToolbox(string name) {
		Label lab = new Label();
		parentToolbox.Controls.Add(lab);
		lab.BorderStyle = BorderStyle.FixedSingle;
		lab.Text = name;
		lab.Margin = new Padding(2);
		lab.Size = new Size(parentToolbox.Width - lab.Margin.Horizontal - lab.Padding.Horizontal, 30);
		lab.TextAlign = ContentAlignment.MiddleCenter;
		lab.BackColor = colorIdle;
		lab.ForeColor = SystemColors.ControlText;

		lab.MouseEnter += Lab_MouseEnter;
		lab.MouseLeave += Lab_MouseLeave;
		lab.Click += Lab_Click;
		lab.DoubleClick += Lab_Click;

		return lab;
	}

	private void Lab_MouseEnter(object sender, EventArgs e) {
		if (sender.Equals(selectedControl))
			((Control)sender).BackColor = colorSelectedHover;
		else
			((Control)sender).BackColor = colorIdleHover;
	}

	private void Lab_MouseLeave(object sender, EventArgs e) {
		if (sender.Equals(selectedControl))
			((Control)sender).BackColor = colorSelected;
		else
			((Control)sender).BackColor = colorIdle;
	}

	private void Lab_Click(object sender, EventArgs e) {
		// If this object is the selected control, deselect it
		if (selectedControl != null && selectedControl.Equals(sender)) {
			selectedControl = null;
			((Control)sender).BackColor = colorIdleHover;
			return;
		}

		if (selectedControl != null)
			selectedControl.BackColor = colorIdle;
		selectedControl = (Label)sender;
		((Control)sender).BackColor = colorSelectedHover;
	}
	#endregion

	#region Toolbox control classes
	public abstract class ToolboxControl {
		public Control control { get { return _control; } set { SetControl(value); } }
		public int posx { get { return _posx; } }
		public int posy { get { return _posy; } }
		public string name { get { return _name; } }

		private Control _control;
		private int _posx;
		private int _posy;
		private string _name;

		public ToolboxControl(int posx, int posy, string name) {
			_control = null;

			_posx = posx;
			_posy = posy;
			_name = name;
		}

		public void SetPosition() {
			_posx = control.Location.X;
			_posy = control.Location.Y;
		}

		public void ResetControlPosition() {
			control.Location = new Point(_posx, _posy);
		}

		public abstract void ShowForm();
		public abstract void Send();

		public virtual void SetControl(Control c) {
			_control = c;
		}

		public virtual void SetSettings(ToolboxControlSettings form) {
			_posx = (int)form.nud_PosX.Value;
			_posy = (int)form.nud_PosY.Value;
			_name = form.txtbox_Name.Text;
			control.Text = _name;
			control.Location = new Point(_posx, _posy);
		}

		protected void UpdateForm(ToolboxControlSettings form) {
			form.nud_PosX.Value = _posx;
			form.nud_PosY.Value = _posy;
			form.txtbox_Name.Text = _name;
		}
	}

	public class ToolboxSimpleButton : ToolboxControl {

		public int msg_index;
		public int msg_value;

		public ToolboxSimpleButton(int posx, int posy, string name, int msg_index, int msg_value) : base(posx, posy, name) {
			this.msg_index = msg_index;
			this.msg_value = msg_value;
		}

		public override void ShowForm() {
			// Set up generic settings
			formSimpleButton.SetControl(this);
			// Set up specific settings
			((NumericUpDown)formSimpleButton.allControls[0]).Value = msg_index;
			((NumericUpDown)formSimpleButton.allControls[1]).Value = msg_value;

			UpdateForm(formSimpleButton);
			
			formSimpleButton.ShowDialog();
		}

		public override void SetSettings(ToolboxControlSettings form) {
			// Do main settings
			base.SetSettings(form);

			// Do specific settings
			msg_index = (int)((NumericUpDown)form.allControls[0]).Value;
			msg_value = (int)((NumericUpDown)form.allControls[1]).Value;
		}

		public override void Send() {
			ST_Register.commands[msg_index] = msg_value;
		}
	}

	public class ToolboxOnOffButton : ToolboxControl {

		public int msg1_index;
		public int msg1_value;
		public bool ifdelay = true;
		public int delayms = 100;
		public int msg2_index;
		public int msg2_value;

		private Timer curtimer;

		public ToolboxOnOffButton(int posx, int posy, string name, int msg1_index, int msg1_value, bool ifdelay, int delayms, int msg2_index, int msg2_value) : base(posx, posy, name) {
			this.msg1_index = msg1_index;
			this.msg1_value = msg1_value;
			this.ifdelay = ifdelay;
			this.delayms = delayms;
			this.msg2_index = msg2_index;
			this.msg2_value = msg2_value;
		}

		public override void SetControl(Control c) {
			base.SetControl(c);
			// Set up send events
			if (ifdelay)
				control.MouseUp -= SendOnRelease;
			else
				control.MouseUp += SendOnRelease;
		}

		public override void ShowForm() {
			// Set up generic settings
			formOnOffButton.SetControl(this);
			// Set up specific settings
			((NumericUpDown)formOnOffButton.allControls[0]).Value = msg1_index;
			((NumericUpDown)formOnOffButton.allControls[1]).Value = msg1_value;
			formOnOffButton.SetIfDelay(ifdelay);
			((NumericUpDown)formOnOffButton.allControls[3]).Value = delayms;
			((NumericUpDown)formOnOffButton.allControls[4]).Value = msg2_index;
			((NumericUpDown)formOnOffButton.allControls[5]).Value = msg2_value;
			
			UpdateForm(formOnOffButton);

			formOnOffButton.ShowDialog();
		}

		public override void SetSettings(ToolboxControlSettings form) {
			// Do main settings
			base.SetSettings(form);

			// Do specific settings
			msg1_index = (int)((NumericUpDown)form.allControls[0]).Value;
			msg1_value = (int)((NumericUpDown)form.allControls[1]).Value;
			ifdelay = form.allControls[3].Enabled;
			delayms = (int)((NumericUpDown)form.allControls[3]).Value;
			msg2_index = (int)((NumericUpDown)form.allControls[4]).Value;
			msg2_value = (int)((NumericUpDown)form.allControls[5]).Value;

			if (ifdelay)
				control.MouseUp -= SendOnRelease;
			else
				control.MouseUp += SendOnRelease;
		}

		public override void Send() {

			ST_Register.commands[msg1_index] = msg1_value;

			if (!ifdelay)
				return;
			
			if (timerPool.Count == 0) // Create a new timer
				curtimer = new Timer();
			else // Get a old timer from the pool
				curtimer = timerPool.Dequeue();

			curtimer.Interval = delayms;
			curtimer.Tick += SendOnDelay;
			curtimer.Start();
		}

		private void SendOnDelay(object sender, EventArgs e) {
			curtimer.Tick -= SendOnDelay;
			curtimer.Stop();
			timerPool.Enqueue(curtimer);
			curtimer = null;

			ST_Register.commands[msg2_index] = msg2_value;
		}

		private void SendOnRelease(object sender, EventArgs e) {
			ST_Register.commands[msg2_index] = msg2_value;
		}
	}

	public class ToolboxSlider : ToolboxControl {

		public int index;
		public int interval = 1;
		public int min = -100;
		public int max = 100;
		public bool ifcont = true;

		public ToolboxSlider(int posx, int posy, string name, int index, int interval, int min, int max, bool ifcont) : base(posx, posy, name) {
			this.index = index;
			this.interval = interval;
			this.min = min;
			this.max = max;
			this.ifcont = ifcont;
		}

		public override void SetControl(Control c) {
			base.SetControl(c);
			// Set up send event
			if (ifcont) {
				control.MouseUp -= SendOnRelease;
				((TrackBar)control).ValueChanged += SendOnValueChange;
			} else {
				control.MouseUp += SendOnRelease;
				((TrackBar)control).ValueChanged -= SendOnValueChange;
			}
		}

		public override void ShowForm() {
			// Set up generic settings
			formSlider.SetControl(this);
			// Set up specific settings
			((NumericUpDown)formSlider.allControls[0]).Value = index;
			((NumericUpDown)formSlider.allControls[1]).Value = interval;
			((NumericUpDown)formSlider.allControls[2]).Value = min;
			((NumericUpDown)formSlider.allControls[3]).Value = max;
			formSlider.allControls[4].Text = (ifcont ? ToolboxControlSettings.btnifcontText_OnCont : ToolboxControlSettings.btnifcontText_OnRelease);

			UpdateForm(formSlider);

			formSlider.ShowDialog();
		}

		public override void SetSettings(ToolboxControlSettings form) {
			// Do main settings
			base.SetSettings(form);

			// Do specific settings
			index = (int)((NumericUpDown)formSlider.allControls[0]).Value;
			interval = (int)((NumericUpDown)formSlider.allControls[1]).Value;
			min = (int)((NumericUpDown)formSlider.allControls[2]).Value;
			max = (int)((NumericUpDown)formSlider.allControls[3]).Value;
			ifcont = (formSlider.allControls[4].Text.CompareTo(ToolboxControlSettings.btnifcontText_OnCont) == 0);

			((TrackBar)control).TickFrequency = interval;
			((TrackBar)control).Minimum = min;
			((TrackBar)control).Maximum = max;

			if (ifcont) {
				control.MouseUp -= SendOnRelease;
				((TrackBar)control).ValueChanged += SendOnValueChange;
			} else {
				control.MouseUp += SendOnRelease;
				((TrackBar)control).ValueChanged -= SendOnValueChange;
			}
		}

		public override void Send() {
			// Do nothing
		}

		private void SendOnRelease(object sender, EventArgs e) {
			ST_Register.commands[index] = ((TrackBar)control).Value;
		}

		private void SendOnValueChange(object sender, EventArgs e) {
			ST_Register.commands[index] = ((TrackBar)control).Value;
		}
	}

	#endregion
}