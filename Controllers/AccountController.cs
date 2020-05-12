using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StadiumManagementSys.Data;
using StadiumManagementSys.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StadiumManagementSys.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private DataContext _Context;
        public AccountController(DataContext context)
        {
            _Context = context;

        }
        public IActionResult Cost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cost(Cost cost)
        {
            _Context.Cost.Add(cost);
            _Context.SaveChanges();
            return RedirectToAction("CostList");
        }

        public IActionResult CostList()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                var test = _Context.Cost.ToList();
                var model = new List<Cost>();
                foreach (var i in test)
                {
                    var s = new Cost()
                    {
                        Id=i.Id,
                        MonthName=i.MonthName,
                        Date = i.Date,
                        ReasoneOfCost = i.ReasoneOfCost,
                        Amounnt = i.Amounnt,
                        
                    };
                    model.Add(s);
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult CostDelete(Int64 Id)
        {
            var data = _Context.Cost.Where(u => u.Id == Id).FirstOrDefault();
            var model = _Context.Cost.ToList();
            
            _Context.Remove(data);
            _Context.SaveChanges();


            return RedirectToAction("CostList");
        }
        public IActionResult CostDetails(Int64 Id)
        {

            var data = _Context.Cost.Where(u => u.Id == Id).FirstOrDefault();

            return View(data);
        }

        public IActionResult CostEdit(Int64 Id)
        {
            

            var model = _Context.Cost.Where(u => u.Id == Id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult CostEdit(Cost cost)
        {

            var s = _Context.Cost.Where(u => u.Id == cost.Id).FirstOrDefault();

            s.Id = cost.Id;
            s.Date = cost.Date;
            s.MonthName = cost.MonthName;
            s.ReasoneOfCost = cost.ReasoneOfCost;
            s.Amounnt = cost.Amounnt;
        
            //  _context.StudentPayment.Update(s);
            _Context.SaveChanges();
            return RedirectToAction("CostList");
        }

        //income 

        public IActionResult BookingIncome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookingIncome(Income income)
        {
            _Context.Income.Add(income);
            _Context.SaveChanges();
            return RedirectToAction("BookingIncomeList");
        }
        public IActionResult BookingIncomeList()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                var test = _Context.Income.ToList();
                var model = new List<Income>();
                foreach (var i in test)
                {
                    var s = new Income()
                    {
                        Id = i.Id,
                        OrganizationName = i.OrganizationName,
                        Date = i.Date,
                        Phone = i.Phone,
                        Email = i.Email,
                        BookingCost = i.BookingCost,
                        Advance = i.Advance,
                        Due = i.Due,

                    };
                    model.Add(s);
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult BookingIncomeEdit(Int64 Id)
        {


            var model = _Context.Income.Where(u => u.Id == Id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult BookingIncomeEdit(Income income)
        {

            var s = _Context.Income.Where(u => u.Id == income.Id).FirstOrDefault();
            s.Id = income.Id;
            s.OrganizationName = income.OrganizationName;
            s.Date = income.Date;
            s.Phone = income.Phone;
            s.Email = income.Email;
            s.BookingCost = income.BookingCost;
            s.Advance = income.Advance;
            s.Due = income.Due;
           
            //  _context.StudentPayment.Update(s);
            _Context.SaveChanges();
            return RedirectToAction("BookingIncomeList");
        }
        
        

        public IActionResult IncomeDelete(Int64 Id)
        {
            var data = _Context.Income.Where(u => u.Id == Id).FirstOrDefault();
            var model = _Context.Income.ToList();

            _Context.Remove(data);
            _Context.SaveChanges();


            return RedirectToAction("BookingIncomeList");
        }
        public IActionResult BookingIncomeDetails(Int64 Id)
        {

            var data = _Context.Income.Where(u => u.Id == Id).FirstOrDefault();

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
