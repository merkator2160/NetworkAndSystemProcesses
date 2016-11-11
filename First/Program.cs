using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the diameter ...");
                    var radius = Double.Parse(Console.ReadLine()) / 2;
                    Console.WriteLine($"Length of circumference: { 2 * Math.PI * radius }");
                    Console.WriteLine($"Area: { Math.PI * Math.Pow(radius, 2) }");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Example of correct format is: 8,25");
                    Console.WriteLine();
                }
            }
        }
    }
}
