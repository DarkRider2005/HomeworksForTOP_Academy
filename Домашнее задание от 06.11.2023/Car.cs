using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskTwo
{
    public class Car : Device
    {
        float _enginePower;
        public Car(string title, string description, float enginePower, DateTime dateOfCreation) : base(title, description, dateOfCreation)
        {
            _enginePower = enginePower;
        }

        public override void Sound()
        {
            Console.WriteLine("*Издает звук* <Врум-Врум, Дави Тапку В Пол>");
        }

        public override string ToString()
        {
            return base.ToString() + $"Мощность двигателя {_enginePower}л/с\n";
        }
    }
}
