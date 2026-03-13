using OrderData;
using OrderDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class OrderManager
    {
        public OrderDataService dataService = new OrderDataService();

        public List<Order> GetOrders()
        {
            return dataService.GetOrders();
        }

        public void CreateOrder(string customerName, string productName, int quantity)
        {
            int newId = dataService.GetOrders().Count + 1;

            Order newOrder = new Order(newId, customerName, productName, quantity, "Pending");

            dataService.Add(newOrder);
        }

        public void UpdateOrder(int id, string productName, int quantity)
        {
            Order? order = dataService.GetById(id);

            if (order != null)
            {
                order.ProductName = productName;
                order.Quantity = quantity;

                dataService.Update(order);
            }
        }

        public void DeleteOrder(int id)
        {
            dataService.Delete(id);
        }

        public void UpdateOrderStatus(int id, string status)
        {
            Order? order = dataService.GetById(id);

            if (order != null)
            {
                order.Status = status;
                dataService.Update(order);
            }
        }


    }
}