using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cristutiu_Andreea_Proiect.Data;
using Cristutiu_Andreea_Proiect.Models;

namespace Cristutiu_Andreea_Proiect.Pages.Orders
{
    public class EditModel : OrderProductsPageModel
    {
        private readonly Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext _context;

        public EditModel(Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order.Include(b => b.Customer).Include(b => b.OrderProducts).ThenInclude(b => b.Product).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }
            PopulateAssignedProductData(_context, Order);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "CustomerName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedProducts)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToUpdate = await _context.Order.Include(i => i.Customer).Include(i => i.OrderProducts).ThenInclude(i => i.Product).FirstOrDefaultAsync(s => s.ID == id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Order>(orderToUpdate, "Order", i => i.Customer))
            {
                UpdateOrderProducts(_context, selectedProducts, orderToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care //este editata              
            UpdateOrderProducts(_context, selectedProducts, orderToUpdate);
            PopulateAssignedProductData(_context, orderToUpdate);
            return Page();
        }
    }
} 
