using OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataService
{
    public class OrderDataServices
    {
        OrderDataServiceFramework framework;

        public OrderDataServices(OrderDataServiceFramework framework)
        {
            this.framework = framework;
        }
        public void Add(Order order)
        {
            framework.Add(order);
        }

        public Order? GetById(int id)
        {
            return framework.GetById(id);
        }

        public List<Order> GetOrders()
        {
            return framework.GetOrders();
        }

        public void Update(Order order)
        {
            framework.Update(order);
        }

        public void Delete(int id)
        {
            framework.Delete(id);
        }
    }
}
