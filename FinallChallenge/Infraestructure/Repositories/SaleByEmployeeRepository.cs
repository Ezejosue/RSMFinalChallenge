using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    /// <summary>
    /// Repository for accessing sales data by employee.
    /// </summary>
    public class SaleByEmployeeRepository : ISaleByEmployeeRepository
    {
        private readonly AdvWorksDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleByEmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SaleByEmployeeRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

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
        public async Task<List<SaleByEmployee>> GetSalesByEmployee(string? startDate, string? endDate, string? employee, string? product, int? page, int? pageSize)
        {
            var startDateParam = new SqlParameter("@StartDate", startDate ?? (object)DBNull.Value);
            var endDateParam = new SqlParameter("@EndDate", endDate ?? (object)DBNull.Value);
            var employeeParam = new SqlParameter("@Employee", employee ?? (object)DBNull.Value);
            var productParam = new SqlParameter("@Product", product ?? (object)DBNull.Value);
            var pageNumberParam = new SqlParameter("@PageNumber", page ?? (object)DBNull.Value);
            var pageSizeParam = new SqlParameter("@PageSize", pageSize ?? (object)DBNull.Value);


            return await _context.Set<SaleByEmployee>()
                .FromSqlRaw("EXEC SalesByEmployee @StartDate, @EndDate, @Employee, @Product, @PageNumber, @PageSize",
                startDateParam, endDateParam, employeeParam, productParam, pageNumberParam, pageSizeParam)
                .ToListAsync();
        }

    }
}
