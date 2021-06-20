using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModel
{
    public class ProductModel
    {
        [Required]
        public int product_id { get; set; }
        public string category_name { get; set; }
        public string product_name { get; set; }
        public decimal product_unicost { get; set; }
        public int product_quantity { get; set; }
        public string product_size { get; set; }
        public string product_image { get; set; }
        public string product_des { get; set; } 
        public int product_status { get; set; }
    }
}
