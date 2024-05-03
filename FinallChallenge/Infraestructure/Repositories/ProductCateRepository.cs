using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    public class ProductCateRepository : IProductsCateRepository
    {
        private readonly AdvWorksDbContext _context;

        public ProductCateRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetProducts()
        {

            return await _context.Set<ProductCategory>().AsNoTracking().ToListAsync();
        }
    }
}
