using System;
using System.Linq;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Enter the numbers (input pattern: 1,2,3,4, ... ,n)");
                        var numbers = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), Int32.Parse);
                        if (numbers.Length == 0)
                            throw new Exception("Please input some numbers!");

                        Console.WriteLine($"The arifmetic mean will be: { numbers.Average() }");
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Input pattern: 1,2,3,4, ... ,n");
                    Console.WriteLine();
                }
            }
        }
    }
}
