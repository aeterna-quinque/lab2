using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixSumException: Exception
    {
        public MatrixSumException(string message)
            : base(message)
        { }
    }
}
