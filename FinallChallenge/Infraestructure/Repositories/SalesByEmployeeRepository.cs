using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    public class SalesByEmployeeRepository : ISalesByEmployeeRepository
    {
        private readonly AdvWorksDbContext _context;

        public SalesByEmployeeRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize)
        {
            var startDateParam = new SqlParameter("@StartDate", startDate ?? (object)DBNull.Value);
            var endDateParam = new SqlParameter("@EndDate", endDate ?? (object)DBNull.Value);
            var employeeParam = new SqlParameter("@Employee", employee ?? (object)DBNull.Value);
            var productParam = new SqlParameter("@Product", product ?? (object)DBNull.Value);
            var pageNumberParam = new SqlParameter("@PageNumber", page ?? (object)DBNull.Value);
            var pageSizeParam = new SqlParameter("@PageSize", pageSize ?? (object)DBNull.Value);


            return await _context.Set<SalesByEmployee>()
                .FromSqlRaw("EXEC SalesByEmployee @StartDate, @EndDate, @Employee, @Product, @PageNumber, @PageSize", 
                startDateParam, endDateParam, employeeParam, productParam, pageNumberParam, pageSizeParam)
                .ToListAsync();
        }

    }
}
