using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    /// <summary>
    /// Interface for accessing sales data from a repository.
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Retrieves sales data from the repository filtered by specified parameters.
        /// </summary>
        /// <param name="categoryFilter">The category by which to filter the sales data.</param>
        /// <param name="regionFilter">Optional parameter specifying the region by which to filter the sales data.</param>
        /// <param name="StartDate">Optional parameter indicating the start date for filtering the sales data.</param>
        /// <param name="EndDate">Optional parameter indicating the end date for filtering the sales data.</param>
        /// <param name="page">Optional parameter indicating the page number for pagination.</param>
        /// <param name="pageSize">Optional parameter specifying the number of items per page for pagination.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of SaleReport objects.</returns>
        Task<List<SaleReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize);

    }
}
