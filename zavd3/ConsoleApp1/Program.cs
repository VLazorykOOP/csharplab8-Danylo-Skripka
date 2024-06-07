using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Шлях до вхідного і вихідного файлів
        string directoryPath = @"C:\Users\Admin\Desktop\C# labs\lab8\zavd3\ConsoleApp1";
        string inputFilePath = Path.Combine(directoryPath, "input.txt");
        string outputFilePath = Path.Combine(directoryPath, "output.txt");

        // Перевірка існування каталогу і створення, якщо необхідно
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Створення файлу input.txt, якщо він не існує, для тестування
        if (!File.Exists(inputFilePath))
        {
            File.WriteAllText(inputFilePath, "Це приклад тексту, який містить різні слова різної довжини. Наприклад, слова слова і буде буде буде також також також");
        }

        // Читання тексту з файлу
        string text = File.ReadAllText(inputFilePath);

        // Видалення розділових знаків
        char[] delimiters = new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r' };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        // Групування слів за довжиною
        var groupedWords = words.GroupBy(word => word.Length);

        // Знаходження найдовшого ланцюжка слів однакової довжини
        var longestChain = groupedWords.OrderByDescending(g => g.Count()).First();

        // Формування результату
        string result = $"Найдовший ланцюжок слів однакової довжини ({longestChain.Key} символів):\n";
        result += string.Join(" ", longestChain);

        // Запис результату у файл
        File.WriteAllText(outputFilePath, result);

        // Виведення результату на консоль
        Console.WriteLine(result);
    }
}
