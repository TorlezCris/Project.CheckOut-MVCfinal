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
    class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(string connectionString) : base(connectionString){}

        public bool InsertCartCustomized(string ProductData, string userEmail)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("insert into [dbo].[Cart]([ProductData], [UserId])" +
                                        " values(@ProductData,  "+
                                        " @userEmail )",
                                        new
                                        {
                                            ProductData,
                                            userEmail
                                        });

                return result > 0 ? true : false;
            }
        }

        public string GetCartCustomized(string userEmail)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<string>("select ProductData " +
                    "from [dbo].[Cart] " +
                    "where [UserId] = @userEmail ", new { userEmail }).FirstOrDefault();
            }
        }

        public bool UpdateCartCustomized(string userEmail, string newProductList)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("update [dbo].[Cart] " +
                                        " set ProductData = @newProductList " +
                                        " where [UserId] = @userEmail",
                                        new
                                        {
                                            newProductList,
                                            userEmail
                                        });

                return result > 0 ? true : false;
            }
        }

        public bool DeleteCartCustomized(string userEmail)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("Delete  " +
                                        " from [dbo].[Cart] " +
                                        " where [UserId] = @userEmail",
                                        new
                                        {
                                            userEmail
                                        });

                return result > 0 ? true : false;
            }
        }

    }
}