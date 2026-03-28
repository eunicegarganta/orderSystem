using OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataService
{
    public interface OrderDataServiceFramework
    {
        public void Add(Order order);

        public Order? GetById(int id);

        public List<Order> GetOrders();

        public void Update(Order order);

        public void Delete(int id);
    }
}
