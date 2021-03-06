// * Summary *

/*BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i5-3570 CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.107
[Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


|                       Method |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
| CSharpSplitByLinkedListBench | 736.2 ns | 1.879 ns | 1.569 ns | 0.6323 |     - |     - |   1.95 KB |
|       CSharpSplitByListBench | 700.2 ns | 8.172 ns | 7.644 ns | 0.4978 |     - |     - |   1.53 KB |
|           FSharpSplitByBench | 720.1 ns | 4.272 ns | 3.996 ns | 0.5207 |     - |     - |    1.6 KB |

// * Hints *
Outliers
SplitByBenches.CSharpSplitByLinkedListBench: Default -> 2 outliers were removed (749.17 ns, 753.49 ns)

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


// ***** BenchmarkRunner: End *****

using System;
using BenchmarkDotNet.Attributes;
using CSharp;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace Main {
    [MemoryDiagnoser]
    public class SplitByBenches {
        [Benchmark]
        [BenchmarkCategory("CSharp")]
        public void CSharpSplitByLinkedListBench() {
            foreach ((int[] source, int[] left, int[] right) tuple in CSharp.TestSources.SplitBySource) {
                Ext.SplitBy_v1LinkedList(tuple.source, CSharp.TestSources.SplitByPredicate);
            }
        }

        [Benchmark]
        [BenchmarkCategory("CSharp")]
        public void CSharpSplitByListBench() {
            foreach ((int[] source, int[] left, int[] right) tuple in CSharp.TestSources.SplitBySource) {
                Ext.SplitBy_v2List(tuple.source, CSharp.TestSources.SplitByPredicate);
            }
        }

        private static readonly FSharpFunc<int, bool> SplitByPredicate =
            Extensions.FSharpFuncUtil.ToFSharpFunc<int, bool>(TestSources.splitByPredicate);

        [Benchmark]
        [BenchmarkCategory("FSharp")]
        public void FSharpSplitByBench() {
            foreach (Tuple<FSharpList<int>, FSharpList<int>, FSharpList<int>> tuple in TestSources.splitBySource) {
                QuickSort.splitBy(SplitByPredicate, tuple.Item1);
            }
        }
    }
}