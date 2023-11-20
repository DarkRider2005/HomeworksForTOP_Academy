using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.TaskOne
{
    public class Pilot : Employee
    {
        private string _rank;
        public Pilot(string fName, string lName, string rank, DateTime date, double salary) : base(fName, lName, date, salary)
        {
            _rank = rank;
        }

        public override string ToString()
        {
            return base.ToString() + $"Пилот. Звание: {_rank}.\n";
        }
    }
}
