using Mauka.Entities;
using Mouka.Services;
using Mouka.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mouka.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();

        UserService userService = new UserService();


        public ActionResult Index()
        {
            
            return View();
        }
        // GET: Product
        public ActionResult ProductTable(string search)
        {
            var products = productsService.GetProducts();
            if(string .IsNullOrEmpty(search) == false)
            {
                products = products.Where(p => p.Name!=null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            

            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);

            return RedirectToAction("ProductTable");
        }

        //add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            product.postTime = DateTime.Now;
            productsService.SaveProduct(product);

            TempData["Addpost"] = true;

            return RedirectToAction("Index","Home");
        }

        //edit

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product =  productsService.GetProduct(ID);

            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsService.UpdateProduct(product);

            return RedirectToAction("ProductTable");
        }


        //delete
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsService.DeleteProduct(ID);

            return View();
        }


        //Vehicle
        [HttpGet]
        public ActionResult Vehicle(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Mobiles
        [HttpGet]
        public ActionResult Mobiles(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Electonics
        [HttpGet]
        public ActionResult Electonics(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //RealEstate
        [HttpGet]
        public ActionResult RealEstate(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Fashion
        [HttpGet]
        public ActionResult Fashion(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Furniture
        [HttpGet]
        public ActionResult Furniture(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Jobs
        [HttpGet]
        public ActionResult Jobs(int? id)
        {
            var products = productsService.GetProducts();

            UserService userService = new UserService();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Services
        [HttpGet]
        public ActionResult Services(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Pets
        [HttpGet]
        public ActionResult Pets(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Education
        [HttpGet]
        public ActionResult Education(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Matrimony
        [HttpGet]
        public ActionResult Matrimony(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Notes and Coins
        [HttpGet]
        public ActionResult NotesAndCoins(int? id)
        {
            var products = productsService.GetProducts();

            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }

            return View(products);
        }

        //Notes and Coins
        [HttpGet]
        public ActionResult SingleProduct(int id)
        {
            var product = productsService.GetProduct(id);
            var user = userService.GetUser(product.UserId);

            var userAndProduct = new UserAndProduct
            {
                Id = product.ID,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductId = product.ID,
                ProductPrice = product.Price,
                ProductTime = product.postTime,
                ProductURL = product.ImageURL,
                ProductLocation = product.City,
                UserName = user.Name,
                UserDescription = user.Description,
                UserId = user.ID,
                UserTime = user.CreateTime,
                UserURL = user.ImageURL,
                UserLocation = user.Location,
                PhoneNumber = user.PhoneNumber
            };

            return View(userAndProduct);
        }

        //Notes and Coins
        [HttpGet]
        public ActionResult MyProducts(int? id)
        {
            var products = productsService.GetProducts();
            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.UserId == id.Value).ToList();
            }
            var user= userService.GetUser(id.Value);


            var alldata = new Alldata
            {
                UserName = user.Name,
                UserDescription = user.Description,
                UserId = user.ID,
                UserTime = user.CreateTime,
                UserURL = user.ImageURL,
                UserLocation = user.City,
                PhoneNumber = user.PhoneNumber,
                Products = products

            };

            return View(alldata);
        }


        [HttpPost]
        public ActionResult ForSearch()
        {
            

            return View();
        }

        [HttpGet]
        public ActionResult ForSearch(string location, int? category, string searchValue)
        {
            var products = productsService.GetProducts(); // Assuming you have a list of products

            // Filter products based on location, category, and search value
            var filteredProducts = products.Where(p => p.City.ToLower() == location.ToLower()
                                                    && p.CategoryId == category
                                                    )
                                            .ToList();

            return View(filteredProducts);
        }











    }
}