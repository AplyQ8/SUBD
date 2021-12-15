using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Matrix_operations
{
    public class NumPyInstallation
    {
        public void Task()
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript(File.ReadAllText(@"PSscript\Psscript.txt")).Invoke();
        }
    }
    public class Singularity
    {
       
        private double[,] Matrix_Transpose(double[,] matrix)
        {

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            double[,] transposed_matrix = new double[n, m];
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    transposed_matrix[j, i] = matrix[i, j];
                }
            }
            return transposed_matrix;
        }
        public double [,] Matrix_multiplier(double [,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new Exception("Матрицы нельзя перемножить");

            double[,] result = new double[matrix1.GetLength(0),matrix2.GetLength(1)];

            for(int i = 0; i < matrix1.GetLength(0); i++)
            {
                for(int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for(int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        result[i,j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        private double[] Eigenvalues_ascending(double[,] origin_matrix)
        {
            FileStream fs = File.Create(@"origin_matrix.txt");
            fs.Close();
            using (StreamWriter sw = new StreamWriter(@"origin_matrix.txt"))
            {
                for (int i = 0; i < origin_matrix.GetLength(0); i++)
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
            System.Threading.Thread.Sleep(1000);

            int ammountOfLines = 0;
            using (StreamReader sr = new StreamReader(@"eigenvalues.txt"))
            {
                String line;
                
                while ((line = sr.ReadLine()) != null)
                    ammountOfLines++;
                
            }
            double[] eigenvalues = new double[ammountOfLines];
            using (StreamReader sr = new StreamReader(@"eigenvalues.txt"))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    line = Replacer(line);
                    double value = Math.Round(Convert.ToDouble(line), 10);
                    eigenvalues[i] = value;
                    //eigenvalues[i] = Math.Round(value, 14);
                    i++;
                }
            }
            
            for (int i = 0; i < eigenvalues.Length; i++)
            {
                for (int j = 0; j < eigenvalues.Length - 1; j++)
                {
                    if (eigenvalues[j] < eigenvalues[j + 1])
                    {
                        double z = eigenvalues[j];
                        eigenvalues[j] = eigenvalues[j + 1];
                        eigenvalues[j + 1] = z;
                    }
                }
            }
            return eigenvalues;
        }

        private string Replacer(string line)
        {
            char[] array = line.ToCharArray(0, line.Length);
            for(int i = 0; i < line.Length; i++)
            {
                if (array[i] == '.')
                    array[i] = ',';

            }
            string newline = new string(array);
            return newline;
        }
        private bool IsNull(double element)
        {
            if (element == 0)
                return true;
            return false;
        }
        private void ChangeRows(ref double[,] curr_matrix, int row, int changing_row)
        {
            for(int j = 0; j < curr_matrix.GetLength(1); j++)
            {
                double temp = curr_matrix[row, j];
                curr_matrix[row, j] = curr_matrix[changing_row, j];
                curr_matrix[changing_row, j] = temp;
            }
        }

        private double[,] ToTriangle(double[,] curr_matrix, double eignvalue, int size) // закончить 
        {
            int offset = 0; // смещение
            int m = curr_matrix.GetLength(0) - 1;
            int n = curr_matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1 ; j < curr_matrix.GetLength(1); j++)
                {
                    //if (i == 3 && eignvalue == 0 && size == 13 && j == 5)
                    //{
                    //    Console.ReadKey();
                    //}
                    if (IsNull(curr_matrix[i, i + offset]))
                    {
                        bool notFound = true;
                        
                        
                        for (int k = i+1; k < curr_matrix.GetLength(0); k++)
                        {
                            if(curr_matrix[k, i + offset] != 0)
                            {
                                ChangeRows(ref curr_matrix, i, k );
                                notFound = false;
                                break;
                            }
                        }
                        if (notFound == true)
                        {
                            offset++;
                            m--;
                            n--;
                        }
                        else
                        {
                            double koefic = curr_matrix[j, i + offset] / curr_matrix[i, i + offset];

                            for (int k = i; k < n; k++)
                            {
                                curr_matrix[j, k + offset] -= curr_matrix[i, k + offset] * koefic;
                            }
                        }
                        
                    }
                    else
                    {
                        double koefic = curr_matrix[j, i + offset] / curr_matrix[i, i + offset];

                        for (int k = i; k < n; k++)
                        {
                            curr_matrix[j, k + offset] -= curr_matrix[i, k + offset] * koefic;
                        }
                    }


                }
            }
            return curr_matrix;
        }
        private double[,] CopyArray(double[,] curr_matrix,double[,] origin_matrix)
        {
            
            for (int i = 0; i < origin_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < origin_matrix.GetLength(1); j++)
                {
                    curr_matrix[i, j] = origin_matrix[i, j];
                }
            }
            return curr_matrix;
        }
        private void Rounding_Matrix(ref double[,] curr_matrix)
        {
            for(int i = 0; i < curr_matrix.GetLength(0); i++)
            {
                for( int j = 0; j < curr_matrix.GetLength(1); j++)
                {
                    curr_matrix[i, j] = Math.Round(curr_matrix[i, j], 9);
                }
            }
        }
        private int First_Not_Null_Row(double[,] curr_matrix) // нахождение последней нулевой строки
        {
            int First_not_null_row = curr_matrix.GetLength(0) - 1;
            for(int i = curr_matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool isNotNull = false;
                for(int j = 0; j < curr_matrix.GetLength(1); j ++)
                {
                    if (curr_matrix[i, j] != 0)
                        isNotNull = true;
                }
                if (isNotNull)
                {
                    First_not_null_row = i;
                    break;
                }

            }

            return First_not_null_row;
        }
        private int First_Not_Null_Element(double[,] curr_matrix, int row)
        {
            int index = 0;
            for(int j = 0; j < curr_matrix.GetLength(1); j++)
            {
                if(curr_matrix[row, j] != 0)
                {
                    index = j;
                    break;
                }
            }
            return index;
        }
        private double[] Eigenvector(double[,] matrix, double eigenvalue, int size_of_current_matrix) //надо доработать
        {
            Random random = new Random();
            double[,] curr_matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            curr_matrix = CopyArray(curr_matrix, matrix);
            double[] vector = new double[size_of_current_matrix];
            for (int i = 0; i < curr_matrix.GetLength(0); i++)
            {
                curr_matrix[i, i] -= eigenvalue;
            }
            curr_matrix = ToTriangle(curr_matrix, eigenvalue, curr_matrix.GetLength(0));
            Rounding_Matrix(ref curr_matrix);

            int first_not_null_row = First_Not_Null_Row(curr_matrix);
            int first_not_null_element = First_Not_Null_Element(curr_matrix, first_not_null_row);

            int vector_filled_values = 0;
            if (first_not_null_element == curr_matrix.GetLength(1) - 1)
            {
                vector[vector.Length - 1] = 0;
            }
            else
            {
                double sum_of_vector_values = 0;
                for(int j = first_not_null_element; j < vector.Length - 1; j++)
                {
                    vector[j+1] = random.NextDouble() * 7;
                    vector_filled_values++;
                    sum_of_vector_values += vector[j+1] * curr_matrix[first_not_null_row, j+1];
                }
                vector[first_not_null_element] = -(sum_of_vector_values / curr_matrix[first_not_null_row, first_not_null_element]);
                vector_filled_values++;
            }

            for(int i = first_not_null_row - 1; i >= 0; i--)
            {
                double sum = 0;
                int not_null_element = First_Not_Null_Element(curr_matrix, i);
                if(vector.Length - vector_filled_values - not_null_element > 1 )
                {
                    for (int j = not_null_element + 1; j < vector.Length - vector_filled_values; j++)
                    {
                        vector[j] = random.NextDouble() * 7;
                        vector_filled_values++;
                    }
                }
                int column = curr_matrix.GetLength(0) - 1;

                
                for(int k = vector.Length - 1; k >= vector.Length - vector_filled_values; k--)
                {
                    sum += curr_matrix[i, column] * vector[k];
                    column--;
                }
                vector[vector.Length - vector_filled_values - 1] = -(sum / curr_matrix[i, not_null_element]);
                vector_filled_values++;
            }


            double normalized_koef = 0;
            for (int i = 0; i < vector.Length; i++)
                normalized_koef += Math.Pow(vector[i], 2);
            for (int i = 0; i < vector.Length; i++)
                vector[i] = vector[i] / Math.Sqrt(normalized_koef);

            return vector;

        }
        public double[] Singular_Values(double[] eignvalues)
        {
            for(int i = 0; i < eignvalues.Length; i++)
            {
                eignvalues[i] = Math.Round(Math.Sqrt(eignvalues[i]), 4);
            }
            return eignvalues;
        }
        public double[,] Sigma(double[,] origin_matrix, double[] eignvalues)
        {
            double[] singular_values = Singular_Values(eignvalues);
            double[,] S = new double[origin_matrix.GetLength(0),origin_matrix.GetLength(1)];

            int count_of_singular_values = 0;
            for(int i = 0; i < S.GetLength(0); i++)
            {
                for(int j = 0; j < S.GetLength(1); j++)
                {
                    if(i == j)
                    {
                        S[i, j] = singular_values[count_of_singular_values];
                        count_of_singular_values++;
                    }
                    if (count_of_singular_values == singular_values.Length)
                        break;
                }
            }

            return S;
        }
        public double[,] V_transposed(double[,] origin_matrix, double[] eignvalues, double[,] AtA)
        {
            double[,] V_transposed = new double[origin_matrix.GetLength(1), origin_matrix.GetLength(1)];

            int count_of_eignvalues = 0;
            int i = 0;
            while( i < V_transposed.GetLength(0))
            {

                double[] vector = Eigenvector(AtA, eignvalues[count_of_eignvalues], V_transposed.GetLength(1));
                for(int j = 0; j < V_transposed.GetLength(1); j++)
                {
                    V_transposed[i, j] = vector[j];
                }
                i++;
                count_of_eignvalues++;
            }

            return V_transposed;
        }

        public double[,] U_matrix(double[,] origin_matrix, double[] eignvalues, double[,] AAt)
        {
            double[,] u_matrix = new double[origin_matrix.GetLength(0), origin_matrix.GetLength(0)];

            int count_of_eignvalues = 0;
            int i = 0;
            while (i != u_matrix.GetLength(0))
            {
                double[] vector = Eigenvector(AAt, eignvalues[count_of_eignvalues], u_matrix.GetLength(1));
                for (int j = 0; j < u_matrix.GetLength(1); j++)
                {
                    u_matrix[i, j] = vector[j];
                }
                i++;
                count_of_eignvalues++;
            }

            u_matrix = Matrix_Transpose(u_matrix);

            return u_matrix;
        }
        public List<double[,]> Decomposition(double[,] matrix)
        {
            //NumPyInstallation npi = new NumPyInstallation();
            //Task task = new Task(npi.Task);
            //task.Start();
            //task.Wait();

            List<double[,]> results_of_decomposition = new List<double[,]>();

            double[,] transposed_matrix = Matrix_Transpose(matrix);
            double[,] AtA = Matrix_multiplier(transposed_matrix, matrix); //матрица для S и Vt
            
            double[] eigenvalues = Eigenvalues_ascending(AtA); //собственные значения для S и Vt 

            double[,] Vt = V_transposed(matrix, eigenvalues, AtA);
            double[,] S = Sigma(matrix, eigenvalues);

            double[,] AAt = Matrix_multiplier(matrix, transposed_matrix);
            eigenvalues = Eigenvalues_ascending(AAt);
            double[,] U = U_matrix(matrix, eigenvalues, AAt);


            results_of_decomposition.Add(U);            
            results_of_decomposition.Add(S); 
            results_of_decomposition.Add(Vt);


            return results_of_decomposition;
        }
    }
}
