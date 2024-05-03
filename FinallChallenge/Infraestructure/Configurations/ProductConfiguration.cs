using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinallChallenge.Infraestructure.Configurations
{
    /// <summary>
    /// Configuration for the ProductCategory entity.
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        /// <summary>
        /// Configures the ProductCategory entity.
        /// </summary>
        /// <param name="builder">The entity type builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            // Table name and schema
            builder.ToTable(nameof(ProductCategory), "Production");

            // Primary key
            builder.HasKey(e => e.ProductCategoryID);

            // Column mappings
            builder.Property(e => e.ProductCategoryID).HasColumnName("ProductCategoryID");
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
