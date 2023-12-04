using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dictionary_FinallyProject
{
    public class Program
    {
        private void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Dictionary dictionary = null;
            int action = 0;

            Console.WriteLine("Добро пожаловать в словарь. Данный словарь поддерживает три языка -> Русский, Английский и Немецкий");
            Console.WriteLine("Выберите тип словаря");
            Console.WriteLine("|1| <Rus-Eng>\n|2| <Eng-Rus>\n|3| <Rus-Ger>\n|4| <Ger-Rus>\n|5| <Eng-Ger>\n|6| <Ger-Eng>\n<Для выхода нажмите 7>");
            Console.Write("Выбираю -> ");

            try
            {
                action = int.Parse(Console.ReadLine());
                if (action == 1)
                    dictionary = new Dictionary(Dictionary.TypeDictionary.RussianInEnglish);

                else if (action == 2)
                    dictionary = new Dictionary(Dictionary.TypeDictionary.EnglishInRussian);

                else if (action == 3)
                    dictionary = new Dictionary(Dictionary.TypeDictionary.RussianInGerman);

                else if (action == 4)
                    dictionary = new Dictionary(Dictionary.TypeDictionary.GermanInRussian);

                else if (action == 5)
                    dictionary = new Dictionary(Dictionary.TypeDictionary.EnglishInGerman);

                else if (action == 6)
                    dictionary = new Dictionary(Dictionary.TypeDictionary.GermanInEnglish);

                else if (action == 7)
                    return;

                else throw new ArgumentException("Введите число от 1 до 7!");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                MainMenu();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вводите целочисленные значения!");
                Thread.Sleep(1000);
                MainMenu();
            }

            DictionaryMenu(dictionary);
        }

        private void DictionaryMenu(Dictionary dic)
        {
            int action = 0;
            Console.Clear();

            Console.WriteLine("Загружается информация о словаре...");
            Thread.Sleep(3000);

            Console.WriteLine("Тип словаря: " + dic.FromLanguage + "-" + dic.ToLanguage);
            dic.ShowDictionary();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Возможные действия: ");
            Console.WriteLine("|1| <Добавить слово и перевод для него в словарь>");
            Console.WriteLine("|2| <Найти перевод слова>");
            Console.WriteLine("|3| <Изменить слово и его перевод>");
            Console.WriteLine("|4| <Удалить слово с его переводом>");
            Console.WriteLine("|5| <Экспортировать слово с его переводом в отдельный .bin файл>");
            Console.WriteLine("|6| <Выйти в главное меню>");
            Console.Write(" Выбираю -> ");

            try
            {
                int lineNumber = 0;
                action = int.Parse(Console.ReadLine());

                if (action > 2 && action < 6)
                {
                    Console.Write("Введите номер слова(строки), с которым хотите работать. Номер -> ");
                    lineNumber = int.Parse(Console.ReadLine());

                    Console.Clear();
                }

                string word = " ";

                if (action == 1)
                {
                    string translate = " ";
                    Console.Clear();

                    Console.Write($"Введите новое слово (на {dic.FromLanguage} языке) -> ");
                    word = Console.ReadLine();

                    Console.Write($"Введите перевод этого слова на {dic.ToLanguage} языке -> ");
                    translate = Console.ReadLine();

                    dic.AddWord(word, translate);
                }

                else if (action == 2)
                {
                    Console.Clear();

                    Console.Write($"Введите слово (на {dic.FromLanguage} языке) для поиска его перевода -> ");
                    word = Console.ReadLine();
                    dic.FindTranslateWord(word);
                }

                else if (action == 3)
                    dic.EditWordAndTranslate(lineNumber);

                else if (action == 4)
                    dic.DeleteWord(lineNumber);

                else if (action == 5)
                    dic.ExportWordAndTranslateInFile(lineNumber);

                else if (action == 6)
                    MainMenu();

                else
                    throw new ArgumentException("Введите число от 1 до 6!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                DictionaryMenu(dic);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                DictionaryMenu(dic);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу");
            DictionaryMenu(dic);
        }

        static void Main(string[] args)
        {
            Program prog = new Program();

            prog.MainMenu();

        }
    }
}
