using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Common;

namespace Lab2.CSharpSort {
    public static class CSharpQuickSort {
        public static IEnumerable<int> QuickSort(
   this IEnumerable<int> source,
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
    }
}