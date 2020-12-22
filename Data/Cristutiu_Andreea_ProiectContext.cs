using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cristutiu_Andreea_Proiect.Models;

namespace Cristutiu_Andreea_Proiect.Data
{
    public class Cristutiu_Andreea_ProiectContext : DbContext
    {
        public Cristutiu_Andreea_ProiectContext (DbContextOptions<Cristutiu_Andreea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Cristutiu_Andreea_Proiect.Models.Order> Order { get; set; }

        public DbSet<Cristutiu_Andreea_Proiect.Models.Customer> Customer { get; set; }

        public DbSet<Cristutiu_Andreea_Proiect.Models.Product> Product { get; set; }

        public DbSet<Cristutiu_Andreea_Proiect.Models.Platform> Platform { get; set; }
    }
}
