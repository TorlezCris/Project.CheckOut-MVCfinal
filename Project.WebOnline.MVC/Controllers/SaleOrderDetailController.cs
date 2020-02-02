using Newtonsoft.Json;
using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebOnline.Controllers
{
    public class SaleOrderDetailController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public SaleOrderDetailController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: OrderDetail
        //public ActionResult Index(int OrderId, string OrderNumber)
        //{
        //    var orderDetail = _unit.OrderDetail.GetOrderDetailCustomized(OrderId);
        //    var fields = JsonConvert.DeserializeObject<List<CartDetail>>(orderDetail.Products);

        //    var totalCart = new TotalCart
        //    {
        //        OrderNumber = OrderNumber,
        //        TotalAmount = orderDetail.TotalPay
        //    };

        //    totalCart.Cart = fields;

        //    return View(totalCart);
        //}

        public PartialViewResult Index(int OrderId, string OrderNumber)
        {
            var orderDetail = _unit.OrderDetail.GetOrderDetailCustomized(OrderId);
            var fields = JsonConvert.DeserializeObject<List<CartDetail>>(orderDetail.Products);

            var totalCart = new TotalCart
            {
                OrderNumber = OrderNumber,
                TotalAmount = orderDetail.TotalPay
            };

            totalCart.Cart = fields;

            return PartialView("_Index", totalCart);
        }
    }
}