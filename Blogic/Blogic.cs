﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DAL;

namespace Blogic
{
    public class Blogiclayer
    {
        DALLayer ob = new DALLayer();
        public int Addcar(VehiclesBE a)
        {
            return ob.Addcar(a);
        }
        public int newbooking(bookingBE b,string carid)
        {
            return ob.newbooking(b,carid);
        }
        public List<VehiclesBE> Vehicles()
        {
            return ob.Vehicles();
        }
       
        public List<bookingBE> bookingdetails(string custid)
        {
            return ob.bookingdetails(custid);
        }

       

        public List<VehiclesBE> cardetails(string custid)
        {
            return ob.cardetails(custid);
        }

            public int Cancel(bookingBE b, string bookingid)
        {
            return ob.Cancel(b,bookingid);
        }

        public int Editprofile(CustomerBE c,string custid)
        {
            return ob.Editprofile(c,custid);
        }

        public int Editbooking(bookingBE b)
        {
            return ob.Editbooking(b);
        }


        public int Adddriver(driverBE e)
        {
            return ob.Adddriver(e);
        }

        public int ValidateforAdmin(string userid, string pwd)
        {
            return ob.ValidateAdmin(userid, pwd);
        }
        public int ValidateforCustomer(string userid, string pwd)
        {
            return ob.ValidateforCustomer(userid, pwd);
        }


        public int Registration(CustomerBE s)
        {
            return ob.Registration(s);
        }

        public int ValidateBCars(DateTime? start, string WeekMonth)
        {
            return ob.ValidateBCars(start, WeekMonth);
        }
        public List<bookingBE> viewVehicle(DateTime? start, string WeekMonth)
        {
            return ob.viewVehicle(start, WeekMonth);
        }
        public int Editcars(VehiclesBE a)
        {
            return ob.Editcars(a);
        }
        public int Allotdriver(string bookingid, string carid, string driverid)
        {
            return ob.Allotdriver(bookingid, carid, driverid);
        }
        public int nofcars()
        {
            return ob.nofcars();
        }
        public int noofbooks()
        {
            return ob.noofbooks();
        }
        public int noofusers()
        {
            return ob.noofusers();
        }
        public int noofcarmodels()
        {
            return ob.noofcarmodels();
        }
        public int nofcancel()
        {
            return ob.nofcancel();
        }
        public int nooftdy()
        {
            return ob.nooftdy();
        }
        public int nbymonth(string Month)
        {
           return ob.nbymonth(Month);
        }
        public List<bookingBE> printbill(string bookingid)
        {
            return ob.printbill(bookingid);
        }
    }
}
