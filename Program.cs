using System.Xml.Serialization;

namespace orderFullfilment
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Order Management:\n");
            Console.WriteLine(" 1. Create Order");
            Console.WriteLine(" 2. View Order");
            Console.WriteLine(" 3. Update Order");
            Console.WriteLine(" 4. Delete Order");
            Console.WriteLine(" 5. Exit");
            Console.Write("\nEnter an Option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter Order ID:");
                string orderId = Console.ReadLine();
                Console.Write("Enter Customer Name:");
                string customerName = Console.ReadLine();
                Console.Write("Enter Product Name:");
                string productName = Console.ReadLine();
                Console.Write("Enter Quantity:");
                int quantity = int.Parse(Console.ReadLine());


            }

        }
    }
}
