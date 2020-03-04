using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class DetException: Exception
    {
        public DetException(string message)
            :base (message)
        { }
    }
}
