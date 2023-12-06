using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Logger
    {
        public static void AddLog(string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("Notes.txt", true))
                {
                    writer.WriteLine(DateTime.Today + " -> " +text);
                    using (StreamWriter writer1 = new StreamWriter("Journal.log", true))
                    {
                        writer1.WriteLine(DateTime.Now + " Создана новая заметка");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                using (StreamWriter writer1 = new StreamWriter("Journal.log", true))
                {
                    writer1.WriteLine(DateTime.Now + ex.Message);
                }

                return;
            }
        }

        public static void ReadAllLog()
        {
            try
            {
                using (StreamReader reader = new StreamReader("Notes.txt", true))
                {
                    Console.WriteLine(" Данные полученные из файла <Notes.txt>");
                    Console.WriteLine(reader.ReadToEnd());
                    using (StreamWriter writer = new StreamWriter("Journal.log", true))
                    {
                        writer.WriteLine(DateTime.Now + " Заметки прочитаны");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                using (StreamWriter writer = new StreamWriter("Journal.log", true))
                {
                    writer.WriteLine(DateTime.Now + ex.Message);
                }

                return;
            }
        }
    }
}
