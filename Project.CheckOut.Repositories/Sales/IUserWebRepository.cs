using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CheckOut.Repositories.Sales
{
    public interface IUserWebRepository
    {
        UserWeb ValidateUser(string email, string password);
        UserWeb CreateUser(UserWeb user);
        int GetUserCustomized(string email);
    }
}
