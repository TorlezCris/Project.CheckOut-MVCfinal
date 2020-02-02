using Newtonsoft.Json;
using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Project.WebOnline.Controllers
{
    public class CheckOutController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public CheckOutController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: Home
        public ActionResult Index()
        {
            var productInCart = new TotalCart();
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("emailaddress")).Value;
            var authenticationClaim = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("authentication"));
            var cart = _unit.Cart.GetCartCustomized(userId);

            if(!string.IsNullOrEmpty(cart))
                productInCart = JsonConvert.DeserializeObject<TotalCart>(cart);

            var myCart = new TotalCart();
            var ItemsCart = new List<CartDetail>();
            
            return View(productInCart);
        }
    }
}
