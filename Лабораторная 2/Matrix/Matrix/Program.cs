using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(3);
            m1.Input();
            Matrix m2 = new Matrix();
            m2.SizeEnter();
            m2.Input();
            m1.Output();
            m2.Output();
            int[,] sum = new int[3, 3];
            //sum = m1.SumMatrix(m2);
            int[,] mltplx = new int[3, 3];
            mltplx = m1.MultiplyMatrix(m2);
            //m1.InverseMatrix();
            m2.InverseMatrix();
        }
    }
}
