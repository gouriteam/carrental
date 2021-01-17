using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

    }
    public class driverBE
    {


        public string driverid { get; set; }
        public string drivername { get; set; }
        public string phonenum { get; set; }


     }
    public class bookingBE
    {

        public string bookingid { get; set; }
        public string custid { get; set; }
        public string carid { get; set; }
        public string driverid { get; set; }

        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public double totalprice { get; set; }
        public string fromroute { get; set; }
        public string toroute { get; set; }
        public bool status { get; set; }


    }

    public class CustomerBE
    {
        [RegularExpression("CH[0-9][0-9][0-9][0-9]",ErrorMessage ="Customer id should start with CH and have 4 digits")]
        public string custid { get; set; }

        [Required(ErrorMessage = "Password cannot be left blank")]
        public string pwd { get; set; }

        [Required(ErrorMessage = "Confirm password is Required")]
        [Compare("pwd")]
        public string confirmpassword { get; set; }

        [Required(ErrorMessage = "Enter your name")]
        public string custname { get; set; }

        [Required(ErrorMessage = "Choose your gender")]
        public string gender { get; set; }

        [Range(typeof(DateTime), "1-1-1920", "1-1-2021", ErrorMessage = "Choose Valid Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("([0-9]{10})", ErrorMessage = "Invalid Mobile Number.")]
        public string phonenum { get; set; }

        [Required(ErrorMessage = "Must be valid email")]
        [RegularExpression("[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+.[a-zA-Z0-9_.-]")]
        public string email { get; set; }
    }

    public class feedbackBE
    {
        public string id { get; set; }
        public string bookingid { get; set; }
        public string comments { get; set; }
        public int rating { get; set; }
    }
    }
   


   


    


