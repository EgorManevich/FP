namespace CSharp {
	public static class TestSources {
		public static bool SplitByPredicate(int x) => x % 2 == 0;

		public static (int[]source, int[] left, int[] right)[] SplitBySource = {
			(new int[] { }, new int[] { }, new int[] { }),
			(new[] {1}, new int[] { }, new [] { 1 }),
			(new[] {1, 2}, new [] { 2 }, new [] { 1 }),
			(new[] {5, 2, 7, 2, 8, 8}, new [] { 2, 2, 8, 8 }, new [] { 5, 7 }),
			(new[] {19, 5, 0, 12}, new [] { 0, 12 }, new [] { 19, 5})
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

		public static (int[] left, int[] right, int[] expected)[] MergeSorce = {
			(new int[] { }, new int[] { }, new int [] { }),
			(new []{1}, new int[] { }, new [] { 1 }),
			(new []{1}, new[] {3}, new [] { 1,3 }),
			(new []{3}, new[] {1}, new [] { 1, 3 }),
			(new []{1, 2, 3}, new [] {5}, new [] { 1, 2, 3, 5 }),
			(new []{1, 2, 3}, new [] {-4}, new [] { -4, 1, 2, 3 }),
			(new []{1, 2, 3}, new[] {-4, 5}, new [] { -4, 1, 2, 3, 5 }),
			(new []{-2, 3, 6}, new [] {1, 2, 7}, new [] { -2, 1, 2, 3, 6, 7 })
		};

		public static (int[] source, int pieces, int[][] expected)[] SplitIntoSource = {
			(new int[] { }, 2, new int[][] { }),
			(new[] {1}, 2, new [] { new [] { 1 }}),
			(new[] {1, 2, 3}, 5, new [] { new [] { 1 }, new [] { 2 }, new [] { 3 }}),
			(new[] {1, 2, 3}, 3, new [] { new [] { 1 }, new [] { 2 }, new [] { 3 }}),
			(new[] {1, 2, 3, 4, 5, 6, 7}, 2, new [] { new [] { 1, 2, 3, 4 }, new [] { 5, 6, 7 } }),
			(new[] {1, 2, 3, 4, 5, 6, 7}, 4, new [] { new [] { 1, 2 }, new [] { 3, 4 }, new [] { 5, 6 }, new [] { 7 } }),
			(new[] {1, 2, 3, 4, 5, 6, 7}, 1, new [] { new [] { 1, 2, 3, 4, 5, 6, 7 }}),
			(new[] {1, 2, 3, 4, 5, 6, 7}, 0, new int[][] {  })
		};
	}
}