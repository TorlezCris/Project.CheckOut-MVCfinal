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
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {

        }

        public Category GetCategoryCustomized(int CategoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Category>("select CategoryId, CategoryName, State " +
                    "from Category " +
                    "where CategoryId = @CategoryId ", new { CategoryId }).FirstOrDefault();
            }
        }
    }
}