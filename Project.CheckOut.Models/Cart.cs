using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class CartDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Discount { get; set; }
        public string Image { get; set; }
    } 

    public class TotalCart
    {
        public List<CartDetail> Cart { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentData PaymentData { get; set; }
        public string OrderNumber { get; set; }
    }

    public class PaymentData
    {
        public string TitularName { get; set; }
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CVV { get; set; }
    }

    public class Cart
    {
        public int id { get; set; }
        public int CartId { get; set; }
        public string ProductData { get; set; }
    }
}