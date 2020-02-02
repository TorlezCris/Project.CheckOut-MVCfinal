using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut_MVC.Model
{
    public class DetailCart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Discount { get; set; }
    }

    public class TotalDetailCart
    {
        public List<DetailCart> Cart { get; set; }
        public decimal TotalAmount { get; set; }
    }
}