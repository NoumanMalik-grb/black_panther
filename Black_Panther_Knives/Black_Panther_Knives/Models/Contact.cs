namespace Black_Panther_Knives.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int Contact_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact_Email { get; set; }

        [Required]
        public string Contact_Message { get; set; }

        public DateTime Contact_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
