``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i5-3570 CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.107
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                   Method |     Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |---------:|----------:|----------:|-------:|------:|------:|----------:|
|           MergeSortBench | 27.57 us | 0.3789 us | 0.3544 us | 6.4697 |     - |     - |  19.97 KB |
| QuickSortLinkedListBench | 17.99 us | 0.3497 us | 0.3591 us | 6.8970 |     - |     - |  21.22 KB |
|       QuickSortListBench | 15.80 us | 0.2417 us | 0.2261 us | 5.8594 |     - |     - |  18.02 KB |
