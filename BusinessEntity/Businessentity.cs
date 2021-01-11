using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace BusinessEntity
{
    public class VehiclesBE
    {

        public string carid { get; set; }
        public string model { get; set; }
        public int capacity { get; set; }
        public string ACtype { get; set; }
        public double rentperday { get; set; }
        public string fuelmode { get; set; }
        public string images { get; set; }
        public string available { get; set; }
        public HttpPostedFile ImageFile { get; set; }

    }
    public class driverBE
    {


        public string driverid { get; set; }
        public string drivername { get; set; }
        public string phonenum { get; set; }


    }
}

