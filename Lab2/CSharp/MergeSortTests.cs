using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp {
    [TestFixture]
    public class MergeSortTests {
        private static (int[] source, int pieces, int[][] expected)[] _splitIntoSource = TestSources.SplitIntoSource;
        
        private static (int[] left, int[] right, int[] expected)[] _mergeSorce = TestSources.MergeSorce;
        
        private static int[][] _sortSorce= TestSources.SortSorce;
        
        
        [TestCaseSource(nameof(_splitIntoSource))]
        public void SplitIntoTest((int[] source, int pieces, int[][] expected) args) {
            var result = args.source.SplitInto(args.pieces);
            
            result.Should().BeEquivalentTo(args.expected);
        }

        [TestCaseSource(nameof(_mergeSorce))]
        public void MergeSorceTest((int[] left, int[] right, int[] expected) args) {
            var result = args.left.Merge(args.right);
            
            result.Should().BeEquivalentTo(args.expected);
        }

        [TestCaseSource(nameof(_sortSorce))]
        public void QuickSortTest(int[] array) {
            var result = array.MergeSort();
            var expected = array.OrderBy(x => x).ToArray();
            result.Should().BeEquivalentTo(expected);
        }
    }
}