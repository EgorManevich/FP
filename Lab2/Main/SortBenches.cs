/*BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i5-3570 CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.107
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


|                         Method |   N |          Mean |         Error |        StdDev |      Gen 0 | Gen 1 | Gen 2 |   Allocated |
|------------------------------- |---- |--------------:|--------------:|--------------:|-----------:|------:|------:|------------:|
|           CSharpMergeSortBench | 100 |   4,877.64 us |    41.9686 us |    39.2575 us |   789.0625 |     - |     - |  2435.44 KB |
|           FSharpMergeSortBench | 100 |      45.80 us |     0.8943 us |     1.0982 us |    24.1089 |     - |     - |    74.09 KB |
|           CSharpQuickSortBench | 100 |      65.50 us |     0.2191 us |     0.1942 us |    22.9492 |     - |     - |     70.7 KB |
| FSharpQuickSortLinkedListBench | 100 |     213.06 us |     2.5355 us |     2.3717 us |   192.6270 |     - |     - |   592.36 KB |
|           CSharpMergeSortBench | 200 |  30,531.86 us |   112.0274 us |    99.3094 us |  3093.7500 |     - |     - |  9509.95 KB |
|           FSharpMergeSortBench | 200 |     104.10 us |     0.5256 us |     0.4659 us |    53.8330 |     - |     - |   165.38 KB |
|           CSharpQuickSortBench | 200 |     144.99 us |     1.5900 us |     1.4873 us |    47.3633 |     - |     - |   146.15 KB |
| FSharpQuickSortLinkedListBench | 200 |     465.25 us |     0.9925 us |     0.8798 us |   433.5938 |     - |     - |   1333.2 KB |
|           CSharpMergeSortBench | 300 |  98,278.15 us |   742.3274 us |   694.3736 us |  6666.6667 |     - |     - | 20648.33 KB |
|           FSharpMergeSortBench | 300 |     167.87 us |     0.4872 us |     0.4068 us |    85.2051 |     - |     - |   261.84 KB |
|           CSharpQuickSortBench | 300 |     223.92 us |     1.5402 us |     1.4407 us |    72.0215 |     - |     - |   221.27 KB |
| FSharpQuickSortLinkedListBench | 300 |   1,272.03 us |    30.1845 us |    30.9972 us |  1304.6875 |     - |     - |  4010.09 KB |
|           CSharpMergeSortBench | 400 | 226,668.94 us | 1,826.5497 us | 1,708.5557 us | 11666.6667 |     - |     - | 36660.55 KB |
|           FSharpMergeSortBench | 400 |     237.33 us |     0.9780 us |     0.8166 us |   118.1641 |     - |     - |   363.68 KB |
|           CSharpQuickSortBench | 400 |     329.79 us |     2.0641 us |     1.9307 us |    99.6094 |     - |     - |   306.16 KB |
| FSharpQuickSortLinkedListBench | 400 |   1,148.27 us |     4.9538 us |     4.6338 us |  1115.2344 |     - |     - |  3430.16 KB |

// * Hints *
Outliers
  SortBenches.CSharpQuickSortBench: Default           -> 1 outlier  was  removed (66.61 us)
  SortBenches.CSharpMergeSortBench: Default           -> 1 outlier  was  removed (30.93 ms)
  SortBenches.FSharpMergeSortBench: Default           -> 1 outlier  was  removed, 2 outliers were detected (103.16 us, 105.30 us)
  SortBenches.FSharpQuickSortLinkedListBench: Default -> 1 outlier  was  removed (469.24 us)
  SortBenches.FSharpMergeSortBench: Default           -> 2 outliers were removed (169.93 us, 171.63 us)
  SortBenches.FSharpMergeSortBench: Default           -> 2 outliers were removed (241.57 us, 241.98 us)

// * Legends *
  N         : Value of the 'N' parameter
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen 0     : GC Generation 0 collects per 1000 operations
  Gen 1     : GC Generation 1 collects per 1000 operations
  Gen 2     : GC Generation 2 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)*/

// * Diagnostic Output - MemoryDiagnoser *

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using CSharp;
using Microsoft.FSharp.Collections;

namespace Main {
    [MemoryDiagnoser]
    public class SortBenches {
        private int[] _array;
        private FSharpList<int> _list;
        
        [Params(100, 200, 300, 400)] public static int N { get; set; }        
        
        [GlobalSetup]
        public void GlobalSetup()
        {
            Random rand = new Random();
            _array = Enumerable.Range(0, N).Select(x => rand.Next()).ToArray();                        
        }

        [Benchmark]
        [BenchmarkCategory("CSharp")]
        public void CSharpMergeSortBench() =>Ext.MergeSort(_array).ToArray();

        //mergeSort_v1List is chosen because it uses merge_v1List which won with enormous gap in MergeBenches
        [Benchmark]
        [BenchmarkCategory("FSharp")]
        public void FSharpMergeSortBench() =>MergeSort.mergeSort_v1List(_array);

        //SplitBy_v2List is chosen because it's faster according to SplitByBenches
        [Benchmark]
        [BenchmarkCategory("CSharp")]
        public void CSharpQuickSortBench() => Ext.QuickSort(_array, Ext.SplitBy_v2List).ToArray();

        [Benchmark]
        [BenchmarkCategory("FSharp")]
        public void FSharpQuickSortLinkedListBench() => QuickSort.quickSort(_array);
    }
}