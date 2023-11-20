using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskTwo
{
    internal class Steamboat : Device
    {
        float _weight;
        public Steamboat(string title, string description, float weight, DateTime dateOfCreation) : base(title, description, dateOfCreation)
        {
            _weight = weight;
        }

        public override void Sound()
        {
            Console.WriteLine("*Издает звук* <УУУУ, Я Большой, УУУУ>");
        }

        public override string ToString()
        {
            return base.ToString() + $"Вес {_weight}тонн\n";
        }
    }
}
