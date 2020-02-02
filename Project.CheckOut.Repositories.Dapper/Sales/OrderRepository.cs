using Dapper;
using Project.CheckOut.Models;
using Project.CheckOut.Repositories.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Repositories.Dapper.Sales
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }

        public Tuple<string, int> CreateCustomized(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var response = NumberOrder(DateTime.UtcNow, connection);
                string numberOfOrder = response.Item1;
                var order = new Order {
                    OrderNumber = numberOfOrder,
                    UserID = userId,
                    CreatedDate = DateTime.UtcNow,
                    Status = "Nuevo"
                }; 
                var result = connection.Execute("insert into [Order](OrderNumber, UserId, CreatedDate, ConfirmDate, ShippedDate, Status)" +
                                        " VALUES(@OrderNumber, "+
                                        "@UserID, " +
                                        "@CreatedDate, " +
                                        "@ConfirmDate, " +
                                        "@ShippedDate, " +
                                        "@Status)",
                                        new
                                        {
                                            order.OrderNumber,
                                            order.UserID,
                                            order.CreatedDate,
                                            order.ConfirmDate,
                                            order.ShippedDate,
                                            order.Status
                                        });
                
                if (result == 0)
                    return new Tuple<string, int>("", 0);

                return new Tuple<string, int>(response.Item1, response.Item2);
            }
        }


        Tuple<string, int> NumberOrder(DateTime Date, SqlConnection connection)
        {
            int orderId = connection.Query<int>("select Max(OrderID) " +
                    "from [Order] ").FirstOrDefault();

            string number = (orderId+1).ToString("D3");
            string orderNumber = Date.Day.ToString() + Date.Month.ToString() + Date.Year.ToString() + number;

            return new Tuple<string, int>(orderNumber, orderId+1);
        }

        public List<Order> GetOrdersCustomized(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Order>("select UserID, OrderID, OrderNumber, CreatedDate, ConfirmDate, ShippedDate, Status " +
                    "from [Order] " +
                    "where UserId = @userId ", new { userId } ).ToList();
            }
        }
    }
}