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
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        
        public ActionResult booking(bookingBE b)
        {
           
            return RedirectToAction("Vehicles");
            
           

        }

        public ActionResult Vehicles()
        {
           // TempData["carid"] = carid;
            //TempData.Keep();
            var A = ob.Vehicles();
            return View(A);
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login","Admin");
        }

        [HttpPost]

        public ActionResult Book(bookingBE b,string carid)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
           
            else
            {
                carid = Request.QueryString["carid"];
                
                b.carid = carid;
                b.custid = Session["user"].ToString();
                int res = ob.newbooking(b, carid);
                if (res > 0)
                {
                    ViewData["a"] = "Booked successfully";
                }
                else if(res<0)
                {
                    ViewData["a"] = "start date cannot be greater than end date";

                }
                else
                {
                    ViewData["a"] = "Failed! Try again!!";
                }             
            }
            return View();
        }
        public ActionResult Book()
        {
            return View();
            
        }
        

        public ActionResult profile()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            return View();
        }
        
      
        public ActionResult bookingdetails(string custid)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            else
            {
                custid = Session["user"].ToString();
                
                var A = ob.bookingdetails(custid);

                return View(A);
            }

        }

       

        public ActionResult cardetails(string custid)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            else
            {

                custid = Session["user"].ToString(); 
               
                var A = ob.cardetails(custid);
                return View(A);
            }

            

        }

        public ActionResult Editprofile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editprofile(CustomerBE c,string custid)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            else
            {
                custid = Session["user"].ToString();
                int res = ob.Editprofile(c,custid);
                if (res > 0)
                {
                    ViewData["a"] = "Edited successfully";
                }
                else
                {
                    ViewData["a"] = " Customer Id doesnt Exist";
                }
                return View();
            }
        }

        public ActionResult Editbooking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editbooking(bookingBE b)
        {

            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            else
            {

                int res = ob.Editbooking(b);
                if (res > 0)
                {
                    ViewData["a"] = "Edited successfully";
                }
                else if (res < 0)
                {
                    ViewData["a"] = " You can edit the details one day before your journey";
                }
                else
                {
                    ViewData["a"] = " Bookingid doesn't exist";

                }
                return View();
            }
        }



        public ActionResult CustomerHomepage()
        {
            return View();
        }

        public ActionResult Cancel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cancel(bookingBE b, string bookingid)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login","Admin");
            }

            else
            {
                //b.bookingid = bookingid;
                //b.custid = Session["user"].ToString();

                int res = ob.Cancel(b, bookingid);
                if (res > 0)
                {
                    ViewData["a"] = "Cancelled successfully";
                }
                else
                {
                    ViewData["a"] = "invalid bookingid";
                }
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
        public ActionResult printbill(string bookingid)
        {
            var b = ob.printbill(bookingid);
            return View(b);
        }



    }
}