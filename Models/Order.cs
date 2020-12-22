using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public decimal OrderPrice { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        
    }
}
