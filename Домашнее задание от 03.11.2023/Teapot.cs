using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskTwo
{
    public class Teapot : Device 
    {
        float _volume;
        public Teapot(string title, string description, float volume ,DateTime dateOfCreation) : base(title, description, dateOfCreation) 
        {
            _volume = volume;
        }

        public override void Sound()
        {
            Console.WriteLine("*Издает звук* <Чых-Пых Я Кипячу Воду>");
        }

        public override string ToString()
        {
            return base.ToString() + $"Объем {_volume}л.\n";
        }
    }
}
