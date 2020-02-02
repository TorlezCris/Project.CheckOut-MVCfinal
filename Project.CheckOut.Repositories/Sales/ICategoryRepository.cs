using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CheckOut.Repositories.Sales
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryCustomized(int CategoryId);
    }
}
