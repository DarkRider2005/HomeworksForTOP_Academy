using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Program.TaskOne;
using Program.TaskTwo;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            int action = 0;
            Console.WriteLine("Для проверки желаемого задания напишите его номер, для выхода - 3");
            try
            {
                action = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Вводите целочисленные значения! ");
                Thread.Sleep(1000);
                Console.Clear();
                Main(args);
            }

            if(action == 1)
            {
                Builder builder = new Builder("Петя", "Пупкин", "Прораб", new DateTime(2000, 6, 11), 100000);
                Sailor sailor = new Sailor("Кот", "Матроскин", "Капрал", new DateTime(1999, 2, 15), 145000);
                Pilot pilot = new Pilot("Вася", "Мечтатель", "Курсант", new DateTime(1989, 6, 29), 200000);
                Console.Write(builder.ToString() + "\n" + sailor.ToString() + "\n" + pilot.ToString());
            }
            else if(action == 2)
            {
                Teapot teapot = new Teapot("Я ЧАЙНИК", "ЛЮБЛЮ ХОЛОДНУЮ ВОДУ", 1.7f, new DateTime(2023, 11, 20));
                Nuke nuke = new Nuke("Я МИКРОВОЛНОВКА", "ЛЮБЛЮ ГРЕТЬ ТАРЕЛКИ", "СВЧ + Гриль", new DateTime(2023, 11, 20));
                Car car = new Car("Я АВТОМОБИЛЬ", "ЛЮБЛЮ ГОНЯТЬ ПО ГОРОДСКИМ УЛИЦАМ", 400f, new DateTime(2023, 11, 20));
                Steamboat steamboat = new Steamboat("Я ПАРОХОД", "НРАВИТСЯ ПЛАВАТЬ", 5000f, new DateTime(2023, 11, 20));

                Console.Write(teapot.ToString());
                teapot.Desk();
                teapot.Sound();
                Console.WriteLine();

                Console.Write(nuke.ToString());
                nuke.Desk();
                nuke.Sound();
                Console.WriteLine();

                Console.Write(car.ToString());
                car.Desk();
                car.Sound();
                Console.WriteLine();

                Console.Write(steamboat.ToString());
                steamboat.Desk();
                steamboat.Sound();
                Console.WriteLine();
            }
            else
                return;
        }
    }
}