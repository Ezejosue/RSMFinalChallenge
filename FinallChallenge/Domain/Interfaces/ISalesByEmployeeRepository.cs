using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISalesByEmployeeRepository
    {
        Task<List<SalesByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize);
    }
}
