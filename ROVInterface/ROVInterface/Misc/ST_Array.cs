using System;

public class ST_Array {
	private arrelement[] arr;
	private int sizemax;
	private int sizecur;

	private bool hashiddenarr = false;
	private ST_Array hiddenarr;

	public ST_Array() {
		sizemax = 8;
		sizecur = 0;
		arr = new arrelement[sizemax];
	}
	public ST_Array(int sizemax) {
		this.sizemax = sizemax;
		sizecur = 0;
		arr = new arrelement[sizemax];
	}
	public ST_Array(ST_Array hidden) : this() {
		hashiddenarr = true;
		hiddenarr = hidden;
	}

	// Indexer, so this array instance can be used as a[i];
	public int? this[int i] {
		get {
			if (hashiddenarr)
				return hiddenarr[i];
			i = BinarySearchAlgorithm(i, 0, sizecur);
			if (i < 0)
				return null;
			return arr[i].value;
		}
		set {
			SearchAndSet(i, value);
			if (hashiddenarr)
				hiddenarr.SearchAndSet(i, value);
		}
	}

	// Takes an index and insert it into arr
	private void SearchAndSet(int i, int? v) {
		int found = BinarySearchAlgorithm(i, 0, sizecur);
		if (found >= 0 && arr[found].index == i)
			arr[found].value = (int)v;
		else {
			// If did not find the value, insert the new value
			found = (found + 1) * -1;
			if (sizecur == sizemax) {
				// If the array is full, create a new array
				sizemax = sizemax << 1;
				arrelement[] temp = new arrelement[sizemax];
				for (int x = 0; x < sizecur; x++)
					temp[x] = arr[x];
				arr = temp;
			}

			for (int x = sizemax - 1; x > found; x--)
				arr[x] = arr[x - 1];
			arr[found] = new arrelement(i, (int)v);
			sizecur++;
		}
	}

	private int BinarySearchAlgorithm(int v, int l, int h) {
		int i = (l + h) / 2;

		// If the array is empty
		if (sizecur == 0)
			return -1;

		// found the correct index
		if (arr[i].index == v)
			return i;

		// If v is not found in arr
		if (i == l) {
			if (arr[i].index > v)
				return i * -1 - 1;
			else
				return (i + 1) * -1 - 1;
		}

		if (arr[i].index > v)
			return BinarySearchAlgorithm(v, l, i);
		return BinarySearchAlgorithm(v, i, h);
	}

	public arrelement[] GetAllValues() {
		arrelement[] temp = new arrelement[sizecur];
		for (int i = 0; i < sizecur; i++)
			temp[i] = arr[i];
		return temp;
	}

	public void ResetArray() {
		for (int i = 0; i < sizecur; i++)
			arr[i] = null;
		sizecur = 0;
	}

	public class arrelement {
		public int index;
		public int value;

		public arrelement() {
			index = -1;
			value = 0;
		}
		public arrelement(int index, int value) {
			this.index = index;
			this.value = value;
		}

		public override string ToString() {
			return "(" + index + ", " + value + ")";
		}
	}
}