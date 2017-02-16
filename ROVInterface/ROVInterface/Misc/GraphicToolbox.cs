using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class GraphicToolbox {

	private Control parentGraphic;
	private Control parentToolbox;

	public GraphicToolbox(Control parentGraphic, Control parentToolbox) {
		this.parentGraphic = parentGraphic;
		this.parentToolbox = parentToolbox;

		// Create the toolbox items
		CreateToolbox();
	}

	private void CreateToolbox() {

	}
}