using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskOne
{
    public abstract class Employee : Human
    {
        double _salary;

        public Employee(string fName, string lName) : base(fName, lName)
        { }

        public Employee(string fName, string lName, double salary) : base(fName, lName)
        {
            _salary = salary;
        }

        public Employee(string fName, string lName, DateTime date, double salary)
            : base(fName, lName, date)
        {
            _salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Зарплата: {_salary} руб.\n";
        }
    }
}