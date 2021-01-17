using Blogic;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
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
            int res = ob.newbooking(b);
            if (res > 0)
            {
                return RedirectToAction("Vehicles");
            }
            else
            {
                ViewData["a"] = "Failed! Try again!!";
            }
            return View();

        }

        public ActionResult Vehicles()
        {
            var A = ob.Vehicles();
            return View(A);
        }

        public ActionResult Book()
        {
           
            return View();
        }

        public ActionResult profile()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Viewbooking(string custid)
        {
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

        public ActionResult bookingdetails()
        {
            var A = ob.bookingdetails();
            return View(A);

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
            if (ModelState.IsValid)
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
            else
            {
                return View();
            }

            
        }
        public ActionResult feedback()
        {

            
            return View();
        }
        [HttpPost]
        public ActionResult feedback( feedbackBE f)
        {
            int res = ob.feedback(f);
            if (res > 0)
            {
                ViewData["a"] = "Thank you for feedback";
            }
            else
            {
                ViewData["a"] = "Please give feedback";
            }
            return View();
        }


    }
}