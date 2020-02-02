using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CheckOut.Repositories.Sales
{
    public interface ICartRepository : IRepository<Cart>
    {
        bool InsertCartCustomized(string ProductData, string userEmail);
        string GetCartCustomized(string userEmail);
        bool UpdateCartCustomized(string userEmail, string newProductList);
        bool DeleteCartCustomized(string userEmail);
    }
}
