``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i5-3570 CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.107
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                       Method |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
| CSharpSplitByLinkedListBench | 736.2 ns | 1.879 ns | 1.569 ns | 0.6323 |     - |     - |   1.95 KB |
|       CSharpSplitByListBench | 700.2 ns | 8.172 ns | 7.644 ns | 0.4978 |     - |     - |   1.53 KB |
|           FSharpSplitByBench | 720.1 ns | 4.272 ns | 3.996 ns | 0.5207 |     - |     - |    1.6 KB |
