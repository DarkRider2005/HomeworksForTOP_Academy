using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskOne
{
    public abstract class Human
    {
        string firstName;
        string lastName;
        DateTime birthDate;

        public Human()
        { }

        public Human(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        public Human(string fName, string lName, DateTime date) : this(fName, lName)
        {
            birthDate = date;
        }

        public override string ToString()
        {
            return $"Фамилия: {lastName}\n" +
                $"Имя: {firstName}\n" +
                $"Дата рождения: {birthDate.ToShortDateString()}\n";
        }
    }
}