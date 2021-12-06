using System;
using System.Diagnostics;
using System.IO;

namespace testSVD
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[,] origin_matrix = new int[,] { { 1, 2, 4 }, {2, 5, 8 }, {6, 7, 10 } };
            

            FileStream fs = File.Create(@"origin_matrix.txt");
            fs.Close();
            using (StreamWriter sw = new StreamWriter(@"origin_matrix.txt"))
            {
                for(int i = 0; i < origin_matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < origin_matrix.GetLength(1); j++)
                    {
                        sw.Write($"{origin_matrix[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }

            using Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "python",
                Arguments = @"path\test.py",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            });

            Console.ReadKey();
        }
    }
}
