using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixMultiplyException: Exception
    {
        public MatrixMultiplyException(string message)
            : base(message)
        { }
    }
}
