using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cristutiu_Andreea_Proiect.Data;
using Cristutiu_Andreea_Proiect.Models;

namespace Cristutiu_Andreea_Proiect.Pages.Orders
{
    public class CreateModel : OrderProductsPageModel
    {
        private readonly Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext _context;

        public CreateModel(Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "CustomerName");
            var order = new Order();
            order.OrderProducts = new List<OrderProduct>();
            PopulateAssignedProductData(_context, order);
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedProducts)
        {
            var newOrder = new Order();
            decimal tot = 0;
            if (selectedProducts != null)
            {
                newOrder.OrderProducts = new List<OrderProduct>();
                foreach (var prod in selectedProducts)
                {
                    string[] v= prod.Split('-');
                    var prodToAdd = new OrderProduct
                    {
                        ProductID = int.Parse(v[0])

                    };
                    newOrder.OrderProducts.Add(prodToAdd);
                    tot += decimal.Parse(v[1]);
                }
                
                newOrder.OrderPrice = tot;
                
            }
            
            if (await TryUpdateModelAsync<Order>(
            newOrder,
            "Order", i => i.CustomerID))
            { 

                _context.Order.Add(newOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedProductData(_context, newOrder);
            return Page();
        }
    }
}
