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
                ViewData["b"] = " Driver is Added";
            }
            else
            {
                ViewData["b"] = " Driver Cannot be Added";
            }
            return View();
        }
        public ActionResult ViewBookedCars()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewBookedCars(DateTime? start, DateTime? end, string WeekMonth)
        {
            TempData["start"] = start;
            TempData["end"] = end;
            TempData["WeekMonth"] = WeekMonth;
            TempData.Keep();
            int result = ob.ValidateBCars(start, WeekMonth);
            if (result > 0)
            {
                return RedirectToAction("Bookedcars");
            }
            else
            {
                ViewData["status"] = "No cars Booked on this date";
            }
            return View();
        }
        public ActionResult Bookedcars( DateTime? start, string WeekMonth)
        {
           // start = Convert.ToDateTime(TempData["start"]);
           // end = Convert.ToDateTime(TempData["end"]);
            //var pageNumber = page ?? 1;
            //AccountId = TempData["id"].ToString();
          
            //AccountId = "LN10000";
            start = Convert.ToDateTime(TempData["start"]);
            //end = Convert.ToDateTime(TempData["end"]);
            WeekMonth = TempData["WeekMonth"].ToString();
            TempData.Keep();
            var res = ob.viewVehicle(start,WeekMonth);
            return View(res);
        }
        public ActionResult Editcars()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Editcars(VehiclesBE a)
        {
           
                int res = ob.Editcars(a);
                if ( res > 0)
                {
                    ViewData["a"] = "edited successfully";
                }
                else
                {
                    ViewData["a"] = " Cannot Edit car Id doesnt Exist";
                }
            
            return View();
        }
    }
}