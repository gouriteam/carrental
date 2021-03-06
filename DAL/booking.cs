//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public booking()
        {
            this.feedbacks = new HashSet<feedback>();
        }
    
        public string bookingid { get; set; }
        public string custid { get; set; }
        public string carid { get; set; }
        public string driverid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public Nullable<double> totalprice { get; set; }
        public string fromroute { get; set; }
        public string toroute { get; set; }
        public bool status { get; set; }
    
        public virtual vehicle vehicle { get; set; }
        public virtual registration registration { get; set; }
        public virtual driver driver { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }
    }
}
