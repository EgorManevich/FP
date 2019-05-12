<Query Kind="Program">
  <DisableMyExtensions>true</DisableMyExtensions>
</Query>

void Main() {
	//	new int[] { }.SplitBy_v1LinkedList(x => x % 2 == 0).Print();
	//	new[] { 1 }.SplitBy_v1LinkedList(x => x % 2 == 0).Print();
	//	new[] { 1, 2 }.SplitBy_v1LinkedList(x => x % 2 == 0).Print();
	//	new[] { 5, 2, 7, 2, 8, 8 }.SplitBy_v1LinkedList(x => x % 2 == 0).Print();
	//	new[] { 19, 5, 0, 12 }.SplitBy_v1LinkedList(x => x % 2 == 0).Print();
	//
	//	new int[] { }.SplitBy_v2List(x => x % 2 == 0).Print();
	//	new[] { 1 }.SplitBy_v2List(x => x % 2 == 0).Print();
	//	new[] { 1, 2 }.SplitBy_v2List(x => x % 2 == 0).Print();
	//	new[] { 5, 2, 7, 2, 8, 8 }.SplitBy_v2List(x => x % 2 == 0).Print();
	//	new[] { 19, 5, 0, 12 }.SplitBy_v2List(x => x % 2 == 0).Print();

	QuickSort(new int[] { }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 1 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 1, 2 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 2, 1 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 1, 2, 3 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 3, 2, 1 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 1, 2, 3, 4 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { 4, 3, 2, 1 }, Ext.SplitBy_v1LinkedList).Print();
	QuickSort(new[] { -2, 1, 4, 0, -6, 3 }, Ext.SplitBy_v1LinkedList).Print();

	QuickSort(new int[] { }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 1 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 1, 2 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 2, 1 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 1, 2, 3 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 3, 2, 1 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 1, 2, 3, 4 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { 4, 3, 2, 1 }, Ext.SplitBy_v2List).Print();
	QuickSort(new[] { -2, 1, 4, 0, -6, 3 }, Ext.SplitBy_v2List).Print();
}

IEnumerable<int> QuickSort(
	IEnumerable<int> source,
	Func<IEnumerable<int>, Func<int, bool>, (IEnumerable<int> left, IEnumerable<int> right)> splitByFunc) {
	if (!source.Any()) {
		return new int[] { };
	}
	var head = source.First();
	var tail = source.Skip(1);
	var splitted = splitByFunc(tail, x => x < head);
	var lessSorted = QuickSort(splitted.left, splitByFunc);
	var greaterOrEqualSorted = QuickSort(splitted.right, splitByFunc);
	return lessSorted.Concat(head.ToEnumerable()).Concat(greaterOrEqualSorted);
}

static class Ext {
	public static (IEnumerable<T> left, IEnumerable<T> right) SplitBy_v1LinkedList<T>(this IEnumerable<T> source, Func<T, bool> preficate) {
		return source.Aggregate((left: new LinkedList<T>(), right: new LinkedList<T>()),
			(acc, x) => {
				if (preficate(x)) {
					acc.left.AddLast(x);
					return acc;
				} else {
					acc.right.AddLast(x);
					return acc;
				}
			}
		);
	}

	public static (IEnumerable<T> left, IEnumerable<T> right) SplitBy_v2List<T>(this IEnumerable<T> source, Func<T, bool> preficate) {
		return source.Aggregate((left: new List<T>(), right: new List<T>()),
			(acc, x) => {
				if (preficate(x)) {
					acc.left.Add(x);
					return acc;
				} else {
					acc.right.Add(x);
					return acc;
				}
			}
		);
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
				case System.ValueTuple<LinkedList<int>, LinkedList<int>> tuple:
					Console.Write("(");
					PrintInner(tuple.Item1);
					Console.Write("; ");
					PrintInner(tuple.Item2);
					Console.Write(")");
					break;
				case System.ValueTuple<List<int>, List<int>> tuple:
					Console.Write("(");
					PrintInner(tuple.Item1);
					Console.Write("; ");
					PrintInner(tuple.Item2);
					Console.Write(")");
					break;
				default:
					Console.Write($"{x}, ");
					break;
			}
		}

		PrintInner(source);
		Console.WriteLine();
	}

	public static IEnumerable<T> ToEnumerable<T>(this T x) {
		return Enumerable.Empty<T>().Append(x);
	}
}