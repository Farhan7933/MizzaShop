namespace ADOMizzaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaToppingStyle")]
    public partial class MizzaToppingStyle
    {
        [Key]
        [StringLength(10)]
        public string ToppingStyleID { get; set; }

        [Required]
        [StringLength(50)]
        public string ToppingName { get; set; }
    }
}
