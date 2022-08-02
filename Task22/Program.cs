using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность n=");
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintArray);
            Task task2 = task1.ContinueWith(action);

            task1.Start();
            Console.ReadKey();
        }
        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }       
        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            int sum = 0;
            int min = array[0];
            int max = array[0];
            for (int i = 0; i < array.Count(); i++)
            {

                if (array[i] < min)
                    min = array[i];
                if (array[i] > max)
                    max = array[i];
                Console.Write($"{array[i]} ");
                sum += array[i];
            }
            Console.WriteLine();
            Console.WriteLine("Сумма ="+ sum);
            Console.WriteLine("Максимум =" + max);
            Console.WriteLine("Минимум =" + min);
        }
    }
}
