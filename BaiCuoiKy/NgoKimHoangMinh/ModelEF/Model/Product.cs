namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int product_id { get; set; }

        [Display(Name = "Danh Mục")]
        public int? category_id { get; set; }
        

        [Required]
        [StringLength(255)]
        [Display(Name = "Sản Phẩm")]

        public string product_name { get; set; }
        
        [Display(Name = "Đơn Giá")]
        public decimal product_unicost { get; set; }

        [Display(Name = "Số Lượng")]
        public int product_quantity { get; set; }

        [StringLength(255)]
        [Display(Name = "Kích Cỡ")]
        public string product_size { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình Ảnh")]
        public string product_image { get; set; }

        [StringLength(255)]
        [Display(Name = "Mô Tả")]
        public string product_des { get; set; }

        [Display(Name = "Trạng Thái")]
        public int product_status { get; set; }

        public virtual CategoryProduct CategoryProduct { get; set; }
    }
}
