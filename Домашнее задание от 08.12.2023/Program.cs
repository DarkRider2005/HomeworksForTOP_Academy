using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        private int _numberRequests = 0;

        private void RequestingNumber()
        {
            Console.Clear();

            try
            {
                Console.Write("Введите число от 1 до 2000 -> ");
                int userNumber = int.Parse(Console.ReadLine());

                if (userNumber < 1 || userNumber > 2000)
                    throw new ArgumentOutOfRangeException("Введите число от 1 до 2000");

                GuessNumber(userNumber);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(3000);
                Console.Clear();
                RequestingNumber();
            }
        }

        private void GuessNumber(int userNumber)
        {
            int minNumber = 1;
            int maxNumber = 2001;
            int comNumber = 0;
            Random random = new Random();

            while (comNumber != userNumber)
            {
                comNumber = random.Next(minNumber, maxNumber);

                if (comNumber > userNumber) // это типа как будто компьютер задает неявно вопрос - Ваше число больше или меньше моего числа?
                    maxNumber = comNumber;
                
                else if (comNumber < userNumber)
                    minNumber = comNumber;

                _numberRequests++;
            }

            Console.WriteLine($"Ваше число -> {comNumber}, потребовалось попыток -> {_numberRequests}");
            Console.WriteLine("Хотите сыграть еще? 1 - да, любое другое значение - нет");
            Console.Write("Выбираю -> ");
            string action = Console.ReadLine();

            if (action == "1")
                RequestingNumber();

            else return;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            program.RequestingNumber();
        }
    }
}
