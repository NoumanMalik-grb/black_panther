namespace Black_Panther_Knives.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Detail = new HashSet<Order_Detail>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_Purchase_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_Sale_Price { get; set; }

        public int Sub_cat_Fid { get; set; }

        
        [StringLength(500)]
        public string Product_PIc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Discount { get; set; }

        public string product_discription { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string Main_Discription { get; set; }

        public string Product_pic2 { get; set; }

        public string Product_pic3 { get; set; }

        public string Product_pic4 { get; set; }

        public string Product_pic5 { get; set; }
        [NotMapped]
        public int Quantity { get; set; }

        [StringLength(50)]
        public string isbestsell { get; set; }

        [StringLength(50)]
        public string IsTopRated { get; set; }

        public string Product_Tags { get; set; }
        public string Youtube_Link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        public virtual Sub_Category Sub_Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
