using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.TicTacToe;

namespace Program
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            TicTacToeGameManager ticTacToeGame = new TicTacToeGameManager();

            int action = 0;
            Console.WriteLine("Для проверки желаемого задания введите его номер, для выхода - 3");
            Console.Write("Я выбираю -> ");
            action = Int32.Parse(Console.ReadLine());

            if (action == 1)
                ticTacToeGame.StartGame();

            else journal.SetData();

        }
    }
}