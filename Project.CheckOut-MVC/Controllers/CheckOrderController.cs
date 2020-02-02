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
    //public class Order1Controller : Controller
    //{
    //    protected readonly IUnitOfWork _unit;

    //    public Order1Controller(IUnitOfWork unit)
    //    {
    //        _unit = unit;
    //    }

    //    // GET: Order
    //    public ActionResult Index()
    //    {
    //        //Recuperar userId
    //        int userId = 1;
    //        return View(_unit.Order.GetOrdersCustomized(userId));
    //    }

    //    // GET: Order/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: Order/Create
    //    public ActionResult Create(string OrderNumber)
    //    {
    //        return View(new Order { OrderNumber = OrderNumber });
    //    }

    //    // POST: Order/Create
    //    [HttpPost]
    //    public ActionResult Create(TotalCart detail)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                return RedirectToAction("Index");
    //            }

    //            var response = _unit.Order.CreateCustomized();
    //            if (response.Item2 == 0 && string.IsNullOrEmpty(response.Item1))
    //                return RedirectToAction("Index");

    //            //var productList = JsonConvert.SerializeObject(new List<int> { productId, productId });
    //            var productsList = JsonConvert.SerializeObject(detail.Cart);

    //            var responseOrderDetail = _unit.OrderDetail.CreateCustomized(response.Item2, productsList, detail.TotalAmount);
    //            return RedirectToAction("Create", new { OrderNumber = response.Item1 });
    //        }
    //        catch (Exception ex)
    //        {
    //            return View(ex);
    //        }
    //    }
    //}
}
