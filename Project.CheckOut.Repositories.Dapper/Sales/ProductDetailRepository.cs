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
    class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(string connectionString) : base(connectionString)
        {

        }

        public ProductDetail GetProductDetailCustomized(int ProductId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<ProductDetail>("select ProductDetailID, ProductID, Color, Description, Price, PriceMin, PriceMax, StockMin, StockNow, Image " +
                    "from ProductDetail " +
                    "where ProductId = @ProductId ", new { ProductId }).FirstOrDefault();
            }
        }

        //public List<ProductDetail> GetProductsByCategory(int CategoryId)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        return connection.Query<ProductDetail>("select ProductId, CategoryId, ProductNumber, Name, CreatedDate, State, IsHomeSlider " +
        //            "from ProductDetail " +
        //            "where CategoryId = @CategoryId ", new { CategoryId }).ToList();
        //    }
        //}
    }
}