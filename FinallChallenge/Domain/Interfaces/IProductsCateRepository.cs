using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface IProductsCateRepository
    {
        Task<IEnumerable<ProductCategory>> GetProducts();
    }
}
