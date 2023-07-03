using Mauka.Entities;
using Mouka.Services;
using Mouka.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mouka.Web.Controllers
{
    public class ReportController : Controller
    {
        ProductsService productsService = new ProductsService();

        UserService userService = new UserService();

        ReportService reportService = new ReportService();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);

            return RedirectToAction("");
        }

        // POST: /report
        [HttpPost]
        public ActionResult SubmitReport(ReportViewModel model)
        {
            // Get the report and user ID from the submitted model
            var report = new Report();

            var userCookie = Request.Cookies["user"];

            if (userCookie != null)
            {
                var cookieValue = userCookie.Value;

                // Deserialize the cookie value into a User object
                var user = JsonConvert.DeserializeObject<User>(cookieValue);

                // Use the retrieved ID as needed
                var id = user.ID;
                report.SubmittedUserId = id;
                report.ReportTime = DateTime.Now;
                report.report = model.Report;
                report.ReportOnUserId = model.UserId;
                reportService.SaveReport(report);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
            
            
        }

        // Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Perform deletion logic here
            // Example:
            reportService.DeleteReport(id);


            // Return a JSON response indicating the result
            return Json(new { success = true });
        }


    }
}