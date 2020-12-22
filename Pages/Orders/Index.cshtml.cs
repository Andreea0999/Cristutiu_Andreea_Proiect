using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristutiu_Andreea_Proiect.Data;
using Cristutiu_Andreea_Proiect.Models;

namespace Cristutiu_Andreea_Proiect.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext _context;

        public IndexModel(Cristutiu_Andreea_Proiect.Data.Cristutiu_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }
        public OrderData OrderD { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public async Task OnGetAsync(int? id, int? productID)
        {
            OrderD = new OrderData();

            OrderD.Orders = await _context.Order
            .Include(b => b.Customer)
            .Include(b => b.OrderProducts)
            .ThenInclude(b => b.Product)
            .AsNoTracking()
            .OrderBy(b => b.ID)
            .ToListAsync();
            if (id != null)
            {
                OrderID = id.Value;
                Order order = OrderD.Orders
                .Where(i => i.ID == id.Value).Single();
                OrderD.Products = order.OrderProducts.Select(s => s.Product);
            }
        }
    }
}
