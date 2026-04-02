using System;
using System.IO;

class Program
{
    static void Main()
    {
        string logFile = "logPD25.txt";

        File.WriteAllText(logFile, "");

        MessagePublisher publisher = new MessagePublisher();
        FileLogger logger = new FileLogger(logFile, publisher);

        Console.WriteLine("Введіть текст 4 рази:");

        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Рядок {i + 1}: ");
            string input = Console.ReadLine();
            publisher.Send(input);
        }

        Console.WriteLine($"Повідомлення записані у файл {logFile}");
    }
}