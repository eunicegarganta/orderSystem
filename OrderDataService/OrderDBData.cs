using Microsoft.Data.SqlClient;
using OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataService
{
    public class OrderDBData : OrderDataServiceFramework
    {
        private string connectionString
      = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = OrderSystem; Integrated Security = True; TrustServerCertificate=True;";

       private SqlConnection sqlConnection;

        public OrderDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            ///////////////////
            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = GetOrders();

            if (existing.Count == 0)
            {
                Add(new Order { CustomerName = "Maria Santos", ProductName = "Rice", Quantity = 5, Status = "Pending" });
                Add(new Order { CustomerName = "Juan Dela Cruz", ProductName = "Canned Tuna", Quantity = 10, Status = "Processing" });
                Add(new Order { CustomerName = "Ana Reyes", ProductName = "Cooking Oil", Quantity = 2, Status = "Completed" });
                //Add(new Order { OrderId = 1, CustomerName = "Maria Santos", ProductName = "Rice", Quantity = 5, Status = "Pending" });
                //Add(new Order { OrderId = 2, CustomerName = "Juan Dela Cruz", ProductName = "Canned Tuna", Quantity = 10, Status = "Processing" });
                //Add(new Order { OrderId = 3, CustomerName = "Ana Reyes", ProductName = "Cooking Oil", Quantity = 2, Status = "Completed" });
            }
        }

        public void Add(Order order)
        {
            //remove@OrderId
            var insertStatement = "INSERT INTO Orders VALUES (@CustomerName, @ProductName, @Quantity, @Status)";

            SqlCommand InsertCmd = new SqlCommand(insertStatement, sqlConnection);

            //InsertCmd.Parameters.AddWithValue("@OrderId", order.OrderId);
            InsertCmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
            InsertCmd.Parameters.AddWithValue("@ProductName", order.ProductName);
            InsertCmd.Parameters.AddWithValue("@Quantity", order.Quantity);
            InsertCmd.Parameters.AddWithValue("@Status", order.Status);

            sqlConnection.Open();
            InsertCmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Order> GetOrders()
        {
            string selectStatement = "SELECT OrderId, CustomerName, ProductName, Quantity, Status FROM Orders";

            SqlCommand Selectcmd = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = Selectcmd.ExecuteReader();

            var orders = new List<Order>();

            while (reader.Read())
            {
                Order order = new Order();

                order.OrderId = Convert.ToInt32(reader["OrderId"]);
                order.CustomerName = reader["CustomerName"].ToString();
                order.ProductName = reader["ProductName"].ToString();
                order.Quantity = Convert.ToInt32(reader["Quantity"]);
                order.Status = reader["Status"].ToString();

                orders.Add(order);
            }

            sqlConnection.Close();
            return orders;
        }

        public Order? GetById(int id)
        {
            var selectStatement = "SELECT * FROM Orders WHERE OrderId = @OrderId";

            SqlCommand Getcmd = new SqlCommand(selectStatement, sqlConnection);
            Getcmd.Parameters.AddWithValue("@OrderId", id);

            sqlConnection.Open();
            SqlDataReader reader = Getcmd.ExecuteReader();

            Order order = null;

            while (reader.Read())
            {
                order = new Order
                {
                    OrderId = Convert.ToInt32(reader["OrderId"]),
                    CustomerName = reader["CustomerName"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Status = reader["Status"].ToString()
                };
            }

            sqlConnection.Close();
            return order;
        }

        public void Update(Order order)
        {
            var updateStatement = @"UPDATE Orders SET CustomerName=@CustomerName, ProductName=@ProductName, Quantity=@Quantity, Status=@Status WHERE OrderId=@OrderId";

            SqlCommand Updatecmd = new SqlCommand(updateStatement, sqlConnection);

            Updatecmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
            Updatecmd.Parameters.AddWithValue("@ProductName", order.ProductName);
            Updatecmd.Parameters.AddWithValue("@Quantity", order.Quantity);
            Updatecmd.Parameters.AddWithValue("@Status", order.Status);
            Updatecmd.Parameters.AddWithValue("@OrderId", order.OrderId);

            sqlConnection.Open();
            Updatecmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(int id)
        {
            var deleteStatement = "DELETE FROM Orders WHERE OrderId=@OrderId";

            SqlCommand Deletecmd = new SqlCommand(deleteStatement, sqlConnection);
            Deletecmd.Parameters.AddWithValue("@OrderId", id);

            sqlConnection.Open();
            Deletecmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
    }
