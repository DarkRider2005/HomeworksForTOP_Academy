using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program.TicTacToe
{
    public class TicTacToeGameManager
    {
        private bool _isPLayerGoFirst;

        public Random Random;

        private char[,] _playingBoard;

        private int _numberOfMoves = 0;
        public TicTacToeGameManager()
        {
            Random = new Random();
            int i = Random.Next(0, 2);

            _isPLayerGoFirst = i == 0 ? false : true;

            _playingBoard = new char[3, 3];
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _playingBoard[k, j] = ' ';
                }
            }
        }

        public void StartGame()
        {
            char plSym, comSym;
            plSym = _isPLayerGoFirst == true ? 'X' : 'O';
            comSym = plSym == 'X' ? 'O' : 'X';

            Player player = new Player(this, plSym);
            Player computer = new Player(this, comSym);

            Game(player, computer);
        }

        public void ShowPlayingDesk()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    Console.WriteLine("X->0 1 2");
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        Console.Write(i + "| ");
                    Console.Write(_playingBoard[i, j] + " ");

                    if (j == 2 && i == 2)
                        Console.WriteLine("\nY");
                }
                Console.WriteLine();
            }
        }

        public bool CheckPositionOnDesk(int i, int j)
        {
            if (_playingBoard[i, j] == ' ')
                return true;
            else
                return false;
        }

        public void SetSymOnDesk(int i, int j, char setSym)
        {
            _playingBoard[i, j] = setSym;
            _numberOfMoves++;
        }

        private void Game(Player player, Player computer)
        {
            while ((!CheckWinPlayer(player.Sym) && !CheckWinComputer(computer.Sym)) && _numberOfMoves < 9)
            {
                if (_isPLayerGoFirst)
                {
                    player.Motion();
                    _isPLayerGoFirst = false;
                }
                else
                {
                    computer.AutoMotion();
                    _isPLayerGoFirst = true;
                }
            }

            ShowPlayingDesk();
            if (!CheckWinPlayer(player.Sym) && !CheckWinComputer(computer.Sym))
            {
                Console.WriteLine("Игра закончилась ничьей!");
                return;
            }

            if (CheckWinPlayer(player.Sym))
            {
                Console.WriteLine("ИГРОК ВЫЙГРАЛ");
                return;
            }
            else if (CheckWinComputer(computer.Sym))
            {
                Console.WriteLine("КОМПЬЮТЕР ВЫЙГРАЛ");
                return;
            }
        }

        // Хотел сделать один метод для проверки победы, но при некоторых случаях расстановки символов на поле победа наступала преждевременно, а по факту никто не выиграл.
        private bool CheckWinPlayer(char gameSym)
        {
            bool win = false;

            if (_numberOfMoves < 5)
                return false;
            for (int i = 0; i < 3; i++)  // проверка победы по строкам
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_playingBoard[i, j] == gameSym)
                        win = true;
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return win;


                for (int j = 0; j < 3; j++)
                {
                    if (_playingBoard[j, i] == gameSym)
                        win = true;
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return win;

                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                        if (_playingBoard[i, j] == gameSym)
                            win = true;
                        else
                        {
                            win = false;
                            break;
                        }
                }

                for (int j = 0; j < 3; j++)
                {
                    if (i == j - i)
                    {
                        if (_playingBoard[i, j] == gameSym)
                            win = true;
                        else
                        {
                            win = false;
                            break;
                        }
                    }
                }
            }
            if (win)
                return win;

            return win;
        }
        private bool CheckWinComputer(char gameSym)
        {
            bool win = false;

            if (_numberOfMoves < 5)
                return false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_playingBoard[i, j] == gameSym)
                        win = true;
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return win;


                for (int j = 0; j < 3; j++)
                {
                    if (_playingBoard[j, i] == gameSym)
                        win = true;
                    else
                    {
                        win = false;
                        break;
                    }
                }
                return win;


                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                        if (_playingBoard[i, j] == gameSym)
                            win = true;
                        else
                        {
                            win = false;
                            break;
                        }
                }

                for (int j = 0; j < 3; j++)
                {
                    if (i == j - i)
                    {
                        if (_playingBoard[i, j] == gameSym)
                            win = true;
                        else
                        {
                            win = false;
                            break;
                        }
                    }
                }
            }
            if (win)
                return win;

            return win;
        }
    }
    public class Player
    {
        private TicTacToeGameManager _ticTacToeGameManager;

        private char _sym;
        public char Sym { get { return _sym; } }

        public Player(TicTacToeGameManager ticTacToeGameManager, char sym)
        {
            _ticTacToeGameManager = ticTacToeGameManager;
            _sym = sym;
        }

        public void Motion()
        {
            _ticTacToeGameManager.ShowPlayingDesk();
            int i = 0, j = 0;
            Console.Write("Введите желаемую позицию для установки вашего игрального символа(" + _sym + ")\n X = ");
            j = int.Parse(Console.ReadLine());
            Console.Write(" Y = ");
            i = int.Parse(Console.ReadLine());

            if (_ticTacToeGameManager.CheckPositionOnDesk(i, j))
                _ticTacToeGameManager.SetSymOnDesk(i, j, _sym);

            else
            {
                Console.WriteLine("Это место уже занято!");
                Thread.Sleep(1000);
                Motion();
            }
        }

        public void AutoMotion()
        {
            int indexI = _ticTacToeGameManager.Random.Next(0, 3);
            int indexJ = _ticTacToeGameManager.Random.Next(0, 3);

            if (_ticTacToeGameManager.CheckPositionOnDesk(indexI, indexJ))
                _ticTacToeGameManager.SetSymOnDesk(indexI, indexJ, _sym);

            else
                AutoMotion();
        }
    }
}