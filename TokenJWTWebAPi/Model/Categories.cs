using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TokenJWTWebAPi.Model
{
    public class Categories
    {
        [Key]
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte? Picture { get; set; }



    }
}
