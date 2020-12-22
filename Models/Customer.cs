using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
         
        public string CustomerEmail { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
