using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookingexception
{
    public class NullPointerException : Exception
    {
        public NullPointerException(string message) : base(message) { }
    }
}
