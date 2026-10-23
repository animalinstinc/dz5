using System;
namespace Exercise6_2
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],6}");
                }
                Console.WriteLine();
            }
        }
        static int[,] MultiplyMatrices(int[,] a, int[,] b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);
            if (aCols != bRows)
                throw new ArgumentException("Матрицы нельзя перемножить: число столбцов A не равно числу строк B.");
            int[,] result = new int[aRows, bCols];
            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < aCols; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[,] a =
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            int[,] b =
            {
                { 7,  8 },
                { 9,  10 },
                { 11, 12 }
            };
            Console.WriteLine("Матрица A (2x3):");
            PrintMatrix(a);
            Console.WriteLine("\nМатрица B (3x2):");
            PrintMatrix(b);
            try
            {
                int[,] c = MultiplyMatrices(a, b);
                Console.WriteLine("\nРезультат A * B (2x2):");
                PrintMatrix(c);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}