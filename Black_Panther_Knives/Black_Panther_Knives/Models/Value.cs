namespace Black_Panther_Knives.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Value
    {
        public int id { get; set; }

        public int Happy_Clients { get; set; }

        public int Awards { get; set; }

        public int Years_Experience { get; set; }

        public int Fourth_Amount { get; set; }
    }
}
