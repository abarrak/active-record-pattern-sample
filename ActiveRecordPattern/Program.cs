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

            // Saving ..
            Console.WriteLine(Customer.Find(1));

            // Deleting
            // Console.WriteLine(Customer.Find(1));

            Console.WriteLine("============================");
            Console.ReadKey();
        }
    }
}
