using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Lab2.CSharpSort {
    [TestFixture]
	public class CSharpQuickSortTests {
		private static int[][] SplitBySource = new[]{
			new int[] { },
			new[] { 1 },
			new[] { 1, 2 },
			new[] { 5, 2, 7, 2, 8, 8 },
			new[] { 19, 5, 0, 12 }
		};

		public (IEnumerable<int> left, IEnumerable<int> right) SplitBy_v1LinkedList_Test(int[] array) {
			return array.SplitBy_v1LinkedList(x => x % 2 == 0);
		}

		public (IEnumerable<int> left, IEnumerable<int> right) SplitBy_v2List_Test(int[] array) {
			return array.SplitBy_v2List(x => x % 2 == 0);
		}

		private static int[][] QuickSortSorce = new[]{
			new int[] { },
			new[] { 1 },
			new[] { 1, 2 },
			new[] { 2, 1 },
			new[] { 1, 2, 3 },
			new[] { 3, 2, 1 },
			new[] { 1, 2, 3, 4 },
			new[] { 4, 3, 2, 1 },
			new[] { -2, 1, 4, 0, -6, 3 },
		};

		public IEnumerable<int> EvaluateQuickSort(int[] array) {
			//todo: decide what func for split to use
			return array.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList);
		}

		[Test]
		public void QuickSortTest(int[] array) {
			var result = EvaluateQuickSort(array);
			Array.Sort(array);
            Console.Write("asd");
			result.Should().BeEquivalentTo(array);
		}
	}
}