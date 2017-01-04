using System;

public class ST_Array {
	private arrelement[] arr;
	private int sizemax;
	private int sizecur;

	public ST_Array() {
		sizemax = 10;
		sizecur = 0;
	}
	public ST_Array(int sizemax) {
		this.sizemax = sizemax;
		sizecur = 0;
	}

	// Indexer, so this array instance can be used as a[i];
	public float this[int i] {
		get {
			i = BinarySearchAlgorithm(i, 0, sizecur);
			if (i < 0)
				throw new Exception("Did not find this value in the array.");
			return arr[i].value;
		}
		set { SearchAndSet(i, value); }
	}

	// Takes an index and insert it into arr
	private void SearchAndSet(int i, float v) {
		int found = BinarySearchAlgorithm(i, 0, sizecur);
		if (arr[found].index == i)
			arr[found].value = v;
		else {
			// If did not find the value, insert the new value
			// ----------
		}
	}

	private int BinarySearchAlgorithm(int v, int l, int h) {
		int i = l + h / 2;

		// found the correct index
		if (arr[i].index == v)
			return i;

		// If v is not found in arr
		if (i == l)
			return i;

		if (arr[i].index < v)
			return BinarySearchAlgorithm(v, l, i);
		return BinarySearchAlgorithm(v, i, h);
	}

	private class arrelement {
		public int index;
		public float value;

		public arrelement() {
			index = -1;
			value = 0;
		}
		public arrelement(int index, float value) {
			this.index = index;
			this.value = value;
		}
	}
}