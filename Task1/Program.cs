using System;
using System.IO;

class Program
{

    public delegate string TextOperation(string input);

    static void Main(string[] args)
    {
        string inputFile = "textPD25.txt";
        string outputFile = "resultPD25.txt";

        File.WriteAllText(outputFile, "");

        ProcessFile(inputFile, outputFile, ToUpperCase);
        ProcessFile(inputFile, outputFile, CountCharacters);
        ProcessFile(inputFile, outputFile, CountWords);

        Console.WriteLine("Готово");
    }

    static void ProcessFile(string inputPath, string outputPath, TextOperation operation)
    {
        string[] lines = File.ReadAllLines(inputPath);

        using (StreamWriter writer = new StreamWriter(outputPath, true))
        {
            writer.WriteLine("=== Нова операція ===");

            foreach (string line in lines)
            {
                string result = operation(line);
                writer.WriteLine(result);
            }

            writer.WriteLine();
        }
    }

    static string ToUpperCase(string input)
    {
        return input.ToUpper();
    }

    static string CountCharacters(string input)
    {
        return $"Символів: {input.Length}";
    }

    static string CountWords(string input)
    {
        string[] words = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        return $"Слів: {words.Length}";
    }
}
