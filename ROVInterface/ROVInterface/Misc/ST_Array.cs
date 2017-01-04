using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ST_Array {
	private arrelement[] arr;
	// Indexer, so this array instance can be used as a[i];
	public arrelement this[int i] {
		get {
			return null;
		}
		set {

		}
	}

	public class arrelement {
		private int _index;

		public int index { get { return _index; } set { _index = value; } }
	}
}