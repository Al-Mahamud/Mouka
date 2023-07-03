using Mauka.Entities;
using Mouka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mouka.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryService.Getcategories();

            return View(categories);
        }
        //create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("Index");
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = categoryService.Getcategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = categoryService.Getcategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            //category = categoryService.Getcategory(category.ID);
            categoryService.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }
    }
}