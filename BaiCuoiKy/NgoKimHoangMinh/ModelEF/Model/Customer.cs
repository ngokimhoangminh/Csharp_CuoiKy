namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        public int customer_id { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_name { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_email { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_address { get; set; }

        [Required]
        [StringLength(50)]
        public string customer_password { get; set; }

        [StringLength(255)]
        public string customer_phone { get; set; }
    }
}
