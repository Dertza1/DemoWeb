using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<CategoryProduct> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProviderProduct> Providers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DemoWeb.db");
        }
    }
}
