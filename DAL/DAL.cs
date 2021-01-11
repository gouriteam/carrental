using BusinessEntity;
using System;
using System.Linq;
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

    }
}
