using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Main {
    [MemoryDiagnoser]

    public class Program {
        public static void Main(string[] args) {
//            BenchmarkRunner.Run<MergeBenches>();
//            BenchmarkRunner.Run<SplitByBenches>();
            BenchmarkRunner.Run<SortBenches>();
        }
    }
}