using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface IProductCateRepository
    {
        Task<IEnumerable<ProductCategory>> GetProducts();
    }
}
