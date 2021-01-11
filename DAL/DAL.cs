using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
namespace DAL
{
    public class DALLayer
    {
        rentalEntities ob = new rentalEntities();
        public int Addcar(VehiclesBE a)
        {

            string caridd;
            var lastcus = ob.vehicles.OrderByDescending(c => c.carid).FirstOrDefault();
            if (lastcus == null)
            {
                caridd = "VH10000";
            }
            else
            {
                caridd = "VH" + (Convert.ToInt32(lastcus.carid.Substring(2, 5)) + 1).ToString();
            }

            vehicle st = new vehicle()
            {

                carid = caridd,
                capacity = a.capacity,
                rentperday = a.rentperday,
                fuelmode = a.fuelmode,
                model = a.model,
                ACtype = a.ACtype,
                images = a.images,
                available = a.available,
            };
            ob.vehicles.Add(st);
            return ob.SaveChanges();

        }
        public int Adddriver(driverBE e)         
        {
            string driveridd;
            var lastdriv = ob.drivers.OrderByDescending(c => c.driverid).FirstOrDefault();
            if (lastdriv == null)
            {
                driveridd = "DR10000";
            }
            else
            {
                driveridd = "DR" + (Convert.ToInt32(lastdriv.driverid.Substring(2, 5)) + 1).ToString();
            }
            driver k = new driver()
            {
                driverid = driveridd,
                drivername = e.drivername,
                phonenum = e.phonenum
            };
            ob.drivers.Add(k);
            return ob.SaveChanges();
        }
    }
}
