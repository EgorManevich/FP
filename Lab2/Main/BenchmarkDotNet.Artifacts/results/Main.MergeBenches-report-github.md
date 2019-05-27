``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i5-3570 CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.107
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|               Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|     CSharpMergeBench | 3,718.1 ns | 10.411 ns |  9.738 ns | 1.2589 |     - |     - |   3.88 KB |
| FSharpMergeListBench |   917.9 ns |  8.008 ns |  7.098 ns | 0.3939 |     - |     - |   1.21 KB |
|  FSharpMergeSeqBench | 5,968.3 ns | 29.852 ns | 24.928 ns | 2.9068 |     - |     - |   8.95 KB |
