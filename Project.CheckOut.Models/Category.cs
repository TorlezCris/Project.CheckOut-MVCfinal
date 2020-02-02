using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool State { get; set; }
    }
}