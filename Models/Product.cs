using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string ProductName { get; set; }
        
        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public int PlatformID { get; set; }

        public Platform Platform { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
