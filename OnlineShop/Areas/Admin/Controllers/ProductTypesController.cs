using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Models;
using OnlineShop.Models.Repositories;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly IProductTypesRepository productTypesRepository;

        public ProductTypesController(IProductTypesRepository _productTypesRepository)
        {
            productTypesRepository = _productTypesRepository;
        }
        public IActionResult Index()
        {
            return View(productTypesRepository.List());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                productTypesRepository.Add(productTypes);
                TempData["save"] = "Product has been Saved";
                return RedirectToAction("Index", "ProductTypes");
               
            }
            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(productTypesRepository.FindById(id));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(productTypesRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                productTypesRepository.Update(productTypes);
                TempData["update"] = "Product has been Updated";
                return RedirectToAction("Index");
            }
            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(productTypesRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(ProductTypes productTypes)
        {
            productTypesRepository.Delete(productTypes);
            TempData["del"] = "Product has been Removed";
            return RedirectToAction("Index");
        }
    }
}
