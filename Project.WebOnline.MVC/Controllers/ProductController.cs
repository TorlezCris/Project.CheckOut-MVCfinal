using Project.CheckOut.UnitOfWork;
using Project.WebOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebOnline.MVC.Controllers
{
    public class ProductController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public ProductController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public ActionResult Index(int productId)
        {
            var product = _unit.Product.GetProductCustomized(productId);
            var productDetail = _unit.ProductDetail.GetProductDetailCustomized(productId);
            var productView = new ProductViewModel {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = productDetail.Price,
                Color = productDetail.Color,
                Description = productDetail.Description,
                Image = productDetail.Image,
                state = product.state
            };

            return View(productView);
        }
    }
}