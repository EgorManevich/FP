namespace CSharp {
    public static class TestSources {
        public static int[][] SplitBySource = {
            new int[] { },
            new[] {1},
            new[] {1, 2},
            new[] {5, 2, 7, 2, 8, 8},
            new[] {19, 5, 0, 12}
        };

        public static int[][] SortSorce = {
            new int[] { },
            new[] {1},
            new[] {1, 2},
            new[] {2, 1},
            new[] {1, 2, 3},
            new[] {3, 2, 1},
            new[] {1, 2, 3, 4},
            new[] {4, 3, 2, 1},
            new[] {-2, 1, 4, 0, -6, 3},
        };

        public static (int[] left, int[] right)[] MergeSorce = {
            (new int[] { }, new int[] { }),
            (new int[] {1}, new int[] { }),
            (new int[] {1}, new int[] {3}),
            (new int[] {3}, new int[] {1}),
            (new int[] {1, 2, 3}, new int[] {5}),
            (new int[] {1, 2, 3}, new int[] {-4}),
            (new int[] {1, 2, 3}, new int[] {-4, 5}),
            (new int[] {-2, 3, 6}, new int[] {1, 2, 7})
        };

        public static (int[] source, int pieces)[] SplitIntoSource = {
            (new int[] { }, 2),
            (new[] {1}, 2),
            (new[] {1, 2, 3}, 6),
            (new[] {1, 2, 3}, 3),
            (new[] {1, 2, 3, 4, 5, 6, 7}, 2),
            (new[] {1, 2, 3, 4, 5, 6, 7}, 4),
            (new[] {1, 2, 3, 4, 5, 6, 7}, 1),
            (new[] {1, 2, 3, 4, 5, 6, 7}, 0)
        };
    }
}