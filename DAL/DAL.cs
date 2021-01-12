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

        public int ValidateAdmin(string userid, string pwd)
        {
           var res = (from x in ob.admins where x.adname == userid & x.adpwd == pwd select x).Count();
        
            if(res>0)
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
            var res1 = (from x in ob.registrations where x.custname == userid & x.pwd == pwd select x).Count();

            if (res1>0)
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

            if (res > 0 || res1>0)
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
            registration st = new registration() { custid = custid, custname = s.custname,gender=s.gender, pwd = s.pwd, DOB = s.DOB, phonenum = s.phonenum, email = s.email};

                ob.registrations.Add(st);

                return ob.SaveChanges();
            }
           
        }



    }
