using System;
using System.Drawing;
using System.Windows.Forms;

public class GraphicsCreator {

	public graphicPrototype Prototype { get { return prototype; } }

	private Control parent;
	private bool editMode = false;
	private graphicPrototype prototype;
	
	private Color bgrColor = Color.FromArgb(255, 32, 32, 32);
	private int gridsquaresize = 50;
	private bool fullredraw = true; // If the redrawscene function should redraw everything or just update values
	private Form indexDialogForm;
	private FlowLayoutPanel indexDialogItemContainer;

	private static Bitmap iconWarning;
	private static Bitmap iconDanger;

	public GraphicsCreator(Control p, Button btn) {
		parent = p;
		parent.Paint += TabDrawGraphics;
		btn.Click += ChangeEditMode;

		try {
			iconWarning = new Bitmap(Image.FromFile("./Graphics/Warning.png"));
		} catch (Exception e) {
			Console.WriteLine("Failed to load/find \"./Graphics/Warning.png\".");
			Program.errors.Add("Failed to load/find \"./Graphics/Warning.png\".");
		}
		try {
			iconDanger = new Bitmap(Image.FromFile("./Graphics/Danger.png"));
		} catch (Exception e) {
			Console.WriteLine("Failed to load/find \"./Graphics/Danger.png\".");
			Program.errors.Add("Failed to load/find \"./Graphics/Danger.png\".");
		}
	}

	// Event handler when a button is clicked to change the edit mode
	private void ChangeEditMode(object sender, EventArgs e) {
		// From Display mode
		editMode = !editMode;
		fullredraw = true;
		parent.Refresh();

		// Show the index dialog form
		for (int i = 0, j = prototype.indexes.Length; i < j; i++) {
			((NumericUpDown)indexDialogItemContainer.Controls[i].Controls[0]).Value = prototype.indexes[i]._idx;
		}
		indexDialogForm.ShowDialog();

		// From Edit mode
		editMode = !editMode;
		fullredraw = true;
		parent.Refresh();
	}

	private void TabDrawGraphics(object sender, PaintEventArgs e) {
		fullredraw = true;
		RedrawScene(sender, e);
	}

	// Event handler to update values of the graphics
	public void UpdateValues() {
		fullredraw = false;
		RedrawScene(null, null);
	}

	// Event handler to get the drawing event of the panel
	// The function to redraw the scene
	private void RedrawScene(object sender, PaintEventArgs e) {
		if (fullredraw) {
			Graphics g = e.Graphics;
			fullredraw = false;

			// Clear the screen
			g.Clear(bgrColor);
			
			// Create the graphic
			if (prototype.hasImage)
				g.DrawImage(prototype.image, new PointF(0, 0));
			else {
				// Draw a border or something when an image is not found
			}

			// Force draw the values, etc
			foreach (graphicPrototype.prototypeIndex i in prototype.indexes) {
				i.DrawIndexFull(g);
			}

			// Draw the grid, if it should be drawn
			if (editMode) {
				Pen gridpen = new Pen(Color.FromArgb(255, 70, 70, 70));
				float xmax = parent.Width;
				float ymax = parent.Height;
				for (int x = gridsquaresize; x < xmax; x += gridsquaresize) {
					g.DrawLine(gridpen, x, 0, x, ymax);
				}
				for (int y = gridsquaresize; y < ymax; y += gridsquaresize) {
					g.DrawLine(gridpen, 0, y, xmax, y);
				}
			}
		} else {

			Graphics g = parent.CreateGraphics();

			// Just updated the values
			foreach (graphicPrototype.prototypeIndex i in prototype.indexes) {
				i.DrawIndex(g);
			}

			g.Dispose();
		}
	}

	public void SetPrototype(graphicPrototype ps) {
		prototype = ps;

		if (indexDialogForm != null) {
			// If an old form exists, clean it up --- TO DO ---
		}

		// Set up the form for showing the indexes
		indexDialogForm = new Form();
		indexDialogForm.Size = new Size(400, 400);
		indexDialogForm.Text = "Set Graphic Index Settings";
		indexDialogForm.BackColor = Color.FromArgb(32, 32, 32);
		indexDialogForm.ForeColor = SystemColors.MenuHighlight;
		indexDialogForm.Font = new Font(indexDialogForm.Font.FontFamily, 10);

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

		}
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
		public Bitmap image;
		public prototypeIndex[] indexes;

		public graphicPrototype(string path, prototypeIndex[] indexes) {
			if (path == "")
				hasImage = false;
			else {
				try {
					image = new Bitmap(Image.FromFile(".\\Graphics\\" + path));
				} catch {
					hasImage = false;
				}
			}
			this.indexes = indexes;
		}

		public void UpdateIdxSettingReference() {
			// Loop through the indexes and fix the references to the idx settings
			foreach (prototypeIndex p in indexes)
				p.UpdateIdxRefernce();
		}

		public class prototypeIndex {
			// Store settings for the indexes
			public int posx { get { return _posx; } }
			public int posy { get { return _posy; } }
			public int? ll { get { return _ll; } }
			public int? l { get { return _l; } }
			public int? h { get { return _h; } }
			public int? hh { get { return _hh; } }

			public int _idx = 0;
			// Some holders to remember the index scalings
			public IndexSettings.Setting settingswithidx = null;
			private float scale = 0f;
			private float offset = 0f;

			private bool _hidden;
			private int _posx;
			private int _posy;
			private int? _ll = null;      // critical low
			private int? _l = null;       // low
			private int? _h = null;       // high
			private int? _hh = null;      // critical high

			private static Font font = new Font("Serif", 12);
			private static Brush brush = SystemBrushes.MenuHighlight;
			private int oldvalue = 0;
			private string oldtext = "";
			private bool refresh = true;


			public prototypeIndex(bool hidden, int x, int y, int? ll, int? l, int? h, int? hh) {
				_hidden = hidden;
				_posx = x;
				_posy = y;
				_ll = ll;
				_l = l;
				_h = h;
				_hh = hh;
			}

			public void UpdateIdxRefernce() {
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
				}
			}

			public void DrawIndexFull(Graphics g) {
				refresh = true;
				DrawIndex(g);
			}

			public void DrawIndex(Graphics g) {
				bool found = true;
				int value = 0;
				try {
					value = ST_Register.status[_idx];
				} catch { found = false; }
				
				if (!found) {
					if (_hidden)
						return; // Only show warnings while no value is shown

					if (refresh) {
						DrawOverOldIndex(g, "NaN");
						refresh = false;
					}

					return; // If no value were found in the registers
				}

				string s = "";
				// Check for value to show
				if (refresh || oldvalue != value) {
					oldvalue = value;

					// Check limits with f

					if (!_hidden)
						DrawOverOldIndex(g, settingswithidx != null ? (value * scale + offset).ToString() : value.ToString());
				}

				refresh = false;
			}

			private void DrawOverOldIndex(Graphics g, string s) {
				// Clear the old text first
				SizeF size = g.MeasureString(oldtext, font);
				g.DrawImage(Program.windowStatus.graphicsCreator.prototype.image.Clone(new Rectangle(new Point(_posx, _posy), new Size((int)size.Width + 1, (int)size.Height + 1)), System.Drawing.Imaging.PixelFormat.DontCare), new PointF(_posx, _posy));

				// Draw the new text
				g.DrawString(s, font, SystemBrushes.ControlDarkDark, new PointF(_posx + 1, _posy + 1));
				g.DrawString(s, font, brush, new PointF(_posx, _posy));
				oldtext = s;
			}
		}
	}
}