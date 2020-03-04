using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        private int size;
        private int[,] mtrx;
        private int det;
        private double[,] invmtrx;

        public Matrix()
        {
        }

        public Matrix(int n)
        {
            size = n;
        }

        public void SizeEnter()
        {
            try
            {
                Console.Write("Введите размер квадратной матрицы: ");
                size = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch
            {
                throw new FormatException("Вы ввели недопустимый символ.");
            }
        }

        public void Input()
        {
            try
            {
                mtrx = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write("[" + (i + 1) + "," + (j + 1) + "] = ");
                        mtrx[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();
            }
            catch
            {
                throw new FormatException("Вы ввели недопустимый символ.");
            }
        }

        public void Output()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("[" + (i + 1) + "," + (j + 1) + "] = " + mtrx[i, j] + "\t");
                    if ((j + 1) == size)
                    {
                        Console.Write("\n");
                    }
                }
            }
            Console.WriteLine();
        }

        private int GetSize()
        {
            return size;
        }

        private int GetNumber(int i, int j)
        {
            return mtrx[i - 1, j - 1];
        }

        public int[,] SumMatrix(Matrix m2)
        {
            int size2 = m2.GetSize();
            if (this.size == size2)
            {
                int[,] res = new int[this.size, this.size];
                for (int i = 0; i < this.size; i++)
                {
                    for (int j = 0; j < this.size; j++)
                    {
                        res[i, j] = this.mtrx[i, j] + m2.GetNumber(i + 1, j + 1);
                        Console.Write("[" + (i + 1) + "," + (j + 1) + "] = " + res[i, j] + "\t");
                        if ((j + 1) == size)
                        {
                            Console.Write("\n");
                        }
                    }

                }
                Console.WriteLine();
                return res;
            }
            else throw new MatrixSumException("Матрицы разной размерности.");
        }

        public int[,] MultiplyMatrix(Matrix m2)
        {
            int size2 = m2.GetSize();
            if (size2 == size)
            {
                int[,] res = new int[size, size];
                for (int i = 0; i < this.size; i++)
                {
                    for (int j = 0; j < this.size; j++)
                    {
                        int cij = 0;
                        for (int k = 0; k < this.size; k++)
                        {
                            cij = cij + this.mtrx[i, k] * m2.GetNumber(k + 1, j + 1);
                        }
                        res[i, j] = cij;
                        Console.Write("[" + (i + 1) + "," + (j + 1) + "] = " + res[i, j] + "\t");
                        if ((j + 1) == size)
                        {
                            Console.Write("\n");
                        }
                    }
                }
                Console.WriteLine();
                return res;
            }
            else throw new MatrixMultiplyException("Невозмонжо перемножить матрицы.");
        }

        private int[,] Minor(int[,] m1, int size, int position)
        {
            int[,] minor = new int[size - 1, size - 1];
            for (int j = 1; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (k > position)
                    {
                        minor[j - 1, k - 1] = m1[j, k];
                    }
                    if (k < position)
                    {
                        minor[j - 1, k] = m1[j, k];
                    }
                }
            }
            return minor;
        }

        private int Det(int[,] m1, int size)
        {
            if (size == 2)
                return (m1[0, 0] * m1[1, 1] - m1[0, 1] * m1[1, 0]);
            if (size > 2)
            {
                int det = 0;
                for (int i = 0; i < size; i++)
                {
                    if ((i % 2) == 0)
                        det = det + m1[0, i] * Det(Minor(m1, size, i), size - 1);
                    if ((i % 2) != 0)
                        det = det - m1[0, i] * Det(Minor(m1, size, i), size - 1);
                }
                return det;
            }
            return m1[0, 0];
        }

        private void MatrixDet()
        {
            if (this.size >= 1)
                this.det = Det(this.mtrx, this.size);
        }

        private int[,] Minor(int[,] m1, int size, int position1, int position2)
        {
            int[,] res = new int[size - 1, size - 1];
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if ((k > position2) & (j > position1))
                    {
                        res[j - 1, k - 1] = m1[j, k];
                    }
                    if ((k < position2) & (j > position1))
                    {
                        res[j - 1, k] = m1[j, k];
                    }
                    if ((k < position2) & (j < position1))
                    {
                        res[j, k] = m1[j, k];
                    }
                    if ((k > position2) & (j < position1))
                    {
                        res[j, k - 1] = m1[j, k];
                    }
                }

            }
            return res;
        }

        public void InverseMatrix()
        {
            if (Det(mtrx, size) == 0)
            {
                throw new DetException("Определитель равен нулю. Невозможно найти обратную матрицу.");
            }
            else
            {
                this.MatrixDet();
                int[,] transmtrx = new int[this.size, this.size];
                for (int i = 0; i < this.size; i++)
                {
                    for (int j = 0; j < this.size; j++)
                    {
                        transmtrx[i, j] = this.mtrx[j, i];
                    }
                }
                double[,] result = new double[this.size, this.size];



                for (int i = 0; i < this.size; i++)
                {
                    for (int j = 0; j < this.size; j++)
                    {
                        if ((i + j) % 2 == 1)
                            result[i, j] = -((double)(Det(Minor(transmtrx, this.size, i, j),
                                this.size - 1)) / (double)this.det);
                        if ((i + j) % 2 == 0)
                            result[i, j] = ((double)(Det(Minor(transmtrx, this.size, i, j),
                                this.size - 1)) / (double)this.det);
                        Console.Write("[" + (i + 1) + "," + (j + 1) + "] = " + result[i, j] + "\t");
                        if ((j + 1) == size)
                        {
                            Console.Write("\n");
                        }
                    }
                }
                Console.WriteLine();
                this.invmtrx = result;
            }
        }
    }
}
