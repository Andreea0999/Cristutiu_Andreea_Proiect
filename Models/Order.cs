using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Order Price")]
        public decimal OrderPrice { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Order Details")]
        public ICollection<OrderProduct> OrderProducts { get; set; }
        
    }
}
