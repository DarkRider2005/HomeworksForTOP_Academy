using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = " ";

            Console.Write(" Введите текст заметки для записи в файл -> ");
            text = Console.ReadLine();
            
            Logger.AddLog(text);
            Logger.ReadAllLog();
        }
    }
}
