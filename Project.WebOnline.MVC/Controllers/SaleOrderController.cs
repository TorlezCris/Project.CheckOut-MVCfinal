using Newtonsoft.Json;
using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using Project.CheckOut_MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Project.WebOnline.Controllers
{
    public class SaleOrderController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public SaleOrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: Order
        public ActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("userdata")).Value;

            return View(_unit.Order.GetOrdersCustomized(int.Parse(userId)));
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create(string OrderNumber)
        {
            return View(new Order { OrderNumber = OrderNumber });
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(TotalCart detail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                var identity = (ClaimsIdentity)User.Identity;
                var userEmail = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("emailaddress")).Value;
                var authenticationClaim = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("authentication"));
                int userId = _unit.UserWeb.GetUserCustomized(userEmail);

                var response = _unit.Order.CreateCustomized(userId);
                if (response.Item2 == 0 && string.IsNullOrEmpty(response.Item1))
                    return RedirectToAction("Index");

                //var productList = JsonConvert.SerializeObject(new List<int> { productId, productId });
                var productsList = JsonConvert.SerializeObject(detail.Cart);
                var responseOrderDetail = _unit.OrderDetail.CreateCustomized(response.Item2, productsList, detail.TotalAmount);

                _unit.Cart.DeleteCartCustomized(userEmail);
                return RedirectToAction("Create", new { OrderNumber = response.Item1 });
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //OrderDetail
        public PartialViewResult OrderDetail(int OrderId, string OrderNumber)
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
