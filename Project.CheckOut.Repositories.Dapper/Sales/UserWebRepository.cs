using Dapper;
using Project.CheckOut.Models;
using Project.CheckOut.Repositories.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Repositories.Dapper.Sales
{
    class UserWebRepository : Repository<UserWeb>, IUserWebRepository
    {
        public UserWebRepository(string connectionString) : base(connectionString)
        {
        }

        public UserWeb ValidateUser(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return connection.QueryFirstOrDefault<UserWeb>("dbo.uspValidateUserWeb",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public UserWeb CreateUser(UserWeb user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", user.Email);
                parameters.Add("@password", user.Password);
                parameters.Add("@name", user.Name);
                parameters.Add("@lastName", user.LastName);

                return connection.QueryFirstOrDefault<UserWeb>("dbo.uspCreateUserWeb",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int GetUserCustomized(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>("select UserID " +
                    "from UserWeb " +
                    "where Email = @email ", new { email }).FirstOrDefault();
            }

        }
    }
}