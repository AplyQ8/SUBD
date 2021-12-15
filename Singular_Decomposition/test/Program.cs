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
            double[,] matrix1 =
            {
                { 1, 0, 0, 1, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 0 }
            };
            Singularity s = new Singularity();

            List<double[,]> singular_decomposition = s.Decomposition(matrix1);

            Console.WriteLine("U: ");
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < singular_decomposition[0].GetLength(0); i++)
            {
                string row = null;
                for (int j = 0; j < singular_decomposition[0].GetLength(1); j++)
                {
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
                    row += singular_decomposition[2][i, j].ToString() + " ";
                }
                sb.AppendLine(row);
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Console.WriteLine("Проверка на правильность вычислений: ");

            double[,] check = s.Matrix_multiplier(singular_decomposition[0], singular_decomposition[1]);
            check = s.Matrix_multiplier(check, singular_decomposition[2]);
            for (int i = 0; i < check.GetLength(0); i++)
            {
                string row = null;
                for (int j = 0; j < check.GetLength(1); j++)
                {
                    check[i, j] = Math.Round(check[i, j], 4);
                    row += check[i, j].ToString() + " ";
                }
                sb.AppendLine(row);
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();
            //double x = 8.8708978975E-9;
            //if (x == 0)
            //    Console.WriteLine("is null");
            //else
            //    Console.WriteLine("not actually null");
            //x = Math.Round(x, 10);
            //if (x == 0)
            //    Console.WriteLine("is null");
            //else
            //    Console.WriteLine("not actually null");



        }
    }
}
