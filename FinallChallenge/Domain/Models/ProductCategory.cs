namespace FinallChallenge.Domain.Models
{
    /// <summary>
    /// Represents a product category.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Gets or sets the ID of the product category.
        /// </summary>
        public int ProductCategoryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product category.
        /// </summary>
        public string? Name { get; set; }
    }
}
