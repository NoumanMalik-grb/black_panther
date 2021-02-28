namespace Black_Panther_Knives.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        [Key]
        public int order_id { get; set; }

        
        [StringLength(50)]
        public string Order_First_Name { get; set; }

        
        [StringLength(50)]
        public string Order_Last_name { get; set; }

        
        [StringLength(50)]
        public string Order_Email { get; set; }

        
        [StringLength(50)]
        public string Order_Phone { get; set; }

        [StringLength(50)]
        public string Order_Company { get; set; }

        
        [StringLength(50)]
        public string Order_Country { get; set; }

        
        public string order_Street_Address { get; set; }

        public string Order_Appartment { get; set; }

        
        [StringLength(50)]
        public string Order_City { get; set; }

        public int? Order_Postel { get; set; }

        
        [StringLength(50)]
        public string Order_State { get; set; }

        public DateTime? Order_Date { get; set; }

        [StringLength(50)]
        public string Order_Status { get; set; }

        [StringLength(50)]
        public string order_payment_status { get; set; }

        public int? Acount_fid { get; set; }

        public string Order_Note { get; set; }

        [StringLength(50)]
        public string order_type { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
