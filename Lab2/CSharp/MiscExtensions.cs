using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharp {
	public static class MiscExtensions {
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
					case ValueTuple<LinkedList<int>, LinkedList<int>> tuple:
						Console.Write("(");
						PrintInner(tuple.Item1);
						Console.Write("; ");
						PrintInner(tuple.Item2);
						Console.Write(")");
						break;
					case ValueTuple<List<int>, List<int>> tuple:
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

		public static bool IsEmpty<T>(this ICollection<T> source) {
			return source.Count == 0;
		}
	}
}