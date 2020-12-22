using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class OrderProduct
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public Order Order { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }
    }
}
