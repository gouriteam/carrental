using BusinessEntity;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        public int ValidateBCars(DateTime? start, string WeekMonth)
        {
           // DateTime? from = start;
            //DateTime? to =DateTime.Parse("1-1-2010");
            DateTime d = DateTime.Parse("1-1-1998");
            DateTime d1 = DateTime.Parse("1-1-2022");
            //if (WeekMonth == "Weekly")
            //{
            //    d1 = d.AddDays(7);
            //}
            // if (WeekMonth == "Monthly")
            //    {
            //    d1 = d.AddDays(30);
            //}
              var res = (from t in ob.bookings
                           where t.startdate > d && t.enddate < d1
                           select t).Count();
                if (res > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        public List<VehiclesBE> viewVehicle(DateTime? start, string WeekMonth)
        {
           // DateTime? from = start;
            //DateTime? to = DateTime.Parse("1-1-2010");
            DateTime d = DateTime.Parse("1-1-1998");
            DateTime d1 = DateTime.Parse("1-1-2022");
            //if (WeekMonth == "Weekly")
            //{
            //    d1 = d.AddDays(7);
            //}
            //if (WeekMonth == "Monthly")
            //{
            //    d1 = d.AddDays(30);
            //}
            var caridd = (from t in ob.bookings
                         where t.startdate > DateTime.Now.AddDays(7)
                       select t.carid).ToList();

            //var startdate = DateTime.Parse("2021-01-01");

            ////List<DateTime> res = startdate.ToList();




            var caridd2 = caridd.ToString();
            var vehicle = from k in ob.vehicles
                          where k.carid == caridd2
                          select k;

            List < VehiclesBE> li = new List<VehiclesBE>();

            foreach (var item in vehicle)
            {
                li.Add(new VehiclesBE() {
                    ACtype = item.ACtype,
                    carid = item.carid,
                    capacity =item.capacity,
                    fuelmode = item.fuelmode,
                    available = item.available,
                    images = item.images,
                    model = item.model,
                    rentperday = item.rentperday
                });
            }
            return li;
        }

        public int newbooking(bookingBE b)
        {
            
            string bookingid;
            var lastbooking = ob.bookings.OrderByDescending(c => c.bookingid).FirstOrDefault();
            if (lastbooking == null)
            {
                bookingid = "B00000";
            }
            else
            {
                bookingid = "B" + (Convert.ToInt32(lastbooking.bookingid.Substring(1, 5)) + 1).ToString();
            }


            var res = (from t in ob.vehicles
                      where t.available == "yes"
                      select t).Count();
            if(res>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            var start = b.startdate;
            var end = b.enddate;

            var a = start.Date;
            var k = end.Date;
            int n = Convert.ToInt32(a) - Convert.ToInt32(k);

            //int rentperday = null;
            //var r = rentperday;
            //var totalprice = n * r;

            booking bi = new booking()
            {

                bookingid = bookingid,
                custid = b.custid,
                carid = b.carid,
                driverid = b.driverid,
                startdate = b.startdate,
                enddate = b.enddate,
                //totalprice =n*,
                fromroute = b.fromroute,
                toroute = b.toroute,
                status = b.status


            };
            ob.bookings.Add(bi);
            return ob.SaveChanges();

        }
        public int Editcars(VehiclesBE a)
        {
            var res = from t in ob.vehicles
                      where t.carid == a.carid
                      select t;
            if (res.Count() > 0)
            {
                (from t in ob.vehicles
                 where t.carid == a.carid 
                 select t).ToList().ForEach(
                    x =>
                    {
                        x.ACtype = a.ACtype;
                        x.available = a.available;
                        x.capacity = 15;
                        x.fuelmode = a.fuelmode;
                        x.images = a.images;
                        x.rentperday = a.rentperday;
                        x.model = a.model;
                    });
                return ob.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
