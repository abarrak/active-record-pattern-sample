using System;

namespace ActiveRecordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Active Record Pattern Sample");
            Console.WriteLine("============================");

            // Reading ..
            Console.WriteLine(Customer.Find(1));
            Console.WriteLine(Customer.Find(2));
            Console.WriteLine(Customer.Find(3));

            // Saving ..

            // Deleting

            Console.WriteLine("============================");
            Console.ReadKey();
        }
    }
}
