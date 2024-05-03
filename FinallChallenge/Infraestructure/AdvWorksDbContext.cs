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

        public DbSet<SaleReport> SalesReports { get; set; }
        public DbSet<SaleByEmployee> SalesByEmployees { get; set; }
        public DbSet<ProductCategory> Products { get; set; }
        public DbSet<SaleTerritory> SalesTerritories { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<SaleReport>().HasNoKey();
            modelBuilder.Entity<SaleByEmployee>().HasNoKey();
        }

     
    }
}
