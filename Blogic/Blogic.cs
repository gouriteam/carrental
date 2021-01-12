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
        public int Adddriver(driverBE e)
        {
            return ob.Adddriver(e);
        }
        public int ValidateBCars(DateTime? start,  string WeekMonth)
        {
            return ob.ValidateBCars(start, WeekMonth);
        }
        public List<VehiclesBE> viewVehicle(DateTime? start, string WeekMonth)
        {
            return ob.viewVehicle(start, WeekMonth);
        }
        public int Editcars(VehiclesBE a)
        {
            return ob.Editcars(a);
        }
    }
}
