using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TokenJWTWebAPi.Model
{
    public class OrderDetails
    {
        [Key]
        public int? OrderID { get; set; }

        [Key]
        public int? ProductID { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
        public float? Discount { get; set; }

   
    }
}
