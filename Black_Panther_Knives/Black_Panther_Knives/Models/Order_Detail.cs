namespace Black_Panther_Knives.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Detail
    {
        [Key]
        public int Order_detail_id { get; set; }

        public int product_fid { get; set; }

        public int Order_fid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal od_purchase_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Od_Sale_Price { get; set; }

        [StringLength(50)]
        public string discount_value { get; set; }

        public int ORDER_QUANTITY { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
