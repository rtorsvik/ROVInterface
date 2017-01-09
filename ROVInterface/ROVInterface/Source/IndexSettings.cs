using System;
using System.Windows.Forms;

class IndexSettings {

	private FlowLayoutPanel CreateElement() {
		FlowLayoutPanel temp = new FlowLayoutPanel();
		// Create index and parent it to temp
		// Create name and parent it to temp
		// Create digits and parent it to temp
		// Create size and parent it to temp
		// Create color and parent it to temp
		// Create delete button and parent it to temp, add event for click to Delete(parent)
		NumericUpDown nud = new NumericUpDown();
		nud.Parent = temp;


		return temp;
	}

	private void Delete(FlowLayoutPanel panel) {
		// Delete the panel
	}
}