using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskOne
{
    public class Sailor : Employee
    {
        private string _rank;
        public Sailor(string fName, string lName, string rank, DateTime date, double salary) : base(fName, lName, date, salary)
        {
            _rank = rank;
        }

        public override string ToString()
        {
            return base.ToString() + $"Моряк. Звание: {_rank}.\n";
        }
    }
}
