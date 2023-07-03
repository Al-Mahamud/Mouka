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
    public class AdminController : Controller
    {

        ProductsService productsService = new ProductsService();

        UserService userService = new UserService();

        ReportService reportService = new ReportService();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminPage(Item item)
        {
            var products=productsService.GetProducts();
            
            foreach(var product in products)
            {
                if (product.CategoryId == 1)
                {
                    item.Vehicle++;
                }
                else if(product.CategoryId == 2)
                {
                    item.Mobiles++;
                }
                else if (product.CategoryId == 3)
                {
                    item.Electronics++;
                }
                else if (product.CategoryId == 4)
                {
                    item.RealEstate++;
                }
                else if (product.CategoryId == 5)
                {
                    item.Fashion++;
                }
                else if (product.CategoryId == 6)
                {
                    item.Furniture++;
                }
                else if (product.CategoryId == 7)
                {
                    item.Jobs++;
                }
                else if (product.CategoryId == 8)
                {
                    item.Services++;
                }
                else if (product.CategoryId == 9)
                {
                    item.Pets++;
                }
                else if (product.CategoryId == 10)
                {
                    item.Education++;
                }
                else if (product.CategoryId == 11)
                {
                    item.Matrimony++;
                }
                else if (product.CategoryId == 12)
                {
                    item.NotesAndCoins++;
                }
            }

            return View(item);
        }
        [HttpPost]
        public ActionResult AdminPage(Product product)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewUsers()
        {
            var user= userService.GetUsers();

            return View(user);
        }
        [HttpPost]
        public ActionResult ViewUsers(User user)
        {

            return View();
        }

        [HttpGet]
        public ActionResult UserProducts(int? id)
        {
            var products = productsService.GetProducts();
            // Filter products based on the provided id (if any)
            if (id.HasValue)
            {
                products = products.Where(p => p.UserId == id.Value).ToList();
            }
            var user = userService.GetUser(id.Value);


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
        public ActionResult UserProducts(User user)
        {

            return View();
        }
        //reports
        [HttpGet]
        public ActionResult UserReport()
        {

            var reports = reportService.GetReports();

            List<UserAndReportModel> reportsAndModel = new List<UserAndReportModel>();
            int x = 0;
            foreach (var report in reports)
            {
                var user1 = userService.GetUser(report.SubmittedUserId);
                var user2 = userService.GetUser(report.ReportOnUserId);
                UserAndReportModel model = new UserAndReportModel
                {
                    Id = x,
                    ReportByName = user1.Name,
                    ReportForName = user2.Name,
                    Report = report.report,
                    ReportId = report.ID,
                    ReportDate = report.ReportTime,
                    ReportForId = report.ReportOnUserId
                };
                reportsAndModel.Add(model);
                x++;
            }

            return View(reportsAndModel);
        }
        [HttpPost]
        public ActionResult UserReport(User user)
        {

            return View();
        }



    }


}