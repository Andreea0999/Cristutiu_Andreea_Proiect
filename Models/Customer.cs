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

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Please enter your full name"), Required, StringLength(50,MinimumLength = 3)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Enter a valid email address"), Required, StringLength(50, MinimumLength = 5)]
        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
