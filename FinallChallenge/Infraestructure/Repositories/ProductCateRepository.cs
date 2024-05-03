using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    /// <summary>
    /// Repository for accessing product categories.
    /// </summary>
    public class ProductCateRepository : IProductCateRepository
    {
        private readonly AdvWorksDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCateRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ProductCateRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all product categories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of ProductCategory objects.</returns>
        public async Task<IEnumerable<ProductCategory>> GetProducts()
        {

            return await _context.Set<ProductCategory>().AsNoTracking().ToListAsync();
        }
    }
}
