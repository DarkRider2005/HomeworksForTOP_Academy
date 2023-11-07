using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Задание 1. Пользователь вводит с клавиатуры число в диапазоне от 1 до
100. Если число кратно 3 (делится на 3 без остатка) нужно вывести слово
Fizz. Если число кратно 5 нужно вывести слово Buzz. Если число кратно 3
и 5 нужно вывести Fizz Buzz. Если число не кратно не 3 и 5 нужно вывести
само число. Если пользователь ввел значение не в диапазоне от 1 до 100
требуется вывести сообщение об ошибке.
Задание 2. Пользователь вводит с клавиатуры показания температуры. В
зависимости от выбора пользователя программа переводит температуру из
Фаренгейта в Цельсий или наоборот.
 */
namespace Program
{
    class Program
    {
        private void TaskOne()
        {
            int userNumber = 0;

            Console.WriteLine("Введите число от 1 до 100");
            userNumber = Int32.Parse(Console.ReadLine());

            if (userNumber < 1 || userNumber > 100)
            {
                Console.WriteLine("Вы ввели число вне диапазона!");
                return;
            }

            if (userNumber % 3 == 0)
                Console.WriteLine("Fizz");

            if (userNumber % 5 == 0)
                Console.WriteLine("Buzz");
            else if (userNumber % 3 == 1)
                Console.WriteLine(userNumber);
        }
        private void TaskTwo()
        {
            int unitMeasurement = 0;
            float temperatureValue = 0;
            Console.WriteLine("В какой единице измерения вы будете вводить данные о температуре?\n 1) В Цельсиях\n 2) В Фаренгейтах");

            if (unitMeasurement == 0)
            {
                Console.Write("Введите значение температуры в Цельсиях: ");
                temperatureValue = float.Parse(Console.ReadLine());
                temperatureValue = temperatureValue * 9 / 5 + 32;
                Console.WriteLine("Введенное вами значение температуры по шкале Фаренгейта равно: " + temperatureValue);
            }
            else
            {
                Console.Write("Введите значение температуры в Фаренгейтах: ");
                temperatureValue = float.Parse(Console.ReadLine());
                temperatureValue = (temperatureValue - 32) * 5 / 9;
                Console.WriteLine("Введенное вами значение температуры по шкале Цельсия равно: " + temperatureValue);
            }
        }
        static void Main(string[] args)
        {
            int action = 0;
            Console.WriteLine("Для выбора задания введите номер задания, для выхода - 3");
            action = Int32.Parse(Console.ReadLine());

            Program program = new Program();
            if (action == 1)
                program.TaskOne();

            else if (action == 2)
                program.TaskTwo();

            else return;
        }
    }
}
