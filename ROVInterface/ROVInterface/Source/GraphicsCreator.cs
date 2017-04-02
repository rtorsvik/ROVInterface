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
			//((NumericUpDown)indexDialogItemContainer.Controls[i].Controls[0]).Value = prototype.indexes[i]._idx;
			indexDialogForm.UpdateIndexRow(i, prototype.indexes[i].hidden, prototype.indexes[i]._idx, prototype.indexes[i].posx, prototype.indexes[i].posy, prototype.indexes[i].ll, prototype.indexes[i].l, prototype.indexes[i].h, prototype.indexes[i].hh);
		}
		indexDialogForm.ShowFormProper();
	}

	public void DrawBackgroundImage(PaintEventArgs e) {
		if (prototype.hasImage)
			e.Graphics.DrawImage(prototype.image, new Point(0, 0));
	}

	public void SetPrototype(graphicPrototype ps) {
		prototype = ps;
		prototype.CreateControlsForIdx(parent);

		indexDialogForm = new IndexDialogForm();
		
		for (int i = 0; i < prototype.indexes.Length; i++)
			indexDialogForm.CreateNewIndexRow();
	}

	public void UpdateValues() {
		prototype.UpdateControlsValuesForIdx();
	}

	public void AcceptFormValues() {

		Program.SuspendDrawing(Program.windowStatus, true);

		foreach (graphicPrototype.prototypeIndex pi in prototype.indexes)
			pi.Dispose();

		prototype.indexes = new graphicPrototype.prototypeIndex[indexDialogForm.allRows.Count];
		for (int i = 0, j = prototype.indexes.Length; i < j; i++) {
			IndexRowControls irc = indexDialogForm.allRows[i];
			prototype.indexes[i] = new graphicPrototype.prototypeIndex(irc.hidden.Checked, (int)irc.posx.Value, (int)irc.posy.Value, 
									(irc.cll.Checked ? (float?)irc.ll.Value : null), (irc.cl.Checked ? (float?)irc.l.Value : null),
									(irc.ch.Checked ? (float?)irc.h.Value : null), (irc.chh.Checked ? (float?)irc.hh.Value : null), (int)irc.index.Value);

			prototype.indexes[i].CreateControls(parent);
		}

		prototype.UpdateIdxSettingReference();

		Program.ResumeDrawing(Program.windowStatus, true);
	}

	// The prototype, holding all the information for the graphics
	public class graphicPrototype {

		public bool hasImage = true;
		public string path;
		public Bitmap image;
		public prototypeIndex[] indexes;

		private const string imagelabloaded = @"Image loaded: .\";

		public graphicPrototype(string path, prototypeIndex[] indexes) {
			this.path = path;
			this.indexes = indexes;

			LoadImage();
		}

		public void LoadImage() {
			if (path == "") {
				hasImage = false;
				Program.windowStatus.lab_GraphicsLoaded.Text = imagelabloaded + "<null>";
			} else {
				try {
					image = new Bitmap(Image.FromFile(path));
					Program.windowStatus.lab_GraphicsLoaded.Text = imagelabloaded + path;
					hasImage = true;
				} catch {
					hasImage = false;
					Program.windowStatus.lab_GraphicsLoaded.Text = imagelabloaded + "<null>";
				}
			}
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

		public void Dispose() {
			for (int i = 0, j = indexes.Length; i < j; i++)
				indexes[i].Dispose();

			if (hasImage)
				image.Dispose();
			hasImage = false;
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

			public void Dispose() {
				control_label.Parent.Controls.Remove(control_label);
				if (control_icon != null)
					control_icon.Parent.Controls.Remove(control_icon);

				control_label.Dispose();
				if (control_icon != null)
					control_icon.Dispose();
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