using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp {
	public static partial class Ext {
		public static IEnumerable<int> MergeSort(this int[] source) {
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

		internal static IEnumerable<int> Merge(this IEnumerable<int> left, IEnumerable<int> right) {
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

		internal static T[][] SplitInto<T>(this T[] source, int count) {
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
}