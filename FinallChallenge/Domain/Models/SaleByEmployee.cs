namespace FinallChallenge.Domain.Models
{
    /// <summary>
    /// Represents sales data associated with an employee.
    /// </summary>
    public class SaleByEmployee
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the product category.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets the number of sales.
        /// </summary>
        public int SalesCount { get; set; }

        /// <summary>
        /// Gets or sets the average unit price.
        /// </summary>
        public decimal AvgUnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total sales amount.
        /// </summary>
        public decimal TotalSales { get; set; }

        /// <summary>
        /// Gets or sets the date of the first sale.
        /// </summary>
        public DateTime FirstSaleDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the last sale.
        /// </summary>
        public DateTime LastSaleDate { get; set; }
    }
}
