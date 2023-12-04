using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Dictionary_FinallyProject
{
    [Serializable]
    public class Dictionary
    {
        public enum TypeDictionary
        {
            RussianInEnglish,
            EnglishInRussian,

            RussianInGerman,
            GermanInRussian,

            EnglishInGerman,
            GermanInEnglish,
        }

        private static TypeDictionary Type { get; set; }

        /// <summary>
        /// массив путей к файлам
        /// </summary>
        private string[] _pathsForWords = { "Database\\RussianBase.txt", "Database\\EnglishBase.txt", "Database\\GermanBase.txt" };
        private string _fromLanguage;
        private string _toLanguage;
        private string _thirdLanguage;
        /// <summary>
        /// Из какого языка переводятся слова
        /// </summary>
        public string FromLanguage { get { return _fromLanguage; } }
        /// <summary>
        /// В какой языка переводятся слова
        /// </summary>
        public string ToLanguage { get { return _toLanguage; } }

        /// <summary>
        /// Индекс пути к файлу, который хранит слова
        /// </summary>
        private int _indexPathForWord = 0;
        /// <summary>
        /// Индекс пути к файлу, который переводы слов
        /// </summary>
        private int _indexPathForTranslate = 0;
        private int _indexPathForThirdFileWithWords = 0;

        public Dictionary(TypeDictionary type)
        {
            Type = type;

            if (Type == TypeDictionary.RussianInEnglish || Type == TypeDictionary.RussianInGerman)
            {
                _fromLanguage = "Rus";
                _indexPathForWord = 0;
            }

            else if (Type == TypeDictionary.EnglishInGerman || Type == TypeDictionary.EnglishInRussian)
            {
                _fromLanguage = "Eng";
                _indexPathForWord = 1;
            }

            else if (Type == TypeDictionary.GermanInRussian || Type == TypeDictionary.GermanInEnglish)
            {
                _fromLanguage = "Ger";
                _indexPathForWord = 2;
            }

            if (_indexPathForWord == 0)
            {
                if (Type == TypeDictionary.RussianInEnglish)
                {
                    _toLanguage = "Eng";
                    _thirdLanguage = "Ger";
                    _indexPathForTranslate = 1;
                    _indexPathForThirdFileWithWords = 2;
                }

                else if (Type == TypeDictionary.RussianInGerman)
                {
                    _toLanguage = "Ger";
                    _thirdLanguage = "Eng";
                    _indexPathForTranslate = 2;
                    _indexPathForThirdFileWithWords = 1;
                }
            }
            else if (_indexPathForWord == 1)
            {
                if (Type == TypeDictionary.EnglishInGerman)
                {
                    _toLanguage = "Ger";
                    _thirdLanguage = "Rus";
                    _indexPathForTranslate = 2;
                    _indexPathForThirdFileWithWords = 0;
                }
                else if (Type == TypeDictionary.EnglishInRussian)
                {
                    _toLanguage = "Rus";
                    _thirdLanguage = "Ger";
                    _indexPathForTranslate = 0;
                    _indexPathForThirdFileWithWords = 2;
                }
            }
            else
            {
                if (Type == TypeDictionary.GermanInEnglish)
                {
                    _toLanguage = "Eng";
                    _thirdLanguage = "Rus";
                    _indexPathForTranslate = 1;
                    _indexPathForThirdFileWithWords = 0;
                }
                else
                {
                    _toLanguage = "Rus";
                    _thirdLanguage = "Eng";
                    _indexPathForTranslate = 0;
                    _indexPathForThirdFileWithWords = 1;
                }
            }
        }

        /// <summary>
        /// Метод для добавления нового слова и его перевода в соответствующие файлы
        /// </summary>
        /// <exception cref="Exception"
        /// <param name="word">слово</param>
        /// <param name="translation">перевод передаваемого слова</param>
        public void AddWord(string word, string translation)
        {
            try
            {
                using (StreamWriter writerW = new StreamWriter(_pathsForWords[_indexPathForWord], true))
                {
                    writerW.WriteLine(word);

                    using (StreamWriter writerT = new StreamWriter(_pathsForWords[_indexPathForTranslate], true))
                    {
                        using (StreamWriter writerL = new StreamWriter(_pathsForWords[_indexPathForThirdFileWithWords], true))
                        {
                            Console.Write($"Введите перевод нового слова на {_thirdLanguage} языке-> "); // получение нового слова на третьем языке словаря

                            writerL.WriteLine(Console.ReadLine());
                            writerT.WriteLine(translation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Метод для поиска перевода слова в файле
        /// </summary>
        /// <exception cref="Exception"
        /// <param name="word">слово, перевод которого нужно найти</param>
        public void FindTranslateWord(string word)
        {
            try
            {
                using (StreamReader readerW = new StreamReader(_pathsForWords[_indexPathForWord]))
                {
                    int lineNumber = 0; // номер строки в файле, где находится слово для которого в другом файле на такой же строке есть перевод 
                    bool hasTheWordBeenFound = false;

                    while (!readerW.EndOfStream)
                    {
                        lineNumber++;
                        if (word == readerW.ReadLine())
                        {
                            hasTheWordBeenFound = true;
                            break;
                        }
                    }

                    if (hasTheWordBeenFound)
                    {
                        using (StreamReader readerT = new StreamReader(_pathsForWords[_indexPathForTranslate]))
                        {
                            int lNumber = 0;
                            while (!readerT.EndOfStream)
                            {
                                lNumber++;
                                if (lNumber != lineNumber)
                                {
                                    readerT.ReadLine();
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"Найден перевод слова <{word}> -> ({_toLanguage})<{readerT.ReadLine()}>");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        int action = 0;
                        Console.WriteLine($"Перевода для этого слова <{word}> на {_toLanguage} нет в словаре, но вы можете его добавить. Добавить?");
                        Console.WriteLine("|1| <Да>");
                        Console.WriteLine("|2| <Нет>");

                        action = int.Parse(Console.ReadLine());

                        if (action == 1)
                        {
                            string trans = " ";
                            Console.WriteLine($"Введите перевод слова {word} на {_toLanguage} -> ");
                            trans = Console.ReadLine();

                            AddWord(word, trans);
                        }
                    }
                }
            }
            catch(FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вводите целочисленные значения!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                FindTranslateWord(word);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Метод для редактирования слова и его перевода на трех языках
        /// </summary>
        /// <exception cref="ArgumentException"
        /// <param name="lineNumber">номер строки на которой находится слово</param>
        public void EditWordAndTranslate(int lineNumber)
        {
            string newWord1 = " ";
            string newTrans1 = " ";
            string newTrans2 = " ";

            try
            {
                using (StreamReader readerW = new StreamReader(_pathsForWords[_indexPathForWord]))
                {
                    using (StreamReader readerT = new StreamReader(_pathsForWords[_indexPathForTranslate]))
                    {
                        using (StreamReader readerL = new StreamReader(_pathsForWords[_indexPathForThirdFileWithWords]))
                        {
                            int i = 1;
                            Console.Write($"Введите новое слово на {_fromLanguage} языке(если не хотите менять, введите такое же слово)-> "); // получение нового слова на основном языке словаря
                            newWord1 = Console.ReadLine();

                            Console.Write($"Введите новый перевод нового слова на {_toLanguage} языке -> "); // получение перевода нового слова на второстепенном языке словаря
                            newTrans1 = Console.ReadLine();

                            Console.Write($"Введите новый перевод нового слова на {_thirdLanguage} языке -> "); // получение перевода нового слова на третьем языке словаря
                            newTrans2 = Console.ReadLine();

                            using (StreamWriter writer = new StreamWriter("Database\\newBase.txt", true))
                            {
                                using (StreamWriter writer1 = new StreamWriter("Database\\newBase1.txt", true))
                                {
                                    using (StreamWriter writer2 = new StreamWriter("Database\\newBase2.txt", true))
                                    {
                                        bool changeNorm = false; // если пользователь ввел слишком большой или маленький номер строки, то можно будет сгенерировать ошибку

                                        while (!readerW.EndOfStream || !readerT.EndOfStream)
                                        {
                                            if (i != lineNumber)
                                            {
                                                writer.WriteLine(readerW.ReadLine());
                                                writer1.WriteLine(readerT.ReadLine());
                                                writer2.WriteLine(readerL.ReadLine());
                                            }
                                            else
                                            {
                                                readerW.ReadLine(); // просто смещение указателя по файлу
                                                readerT.ReadLine(); //
                                                readerL.ReadLine(); //

                                                writer.WriteLine(newWord1);   // запись нового слова, на той строчке где было старое
                                                writer1.WriteLine(newTrans1); // запись нового перевода
                                                writer2.WriteLine(newTrans2); // запись нового перевода

                                                changeNorm = true;
                                            }
                                            i++;
                                        }
                                        if (!changeNorm)
                                            throw new ArgumentException("Проверьте правильность выбора номера строки");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Copy("Database\\newBase.txt", _pathsForWords[_indexPathForWord], true);
            File.Copy("Database\\newBase1.txt", _pathsForWords[_indexPathForTranslate], true);
            File.Copy("Database\\newBase2.txt", _pathsForWords[_indexPathForThirdFileWithWords], true);
            File.Delete("Database\\newBase.txt");
            File.Delete("Database\\newBase1.txt");
            File.Delete("Database\\newBase2.txt");
        }

        /// <summary>
        /// Метод для экспортирования слова и его перевода в бинарный файл
        /// </summary>
        /// <exception cref="Exception"
        /// <param name="lineNumber">номер строки на которой находится слово</param>
        public void ExportWordAndTranslateInFile(int lineNumber)
        {
            string path = $"Words\\Word{lineNumber}.bin";

            try
            {
                using (StreamReader readerW = new StreamReader(_pathsForWords[_indexPathForWord]))
                {
                    using (StreamReader readerT = new StreamReader(_pathsForWords[_indexPathForTranslate]))
                    {
                        using (StreamReader readerL = new StreamReader(_pathsForWords[_indexPathForThirdFileWithWords]))
                        {
                            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                int i = 1;
                                while (!readerW.EndOfStream || !readerT.EndOfStream)
                                {
                                    BinaryFormatter formatter = new BinaryFormatter();

                                    if (i == lineNumber)
                                    {
                                        formatter.Serialize(fstream, ($"({_fromLanguage})" + readerW.ReadLine() + $" -> ({_toLanguage})" + readerT.ReadLine() + $"-> ({_thirdLanguage})" + readerL.ReadLine()));
                                        break;
                                    }

                                    readerW.ReadLine();
                                    readerT.ReadLine();
                                    readerL.ReadLine();

                                    i++;
                                }
                                Console.WriteLine("Файл создан, путь -> " + path);
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Метод для чтения(десериализации) бинарного файла из папки bin\Debug\Words
        /// </summary>
        public void ReadWordFromBinaryFile()
        {
            Console.Clear();

            int i = 1;
            int index = 0;
            string[] files = Directory.GetFiles("Words");

            if (files.Length == 0)
                Console.WriteLine("На данный момент в папке нет слов для прочтения");
            else
            {
                Console.WriteLine("На данный момент в папке есть " + files.Length + " слов(а, о)");
                foreach (string file in files)
                {
                    Console.WriteLine(i + "-> " + file);
                    i++;
                }

                Console.Write("Выберите файл (по номеру) для прочтения -> ");
                try
                {
                    index = int.Parse(Console.ReadLine());
                    index--;
                    using(FileStream fstream = new FileStream(files[index], FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        Console.Write("Полученная информация из файла: ");
                        Console.WriteLine(formatter.Deserialize(fstream));
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Вводите целочисленные значения!");
                    ReadWordFromBinaryFile();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод для удаления слова из файла. Все его переводы также будут удалены
        /// </summary>
        /// <exception cref="Exception"
        /// <param name="lineNumber">номер строки на которой находится слово</param>
        public void DeleteWord(int lineNumber)
        {
            try
            {
                int lastIndex = 0;

                if (_indexPathForWord == 0 && _indexPathForTranslate == 1)
                    lastIndex = 2;
                else if (_indexPathForWord == 0 && _indexPathForTranslate == 2)
                    lastIndex = 1;
                else if (_indexPathForWord == 1 && _indexPathForTranslate == 0)
                    lastIndex = 2;
                else if (_indexPathForWord == 1 && _indexPathForTranslate == 2)
                    lastIndex = 0;
                else if (_indexPathForWord == 2 && _indexPathForTranslate == 0)
                    lastIndex = 1;
                else if (_indexPathForWord == 2 && _indexPathForTranslate == 1)
                    lastIndex = 0;

                DeleteWordFromFile(_pathsForWords[_indexPathForWord], "Database\\newBase.txt", lineNumber);
                DeleteWordFromFile(_pathsForWords[_indexPathForTranslate], "Database\\newBase1.txt", lineNumber);
                DeleteWordFromFile(_pathsForWords[lastIndex], "Database\\newBase2.txt", lineNumber);

                File.Copy("Database\\newBase2.txt", _pathsForWords[lastIndex], true);
                File.Copy("Database\\newBase1.txt", _pathsForWords[_indexPathForTranslate], true);
                File.Copy("Database\\newBase.txt", _pathsForWords[_indexPathForWord], true);
                File.Delete("Database\\newBase.txt");
                File.Delete("Database\\newBase1.txt");
                File.Delete("Database\\newBase2.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteWordFromFile(string pathSource, string pathDest, int lineNumber)
        {
            using (StreamReader reader = new StreamReader(pathSource))
            {
                using (StreamWriter writer = new StreamWriter(pathDest, true))
                {
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        i++;
                        if (i == lineNumber)
                        {
                            reader.ReadLine();
                            continue;
                        }

                        writer.WriteLine(reader.ReadLine());
                    }
                }
            }
        }

        /// <summary>
        /// Метод для отображения словаря
        /// </summary>
        /// <exception cref="Exception"
        public void ShowDictionary()
        {
            Console.Clear();
            try
            {
                using (StreamReader readerW = new StreamReader(_pathsForWords[_indexPathForWord]))
                {
                    using (StreamReader readerT = new StreamReader(_pathsForWords[_indexPathForTranslate]))
                    {
                        int i = 1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Слово\t\t\t  Перевод");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        while (!readerW.EndOfStream || !readerT.EndOfStream)
                        {
                            Console.WriteLine(i + $": {readerW.ReadLine()}\t\t\t{readerT.ReadLine()}");

                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}