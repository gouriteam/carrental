using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntity;
using Blogic;
using System.IO;
namespace project.Controllers
{
    public class AdminController : Controller
    {
        Blogiclayer ob = new Blogiclayer();
        // GET: Admin
        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(VehiclesBE a)
        {
            int res = ob.Addcar(a);
            if (res > 0)
            {
                ViewData["a"] = "Vehicle added Successfully";
            }
            else
            {
                ViewData["a"] = "Cannot Add Vehicles";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userid, string pwd)
        {
            int res = ob.ValidateforAdmin( userid,  pwd);
            int res1 = ob.ValidateforCustomer(userid, pwd);
            if (res > 0)
            {
                Session["user"] = userid;
                return RedirectToAction("Homepage");
            }
            if (res1 > 0)
            {
                Session["user"] = userid;
                return RedirectToAction("CustomerHomepage");
            }
            else
            {
                ViewData["a"] = "Registration";
            }
            return View();
        }




        //    if (res > 0)
        //    {
        //        ViewData["a"] = "Vehicle added Successfully";
        //    }
        //    else
        //    {
        //        ViewData["a"] = "Cannot Add Vehicles";
        //    }
        //    return View();
        //}

        public ActionResult AddDriver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDriver(driverBE e)
        {
            int res = ob.Adddriver(e);
            if (res > 0)
            {
                ViewData["b"] = " Driver is assigned";
            }
            else
            {
                ViewData["b"] = " Driver Cannot be Assigned";
            }
            return View();
        }
    }
}