using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut_MVC.Model
{
    public class FieldsByOrderModel
    {
        public int IdOfProduct { get; set; }
        public int QuantityByItem { get; set; }
        public decimal PriceByItem { get; set; }
        public string ProductName { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Discount { get; set; }
    }
}