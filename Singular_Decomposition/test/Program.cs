using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Matrix_operations;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix4 =
            {
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 1, 0, 1, 0, 2, 1, 0, 0, 1, 3, 1, 1, 0, 0, 0 },
                { 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 2, 1, 1, 0, 0, 0, 0, 0, 2 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0, 3, 1, 1, 0, 1, 0, 1, 2, 5, 2, 1 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 2, 2, 2, 1, 1, 0, 0, 0, 0, 3 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 3, 2, 0, 0, 0, 0, 2, 1, 2, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 4, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 2, 1, 2, 2, 2, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
            };
            double[,] matrix1 =
            {
                {1,0,0,0,0,0,0,1,0},
                {1,0,0,1,0,1,0,1,0},
                {1,0,0,1,0,1,0,1,0},
                {0,1,0,0,0,1,0,0,0},
                {0,1,0,0,0,0,1,0,0},
                {0,1,0,0,0,0,1,0,0},
                {0,0,1,0,1,0,0,0,0},
                {0,0,1,0,1,0,0,0,1},
                {0,0,1,0,1,0,0,0,1},
                
            };
            double[,] matrix3 =
            {
                { 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 1, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 1, 0, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0 }
            };
            double[,] matrix0 =
            {
                { 1, 0, 0, 1, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 0, 1, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 0 }
            };
            double[,] matrix2 =
            {
                
                {2, 1, 2, 1, 10 },
                {2, 3, 2, 0, 7 },
                {0, 3, 1, 4, 0 },
                {1, 0, 0, 1, 11 },
                {1, 2, 0, 4, 1 }
            };
            Singularity s = new Singularity();

            List<double[,]> singular_decomposition = s.Decomposition(matrix0, 2);

            Console.WriteLine("U: ");
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < singular_decomposition[0].GetLength(0); i++)
            {
                string row = null;
                for (int j = 0; j < singular_decomposition[0].GetLength(1); j++)
                {
                    singular_decomposition[0][i, j] = Math.Round(singular_decomposition[0][i, j], 2);
                    row += singular_decomposition[0][i, j].ToString() + " ";
                }
                sb.AppendLine(row);
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Console.WriteLine("Sigma: ");
            for (int i = 0; i < singular_decomposition[1].GetLength(0); i++)
            {
                string row = null;
                for (int j = 0; j < singular_decomposition[1].GetLength(1); j++)
                {
                    row += singular_decomposition[1][i, j].ToString() + " ";
                }
                sb.AppendLine(row);
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Console.WriteLine("Vt: ");
            for (int i = 0; i < singular_decomposition[2].GetLength(0); i++)
            {
                string row = null;
                for (int j = 0; j < singular_decomposition[2].GetLength(1); j++)
                {
                    singular_decomposition[2][i, j] = Math.Round(singular_decomposition[2][i, j], 2);
                    row += singular_decomposition[2][i, j].ToString() + " ";
                }
                sb.AppendLine(row);
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            



        }
    }
}
