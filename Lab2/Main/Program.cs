using System;
using Lab2.CSharpQuickSort;

namespace Lab2.Main {
    class Program {
        static void Main(string[] args) {


            new int[] { }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 1 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 1, 2 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 2, 1 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 1, 2, 3 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 3, 2, 1 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 1, 2, 3, 4 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { 4, 3, 2, 1 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();
            new[] { -2, 1, 4, 0, -6, 3 }.QuickSort(CSharpQuickSort.SplitBy_v1LinkedList).Print();

            new int[] { }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 1 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 1, 2 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 2, 1 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 1, 2, 3 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 3, 2, 1 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 1, 2, 3, 4 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { 4, 3, 2, 1 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
            new[] { -2, 1, 4, 0, -6, 3 }.QuickSort(CSharpQuickSort.SplitBy_v2List).Print();
        }
    }
}
