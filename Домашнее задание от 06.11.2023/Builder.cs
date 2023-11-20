using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskOne
{
    public class Builder : Employee
    {
        private string _specialization;
        public Builder(string fName, string lName, string specialization, DateTime date, double salary) : base(fName, lName, date, salary)
        {
            _specialization = specialization;
        }

        public override string ToString()
        {
            return base.ToString() + $"Строитель. Специализация: {_specialization}.\n";
        }
    }
}