//using System.Threading.Channels;
//using System.Xml.Serialization;
using System;
using OrderManagerServices;
using OrderData;//add

namespace OrderManager
{
    internal class Program
    {
        public static OrderManagerService manager = new OrderManagerService();
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
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0) //add
            {
                Console.WriteLine("Invalid Quantity."); //add
                return;//add
            }

            manager.CreateOrder(customerName, productName, quantity);
            Console.WriteLine("Order created.");
        }

        static void ViewOrders()
        {
            var orders = manager.GetOrders();
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }
            foreach (var o in orders)
            {
                Console.WriteLine($"Order ID: {o.OrderId} | Customer: {o.CustomerName} | Item: {o.ProductName} | Qty: {o.Quantity} | Status: {o.Status}");
            }
        }

        static void UpdateOrder()
        {
            Console.Write("\nEnter Order ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("New Item Name: ");
            string productName = Console.ReadLine();//add

            Console.Write("New Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0");
                return;
            }
            manager.UpdateOrder(orderId, productName, quantity);
            Console.WriteLine("Order updated successfully.");
        }
        static void DeleteOrder()
        {
            Console.Write("\nEnter Order ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            manager.DeleteOrder(orderId);
            Console.WriteLine("Order deleted successfully.");
            return;
        }
        static void UpdateOrderStatus()
        {
            Console.Write("\nEnter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            Console.WriteLine("\nSelect Status:");
            Console.WriteLine("1 Pending");
            Console.WriteLine("2 Processing");
            Console.WriteLine("3 Completed");
            Console.WriteLine("4 Cancelled");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            string status;

            switch (choice)
            {
                case "1":
                    status = "Pending";
                    break;
                case "2":
                    status = "Processing";
                    break;
                case "3":
                    status = "Completed";
                    break;
                case "4":
                    status = "Cancelled";
                    break;
                default:
                    status = null;
                    break;
            }

            if (status == null)
            {
                Console.WriteLine("Invalid Choice.");
                return;
            }
            manager.UpdateOrderStatus(orderId, status);
            Console.WriteLine("Status Updated.");
        }
    }
}