using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StadiumManagementSys.Data;
using StadiumManagementSys.Models;

namespace StadiumManagementSys.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _Context;
        public HomeController(DataContext context)
        {
            _Context = context;

        }


        public IActionResult Index()
        {
          
            return View();

         

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {

            var acc = _Context.Login.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();

            if (acc != null)
            {

                HttpContext.Session.SetString("ID", acc.ID.ToString());
                HttpContext.Session.SetString("Actor", acc.Actor);
                HttpContext.Session.SetString("Email", acc.Email);

                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "UserID or Email or password is invalid");
            }
            return View();
        }

        public IActionResult Welcome()
        {
            if (HttpContext.Session.GetString("Actor") != null)
            {
                ViewBag.Message = HttpContext.Session.GetString("Email") + " log in";
                return View();
            }

            else
            {
                return RedirectToAction("Login");

            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
