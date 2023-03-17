/*
 * 26.	Задана квадратная матрица N×N. Найти суммы элементов тех строк, у которых элементы, расположенные на главной диагонали, равны нулю.
 */

namespace task1_csharp
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int[,] matrix = generateRandomMatrix(readSize());
            matrix = putRandomZerosAtMainDiag(matrix);
            printMatrix(matrix);
            int[] result = sumRowsWithZeroAtMainDiag(matrix);
            printVector(result);
        }

        static int readSize()
        {
            int size;
            do
            {
                Console.Write("Enter matrix size (>= 2): ");
                size = Convert.ToInt32(Console.ReadLine());
            } while (size < 2);
            return size;
        }

        static int[,] generateRandomMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }
            return matrix;
        }

        static int[,] putRandomZerosAtMainDiag(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = random.Next(2) == 0 ? 0 : matrix[i, i];
            }
            return matrix;
        }

        static void printMatrix(int[,] matrix)
        {
            Console.WriteLine();
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[] sumRowsWithZeroAtMainDiag(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, i] == 0)
                {
                    result[i] = sumRow(matrix, i);
                }
                else
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        static int sumRow(int[,] matrix, int row)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[row, i];
            }
            return sum;
        }

        static void printVector(int[] vector)
        {
            Console.WriteLine();
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }
    }
}