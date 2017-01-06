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
		arr = new arrelement[sizemax];
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
		if (found < 0)
			found = (found + 1) * -1;
		if (arr[found].index == i)
			arr[found].value = v;
		else {
			// If did not find the value, insert the new value
			if (sizecur == sizemax) {
				// If the array is full, create a new array
				sizemax = sizemax << 2;
				arrelement[] temp = new arrelement[sizemax];
				for (int x = 0; x < sizecur; x++)
					temp[x] = arr[x];
				arr = temp;
			}

			for (int x = sizemax - 1; x > sizecur; x--)
				arr[x] = arr[x - 1];
			arr[found] = new arrelement(i, v);
			sizecur++;
		}
	}

	private int BinarySearchAlgorithm(int v, int l, int h) {
		int i = l + h / 2;

		// found the correct index
		if (arr[i].index == v)
			return i;

		// If v is not found in arr
		if (i == l) {
			if (arr[i].index < v)
				return i * -1 - 1;
			else
				return (i + 1) * -1 - 1;
		}

		if (arr[i].index < v)
			return BinarySearchAlgorithm(v, l, i);
		return BinarySearchAlgorithm(v, i, h);
	}

	public arrelement[] GetAllValues() {
		arrelement[] temp = new arrelement[sizecur];
		for (int i = 0; i < sizecur; i++)
			temp[i] = arr[i];
		return temp;
	}

	public class arrelement {
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

		public override string ToString() {
			return "(" + index + ", " + value + ")";
		}
	}
}