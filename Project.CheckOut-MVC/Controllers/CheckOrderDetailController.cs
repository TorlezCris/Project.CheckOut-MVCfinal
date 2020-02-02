using Newtonsoft.Json;
using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using Project.CheckOut_MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.CheckOut_MVC.Controllers
{
    //public class OrderDetail1Controller : Controller
    //{
    //    protected readonly IUnitOfWork _unit;

    //    public OrderDetail1Controller(IUnitOfWork unit)
    //    {
    //        _unit = unit;
    //    }

    //    // GET: OrderDetail
    //    public ActionResult Index(int OrderId, string OrderNumber)
    //    {
    //        var orderDetail = _unit.OrderDetail.GetOrderDetailCustomized(OrderId);
    //        //var fields = (List<FieldsByOrderModel>)JsonConvert.DeserializeObject(orderDetail.Products);
    //        var fields = JsonConvert.DeserializeObject<List<DetailOfOrder>>(orderDetail.Products);

    //        var totalCart = new ListOrderDetails
    //        {
    //            OrderNumber = OrderNumber,
    //            TotalAmount = orderDetail.TotalPay
    //        };

    //        totalCart.Details = fields;

    //        //var ItemsOfView = new DetailOfOrder();
    //        //ItemsOfView.OrderNumber = OrderNumber;
    //        //ItemsOfView.TotalPay = orderDetail.TotalPay;
    //        //foreach (var field in fields)
    //        //{
    //        //    ItemsOfView.Items.Add(new Items { Discount = field.Discount,
    //        //                                      ProductName = field.ProductName,
    //        //                                      Quantity = field.QuantityByItem,
    //        //                                      UnitPrice = field.PriceByItem
    //        //    });
    //        //}

    //        return View(totalCart);
    //    }
    //}
}