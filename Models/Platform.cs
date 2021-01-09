using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class Platform
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 5)]
        [Display(Name = "Platform Name")]
        public string PlatformName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9+_.-]+.[a-z]+$", ErrorMessage = "Enter a valid url"), Required, StringLength(50,MinimumLength = 5)]
        [Display(Name = "Platform Address")]
        public string PlatformAdress { get; set; }
    }
}
