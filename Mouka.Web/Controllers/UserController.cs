using Mauka.Entities;
using Mouka.Services;
using Mouka.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Polly.Utilities;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;

namespace Mouka.Web.Controllers
{
    public class UserController : Controller
    {


        UserService userService = new UserService();
        ReportService reportService = new ReportService();

        // ...

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword.Equals(hashedPassword);
        }

        // ...

        public ActionResult Logout()
        {
            // Clear the "user" cookie
            var cookie = new HttpCookie("user")
            {
                Expires = DateTime.Now.AddDays(-1),
                Path = "/"
            };
            Response.Cookies.Add(cookie);

            // Redirect to the desired page after logout
            return RedirectToAction("Index", "Home");
        }

        // GET: User
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Resistration()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        public ActionResult Resistration(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists in the database
                bool isEmailExists = CheckIfEmailExists(model.Email);

                if (isEmailExists)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                    return View(model);
                }

                // Create a new user object
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    // Hash the password and store the hashed value
                    Password = HashPassword(model.Password),
                    CreateTime= DateTime.Now
                };

                // Save the user to the database or perform any other necessary actions
                userService.SaveUser(user);

                // Registration logic
                // Here you can save the user data to the database or perform any other necessary actions

                // Redirect to a success page or login page
                TempData["RegistrationSuccess"] = true;
                return RedirectToAction("Login");
            }

            // Model validation failed, return the view with validation errors
            return View(model);
        }

        private bool CheckIfEmailExists(string email)
        {
            // Perform the necessary database query to check if the email already exists
            // Return true if the email exists, false otherwise
            // You can replace this with your actual logic to check email existence in the database
            // For demonstration purposes, let's assume the email always exists
            var users = userService.GetUsers();

            // Compare the input email with each user's email
            foreach (var user in users)
            {
                if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Email exists
                }
            }

            return false; // Email does not exist
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            if(model.Email== "avmahmud0@gmail.com" && model.Password== "ADMIN")
            {
                TempData["LoginAsAdmin"] = true;
                return RedirectToAction("AdminPage", "Admin");
            }
            if (ModelState.IsValid)
            {
                // Perform the necessary authentication logic
                // For example, check if the credentials are valid
                bool isValid = AuthenticateUser(model.Email, model.Password);

                if (isValid)
                {
                    var uuu = userService.GetUsers();
                    var userx = new User();

                    foreach (var user1 in uuu)
                    {
                        if (user1.Email == model.Email)
                        {
                           userx=user1;
                        }
                    }

                    // Create a new cookie
                    HttpCookie userCookie = new HttpCookie("user");

                    // Create a user object or use an existing user object
                    var user = new
                    {
                        Id = userx.ID.ToString(),
                        Name = userx.Name,
                        Email = userx.Email,
                        PhoneNumber = userx.PhoneNumber
                    };

                    // Serialize the user object to a JSON string
                    string userJson = JsonConvert.SerializeObject(user);

                    // Set the cookie value as the JSON string
                    userCookie.Value = userJson;

                    // Set the cookie expiration date (optional)
                    userCookie.Expires = DateTime.Now.AddDays(7); // Cookie will expire in 7 days

                    // Add the cookie to the response
                    Response.Cookies.Add(userCookie);

                    // Authentication successful, redirect to a protected page
                    TempData["LoginSuccess"] = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid email or password. Please try again.");
                    return View(model);
                }
            }

            // If the model state is not valid, return the login view with validation errors
            return View(model);
        }

        private bool AuthenticateUser(string email, string password)
        {


            var users = userService.GetUsers();

            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    // Compare the provided password with the hashed password stored in the user object
                    bool passwordMatch = VerifyPassword(password, user.Password);

                    if (passwordMatch)
                    {
                        // Authentication successful
                        return true;
                    }
                }
            }



            return false;
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            // Get the user cookie
            HttpCookie userCookie = Request.Cookies["user"];

            User currentUser = null; // Initialize with a default value

            if (userCookie != null)
            {
                // Deserialize the cookie value into a User object
                var userJson = userCookie.Value;
                currentUser = JsonConvert.DeserializeObject<User>(userJson);
            }

            var userList = userService.GetUser(currentUser.ID);

            return View(userList);
        }

        [HttpPost]
        public ActionResult Dashboard(User user)
        {
            HttpCookie userCookie = Request.Cookies["user"];

            User currentUser = null; // Initialize with a default value

            if (userCookie != null)
            {
                // Deserialize the cookie value into a User object
                var userJson = userCookie.Value;
                currentUser = JsonConvert.DeserializeObject<User>(userJson);
            }

            var userList = userService.GetUser(currentUser.ID);
            userList.ImageURL= user.ImageURL;

            userService.UpdateUser(userList);

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public ActionResult UserSetting(int id)
        {

            var user = userService.GetUser(id);
            var settingmodel= new SettingModel();
            settingmodel.Name = user.Name;
            settingmodel.Email= user.Email;
            settingmodel.PhoneNumber = user.PhoneNumber;
            settingmodel.OldPassword = user.Password;
            settingmodel.City= user.City;
            settingmodel.ID=user.ID;
            settingmodel.ImageURL= user.ImageURL;
            return View(settingmodel);
        }

        [HttpPost]
        public ActionResult UserSetting(SettingModel user)
        {
            
            
            var user1= userService.GetUser(user.ID);
            if (user1 == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (user.Name != null)
            {
                user1.Name = user.Name;
            }
            
            if(user.Email != null) { 
                user1.Email = user.Email;
            }
            

            if (user.City != null) {
                user1.City = user.City;
            }
            
            if(user.PhoneNumber!= null)
            {
                user1.PhoneNumber = user.PhoneNumber;
            }
            

            if( user.NewPassword == user.RepeatPassword && user.NewPassword !=null ) {
                bool passwordMatch = VerifyPassword(user.OldPassword, user1.Password);

                if (passwordMatch)
                {
                    user1.Password = HashPassword(user.NewPassword);

                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Old passward isn't correct.");
                }
            }


            
            userService.UpdateUser(user1);
            user.ImageURL = user1.ImageURL;

            return View(user);
        }



        [HttpGet]
        public ActionResult About()
        {

            return View();
        }

        [HttpPost]
        public ActionResult About(SettingModel user)
        {

           
            return View();
        }


        [HttpGet]
        public ActionResult TermsAndCondition()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TermsAndCondition(SettingModel user)
        {


            return View();
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordModel model)
        {

            if (ModelState.IsValid)
            {
                // Check if the email already exists in the database
                bool isEmailExists = CheckIfEmailExists(model.Email);

                if (!isEmailExists)
                {
                    ModelState.AddModelError("Email", "Email doesn't exists.");
                    return View(model);
                }

                // Create a new user object
                var user = new User();
                var users = userService.GetUsers();
                foreach(var x in users)
                {
                    if(x.Email == model.Email)
                    {
                        user = x;
                    }
                }
                user.Password=HashPassword(model.Password);

                // Save the user to the database or perform any other necessary actions
                userService.UpdateUser(user);

                // Registration logic
                // Here you can save the user data to the database or perform any other necessary actions

                // Redirect to a success page or login page
                TempData["Resetpassword"] = true;
                return RedirectToAction("Login");
            }

            // Model validation failed, return the view with validation errors
            return View(model);
        }


        //delete
        [HttpPost]
        public ActionResult Delete(int ID)

        {
            var reports = reportService.GetReports();
            foreach (var report in reports)
            {
                if(report.ReportOnUserId== ID)
                {
                    reportService.DeleteReport(report.ID);
                }
                else if(report.SubmittedUserId== ID)
                {
                    reportService.DeleteReport(report.ID);
                }
            }

            HttpCookie userCookie = Request.Cookies["user"];

            User currentUser = null; // Initialize with a default value

            if (userCookie != null)
            {
                // Clear the "user" cookie
                var cookie = new HttpCookie("user")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Path = "/"
                };
                Response.Cookies.Add(cookie);

                userService.DeleteUser(ID);
                return Json(new { success = true });

            }
            userService.DeleteUser(ID);
            

            return RedirectToAction("AdminPage", "Admin");
            


            
        }







    }
}