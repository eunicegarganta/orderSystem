using OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderDataService
{
    public class OrderDataJSON : OrderDataServiceFramework
    {
        public List<Order> dummyOrders = new List<Order>();
        private string _jsonFileName;
        public OrderDataJSON()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Order.json";

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

            this.Add(order1);
            this.Add(order2);
            this.Add(order3);
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.Create(_jsonFileName)) //File.OpenWrite
            {
                JsonSerializer.Serialize<List<Order>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , dummyOrders);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.dummyOrders = JsonSerializer.Deserialize<List<Order>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void Add(Order order)
        {
            dummyOrders.Add(order);
            this.SaveDataToJsonFile();
        }

        public Order? GetById(int id)
        {
            this.RetrieveDataFromJsonFile();
            return dummyOrders.FirstOrDefault(o => o.OrderId == id);
        }

        public List<Order> GetOrders()
        {
            this.RetrieveDataFromJsonFile();
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
                this.SaveDataToJsonFile();
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);

            if (order != null)
            {
                dummyOrders.Remove(order);
                this.SaveDataToJsonFile();
            } 
}
    }
}
