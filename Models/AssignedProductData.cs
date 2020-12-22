using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class AssignedProductData
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Assigned { get; set; }
    }
}
