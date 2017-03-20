using System;
using System.Drawing;
using System.Windows.Forms;

public class GraphicsCreator {

	public graphicPrototype Prototype { get { return prototype; } }

	private Control parent;
	private graphicPrototype prototype;
	
	private Color bgrColor = Color.FromArgb(255, 32, 32, 32);
	//private Form indexDialogForm;
	private IndexDialogForm indexDialogForm;
	private FlowLayoutPanel indexDialogItemContainer;

	private static Bitmap iconWarning;
	private static Bitmap iconDanger;

	public GraphicsCreator(Control p) {
		parent = p;

		graphicPrototype.prototypeIndex.brushbgr = new SolidBrush(bgrColor);

		try {
			iconWarning = new Bitmap(Image.FromFile("./Graphics/Warning.png"));
		} catch {
			Console.WriteLine("Failed to load/find \"./Graphics/Warning.png\".");
			Program.errors.Add("Failed to load/find \"./Graphics/Warning.png\".");
		}
		try {
			iconDanger = new Bitmap(Image.FromFile("./Graphics/Danger.png"));
		} catch {
			Console.WriteLine("Failed to load/find \"./Graphics/Danger.png\".");
			Program.errors.Add("Failed to load/find \"./Graphics/Danger.png\".");
		}
	}

	// Event handler when a button is clicked to change the edit mode
	public void ChangeEditMode(object sender, EventArgs e) {
		// Show the index dialog form
		for (int i = 0, j = prototype.indexes.Length; i < j; i++) {
			((NumericUpDown)indexDialogItemContainer.Controls[i].Controls[0]).Value = prototype.indexes[i]._idx;
		}
		indexDialogForm.ShowDialog();
	}

	public void DrawBackgroundImage(PaintEventArgs e) {
		if (prototype.hasImage)
			e.Graphics.DrawImage(prototype.image, new Point(0, 0));
	}

	public void SetPrototype(graphicPrototype ps) {
		prototype = ps;
		prototype.CreateControlsForIdx(parent);

		if (indexDialogForm != null) {
			// If an old form exists, clean it up --- TO DO ---
		}

		

		// Set up the form for showing the indexes
		/*indexDialogForm = new Form();
		indexDialogForm.Size = new Size(400, 400);
		indexDialogForm.Text = "Set Graphic Index Settings";
		indexDialogForm.BackColor = Color.FromArgb(32, 32, 32);
		indexDialogForm.ForeColor = SystemColors.MenuHighlight;
		indexDialogForm.Font = new Font(indexDialogForm.Font.FontFamily, 10);
		indexDialogForm.FormBorderStyle = FormBorderStyle.FixedDialog;
		indexDialogForm.ShowIcon = false;
		indexDialogForm.ShowInTaskbar = false;
		indexDialogForm.MaximizeBox = false;
		indexDialogForm.MinimizeBox = false;

		TableLayoutPanel table = new TableLayoutPanel();
		indexDialogForm.Controls.Add(table);
		table.SuspendLayout();
		table.ColumnCount = 1;
		table.RowCount = 3;
		table.Dock = DockStyle.Fill;
		table.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
		table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
		table.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
		table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
		table.ResumeLayout();

		// TITLE FLOWLAYOUTPANEL
		FlowLayoutPanel flowtitle = new FlowLayoutPanel();
		table.Controls.Add(flowtitle, 0, 0);
		flowtitle.Dock = DockStyle.Fill;

		Label lab = new Label();
		lab.Text = "Pos (x, y)";
		flowtitle.Controls.Add(lab);

		lab = new Label();
		lab.Text = "Index";
		flowtitle.Controls.Add(lab);

		// BUTTONS FLOWLAYOUTPANEL
		FlowLayoutPanel flowbuttons = new FlowLayoutPanel();
		table.Controls.Add(flowbuttons, 0, 2);
		flowbuttons.Dock = DockStyle.Fill;
		flowbuttons.Margin = new Padding(0);
		flowbuttons.FlowDirection = FlowDirection.RightToLeft;

		Button btnaccept = new Button();
		flowbuttons.Controls.Add(btnaccept);
		btnaccept.Text = "Accept";
		btnaccept.BackColor = Color.White;
		btnaccept.ForeColor = Color.Black;
		btnaccept.Height = 30;
		btnaccept.Click += AcceptFormValues;

		Button btncancel = new Button();
		flowbuttons.Controls.Add(btncancel);
		btncancel.Text = "Cancel";
		btncancel.BackColor = Color.White;
		btncancel.ForeColor = Color.Black;
		btncancel.Height = 30;
		btncancel.Click += CancelFormValues;

		// ITEM COLLECTION FLOWLAYOUTPANEL
		indexDialogItemContainer = new FlowLayoutPanel();
		table.Controls.Add(indexDialogItemContainer, 0, 1);
		indexDialogItemContainer.Dock = DockStyle.Fill;
		indexDialogItemContainer.Margin = new Padding(0);
		indexDialogItemContainer.FlowDirection = FlowDirection.LeftToRight;
		indexDialogItemContainer.AutoScroll = true;
		
		foreach (graphicPrototype.prototypeIndex i in prototype.indexes) {
			TableLayoutPanel pan = new TableLayoutPanel();
			indexDialogItemContainer.Controls.Add(pan);
			pan.Width = indexDialogItemContainer.Width - 24;
			pan.Height = 25;
			pan.ColumnCount = 2;
			pan.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
			pan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

			NumericUpDown nud = new NumericUpDown();
			pan.Controls.Add(nud, 0, 0);
			nud.Minimum = 0;
			nud.Maximum = int.MaxValue;

			Label l = new Label();
			pan.Controls.Add(l, 1, 0);
			l.Text = "( " + i.posx + ", " + i.posy + " )";
			l.AutoSize = true;
			l.Margin = new Padding(2, 4, 2, 2);

		}*/
	}

