using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OrderData;

namespace OrderDataService
{
    public class OrderDataService
    {
        public List<Order> dummyOrders = new List<Order> ();

        public OrderDataService () {
            Order order1 = new Order
            {
                OrderId = 1,
                CustomerName = "Maria Santos",
                ProductName = "Rice",
                Quantity = 5,
                Status = "Pending"
            };

            Order order2 = new Order
            {
                OrderId = 2,
                CustomerName = "Juan Dela Cruz",
                ProductName = "Canned Tuna",
                Quantity = 10,
                Status = "Processing"
            };

            Order order3 = new Order
            {
                OrderId = 3,
                CustomerName = "Ana Reyes",
                ProductName = "Cooking Oil",
                Quantity = 2,
                Status = "Completed"
            };

            dummyOrders.Add(order1);
            dummyOrders.Add(order2);
            dummyOrders.Add(order3);
        }

        public void Add(Order order)
        {
            dummyOrders.Add(order);
        }

        public Order? GetById(int id)
        {
            return dummyOrders.FirstOrDefault(o => o.OrderId == id);
        }

        public List<Order> GetOrders()
        {
            return dummyOrders;
        }

        public void Update(Order order)
        {
            var existing = GetById(order.OrderId);

            if (existing != null)
            {
                existing.CustomerName = order.CustomerName;
                existing.ProductName = order.ProductName;
                existing.Quantity = order.Quantity;
                existing.Status = order.Status;
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);

            if (order != null)
            {
                dummyOrders.Remove(order);
            }
        }
    }
}