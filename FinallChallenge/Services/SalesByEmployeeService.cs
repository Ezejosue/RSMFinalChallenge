using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;

namespace FinallChallenge.Services
{
    public class SalesByEmployeeService : ISalesByEmployeeService
    {
        private readonly ISalesByEmployeeRepository _salesByEmployeeRepository;

        public SalesByEmployeeService(ISalesByEmployeeRepository salesByEmployeeRepository)
        {
            _salesByEmployeeRepository = salesByEmployeeRepository;
        }

        public async Task<List<SalesByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize)
        {
            return await _salesByEmployeeRepository.GetSalesByEmployee(startDate, endDate, employee, product, page, pageSize);
        }
    }
}
