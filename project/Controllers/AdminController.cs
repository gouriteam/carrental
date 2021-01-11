using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntity;
using Blogic;
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
            int res = ob.ValidateAdmin( userid,  pwd);

            if (res > 0)
            {
                return RedirectToAction("Homepage");
            }
            else
            {
                ViewData["a"] = "Invalid User";
            }
            return View();
        }



    }
}