using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinallChallenge.Infraestructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory), "Production");

            builder.HasKey(e => e.ProductCategoryID);
            builder.Property(e => e.ProductCategoryID).HasColumnName("ProductCategoryID");
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
