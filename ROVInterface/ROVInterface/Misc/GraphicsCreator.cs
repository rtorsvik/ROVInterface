using System;
using System.Drawing;
using System.Windows.Forms;

public class GraphicsCreator {

	private Control parent;
	private bool editMode = true;
	
	private Color bgrColor = Color.FromArgb(255, 32, 32, 32);
	private int gridsquaresize = 50;

	public GraphicsCreator(Control p, Button btn) {
		parent = p;
		parent.Paint += RedrawScene;
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

	}
}