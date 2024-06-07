using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFilePath = @"C:\Users\Admin\Desktop\C# labs\lab8\zavd2\zavd2\input.txt";
        string outputFilePath = @"C:\Users\Admin\Desktop\C# labs\lab8\zavd2\zavd2\output.txt";
        string keyword = "ключове слово"; // Задане слово для пошуку

        // Читання вхідного файлу
        string[] lines = File.ReadAllLines(inputFilePath);

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            bool found = false;
            foreach (string line in lines)
            {
                if (line.Contains(keyword))
                {
                    writer.WriteLine(line);
                    found = true;
                }
            }

            if (found)
            {
                writer.WriteLine($"\nЗадане слово \"{keyword}\" було знайдено у тексті.");
            }
            else
            {
                writer.WriteLine($"\nЗадане слово \"{keyword}\" не було знайдено у тексті.");
            }
        }

        Console.WriteLine("Processing completed. Check the output file for results.");
    }
}
