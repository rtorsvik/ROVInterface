using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class IndexDialogForm : Form {
	public IndexDialogForm() {
		InitializeComponent();

		_allRows = new List<IndexRowControls>();
	}

	public List<IndexRowControls> allRows { get { return _allRows; } }
	private List<IndexRowControls> _allRows;

	private const int ROWHEIGHT = 30;

	private bool shown = false;

	public void ShowFormProper() {
		shown = true;
		ShowDialog();
	}

	private void CreateNewIndexRowEvent(object sender, EventArgs e) {
		CreateNewIndexRow();
	}

	public void UpdateIndexRow(int row, bool hidden, int index, int posx, int posy, float? ll, float? l, float? h, float? hh) {
		_allRows[row].hidden.Checked = hidden;
		_allRows[row].index.Value = index;
		_allRows[row].posx.Value = posx;
		_allRows[row].posy.Value = posy;

		loadWarningValues(ll, _allRows[row].cll, _allRows[row].ll);
		loadWarningValues(l, _allRows[row].cl, _allRows[row].l);
		loadWarningValues(h, _allRows[row].ch, _allRows[row].h);
		loadWarningValues(hh, _allRows[row].chh, _allRows[row].hh);
	}

	private void loadWarningValues(float? v, CheckBox c, NumericUpDown n) {
		c.Checked = v.HasValue;
		n.Enabled = v.HasValue;
		n.Value = (Decimal)(v.HasValue ? v.Value : 0);
	}

	public IndexRowControls CreateNewIndexRow() {

		Program.SuspendDrawing(this, shown);

		IndexRowControls irc = new IndexRowControls();
		int y = _allRows.Count;
		pan_Main.RowCount = y + 2;
		pan_Main.RowStyles.Insert(y, new RowStyle(SizeType.Absolute, ROWHEIGHT));

		// Create the controls
		irc.hidden = new CheckBox();
		pan_Main.Controls.Add(irc.hidden, 0, y);
		irc.hidden.Dock = DockStyle.Fill;
		irc.hidden.CheckAlign = ContentAlignment.MiddleCenter;

		irc.index = new NumericUpDown();
		pan_Main.Controls.Add(irc.index, 1, y);

		irc.posx = new NumericUpDown();
		pan_Main.Controls.Add(irc.posx, 2, y);

		irc.posy = new NumericUpDown();
		pan_Main.Controls.Add(irc.posy, 3, y);

		irc.index.Dock = irc.posx.Dock = irc.posy.Dock = DockStyle.Fill;
		irc.index.Minimum = irc.posx.Minimum = irc.posy.Minimum = 0;
		irc.index.Maximum = irc.posx.Maximum = irc.posy.Maximum = int.MaxValue;

		irc.delete = new Button();
		pan_Main.Controls.Add(irc.delete, 8, y);
		irc.delete.Dock = DockStyle.Fill;
		irc.delete.UseVisualStyleBackColor = true;
		irc.delete.ForeColor = SystemColors.ControlText;
		irc.delete.Text = "DELETE";
		irc.delete.Click += DeleteIndexRowEvent;

		pan_Main.Controls.Add(irc.fll = new FlowLayoutPanel(), 4, y);
		irc.fll = CreateFlowLayoutPanelWithComponents(irc.fll, out irc.cll, out irc.ll);
		pan_Main.Controls.Add(irc.fl = new FlowLayoutPanel(), 5, y);
		irc.fl = CreateFlowLayoutPanelWithComponents(irc.fl, out irc.cl, out irc.l);
		pan_Main.Controls.Add(irc.fh = new FlowLayoutPanel(), 6, y);
		irc.fh = CreateFlowLayoutPanelWithComponents(irc.fh, out irc.ch, out irc.h);
		pan_Main.Controls.Add(irc.fhh = new FlowLayoutPanel(), 7, y);
		irc.fhh = CreateFlowLayoutPanelWithComponents(irc.fhh, out irc.chh, out irc.hh);

		_allRows.Add(irc);
		Program.ResumeDrawing(this, shown);
		return irc;
	}

	private FlowLayoutPanel CreateFlowLayoutPanelWithComponents(FlowLayoutPanel fll, out CheckBox cll, out NumericUpDown ll) {
		cll = new CheckBox();
		ll = new NumericUpDown();
		fll.Controls.Add(cll);
		fll.Controls.Add(ll);

		fll.Dock = DockStyle.Fill;
		fll.Margin = Padding.Empty;

		cll.Size = new Size(10, 24);
		cll.Margin = new Padding(9, 3, 0, 3);
		cll.CheckedChanged += Cll_CheckedChanged;

		ll.Size = new Size(90, 24);
		ll.Minimum = int.MinValue;
		ll.Maximum = int.MaxValue;
		ll.DecimalPlaces = 3;

		return fll;
	}

	private void Cll_CheckedChanged(object sender, EventArgs e) {
		TableLayoutPanelCellPosition pos = pan_Main.Controls.Container.GetCellPosition(((Control)sender).Parent);

		if (pos.Column == 4)
			_allRows[pos.Row].ll.Enabled = _allRows[pos.Row].cll.Checked;
		else if (pos.Column == 5)
			_allRows[pos.Row].l.Enabled = _allRows[pos.Row].cl.Checked;
		else if (pos.Column == 6)
			_allRows[pos.Row].h.Enabled = _allRows[pos.Row].ch.Checked;
		else if (pos.Column == 7)
			_allRows[pos.Row].hh.Enabled = _allRows[pos.Row].chh.Checked;
	}

	private void DeleteIndexRowEvent(object sender, EventArgs e) {
		DeleteIndexRowAtIndex(pan_Main.Controls.Container.GetCellPosition((Control)sender).Row);
	}

	public void DeleteIndexRowAtIndex(int index) {

		Program.SuspendDrawing(this, shown);

		_allRows[index].Dispose(pan_Main);
		_allRows.RemoveAt(index);
		
		pan_Main.RowStyles.RemoveAt(index);
		pan_Main.RowCount--;

		// Move everything below the row up one
		for (int i = index, max = _allRows.Count; i < max; i++)
			_allRows[i].MoveToIndex(pan_Main, i);

		Program.ResumeDrawing(this, shown);
	}

	private void btn_Accept_Click(object sender, EventArgs e) {
		// Save the values and close the form
		Program.windowStatus.graphicsCreator.AcceptFormValues();
		shown = false;
		Close();
	}

	private void btn_Cancel_Click(object sender, EventArgs e) {
		// Do nothing, just close the form
		shown = false;
		Close();
	}

	private void IndexDialogForm_FormClosing(object sender, FormClosingEventArgs e) {
		// When the user exits out of the form
		shown = false;
	}
}

