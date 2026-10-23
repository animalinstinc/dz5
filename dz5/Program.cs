using System;
namespace Exercise6_3
{
    class Program
    {
        static double[] GetMonthlyAverages(int[,] temperature)
        {
            int months = temperature.GetLength(0);
            int days = temperature.GetLength(1);
            double[] averages = new double[months];
            for (int i = 0; i < months; i++)
            {
                double sum = 0;
                for (int j = 0; j < days; j++)
                {
                    sum += temperature[i, j];
                }
                averages[i] = sum / days;
            }
            return averages;
        }
        static void PrintAverages(double[] averages)
        {
            for (int i = 0; i < averages.Length; i++)
            {
                Console.WriteLine($"{i + 1,2}: {averages[i],6:F2}");
            }
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] temperature = new int[12, 30];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = rnd.Next(-30, 36);
                }
            }
            double[] averages = GetMonthlyAverages(temperature);
            Console.WriteLine("Средняя температура по месяцам:");
            PrintAverages(averages);
            Array.Sort(averages);
            Console.WriteLine("\nСредние температуры по возрастанию:");
            PrintAverages(averages);
        }
    }
}