	public void UpdateValues() {
		// TODO
		// Go through every control in graphicPrototype and update its controls, or just update it through functions
		prototype.UpdateControlsValuesForIdx();
	}

	private void AcceptFormValues(object sender, EventArgs e) {
		indexDialogForm.Close();

		for (int i = 0, j = prototype.indexes.Length; i < j; i++) {
			prototype.indexes[i]._idx = (int)((NumericUpDown)indexDialogItemContainer.Controls[i].Controls[0]).Value;
		}

		prototype.UpdateIdxSettingReference();
	}

	private void CancelFormValues(object sender, EventArgs e) {
		indexDialogForm.Close();
	}

	// The prototype, holding all the information for the graphics
	public class graphicPrototype {

		public bool hasImage = true;
		public string path;
		public Bitmap image;
		public prototypeIndex[] indexes;

		public graphicPrototype(string path, prototypeIndex[] indexes) {
			this.path = path;
			if (path == "")
				hasImage = false;
			else {
				try {
					image = new Bitmap(Image.FromFile(path));
				} catch {
					hasImage = false;
				}
			}
			this.indexes = indexes;
		}

		public void UpdateIdxSettingReference() {
			// Loop through the indexes and fix the references to the idx settings
			foreach (prototypeIndex p in indexes)
				p.UpdateIdxReference();
		}

		public void CreateControlsForIdx(Control parent) {
			foreach (prototypeIndex p in indexes)
				p.CreateControls(parent);

			UpdateControlsValuesForIdx();
		}

		public void UpdateControlsValuesForIdx() {
			foreach (prototypeIndex p in indexes)
				p.UpdateControlsValues();
		}

		public class prototypeIndex {
			// Store settings for the indexes
			public bool hidden { get { return _hidden; } }
			public int posx { get { return _posx; } }
			public int posy { get { return _posy; } }
			public float? ll { get { return _ll; } }
			public float? l { get { return _l; } }
			public float? h { get { return _h; } }
			public float? hh { get { return _hh; } }

			public int _idx = 0;
			// Some holders to remember the index scalings
			public IndexSettings.Setting settingswithidx = null;
			private float scale = 0f;
			private float offset = 0f;

