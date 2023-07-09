# Find Most Repeated Characters Performance Benchmark
Which is the fastest method to find the most repeated character?

# Repeated Characters Performance Benchmark

This project is a benchmark application that compares the performance of different methods for finding repeated characters in a text.

## Test Scenario
The benchmark compares the performance of the following methods:

- `GetMostRepeatedCharacterWithCount2`: Finds the most repeated character using a dictionary-based approach.
- `FindRepeatedCharacters`: Finds the most repeated character using an array-based approach.
- `FindRepeatedCharactersUnsafe`: Finds the most repeated character using unsafe code to improve performance.
- `FindRepeatedCharacterLinq`: Finds the most repeated character using LINQ.

The goal is to determine which method performs better in terms of finding the most repeated character.

## Methods
### GetMostRepeatedCharacterWithCount2
This method iterates through each character in the input text and counts the occurrences of each character. It uses a dictionary to store the character counts and returns the character with the highest count.

### FindRepeatedCharacters
This method counts the occurrences of each character in the input text using an array. It supports ASCII characters and calculates the character counts based on the ASCII value of the character as the index of the array.

### FindRepeatedCharactersUnsafe
This method counts the occurrences of each character in the input text using an array and unsafe code. It improves performance by directly accessing the character pointer and incrementing the count in the array.

### FindRepeatedCharacterLinq
This method uses LINQ to group the characters in the input text and calculates the number of repetitions for each character. It returns a dictionary of repeated characters.

## Results
The benchmark results can be found in the [BenchmarkDotNet](https://benchmarkdotnet.org) table format in the [Results.md](Results.md) file.

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
|                             Method |     Iterations |       Mean |     Error |    StdDev |
|----------------------------------- |------ |-----------:|----------:|----------:|
| GetMostRepeatedCharacterWithCount2 | 10000 |  83.905 us | 1.0710 us | 0.9494 us |
|             FindRepeatedCharacters | 10000 |   6.383 us | 0.0660 us | 0.0551 us |
|       FindRepeatedCharactersUnsafe | 10000 |   5.715 us | 0.0916 us | 0.1531 us |
|          FindRepeatedCharacterLinq | 10000 | 150.195 us | 1.3161 us | 1.1667 us |

## How to Run?
To run the benchmark, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio, Rider or any compatible IDE.
3. Build the solution to restore the dependencies. (dotnet build)
4. Run the `RepeatedCharactersPerformanceBenchmark` project. (dotnet run --configuration Release)
5. The benchmark will execute and display the results in the console.

## Contributing
To contribute, please create an issue or pull request on the GitHub repository.
