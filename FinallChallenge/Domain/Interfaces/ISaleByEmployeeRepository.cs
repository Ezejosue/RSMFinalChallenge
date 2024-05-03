using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    // Interface for a repository that handles data operations related to sales filtered by employee details.
    public interface ISaleByEmployeeRepository
    {
        // Retrieves sales data filtered by various parameters.
        // Parameters include optional start and end dates, employee name, product name,
        // and pagination details such as page number and page size.
        // Returns a task that resolves to a list of SaleByEmployee objects,
        // each representing sales data associated with a specific employee.
        Task<List<SaleByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize);
    }
}
