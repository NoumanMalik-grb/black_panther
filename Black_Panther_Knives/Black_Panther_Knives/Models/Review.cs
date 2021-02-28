namespace Black_Panther_Knives.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        [Key]
        public int Review_id { get; set; }

        public int Reviews_Star { get; set; }

        [Required]
        public string Review_msg { get; set; }

        public int Product_Fid { get; set; }

        public int? Account_Fid { get; set; }

        [StringLength(50)]
        public string Customer_Name { get; set; }

        [StringLength(50)]
        public string Customer_Email { get; set; }

        public virtual Account Account { get; set; }

        public virtual Product Product { get; set; }
    }
}
