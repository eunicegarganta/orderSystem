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
            Console.WriteLine("GROCERY FULFILLMENT SYSTEM");
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

                    case "2":
                        ViewOrders();
                        break;

                    case "3":
                        UpdateOrder();
                        break;

                    case "4":
                        DeleteOrder();
                        break;

                    case "5":
                        UpdateOrderStatus();
                        break;

                    case "6":
                        ordersys = false;
                        Console.WriteLine("System exited.");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;

                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine(" \n---MAIN MENU---");
            Console.WriteLine(" 1. Create Order");
            Console.WriteLine(" 2. View Order");
            Console.WriteLine(" 3. Update Order");
            Console.WriteLine(" 4. Delete Order");
            Console.WriteLine(" 5. Update Order Status");
            Console.WriteLine(" 6. Exit");
            Console.Write("\nEnter an Option: ");
        }

        static void CreateOrder()
        {
            Console.WriteLine(" ---CREATE MENU---");
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return;
            }

            orderId.Add(newOrder);
            cusNm.Add(customerName);
            prodNm.Add(productName);
            qnty.Add(quantity);
            ordrStt.Add("Pending");

            Console.WriteLine($"Order {newOrder} created successfully.");
            newOrder++;

        }

        static void ViewOrders()
        {
            Console.WriteLine("\n--- ORDER LIST ---");

            if (orderId.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            for (int i = 0; i < orderId.Count; i++)
            {
                Console.WriteLine(
                    $"Order ID: {orderId[i]} | Customer: {cusNm[i]} | Item: {prodNm[i]} | Qty: {qnty[i]} | Status: {ordrStt[i]}");
            }
        }

        static void UpdateOrder()
        {
            Console.Write("\nEnter Order ID to update: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < orderId.Count; i++)
            {
                if (orderId[i] == id)
                {
                    Console.Write("New Item Name: ");
                    prodNm[i] = Console.ReadLine();

                    Console.Write("New Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    if (quantity <= 0)
                    {
                        Console.WriteLine("Quantity must be greater than 0.");
                        return;
                    }

                    Console.WriteLine("Order updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Order not found.");
        }
        static void DeleteOrder()
        {
            Console.Write("\nEnter Order ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < orderId.Count; i++)
            {
                if (orderId[i] == id)
                {
                    orderId.RemoveAt(i);
                    cusNm.RemoveAt(i);
                    prodNm.RemoveAt(i);
                    qnty.RemoveAt(i);
                    ordrStt.RemoveAt(i);

                    Console.WriteLine("Order deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Order not found.");
        }
        static void UpdateOrderStatus()
        {
            Console.Write("\nEnter Order ID: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < orderId.Count; i++)
            {
                if (orderId[i] == id)
                {
                    Console.WriteLine("Select Status:");
                    Console.WriteLine("1 Pending");
                    Console.WriteLine("2 Processing");
                    Console.WriteLine("3 Completed");
                    Console.WriteLine("4 Cancelled");
                    Console.Write("Choice: ");

                    string statusChoice = Console.ReadLine();

                    if (statusChoice == "1") ordrStt[i] = "Pending";
                    else if (statusChoice == "2") ordrStt[i] = "Processing";
                    else if (statusChoice == "3") ordrStt[i] = "Completed";
                    else if (statusChoice == "4") ordrStt[i] = "Cancelled";
                    else
                    {
                        Console.WriteLine("Invalid status.");
                        return;
                    }

                    Console.WriteLine("Order status updated.");
                    return;
                }
            }

            Console.WriteLine("Order not found.");
        }

    }
}
