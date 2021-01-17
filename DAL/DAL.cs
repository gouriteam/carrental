using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            DateTime? d = start;
            DateTime d1 = DateTime.Parse("1-1-2022");
            if (WeekMonth == "Weekly")
            {
                d1 = d.Value.AddDays(7);
            }
            if (WeekMonth == "Monthly")
            {
                d1 = d.Value.AddDays(30);
            }
            var res = (from t in ob.bookings
                       where t.startdate >= d && t.enddate <= d1
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
        public List<bookingBE> viewVehicle(DateTime? start, string WeekMonth)
        {
            // DateTime? from = start;
            //DateTime? to = DateTime.Parse("1-1-2010");
            DateTime? d = start;
            DateTime d1 = DateTime.Parse("1-1-2022");
            if (WeekMonth == "Weekly")
            {
                d1 = d.Value.AddDays(7);
            }
            if (WeekMonth == "Monthly")
            {
                d1 = d.Value.AddDays(30);
            }
            var caridd = from t in ob.bookings
                         where t.startdate >= d && t.enddate <= d1
                         select t;
            List<bookingBE> li = new List<bookingBE>();
            foreach (var item in caridd)
            {
                li.Add(new bookingBE()
                {
                    carid = item.carid,
                    bookingid = item.bookingid,
                    startdate = (DateTime)item.startdate,
                    enddate = (DateTime)item.enddate,
                });
            }
            return li;
            //List < VehiclesBE> li = new List<VehiclesBE>();
            //foreach (var item1 in caridd)
            //{
            //    foreach (var item in res)
            //    {
            //        li.Add(new VehiclesBE()
            //        {
            //            ACtype = item.ACtype,
            //            carid = item.carid,
            //            capacity = item.capacity,
            //            fuelmode = item.fuelmode,
            //            available = item.available,
            //            images = item.images,
            //            model = item.model,
            //            rentperday = item.rentperday
            //        });
            //    }
            //}
            //return li;
        }


        public int newbooking(bookingBE b,string carid)
        {
            
                string bookingid;
                var lastbooking = ob.bookings.OrderByDescending(c => c.bookingid).FirstOrDefault();
                if (lastbooking == null)
                {
                    bookingid = "BD10000";
                }
                else
                {
                    bookingid = "BD" + (Convert.ToInt32(lastbooking.bookingid.Substring(2, 5)) + 1).ToString();
                }


            DateTime d = b.startdate;
            DateTime j = b.enddate;
            var o = (j - d).TotalDays;
            

            var price = from t in ob.vehicles
                         where t.carid == carid
                         select t.rentperday;
            var g = price.SingleOrDefault();
            var n = g * o;
            if (j > d)
            {

                var k = ob.bookings.Where(c => c.custid == b.custid).Count();

                if (k >= 3)
                {
                    var dis = n - (n * (0.3));
                    booking bi = new booking()
                    {

                        bookingid = bookingid,
                        custid = b.custid,
                        carid = b.carid,
                        startdate = b.startdate,
                        enddate = b.enddate,
                        totalprice = dis,
                        fromroute = b.fromroute,
                        toroute = b.toroute,
                        status = true


                    };
                    ob.bookings.Add(bi);
                }
                else
                {

                    booking bi = new booking()
                    {

                        bookingid = bookingid,
                        custid = b.custid,
                        carid = b.carid,

                        startdate = b.startdate,
                        enddate = b.enddate,
                        totalprice = n,
                        fromroute = b.fromroute,
                        toroute = b.toroute,
                        status = true


                    };
                    ob.bookings.Add(bi);

                }

                return ob.SaveChanges();
            }
            else
            {
                return -1;
            }
            

        }

        public List<VehiclesBE> Vehicles()
        {
            var res = from v in ob.vehicles
                      where v.available == "yes"
                      select v;
            List<VehiclesBE> A = new List<VehiclesBE>();

            foreach (var item in res)
            {

                A.Add(new VehiclesBE() { carid = item.carid, model = item.model, capacity = (int)item.capacity, ACtype = item.ACtype, rentperday = (double)item.rentperday, fuelmode = item.fuelmode, images = item.images, available = item.available });
            }
            return A;

        }

       
        public List<bookingBE> bookingdetails(string custid)
        {
           
            
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




        public int Editprofile(CustomerBE c,string custid)
        {
            var res = from t in ob.registrations
                      where t.custid == custid
                      select t;
            if (res.Count() > 0)
            {
                (from t in ob.registrations
                 where t.custid == custid
                 select t).ToList().ForEach(
                    e =>
                    {
                        e.custname = c.custname;
                        e.pwd = c.pwd;
                        e.email = c.email;
                        e.phonenum = c.phonenum;
                    });
                    return ob.SaveChanges();


            }
            else
            {
                return 0;
            }
        }

        public int Editbooking(bookingBE b)
        {
            var l = from t in ob.bookings
                    where t.bookingid == b.bookingid
                    select t.startdate;

            DateTime d = l.SingleOrDefault();
            DateTime j = DateTime.Now.Date;
            var o = (d - j).TotalDays;

            var res = from t in ob.bookings
                      where t.bookingid == b.bookingid
                      select t;
            if (res.Count() > 0)
            {
                if (o >= 1)
                {
                    (from t in ob.bookings
                     where t.bookingid == b.bookingid
                     select t).ToList().ForEach(
                        e =>
                        {
                            e.custid = b.custid;

                            e.carid = b.carid;

                        });
                }
                else
                {
                    return -1;
                }
                return ob.SaveChanges();


            }
            else
            {
                return 0;
            }
        }

        public int Cancel(bookingBE b,string bookingid)
        {
            var l = from t in ob.bookings
                    where t.bookingid == bookingid
                    select t.startdate;

            DateTime d = l.SingleOrDefault();
            DateTime j = DateTime.Now.Date;
            var o = (d - j).TotalDays;
            //var o = 1;

            //var price = from t in ob.vehicles
            //            where t.carid == b.carid
            //            select t.rentperday;

            var price = from t in ob.vehicles
                        from v in ob.bookings
                        where v.bookingid == bookingid && v.carid==t.carid
                        select t.rentperday;

            var g = price.SingleOrDefault();
            var n = g * o;

            var tot =  n*0.15;

            var res = ob.bookings.Where(t => t.bookingid == bookingid);

            if (o <= 1)
            {
                foreach (var item in res)
                {
                    item.totalprice = tot;
                    item.status = false;
                }
                
            }

            else
            {
                foreach (var item in res)
                {
                    item.status = false;
                }

                
            }
            return ob.SaveChanges();
            


        }

        public List<VehiclesBE> cardetails(string custid)
        {


            //var res = from t in ob.bookings
            //          where t.custid == custid
            //          select t;

            var res = from t in ob.vehicles
                       from c in ob.bookings
                       where c.custid == custid && c.carid== t.carid
                       select t;
            List<VehiclesBE> A = new List<VehiclesBE>();

            foreach (var item in res)
            {
                 
               A.Add(new VehiclesBE() { carid = item.carid, model = item.model, images = item.images, rentperday = item.rentperday });
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
       
        public int Allotdriver(string bookingid, string carid, string driverid)
        {
            var res = from t in ob.bookings
                      where t.carid == carid && t.bookingid == bookingid
                      select t;
            var res1 = from t in ob.bookings
                       where t.carid == carid
                       select t;
            var res2 = from t in ob.bookings
                       where t.driverid == driverid
                       select t;
            DateTime s = DateTime.Parse("1-1-2010");
            DateTime e = DateTime.Parse("2-1-2010");
            DateTime s1 = DateTime.Parse("3-1-2010");
            DateTime e1 = DateTime.Parse("4-1-2010");
            foreach (var item in res1)
            {
                s = (DateTime)item.startdate;
                e = (DateTime)item.enddate;
            }


            foreach (var item in res1)
            {
                s1 = (DateTime)item.startdate;
                e1 = (DateTime)item.enddate;
            }
            if (s > s1 && s > e1)
            {
                if (res.Count() > 0)
                {
                    (from t in ob.bookings
                     where t.bookingid == bookingid
                     select t).ToList().ForEach(x => x.driverid = driverid);
                    return ob.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }

        }
     
        public int nofcars()
        {
            var r = (from t in ob.vehicles
                     select t).Count();
            return r;
        }
        public int noofbooks()
        {
            var r = (from t in ob.bookings
                     select t).Count();
            return r;
        }
        public int noofusers()
        {
            var r = (from t in ob.registrations
                     select t).Count();
            return r;
        }
        public int noofcarmodels()
        {
            var r = (from t in ob.vehicles
                     select t).Distinct().Count();
            return r;
        }
        public int nofcancel()
        {
            var r = (from t in ob.bookings
                     where t.status == false
                     select t).Count();
            return r;
        }
        public int nooftdy()
        {
            var r = (from t in ob.bookings
                     where t.startdate == DateTime.Now
                     select t).Count();
            return r;
        }
        public int nbymonth(string Month)
        {
            int d = Convert.ToInt32(Month);
            int r = (from t in ob.bookings
                     where t.startdate.Month == d
                     select t).Count();
            return r;
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
        public List<bookingBE> printbill(string bookingid)
        {
            var res = ob.bookings.OrderByDescending(c => c.bookingid).FirstOrDefault();
            List<bookingBE> A = new List<bookingBE>();


                A.Add(new bookingBE()
                {
                    bookingid = res.bookingid,
                    custid = res.custid,
                    carid = res.carid,

                    startdate = (DateTime)res.startdate,
                    enddate = (DateTime)res.enddate,
                    totalprice = (double)res.totalprice,
                    fromroute = res.fromroute,
                    toroute = res.toroute,
          
                });
     
            return A;
        }




    }



}
       
