using System;
using System.IO;
namespace Exercise6_1
{
    class Program
    {
        const string Vowels = "аеёиоуыэюяaeiou";
        const string Consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";
        static void CountLetters(char[] text, out int vowels, out int consonants)
        {
            vowels = 0;
            consonants = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToLower(text[i]);

                if (Vowels.IndexOf(c) >= 0)
                    vowels++;
                else if (Consonants.IndexOf(c) >= 0)
                    consonants++;
            }
        }
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите имя файла: программа.exe <имя_файла>");
                return;
            }
            try
            {
                char[] text = File.ReadAllText(args[0]).ToCharArray();

                CountLetters(text, out int vowels, out int consonants);

                Console.WriteLine($"Гласных букв:   {vowels}");
                Console.WriteLine($"Согласных букв: {consonants}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}