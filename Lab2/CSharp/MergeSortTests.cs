using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp {
    [TestFixture]
    public class MergeSortTests {
        private static (int[] source, int pieces)[] _splitIntoSource = TestSources.SplitIntoSource;
        
        private static (int[] left, int[] right)[] _mergeSorce = TestSources.MergeSorce;
        
        private static int[][] _sortSorce= TestSources.SortSorce;
        
        
        [TestCaseSource(nameof(_splitIntoSource))]
        public void SplitIntoTest((int[] source, int pieces) arg) {
            arg.source.SplitInto(arg.pieces).Print();
        }

        [TestCaseSource(nameof(_mergeSorce))]
        public void MergeSorceTest((int[] left, int[] right) arg) {
            arg.left.Merge(arg.right).Print();
        }

        [TestCaseSource(nameof(_sortSorce))]
        public void QuickSortTest(int[] array) {
            var result = array.MergeSort();
            var expected = array.OrderBy(x => x).ToArray();
            result.Should().BeEquivalentTo(expected);
        }
    }
}