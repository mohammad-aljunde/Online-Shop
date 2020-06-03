using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Repositories;
using OnlineShop.Utility;

namespace OnlineShop.Areas.Customer.Controllers
{
   
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public IActionResult Index()
        {
            return View(productRepository.List());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(productRepository.FindById(id));
        }

        // Add To Cart Method
        [HttpPost]
        [ActionName("Details")]
        public IActionResult ProductDetails(int id)
        {
            List<Product> products = new List<Product>();

            var product = productRepository.FindById(id);

            products = HttpContext.Session.Get<List<Product>>("products"); // Ask about this step
            if (products == null)
            {
                products = new List<Product>();
            }

            products.Add(product);
            HttpContext.Session.Set("products", products);
            return View(product);
        }
        // Remove from Cart Method
        [HttpGet]
        public IActionResult RemoveFromCart(int id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }

            }


            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Remove(int id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if(products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if(product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
                
            }

           
            return RedirectToAction("Index");
        }
        // View Cart Get Method
        [HttpGet]
        public IActionResult Cart()
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if(products == null)
            {
                products = new List<Product>();
            }
            return View(products);
        }


    }
}
