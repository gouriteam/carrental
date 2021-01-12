using Blogic;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        Blogiclayer ob = new Blogiclayer();


        public ActionResult Home()
        {
            return View();
        }
        public ActionResult booking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult booking(bookingBE b)
        {
            int res = ob.newbooking(b);
            if (res > 0)
            {
                ViewData["a"] = "Booked Successfully";
            }
            else
            {
                ViewData["a"] = "Booking failed! Try again!!";
            }
            return View();
            
        }
        public ActionResult CustomerHomepage()
        {
            return View();
        }
        

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(CustomerBE s)
        {
            
                int res = ob.Registration(s);
                if (res > 0)
                {
                    ViewData["status"] = " Registered successfully ";
                }
                else
                {
                    ViewData["status"] = "CustID already Exists";
                }
                return View();
            
        }

    }
}