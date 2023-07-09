``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
|                             Method |     N |          Mean |        Error |       StdDev |
|----------------------------------- |------ |--------------:|-------------:|-------------:|
|  **GetMostRepeatedCharacterWithCount** |    **10** |     **288.51 ns** |     **2.833 ns** |     **2.650 ns** |
| GetMostRepeatedCharacterWithCount2 |    10 |     169.34 ns |     3.367 ns |     4.258 ns |
|             FindRepeatedCharacters |    10 |     104.62 ns |     0.626 ns |     0.585 ns |
|       FindRepeatedCharactersUnsafe |    10 |      97.20 ns |     1.083 ns |     1.013 ns |
|          FindRepeatedCharacterLinq |    10 |     467.53 ns |     6.250 ns |     5.846 ns |
|  **GetMostRepeatedCharacterWithCount** |   **100** |   **2,082.16 ns** |    **33.993 ns** |    **31.797 ns** |
| GetMostRepeatedCharacterWithCount2 |   100 |   1,105.78 ns |    10.033 ns |     9.385 ns |
|             FindRepeatedCharacters |   100 |     153.08 ns |     3.097 ns |     7.882 ns |
|       FindRepeatedCharactersUnsafe |   100 |     165.92 ns |     1.414 ns |     1.323 ns |
|          FindRepeatedCharacterLinq |   100 |   3,814.08 ns |    73.797 ns |    65.419 ns |
|  **GetMostRepeatedCharacterWithCount** |  **1000** |  **16,066.66 ns** |   **306.461 ns** |   **449.207 ns** |
| GetMostRepeatedCharacterWithCount2 |  1000 |   8,440.00 ns |   167.260 ns |   156.455 ns |
|             FindRepeatedCharacters |  1000 |     771.47 ns |    14.773 ns |    18.143 ns |
|       FindRepeatedCharactersUnsafe |  1000 |     713.07 ns |    13.859 ns |    21.164 ns |
|          FindRepeatedCharacterLinq |  1000 |  18,543.42 ns |   183.907 ns |   172.026 ns |
|  **GetMostRepeatedCharacterWithCount** | **10000** | **147,590.99 ns** | **1,962.791 ns** | **1,739.963 ns** |
| GetMostRepeatedCharacterWithCount2 | 10000 |  80,075.18 ns | 1,588.425 ns | 1,408.097 ns |
|             FindRepeatedCharacters | 10000 |   6,266.70 ns |    53.613 ns |    50.150 ns |
|       FindRepeatedCharactersUnsafe | 10000 |   5,565.20 ns |    52.678 ns |    46.698 ns |
|          FindRepeatedCharacterLinq | 10000 | 144,340.50 ns | 2,139.167 ns | 2,000.978 ns |
