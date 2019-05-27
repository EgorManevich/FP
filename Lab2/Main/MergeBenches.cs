// * Summary *

/*BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i5-3570 CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.107
[Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


|               Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|     CSharpMergeBench | 3,718.1 ns | 10.411 ns |  9.738 ns | 1.2589 |     - |     - |   3.88 KB |
| FSharpMergeListBench |   917.9 ns |  8.008 ns |  7.098 ns | 0.3939 |     - |     - |   1.21 KB |
|  FSharpMergeSeqBench | 5,968.3 ns | 29.852 ns | 24.928 ns | 2.9068 |     - |     - |   8.95 KB |

// * Hints *
Outliers
MergeBenches.CSharpMergeBench: Default     -> 1 outlier  was  detected (3.70 us)
MergeBenches.FSharpMergeListBench: Default -> 1 outlier  was  removed (959.18 ns)
MergeBenches.FSharpMergeSeqBench: Default  -> 2 outliers were removed (6.07 us, 6.15 us)

// * Legends *
Mean      : Arithmetic mean of all measurements
Error     : Half of 99.9% confidence interval
StdDev    : Standard deviation of all measurements
Gen 0     : GC Generation 0 collects per 1000 operations
Gen 1     : GC Generation 1 collects per 1000 operations
Gen 2     : GC Generation 2 collects per 1000 operations
Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 ns      : 1 Nanosecond (0.000000001 sec)*/

// * Diagnostic Output - MemoryDiagnoser *

using System;
using BenchmarkDotNet.Attributes;
using CSharp;
using Microsoft.FSharp.Collections;

namespace Main {
    [MemoryDiagnoser]
    public class MergeBenches {
        [Benchmark]
        [BenchmarkCategory("CSharp")]
        public void CSharpMergeBench() {
            foreach ((int[] left, int[] right, int[] expected) tuple in CSharp.TestSources.MergeSorce) {
                Ext.Merge(tuple.left, tuple.right);
            }
        }

        [Benchmark]
        [BenchmarkCategory("FSharp")]
        public void FSharpMergeListBench() {
            foreach (Tuple<FSharpList<int>, FSharpList<int>, FSharpList<int>> tuple in TestSources.mergeSource) {
                MergeSort.merge_v1List(tuple.Item1, tuple.Item2);
            }
        }

        [Benchmark]
        [BenchmarkCategory("FSharp")]
        public void FSharpMergeSeqBench() {
            foreach (Tuple<FSharpList<int>, FSharpList<int>, FSharpList<int>> tuple in TestSources.mergeSource) {
                MergeSort.merge_v2Seq(tuple.Item1, tuple.Item2);
            }
        }
    }
}