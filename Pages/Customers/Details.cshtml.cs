using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristutiu_Andreea_Proiect.Data;
using Cristutiu_Andreea_Proiect.Models;

namespace Cristutiu_Andreea_Proiect.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext _context;

        public DetailsModel(Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
