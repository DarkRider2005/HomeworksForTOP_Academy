using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class ListBookException : SystemException
    {
        public ListBookException(string message) : base(message) { }
    }
}
