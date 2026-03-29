using OrderDataService;
using OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerServices
{
    public class OrderManagerService
    {
        public OrderDataServices dataService = new OrderDataServices(new OrderDBData());
        //public OrderDataServices dataService = new OrderDataServices(new OrderDataJSON());//del

        //doesn't need
        //public OrderManagerService()
        //{
        //    OrderDBData orderDBData = new OrderDBData();//add
        //}
            
            public List<Order> GetOrders()
            {
                return dataService.GetOrders();
            }

            public void CreateOrder(string customerName, string productName, int quantity)
            {
                var orders = dataService.GetOrders();

                int newId = orders.Count > 0
                ? orders.Max(o => o.OrderId) + 1
                : 1;

                Order newOrder = new Order(newId, customerName, productName, quantity, "Pending");
                dataService.Add(newOrder);
            }

            public void UpdateOrder(int orderId, string productName, int quantity)
            {
                var order = dataService.GetById(orderId);

                if (order != null)
                {
                    order.ProductName = productName;
                    order.Quantity = quantity;
                    dataService.Update(order);
                }
            }

            public void DeleteOrder(int orderId)
            {
                dataService.Delete(orderId);
            }

            public void UpdateOrderStatus(int orderId, string status)
            {
                var order = dataService.GetById(orderId);

                if (order != null)
                {
                    order.Status = status;
                    dataService.Update(order);
                }
            }


        }
    }
  