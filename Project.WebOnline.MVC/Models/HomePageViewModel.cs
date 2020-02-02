using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.WebOnline.MVC.Models
{
    public class HomePageViewModel
    {
        public List<ProductViewModel> productsView { get; set; }
        public List<CategoryViewModel> categoriesView { get; set; }
        public List<SliderViewModel> sliderView { get; set; }
    }

    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public bool state { get; set; }

        //ProductDetail
        public int ProductDetailID { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        [RegularExpression("([1-5]+)", ErrorMessage ="Por favor, ingrese una cantidad correcta")]
        public int Quantity { get; set; }
        public string Image { get; set; }
    }

    //public class totalCart
    //{
    //    public ProductViewModel crt
    //    public decimal TotalAmount { get; set; }
    //    public PaymentData PaymentData { get; set; }
    //    public string OrderNumber { get; set; }
    //}

    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class SliderViewModel
    {
        public int ProductId { get; set; }  
        public string Image { get; set; }
    }

}