``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
|                             Method |     N |       Mean |     Error |    StdDev |
|----------------------------------- |------ |-----------:|----------:|----------:|
| GetMostRepeatedCharacterWithCount2 | 10000 |  84.892 μs | 1.6811 μs | 2.2443 μs |
|             FindRepeatedCharacters | 10000 |   6.337 μs | 0.0449 μs | 0.0350 μs |
|       FindRepeatedCharactersUnsafe | 10000 |   5.471 μs | 0.0547 μs | 0.0485 μs |
|          FindRepeatedCharacterLinq | 10000 | 148.369 μs | 1.7410 μs | 1.5434 μs |
