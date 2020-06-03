using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Models;
using OnlineShop.Models.Repositories;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IProductTypesRepository productTypesRepository;
        private readonly ISpecialTagsRepository specialTagsRepository;

        public ProductController(IProductRepository _productRepository,IWebHostEnvironment _HostEnvironment,IProductTypesRepository _productTypesRepository,ISpecialTagsRepository _specialTagsRepository)
        {
            productRepository = _productRepository;
            hostEnvironment = _HostEnvironment;
            productTypesRepository = _productTypesRepository;
            specialTagsRepository = _specialTagsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(productRepository.List());
        }
        [HttpPost]
        public IActionResult Index(decimal lowAmmount,decimal largAmmount)
        {
            if(lowAmmount == 0 || largAmmount == 0)
            {
                var productZero = productRepository.List(); 
                return View(productZero);
            }
            var product = productRepository.List().Where(c => c.Price >= lowAmmount && c.Price <= largAmmount).ToList();
            return View(product);
        }


        [HttpGet]
        public IActionResult Create()
        {
            SelectList productTypes = new SelectList(productTypesRepository.List(),"Id", "ProductType");
            ViewBag.productTypesList = productTypes;

            SelectList specialTags = new SelectList(specialTagsRepository.List(), "Id", "SpecialTag");
            ViewBag.specialTagsList = specialTags;


            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product,IFormFile Image)
        {
            if (ModelState.IsValid)
            {

                var searchByname = productRepository.SearchByName(product);
                if(searchByname != null)
                {
                    SelectList productTypes = new SelectList(productTypesRepository.List(), "Id", "ProductType");
                    ViewBag.productTypesList = productTypes;

                    SelectList specialTags = new SelectList(specialTagsRepository.List(), "Id", "SpecialTag");
                    ViewBag.specialTagsList = specialTags;
                    ViewBag.message = "This Product is Alredy Exist !!";
                    return View(product);
                }


                if (Image != null)
                {
                    var imgName = MyUploadFiels(Image);
                    product.Image = "~/Uploads/" + imgName;

                }
                else
                {
                   product.Image = "~/Images/noimage.PNG";
                    productRepository.Add(product);
                    TempData["save"] = "Product has been Saved";
                    return RedirectToAction("Index");
                }

                
                productRepository.Add(product);
                TempData["save"] = "Product has been Saved";
                return RedirectToAction("Index");

            }
            return View(product);
        }

        public string MyUploadFiels(IFormFile Image)
        {
            
            string folderPath = Path.Combine(hostEnvironment.WebRootPath, "Uploads");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            string fullPath = Path.Combine(folderPath, fileName);
            using (var filestream = new FileStream(fullPath, FileMode.Create))
            {
                Image.CopyTo(filestream);
            }
            return fileName;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SelectList productTypes = new SelectList(productTypesRepository.List(), "Id", "ProductType");
            ViewBag.productTypesList = productTypes;

            SelectList specialTags = new SelectList(specialTagsRepository.List(), "Id", "SpecialTag");
            ViewBag.specialTagsList = specialTags;
            return View(productRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var imgName = MyUploadFiels(Image);
                    product.Image = "~/Uploads/" + imgName;

                }
                else
                {
                    product.Image = "~/Images/noimage.PNG";
                    productRepository.Update(product);
                    TempData["save"] = "Product has been Updated";
                    return RedirectToAction("Index");
                }


                productRepository.Update(product);
                TempData["save"] = "Product has been Updated";
                return RedirectToAction("Index");

            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(productRepository.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(productRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Product product,string Imgpath)
        {
            string idPath = product.Image.ToString();
            Imgpath = Path.Combine(hostEnvironment.WebRootPath,idPath);
            FileInfo fi = new FileInfo(Imgpath);
            if(fi != null)
            {
                System.IO.File.Delete(Imgpath);
                fi.Delete();
            }


            productRepository.Delete(product);
            TempData["del"] = "Product has been Removed";
            return RedirectToAction("Index");
        }
    }
}
