using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFilePath = @"C:\Users\Admin\Desktop\C# labs\lab8\zavd1\zavd1\input.txt";
        string outputFilePath = @"C:\Users\Admin\Desktop\C# labs\lab8\zavd1\zavd1\output.txt";

        // Читання вхідного файлу
        string[] lines = File.ReadAllLines(inputFilePath);

        // Регулярний вираз для дати у форматі дд.мм.рррр
        string datePattern = @"\b([0-2][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19[0-9]{2}|20[0-9]{2})\b";

        // Параметри користувача для заміни
        string oldText = "старий текст";
        string newText = "новий текст";

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            int subtextCount = 0;

            foreach (string line in lines)
            {
                // Перевірка чи рядок містить дату
                if (Regex.IsMatch(line, datePattern))
                {
                    // Заміна тексту за параметрами користувача
                    string modifiedLine = line.Replace(oldText, newText);
                    writer.WriteLine(modifiedLine);
                    subtextCount++;
                }
            }

            // Запис кількості підтекстів
            writer.WriteLine($"Total subtexts: {subtextCount}");
        }

        Console.WriteLine("Processing completed. Check the output file for results.");
    }
}
