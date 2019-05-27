using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp {
    [TestFixture]
    public class QuickSortTests {
        private static Func<int, bool> _splitByPreficate = TestSources.SplitByPredicate;
        private static (int[] source, int[] left, int[] right)[] _splitBySource = TestSources.SplitBySource;
        private static int[][] _sortSorce = TestSources.SortSorce;

        [TestCaseSource(nameof(_splitBySource))]
        public void SplitBy_v1LinkedList_Test((int[] source, int[] left, int[] right) args) {
            var result = args.source.SplitBy_v1LinkedList(_splitByPreficate);

            result.left.ToArray().Should().BeEquivalentTo(args.left);
            result.right.ToArray().Should().BeEquivalentTo(args.right);
        }

        [TestCaseSource(nameof(_splitBySource))]
        public void SplitBy_v2List_Test((int[] source, int[] left, int[] right) args) {
            var result = args.source.SplitBy_v2List(_splitByPreficate);

            result.left.ToArray().Should().BeEquivalentTo(args.left);
            result.right.ToArray().Should().BeEquivalentTo(args.right);
        }

        [TestCaseSource(nameof(_sortSorce))]
        public void QuickSortListTest(int[] array) {
            var result = array.QuickSort(Ext.SplitBy_v2List);
            
            var expected = array.OrderBy(x => x).ToArray();
            result.Should().BeEquivalentTo(expected);
        }
        
        [TestCaseSource(nameof(_sortSorce))]
        public void QuickSorLinkedListtTest(int[] array) {
            var result = array.QuickSort(Ext.SplitBy_v1LinkedList);
            
            var expected = array.OrderBy(x => x).ToArray();
            result.Should().BeEquivalentTo(expected);
        }
    }
}