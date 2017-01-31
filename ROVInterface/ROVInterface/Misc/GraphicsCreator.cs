﻿using System;
using System.Drawing;
using System.Windows.Forms;

public class GraphicsCreator {

	private Control parent;
	private bool editMode = true;
	private graphicPrototype[] prototypes;
	
	private Color bgrColor = Color.FromArgb(255, 32, 32, 32);
	private int gridsquaresize = 50;

	public GraphicsCreator(Control p, Button btn) {
		parent = p;
		parent.Paint += RedrawScene;
		parent.MouseClick += ClickOnScreen;
		btn.Click += ChangeEditMode;
	}

	// Event handler when a button is clicked to change the edit mode
	private void ChangeEditMode(object sender, EventArgs e) {
		editMode = !editMode;
		parent.Refresh();
	}

	// Event handler to get the drawing event of the panel
	// The function to redraw the scene
	private void RedrawScene(object sender, PaintEventArgs e) {
		Graphics g = e.Graphics;

		// Clear the screen
		g.Clear(bgrColor);

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

		// Create the objects
		foreach(graphicPrototype p in prototypes) {
			if (p.hasImage)
				g.DrawImage(p.image, new PointF(0, 0));
		}
	}

	private void ClickOnScreen(object sender, MouseEventArgs e) {
		Console.WriteLine("Mouse position: " + e.Location);
	}

	public void SetAllPrototypes(graphicPrototype[] ps) {
		prototypes = ps;
	}

	// The prototype, holding all the information for every instance of this
	public class graphicPrototype {

		public bool hasImage = true;
		public Image image;
		public prototypeIndex[] indexes;

		public graphicPrototype(string path, prototypeIndex[] indexes) {
			if (path == "")
				hasImage = false;
			else {
				try {
					image = Image.FromFile(".\\Graphics\\" + path);
				} catch {
					hasImage = false;
				}
			}
			this.indexes = indexes;
		}

		public class prototypeIndex {
			// Store settings for the indexes
			public int posx { get { return _posx; } }
			public int posy { get { return _posy; } }

			private int _posx;
			private int _posy;

			public prototypeIndex(int x, int y) {
				_posx = x;
				_posy = y;
			}
		}
	}

	// The object living in the graphics, using the prototype to get all its settings
	private class graphicObject {

		private graphicPrototype prototype;
		private int[] indexes;

		public graphicObject(graphicPrototype p) {
			prototype = p;
			indexes = new int[prototype.indexes.Length];
		}
	}
}