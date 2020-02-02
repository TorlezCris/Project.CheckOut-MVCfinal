using Newtonsoft.Json;
using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using Project.WebOnline.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.WebOnline.MVC.Controllers
{
    public class StoreController : Controller
    {
        protected readonly IUnitOfWork _unit;
        //protected readonly ILog _log;

        public StoreController(/*ILog log,*/ IUnitOfWork unit)
        {
            //_log = log;
            _unit = unit;
        }

        public ActionResult Index(int? categoryId)
        {
            var products = new List<Product>();
            var categories = new List<Category>();
            if(categoryId != null && categoryId > 0)
            {
                products = _unit.Product.GetProductsByCategory(categoryId.Value);
                var category = _unit.Category.GetCategoryCustomized(categoryId.Value);
                categories.Add(category);
                ViewBag.CategoryFilter = true;
            }
            else
            {
                products = _unit.Product.GetList().ToList();
                categories = _unit.Category.GetList().ToList();
                ViewBag.CategoryFilter = false;
            }
            HomePageViewModel view = new HomePageViewModel();
            List<ProductViewModel> productView = new List<ProductViewModel>();
            List<CategoryViewModel> categoryView = new List<CategoryViewModel>();
            List<SliderViewModel> sliderView = new List<SliderViewModel>();

            foreach(var product in products)
            {
                if (product.state)
                {
                    var detail = _unit.ProductDetail.GetProductDetailCustomized(product.ProductId);
                    if (detail.StockNow > 0 && product.state)
                    {
                        productView.Add(new ProductViewModel
                        {
                            ProductId = product.ProductId,
                            Name = product.Name,
                            ProductNumber = product.ProductNumber,
                            Color = detail.Color,
                            Description = detail.Description,
                            Image = detail.Image,
                            Price = detail.Price,
                            Quantity = 1,
                            state = product.state
                        });
                    }

                    if(product.IsHomeSlider && product.state)
                        sliderView.Add(new SliderViewModel {
                            ProductId = product.ProductId,
                            Image = detail.Image
                        });
                }
            }

            foreach(var category in categories)
            {
                categoryView.Add(new CategoryViewModel {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                });
            }

            view.productsView = productView;
            view.categoriesView = categoryView;
            view.sliderView = sliderView;
            return View(view);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpGet]
        //public ActionResult Buy()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    string userId = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("emailaddress")).Value;
        //    string productData = System.Web.HttpContext.Current.Session["cartData"] as string;
        //    return RedirectToAction("http://localhost:56058/Home", new { UserId = userId, cartData = productData });
        //}

        [Authorize]
        [HttpGet]
        public ActionResult Buy(ProductViewModel product)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var email = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("emailaddress"));
            var authenticationClaim = identity.Claims.FirstOrDefault(x => x.Type.ToLower().Contains("authentication"));
            var token = string.Empty;

            if (email != null && authenticationClaim != null)
            {
                token = authenticationClaim.Value;
            }
            //else
            //{
            //    var cartData = JsonConvert.SerializeObject(product);
            //    System.Web.HttpContext.Current.Session["cartData"] = cartData;
            //    return RedirectToRoute("Login");
            //}

            //Add to cart
            if(product.Quantity > 0)
            {
                if (!AddToCart(product, email.Value))
                    return Redirect("Index");
            }

            //var returnUrl = Url.Action("~/Home", new { UserId = userId });
            return Redirect("~/CheckOut");
        }

        public bool AddToCart(ProductViewModel product, string email)
        {
            List<CartDetail> cartProducts = new List<CartDetail>();
            TotalCart totalCart = new TotalCart();
            CartDetail cartProduct = new CartDetail();
            cartProduct.ProductId = product.ProductId;
            cartProduct.ProductName = product.Name;
            cartProduct.Price = product.Price;
            cartProduct.Quantity = product.Quantity;
            cartProduct.IsAvailable = product.state;
            cartProduct.Image = product.Image;

            var anyCart = _unit.Cart.GetCartCustomized(email);
            string totalCartJson = string.Empty;

            if (!string.IsNullOrEmpty(anyCart))
            {
                var productInCart = JsonConvert.DeserializeObject<TotalCart>(anyCart);
                var otherProductsInCart = productInCart.Cart;
                var itemExistInCart = productInCart.Cart.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                var cartQuantity = productInCart.Cart.Sum(x => x.Quantity);
                totalCart.TotalAmount = productInCart.Cart.Sum(x => x.Quantity * x.Price) + cartProduct.Price*cartProduct.Quantity;

                if (itemExistInCart != null)
                    otherProductsInCart = productInCart.Cart.Except(new List<CartDetail> { itemExistInCart }).ToList();

                cartProducts = otherProductsInCart;

                if ( itemExistInCart!= null )
                {
                    itemExistInCart.Quantity = itemExistInCart.Quantity + product.Quantity;
                    cartProducts.Add(itemExistInCart);
                    totalCart.Cart = cartProducts;

                    totalCartJson = JsonConvert.SerializeObject(totalCart);
                }
                else
                {
                    cartProducts.Add(cartProduct);
                    totalCart.Cart = cartProducts;
                    totalCartJson = JsonConvert.SerializeObject(totalCart);
                }
                return _unit.Cart.UpdateCartCustomized(email, totalCartJson);
            }

            cartProducts.Add(cartProduct);
            totalCart.TotalAmount = cartProduct.Price * cartProduct.Quantity;
            totalCart.Cart = cartProducts;
            totalCartJson = JsonConvert.SerializeObject(totalCart);

            return _unit.Cart.InsertCartCustomized(totalCartJson, email);
        }
    }
}