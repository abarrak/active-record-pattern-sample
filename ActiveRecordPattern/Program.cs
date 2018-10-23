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
            Console.WriteLine("Reading ..");
            Console.WriteLine(Customer.Find(1));
            Console.WriteLine(Customer.Find(2));
            Console.WriteLine(Customer.Find(3));
            Console.WriteLine(Customer.Find(4));

            // Saving ..
            Console.WriteLine("Adding ..");

            var customer = new Customer("Ali", 50, 40.5);
            Console.WriteLine(customer.Save());

            customer = Customer.Last();
            Console.WriteLine(customer);

            customer.Name = "Khalid";
            customer.Save();
            Console.WriteLine(Customer.Last());

            // Deleting
            Console.WriteLine("Deleting ..");
            Console.WriteLine(customer.Delete());

            Console.WriteLine("============================");
            Console.ReadKey();
        }
    }
}
