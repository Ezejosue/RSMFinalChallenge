using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;

namespace FinallChallenge.Services
{
    public class SaleByEmployeeService : ISaleByEmployeeService
    {
        private readonly ISaleByEmployeeRepository _salesByEmployeeRepository;

        public SaleByEmployeeService(ISaleByEmployeeRepository salesByEmployeeRepository)
        {
            _salesByEmployeeRepository = salesByEmployeeRepository;
        }

        public async Task<List<SaleByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize)
        {
            return await _salesByEmployeeRepository.GetSalesByEmployee(startDate, endDate, employee, product, page, pageSize);
        }
    }
}
