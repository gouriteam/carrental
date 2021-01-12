using System;
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
        //public int Adddriver(driverBE e)
        //{
        //    return ob.Adddriver(e);
        //}

        public int ValidateAdmin(string userid, string pwd)
        {
            return ob.ValidateAdmin(userid, pwd);
        }



    }
}