public struct IndexRowControls {
	public CheckBox hidden;
	public NumericUpDown index;
	public NumericUpDown posx;
	public NumericUpDown posy;

	public CheckBox cll;
	public CheckBox cl;
	public CheckBox ch;
	public CheckBox chh;

	public NumericUpDown ll;
	public NumericUpDown l;
	public NumericUpDown h;
	public NumericUpDown hh;

	public Button delete;

	public FlowLayoutPanel fll;
	public FlowLayoutPanel fl;
	public FlowLayoutPanel fh;
	public FlowLayoutPanel fhh;

	public void Dispose(TableLayoutPanel pan) {
		pan.Controls.Remove(hidden);
		pan.Controls.Remove(index);
		pan.Controls.Remove(posx);
		pan.Controls.Remove(posy);
		pan.Controls.Remove(fll);
		pan.Controls.Remove(fl);
		pan.Controls.Remove(fh);
		pan.Controls.Remove(fhh);
		pan.Controls.Remove(delete);

		hidden.Dispose();
		index.Dispose();
		posx.Dispose();
		posy.Dispose();
		fll.Dispose();
		fl.Dispose();
		fh.Dispose();
		fhh.Dispose();
		delete.Dispose();
	}

	public void MoveToIndex(TableLayoutPanel pan, int indexto) {
		pan.Controls.Remove(hidden);
		pan.Controls.Remove(index);
		pan.Controls.Remove(posx);
		pan.Controls.Remove(posy);
		pan.Controls.Remove(fll);
		pan.Controls.Remove(fl);
		pan.Controls.Remove(fh);
		pan.Controls.Remove(fhh);
		pan.Controls.Remove(delete);

		pan.Controls.Add(hidden, 0, indexto);
		pan.Controls.Add(index, 1, indexto);
		pan.Controls.Add(posx, 2, indexto);
		pan.Controls.Add(posy, 3, indexto);
		pan.Controls.Add(fll, 4, indexto);
		pan.Controls.Add(fl, 5, indexto);
		pan.Controls.Add(fh, 6, indexto);
		pan.Controls.Add(fhh, 7, indexto);
		pan.Controls.Add(delete, 8, indexto);
	}
}