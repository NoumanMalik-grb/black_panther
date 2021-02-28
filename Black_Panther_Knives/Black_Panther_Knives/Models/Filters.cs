using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Black_Panther_Knives.Models
{
    public class Filters
    {
        public DateTime? Date_From { get; set; }
        public DateTime? Date_To { get; set; }
        public int? Category { get; set; }
        public int? Product { get; set; }
    }
}