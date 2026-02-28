using System.Xml.Serialization;

namespace orderFullfilment
{
    internal class Program
    {

        static List<int> orderId = new List<int>();
        static List<string> cusNm = new List<string>();
        static List<string> prodNm = new List<string>();
        static List<int> qnty = new List<int>();
        static List<string> ordrStt = new List<string>();

        static int newOrder = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("CONSOLE FULFILLMENT SYSTEM");
            bool ordersys = true;
            while (ordersys)
            {
                ShowMainMenu();
                string choices = Console.ReadLine();

                switch (choices)
                {
                    case "1":
                        CreateOrder();
                        break;
                    
                }
            }

            static void ShowMainMenu()
            {
                Console.WriteLine(" 1. Create Order");
                Console.WriteLine(" 2. View Order");
                Console.WriteLine(" 3. Update Order");
                Console.WriteLine(" 4. Delete Order");
                Console.WriteLine(" 5. Exit");
                Console.Write("\nEnter an Option: ");
            }

            static void CreateOrder()
            {
                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                orderId.Add(newOrder);
                cusNm.Add(customerName);
                prodNm.Add(productName);
                qnty.Add(quantity);
                ordrStt.Add("Pending");

                Console.WriteLine("Order successfully.");
                newOrder++;


            }

        }
    }
}
