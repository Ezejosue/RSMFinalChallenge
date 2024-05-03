using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    /// <summary>
    /// Interface for retrieving sales data by employee.
    /// </summary>
    public interface ISaleByEmployeeService
    {
        /// <summary>
        /// Retrieves sales data filtered by specified parameters.
        /// </summary>
        /// <param name="startDate">Optional parameter indicating the start date for filtering the sales data.</param>
        /// <param name="endDate">Optional parameter indicating the end date for filtering the sales data.</param>
        /// <param name="employee">Optional parameter specifying the name of the employee for whom sales data is to be retrieved.</param>
        /// <param name="product">Optional parameter specifying the name of the product for which sales data is to be retrieved.</param>
        /// <param name="page">Optional parameter indicating the page number for pagination.</param>
        /// <param name="pageSize">Optional parameter specifying the number of items per page for pagination.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of SaleByEmployee objects.</returns>
        Task<List<SaleByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize);
    }
}
