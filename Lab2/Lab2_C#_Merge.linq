<Query Kind="Program">
  <DisableMyExtensions>true</DisableMyExtensions>
</Query>

void Main() {
	//	Merge(new int[] { }, new int[] { }).Print();
	//	Merge(new int[] { 1 }, new int[] { }).Print();
	//	Merge(new int[] { 1 }, new int[] { 3 }).Print();
	//	Merge(new int[] { 3 }, new int[] { 1 }).Print();
	//	Merge(new int[] { 1, 2, 3 }, new int[] { 5 }).Print();
	//	Merge(new int[] { 1, 2, 3 }, new int[] { -4 }).Print();
	//	Merge(new int[] { 1, 2, 3 }, new int[] { -4, 5 }).Print();
	//	Merge(new int[] { -2, 3, 6 }, new int[] { 1, 2, 7 }).Print();

	//	new int[] { }.SplitInto(2).Print();
	//	new[] { 1 }.SplitInto(2).Print();
	//	new[] { 1, 2, 3 }.SplitInto(6).Print();
	//	new[] { 1, 2, 3 }.SplitInto(3).Print();
	//	new[] { 1, 2, 3, 4, 5, 6, 7 }.SplitInto(2).Print();
	//	new[] { 1, 2, 3, 4, 5, 6, 7 }.SplitInto(4).Print();
	//	new[] { 1, 2, 3, 4, 5, 6, 7 }.SplitInto(1).Print();
	//	new[] { 1, 2, 3, 4, 5, 6, 7 }.SplitInto(0).Print();

	MergeSort(new int[] { }).Print();
	MergeSort(new[] { 1 }).Print();
	MergeSort(new[] { 1, 2 }).Print();
	MergeSort(new[] { 2, 1 }).Print();
	MergeSort(new[] { 1, 2, 3 }).Print();
	MergeSort(new[] { 3, 2, 1 }).Print();
	MergeSort(new[] { 1, 2, 3, 4 }).Print();
	MergeSort(new[] { 4, 3, 2, 1 }).Print();
	MergeSort(new[] { -2, 1, 4, 0, -6, 3 }).Print();
}


IEnumerable<int> Merge(IEnumerable<int> left, IEnumerable<int> right) {
	if (!left.Any()) {
		return right;
	}
	if (!right.Any()) {
		return left;
	}
	var leftHead = left.First();
	var leftTail = left.Skip(1);
	var rightHead = right.First();
	var rightTail = right.Skip(1);
	if (leftHead < rightHead) {
		return leftHead.ToEnumerable().Concat(Merge(leftTail, right));
	} else {
		return rightHead.ToEnumerable().Concat(Merge(left, rightTail));
	}
}

IEnumerable<int> MergeSort(int[] source) {
	if (source.IsEmpty()) {
		return source;
	}
	if (source.Length == 1) {
		return source;
	}
	var splittedArrays = source.SplitInto(2);
	var left = MergeSort(splittedArrays[0]);
	var right = MergeSort(splittedArrays[1]);
	return Merge(left, right);
}

static class Ext {
	public static IEnumerable<T> ToEnumerable<T>(this T x) {
		return Enumerable.Empty<T>().Append(x);
	}

	public static void Print<T>(this T source) {
		void PrintInner(object x) {
			switch (x) {
				case IEnumerable e:
					Console.Write("{");
					foreach (var elem in e) {
						PrintInner(elem);
					}
					Console.Write("}, ");
					break;
				default: Console.Write($"{x}, "); break;
			}
		}

		PrintInner(source);
		Console.WriteLine();
	}


	public static bool IsEmpty<T>(this ICollection<T> source) {
		return source.Count == 0;
	}

	public static T[][] SplitInto<T>(this T[] source, int count) {
		IEnumerable<T[]> SplitInto() {
			int length = source.Length;
			count = length < count ? length : count;
			if (count == 0) {
				yield return Array.Empty<T>();
			}
			int maxPartLength = (int)Math.Ceiling((double)length / count);
			for (int i = 0; i < count; i++) {
				int sourceIndex = i * maxPartLength;
				var diff = length - sourceIndex - maxPartLength;
				int partLength = diff >= 0 ? maxPartLength : length - sourceIndex;
				T[] part = new T[partLength];
				Array.Copy(source, sourceIndex, part, 0, partLength);
				yield return part;
			}
		};
		return SplitInto().ToArray();
	}
}