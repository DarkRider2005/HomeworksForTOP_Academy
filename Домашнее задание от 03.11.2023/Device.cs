using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskTwo
{
    public abstract class Device
    {
        string _title;
        string _description;

        DateTime _dateOfCreation;

        public Device() { }

        public Device(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public Device(string title, string description, DateTime dateOfCreation) : this(title, description)
        {
            _dateOfCreation = dateOfCreation;
        }

        public override string ToString()
        {
            return $"Название: {_title}\n";
        }

        public virtual void Sound() { }
        public void Desk() 
        { 
            Console.WriteLine("ОПИСАНИЕ: " +_description);
        }
    }
}
