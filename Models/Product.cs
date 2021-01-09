using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cristutiu_Andreea_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 5)]
        [Display(Name = "Course Name")]
        public string ProductName { get; set; }

        [Range(100, 500)]
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Course Price")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Course Description")]
        public string ProductDescription { get; set; }

        public int PlatformID { get; set; }

        public Platform Platform { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
