using System;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;

namespace Решение_задач
{
    internal class Program
    {

        static void Displaying_numbers_on_the_screen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }


        static int Calculate_factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Calculate_factorial(number - 1);
        }


        static async Task<int> Calculate_factorial_async(int number)
        {
            int factorial = await Task.Run(() => Calculate_factorial(number));
            Thread.Sleep(8000);

            return factorial;
        }


        static int Calculate_square_of_number(int number)
        {
            return (number * number);
        }

        static async Task Main()
        {
            bool isTaskEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("Меню упражнений");

                Console.WriteLine("Подсказка:\n" +
                                  "Задание №1.                           -   цифра 1\n" +
                                  "Задание №2.                           -   цифра 2\n" +
                                  "Задание №3.                           -   цифра 3\n" +
                                  "Выйти из программы                    -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Упражнение 1");

                        Thread Thread1 = new Thread(Displaying_numbers_on_the_screen);
                        Thread Thread2 = new Thread(Displaying_numbers_on_the_screen);
                        Thread Thread3 = new Thread(Displaying_numbers_on_the_screen);

                        Thread1.Start();
                        Thread2.Start();
                        Thread3.Start();

                        Thread.Sleep(100);

                        Console.Write("Нажмите на любую кнопку, чтобы выйти");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Упражнение 2");

                        int number = Convert.ToInt32(Console.ReadLine());

                        int square = Calculate_square_of_number(number);
                        Console.WriteLine($"{number}^2 = {square}");

                        int factorial = await Calculate_factorial_async(number);
                        Console.WriteLine($"{number}! = {factorial}");

                        Console.Write("Нажмите на любую кнопку, чтобы выйти");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Упражнение 3");

                        Reflection Refl_test_obj = new Reflection();

                        Type myType = Refl_test_obj.GetType();
                        MethodInfo[] methods = myType.GetMethods();

                        Console.WriteLine("Методы:");

                        foreach (MethodInfo method in methods)
                        {
                            Console.WriteLine(method.Name);
                        }

                        Console.Write("Нажмите на любую кнопку, чтобы выйти");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Вы вышли из программы");
                        isTaskEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такого задания нет");
                        break;
                }
            } while (!isTaskEnd);
        }
    }
}