using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.CheckOut_MVC.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public HomeController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: Home
        public ActionResult Index(string UserId, string cartData)
        {
            var myCart = new TotalCart();
            var ItemsCart = new List<CartDetail>();
            ItemsCart.Add(new CartDetail { Image = "/Content/Images/fff.png",
                                           IsAvailable = true,
                                           Price = 124.90M,
                                           ProductId = 1,
                                           ProductName = "Televisor",
                                           Quantity = 1
            });

            ItemsCart.Add(new CartDetail { Image = "/Content/Images/fff.png",
                                           IsAvailable = true,
                                           Price = 33.90M,
                                           ProductId = 2,
                                           ProductName = "Radio",
                                           Quantity = 1
            });

            ItemsCart.Add(new CartDetail { Image = "/Content/Images/fff.png",
                                           IsAvailable = true,
                                           Price = 70.00M,
                                           ProductId = 3,
                                           ProductName = "Monitor",
                                           Quantity = 2
            });

            myCart.Cart = ItemsCart;
            myCart.TotalAmount = 228.80M;
            return View(myCart);
        }
    }
}
