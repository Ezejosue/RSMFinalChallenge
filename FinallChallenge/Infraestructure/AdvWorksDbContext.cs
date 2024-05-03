namespace FinallChallenge.Infraestructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Reflection;
    using FinallChallenge.Domain.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public class AdvWorksDbContext : DbContext
    {
        public AdvWorksDbContext()
        {
        }

        public AdvWorksDbContext(DbContextOptions<AdvWorksDbContext> options)
            : base(options)
        {
        }

        public DbSet<SalesReport> SalesReports { get; set; }
        public DbSet<SalesByEmployee> SalesByEmployees { get; set; }
        public DbSet<ProductCategory> Products { get; set; }
        public DbSet<SalesTerritory> SalesTerritories { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<SalesReport>().HasNoKey();
            modelBuilder.Entity<SalesByEmployee>().HasNoKey();
        }

     
    }
}
