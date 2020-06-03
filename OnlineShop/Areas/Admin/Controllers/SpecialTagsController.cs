using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Repositories;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private readonly ISpecialTagsRepository specialTagsRepository;

        public SpecialTagsController(ISpecialTagsRepository _specialTagsRepository)
        {
            specialTagsRepository = _specialTagsRepository;
        }
        public IActionResult Index()
        {
            return View(specialTagsRepository.List());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                specialTagsRepository.Add(specialTags);
                TempData["save"] = "Tag has been Saved";
                return RedirectToAction("Index", "SpecialTags");
            }
            return View(specialTags);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(specialTagsRepository.FindById(id));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(specialTagsRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                specialTagsRepository.Update(specialTags);
                TempData["update"] = "Tag has been Updated";
                return RedirectToAction("Index", "SpecialTags");
            }
            return View(specialTags);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(specialTagsRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(SpecialTags specialTags)
        {
            specialTagsRepository.Delete(specialTags);
            TempData["del"] = "Tag has been Removed";
            return RedirectToAction("Index", "SpecialTags");
        }
    }
}
