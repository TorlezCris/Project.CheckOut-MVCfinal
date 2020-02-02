using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut_MVC.Model
{
    //public class DetailOfOrder
    //{
    //    public string OrderNumber { get; set; }
    //    public decimal TotalPay { get; set; }
    //    public List<Items> Items { get; set; }
    //}

    //public class Items
    //{
    //    public string ProductName { get; set; }
    //    public decimal UnitPrice { get; set; }
    //    public int Quantity { get; set; }
    //    public decimal Discount { get; set; }
    //}

    public class DetailOfOrder
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Discount { get; set; }
        public string Image { get; set; }
    }

    public class ListOrderDetails
    {
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public List<DetailOfOrder> Details { get; set; }
    }
}