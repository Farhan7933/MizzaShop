namespace APIConsumingIntoMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MizzaSize")]
    public partial class MizzaSize
    {
        [Required]
        [StringLength(50)]
        public string MizzaSizeName { get; set; }

        [StringLength(10)]
        public string MizzaSizeID { get; set; }
    }
}
