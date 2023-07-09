using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;

namespace RepeatedCharactersPerformanceBenchmark;

public class RepeatedCharactersBenchmark
{
    private string _text = null!;

    [Params(10, 100, 1000, 10000)]public int N;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _text = GenerateRandomText(N);
    }

    [Benchmark]
    public KeyValuePair<char, int> GetMostRepeatedCharacterWithCount()
    {
        return GetMostRepeatedCharacterWithCount(_text);
    }
    
    [Benchmark]
    public KeyValuePair<char, int> GetMostRepeatedCharacterWithCount2()
    {
        return GetMostRepeatedCharacterWithCount2(_text);
    }

    [Benchmark]
    public KeyValuePair<char, uint> FindRepeatedCharacters()
    {
        return FindMostRepeatedCharacters(_text);
    }

    [Benchmark]
    public KeyValuePair<char, uint> FindRepeatedCharactersUnsafe()
    {
        return FindMostRepeatedCharactersUnsafe(_text);
    }

    [Benchmark]
    public Dictionary<char, int> FindRepeatedCharacterLinq()
    {
        return FindMostRepeatedCharactersLinq(_text);
    }

    private static string GenerateRandomText(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
        var random = new Random();
        var result = new char[length];

        for (var i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }

        return new string(result);
    }

    private static KeyValuePair<char, int> GetMostRepeatedCharacterWithCount(string text)
    {
        var charDictionary = new Dictionary<char, int>();
        foreach (var chr in text)
        {
            if (chr == ' ')
                continue;

            charDictionary[chr] = charDictionary.ContainsKey(chr) ? ++charDictionary[chr] : 1;
        }

        return charDictionary.OrderBy(x => x.Value).Last();
    }

    private static KeyValuePair<char, int> GetMostRepeatedCharacterWithCount2(string text)
    {
        var charDictionary = new Dictionary<char, int>();
        char maxChr = ' ';
        int maxCount = 0;

        foreach (var chr in text)
        {
            if (chr != ' ')
            {
                charDictionary.TryGetValue(chr, out int count);
                count++;
                charDictionary[chr] = count;

                if (count > maxCount)
                {
                    maxChr = chr;
                    maxCount = count;
                }
            }
        }

        return new KeyValuePair<char, int>(maxChr, maxCount);
    }

    private static KeyValuePair<char, uint> FindMostRepeatedCharacters(string text)
    {
        uint[] charCounts = new uint[128];

        foreach (var chr in text)
        {
            if (chr < 128)
            {
                charCounts[chr]++;
            }
        }

        KeyValuePair<char, uint> mostRepeatedCharacter = default;

        for (int i = 0; i < charCounts.Length; i++)
        {
            if (charCounts[i] > mostRepeatedCharacter.Value)
            {
                mostRepeatedCharacter = new KeyValuePair<char, uint>((char)i, charCounts[i]);
            }
        }

        return mostRepeatedCharacter;
    }

    private static KeyValuePair<char, uint> FindMostRepeatedCharactersUnsafe(string text)
    {
        uint[] charCounts = new uint[128];

        unsafe
        {
            fixed (char* charPtr = text)
            {
                char* currentChar = charPtr;
                char* endChar = charPtr + text.Length;

                while (currentChar < endChar)
                {
                    if (*currentChar < 128)
                    {
                        charCounts[*currentChar]++;
                    }

                    currentChar++;
                }
            }
        }

        KeyValuePair<char, uint> mostRepeatedCharacter = default;

        for (uint i = 0; i < charCounts.Length; i++)
        {
            if (charCounts[i] > mostRepeatedCharacter.Value)
            {
                mostRepeatedCharacter = new KeyValuePair<char, uint>((char)i, charCounts[i]);
            }
        }

        return mostRepeatedCharacter;
    }

    private static Dictionary<char, int> FindMostRepeatedCharactersLinq(string str)
    {
        var repeatedCharacters = str
            .GroupBy(c => c)
            .Where(g => g.Count() > 1)
            .ToDictionary(g => g.Key, g => g.Count());

        return repeatedCharacters;
    }
}

internal class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run<RepeatedCharactersBenchmark>();
    }
}

public class Config : ManualConfig
{
    [Obsolete("Obsolete")]
    public Config()
    {
        Add(MarkdownExporter.Default);
        Add(MarkdownExporter.GitHub);
    }
}
