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
        public int newbooking(bookingBE b)
        {
            return ob.newbooking(b);
        }
        public List<VehiclesBE> Vehicles()
        {
            return ob.Vehicles();
        }
        public int Viewbooking(string custid)
        {
            return ob.Viewbooking(custid);
        }
        public List<bookingBE> bookingdetails()
        {
            return ob.bookingdetails();
        }

        //public int Adddriver(driverBE e)
        //{
        //    return ob.Adddriver(e);
        //}

    }
}
