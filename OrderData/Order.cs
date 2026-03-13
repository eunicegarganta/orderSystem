using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set;  }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public Order() { }
        public Order(int orderId, string customerName, string productName, int quantity, string status)
        {
            OrderId = orderId;
            CustomerName = customerName;
            ProductName = productName;
            Quantity = quantity;
            Status = status;
        }
    }
}