			private bool _hidden;
			private int _posx;
			private int _posy;
			private float? _ll = null;      // critical low
			private float? _l = null;       // low
			private float? _h = null;       // high
			private float? _hh = null;      // critical high

			private static Color labelbackcolor = Color.FromArgb(200, 32, 32, 32);
			private static Font font = new Font("Serif", 12);
			public  static Brush brushbgr;
			private int oldvalue = 0;
			private icontype oldicontype = icontype.none;
			private bool refresh = true;

			public Label control_label;
			public PictureBox control_icon;

			public prototypeIndex(bool hidden, int x, int y, float? ll, float? l, float? h, float? hh, int index) {
				_hidden = hidden;
				_posx = x;
				_posy = y;
				_ll = ll;
				_l = l;
				_h = h;
				_hh = hh;
				_idx = index;
			}

			public void UpdateIdxReference() {
				if (settingswithidx != null) {
					// Check if the old settings are still valid
					if ((int)settingswithidx.index.Value != _idx)
						settingswithidx = null;
				}

				if (settingswithidx == null) {
					// Search for a correct setting
					foreach (IndexSettings.Setting set in Program.windowStatus.indexSettings.allSettings) {
						if ((int)set.index.Value == _idx) {
							settingswithidx = set;
							break;
						}
					}
				}

				if (settingswithidx != null) {
					// Scale the value
					scale = 0f;
					offset = 0f;

					if (settingswithidx.val2raw.Value - settingswithidx.val1raw.Value == 0) {
						scale = 0f;
						offset = (float)(settingswithidx.val1scaled.Value + settingswithidx.val2scaled.Value) / 2f;
					} else {
						scale = (float)(settingswithidx.val2scaled.Value - settingswithidx.val1scaled.Value) / (float)(settingswithidx.val2raw.Value - settingswithidx.val1raw.Value);
						offset = scale * (float)settingswithidx.val1raw.Value - (float)settingswithidx.val1scaled.Value;
					}
				} else {
					scale = 1f;
					offset = 0f;
				}
			}

			public void CreateControls(Control parent) {
				control_label = new Label();
				parent.Controls.Add(control_label);
				control_label.Parent = parent;
				control_label.Location = new Point(_posx, _posy);
				control_label.AutoSize = true;
				control_label.BackColor = labelbackcolor;
				control_label.ForeColor = SystemColors.MenuHighlight;
				control_label.Font = font;

				if (_hh != null || _h != null || _l != null || _ll != null) {
					// If there is a limit
					control_icon = new PictureBox();
					parent.Controls.Add(control_icon);
					control_icon.Parent = parent;
					control_icon.Size = new Size(50, 50);
					if (_hidden)
						control_icon.Location = new Point(_posx -25, _posy - 25);
					else
						control_icon.Location = new Point(_posx - 50, _posy - 15);
					control_icon.BackColor = Color.Transparent;
				}
			}

			public void UpdateControlsValues() {
				int? value = ST_Register.status[_idx];

				if (value != null) {

					if (value != oldvalue || refresh) {
						if (!_hidden) {
							float v = (int)value * scale + offset;

							if (v < _ll || v > _hh) {
								// Show Danger
								if (oldicontype != icontype.danger) {
									oldicontype = icontype.danger;
									control_icon.Image = iconDanger;
								}
							} else if (v < _l || v > _h) {
								// Show Warning
								if (oldicontype != icontype.warning) {
									oldicontype = icontype.warning;
									control_icon.Image = iconWarning;
								}
							} else {
								// Show Empty
								if (oldicontype != icontype.none) {
									oldicontype = icontype.none;
									control_icon.Image = null;
								}
							}

							control_label.Text = (settingswithidx == null ? value.ToString() : (v.ToString("N" + settingswithidx.digit.Value) + " " + settingswithidx.suffix.Text));
						}
					}
				} else {
					if (refresh) {
						control_label.Text = "NaN";
						refresh = false;
					}
				}
			}

			private enum icontype {
				none = 0,
				warning = 1,
				danger = 2
			}
		}
	}
}