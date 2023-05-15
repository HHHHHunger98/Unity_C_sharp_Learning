``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                          Method |      Mean |     Error |    StdDev |      Gen0 |      Gen1 |     Gen2 | Allocated |
|-------------------------------- |----------:|----------:|----------:|----------:|----------:|---------:|----------:|
| ConcatStringsUsingStringBuilder |  6.689 ms | 0.1266 ms | 0.1300 ms | 2429.6875 | 1484.3750 | 992.1875 |  14.86 MB |
|   ConcatStringsUsingGenericList | 19.908 ms | 0.3970 ms | 1.0176 ms | 1531.2500 |  718.7500 | 281.2500 |   9.16 MB |
