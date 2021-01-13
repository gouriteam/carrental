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

        
        public ActionResult booking(bookingBE b)
        {
           
            return RedirectToAction("Vehicles");
            
           

        }

        public ActionResult Vehicles()
        {
            var A = ob.Vehicles();
            return View(A);
        }

        [HttpPost]

        public ActionResult Book(bookingBE b)
        {
            int res = ob.newbooking(b);
            if (res > 0)
            {
                ViewData["a"] = "Booked successfully";
            }
            else
            {
                ViewData["a"] = "Failed! Try again!!";
            }
            return View();
        }
        public ActionResult Book()
        {
            return View();
            
        }

        public ActionResult profile()
        {
            
            return View();
        }
        public ActionResult Viewbooking()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Viewbooking(string custid)
        {
            TempData["a"] = custid;
            TempData.Keep();
            int res = ob.Viewbooking(custid);
            if(res>0)
            {
                return RedirectToAction("bookingdetails");
            }
            else
            {
                ViewData["a"] = "try again";
            }
            return View();
        }
      
        public ActionResult bookingdetails(string custid)
        {
            custid = TempData["a"].ToString();
            TempData.Keep();
            var A = ob.bookingdetails(custid);
            return View(A);

        }

        //public ActionResult Edit
        public ActionResult CustomerHomepage()
        {
            return View();
        }

        public ActionResult Cancel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cancel(string bookingid)
        {
            
            int res = ob.Cancel(bookingid);
            if (res > 0)
            {
                ViewData["a"] = "Cancelled successfully";
            }
            else
            {
                ViewData["a"] = "invalid bookingid";
            }
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