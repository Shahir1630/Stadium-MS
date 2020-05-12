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
    public class TicketsController : Controller
    {

        private DataContext _Context;
        public TicketsController(DataContext context)
        {
            _Context = context;

        } 

        // GET: /<controller>/
        //public IActionResult Tic()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Tic(Tickets tickets)
        //{
        //    _Context.Tickets.Add(tickets);
        //    _Context.SaveChanges();
        //    return RedirectToAction("Seat");
        //}

        // public IActionResult Seat(Int64 TicketNo)
        //{
        //    var model = _Context.Tickets.Where(u => u.TicketNo == TicketNo).FirstOrDefault();
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Seat(Tickets tickets)
        //{
        //    var s = _Context.Tickets.Where(u => u.TicketNo == tickets.TicketNo).FirstOrDefault();

        //    s.Zone = tickets.Zone;
        //    s.SeatNo = tickets.SeatNo;
        //    //  _context.StudentPayment.Update(s);
        //    _Context.SaveChanges();
        //    return RedirectToAction("CostList");
        //}



        [HttpGet]
        public IActionResult TicketsIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TicketsIndex(string zone)
        {

            if (zone == "Zoon1" || zone == "Zoon2" || zone == "Zoon3" || zone == "Zoon4")
            {

                return RedirectToAction("Buy", new { Zome = zone });
            }
            return RedirectToAction("BuyCorner", new { Zome = zone });
        }

        [HttpGet]
        public IActionResult Buy(string Zone)
        {
            ViewData["Zone"] = Zone;
            return View();
        }
        

        [HttpGet]
        public IActionResult BuyCorner(string Zone)
        {
            ViewData["Zone"] = Zone;

            return View();
        }

        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Booking( Booking booking)
        {
            _Context.Booking.Add(booking);
            _Context.SaveChanges();



            return RedirectToAction("Successful");
        }

        public IActionResult Successful()
        {
            return View();
        }

        public IActionResult BookingDetails(Int64 RequestNo)
        {

            var data = _Context.Booking.Where(u => u.RequestNo == RequestNo).FirstOrDefault();

            return View(data);
        }

        public IActionResult BookingList()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                var test = _Context.Booking.ToList();
                var model = new List<Booking>();
                foreach (var i in test)
                {
                    var s = new Booking()
                    {
                        RequestNo = i.RequestNo,
                        Name = i.Name,
                        Purpose = i.Purpose,
                        Phone = i.Phone
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

        public IActionResult Delete(Int64 RequestNo)
        {
            var data = _Context.Booking.Where(u => u.RequestNo == RequestNo).FirstOrDefault();
            var model = _Context.Booking.ToList();
            
            _Context.Remove(data);
            _Context.SaveChanges();

            return RedirectToAction("BookingList");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
