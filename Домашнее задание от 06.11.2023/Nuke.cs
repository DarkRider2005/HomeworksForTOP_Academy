using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskTwo
{
   public class Nuke : Device
    {
        string _type;
        public Nuke(string title, string description, string type, DateTime dateOfCreation) : base(title, description, dateOfCreation)
        {
            _type = type;
        }

        public override void Sound()
        {
            Console.WriteLine("*Издает звук* <Я Жу-Жу И Грею Еду>");
        }

        public override string ToString()
        {
            return base.ToString() + $"Тип микроволной печи {_type}\n";
        }
    }
}
