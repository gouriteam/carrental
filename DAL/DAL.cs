using BusinessEntity;
using System;
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
        //public int Adddriver(driverBE e)         
        //{

        //    string driveridd;
        //    var lastdriv = ob.drivers.OrderByDescending(c => c.driverid).FirstOrDefault();
        //    if (lastdriv == null)
        //    {
        //        driveridd = "DR10000";
        //    }
        //    else
        //    {
        //        driveridd = "DR" + (Convert.ToInt32(lastdriv.driverid.Substring(2, 5)) + 1).ToString();
        //    }
        //    driver k = new driver()
        //    {
        //        driverid = driveridd,
        //        drivername = e.drivername,
        //        phonenum = e.phonenum
        //    };
        //    ob.drivers.Add(k);
        //    return ob.SaveChanges();
        //}

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
                bookingid = "B" + (Convert.ToInt32(lastbooking.bookingid.Substring(1, 5)) + 11111).ToString();
            }

            //var start = b.startdate;
            //var end = b.enddate;

            //var a = start.Date;
            //var k = end.Date;
            //int n = DateTime.Parse(a) - Convert.ToInt32(k);

            //string rentperday="a";
            //var r = rentperday;
            //var totalp = n * int.Parse(r);

            booking bi = new booking()
            {

                bookingid = bookingid,
                custid = b.custid,
                carid = b.carid,
                driverid = b.driverid,
                startdate = DateTime.Parse("01-01-2021"),
                enddate = DateTime.Parse("02-01-2021"),
                totalprice = b.totalprice,
                fromroute = b.fromroute,
                toroute = b.toroute,
                status = b.status


            };
            ob.bookings.Add(bi);
            return ob.SaveChanges();

        }

        public List<VehiclesBE> Vehicles()
        {
            var res = from v in ob.vehicles
                      where v.available == "yes"
                      select v;
            List<VehiclesBE> A = new List<VehiclesBE>();

            foreach (var item in res)
            {

                A.Add(new VehiclesBE() { carid = item.carid, model = item.model, capacity = item.capacity, ACtype = item.ACtype, rentperday = item.rentperday, fuelmode = item.fuelmode, images = item.images, available = item.available });
            }
            return A;

        }

        public int Viewbooking(string custid)
        {
            var res = (from t in ob.bookings
                       where t.custid == custid
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
        public List<bookingBE> bookingdetails()
        {
            string custid = "a";
            var res = from t in ob.bookings
                      where t.custid == custid
                      select t;
            List<bookingBE> A = new List<bookingBE>();

            foreach (var item in res)
            {

                A.Add(new bookingBE()
                {
                    bookingid = item.bookingid,
                    custid = item.custid,
                    carid = item.carid,
                    driverid = item.driverid,
                    startdate = (DateTime)item.startdate,
                    enddate = (DateTime)item.enddate,
                    totalprice = (double)item.totalprice,
                    fromroute = item.fromroute,
                    toroute = item.toroute,
                    status = item.status
                });
            }
            return A;
        }



        public int ValidateAdmin(string userid, string pwd)
        {
            var res = (from x in ob.admins where x.adminid == userid & x.adpwd == pwd select x).Count();

            if (res > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        public int ValidateforCustomer(string userid, string pwd)
        {
            var res1 = (from x in ob.registrations where x.custid == userid & x.pwd == pwd select x).Count();

            if (res1 > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }


        public int Validateforid(string id)
        {
            var res = (from x in ob.admins where x.adminid == id select x).Count();
            var res1 = (from x in ob.registrations where x.custid == id select x).Count();

            if (res > 0 || res1 > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public int Registration(CustomerBE s)
        {

            string custid;
            var lastcus = ob.registrations.OrderByDescending(c => c.custid).FirstOrDefault();
            if (lastcus == null)
            {
                custid = "CH1234";
            }
            else
            {
                custid = "CH" + (Convert.ToInt32(lastcus.custid.Substring(2, 4)) + 1).ToString();
            }
            registration st = new registration() { custid = custid, custname = s.custname, gender = s.gender, pwd = s.pwd, DOB = s.DOB, phonenum = s.phonenum, email = s.email };

            ob.registrations.Add(st);

            return ob.SaveChanges();
        }

    }
}



