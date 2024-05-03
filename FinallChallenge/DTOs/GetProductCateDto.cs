namespace FinallChallenge.DTOs
{
    /// <summary>
    /// Data transfer object for product categories.
    /// </summary>
    public class GetProductCateDto
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
