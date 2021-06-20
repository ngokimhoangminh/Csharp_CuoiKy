namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryProduct")]
    public partial class CategoryProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryProduct()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int category_id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Danh Mục")]
        public string category_name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Mô Tả")]
        public string category_des { get; set; }

        [Display(Name = "Trạng Thái")]
        public int category_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
