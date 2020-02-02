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
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {

        }

        public Product GetProductCustomized(int ProductId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Product>("select ProductId, CategoryId, ProductNumber, Name, CreatedDate, State, IsHomeSlider " +
                    "from Product " +
                    "where ProductId = @ProductId " +
                    "and state = 1 ", new { ProductId }).FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(int CategoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Product>("select ProductId, CategoryId, ProductNumber, Name, CreatedDate, State, IsHomeSlider " +
                    "from Product " +
                    "where CategoryId = @CategoryId " +
                    "and state = 1 ", new { CategoryId }).ToList();
            }
        }
    }
}