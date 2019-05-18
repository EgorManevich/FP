using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp {
	[TestFixture]
	public class QuickSortTests
    {
        private static int[][] _splitBySource = TestSources.SplitBySource;
        private static int[][] _sortSorce = TestSources.SortSorce;
        
		[TestCaseSource(nameof(_splitBySource))]
		public void SplitBy_v1LinkedList_Test(int[] array) {
			array.SplitBy_v1LinkedList(x => x % 2 == 0).Print();
		}

		[TestCaseSource(nameof(_splitBySource))]
		public void SplitBy_v2List_Test(int[] array) {
			array.SplitBy_v2List(x => x % 2 == 0).Print();
		}

		[TestCaseSource(nameof(_sortSorce))]
		public void QuickSortTest(int[] array) {
			var result = array.QuickSort(Ext.SplitBy_v2List);
            var expected = array.OrderBy(x => x).ToArray();
			result.Should().BeEquivalentTo(expected);
		}
	}
}