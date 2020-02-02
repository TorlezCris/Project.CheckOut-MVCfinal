using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class ProductDetail
    {
        public int ProductDetailID { get; set; }
        public int ProductID { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public int StockMin { get; set; }
        public int StockNow { get; set; }
        public string Image { get; set; }
    }
}