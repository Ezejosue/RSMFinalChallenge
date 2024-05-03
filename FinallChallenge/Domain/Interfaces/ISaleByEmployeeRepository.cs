using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISaleByEmployeeRepository
    {
        Task<List<SaleByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize);
    }
}
