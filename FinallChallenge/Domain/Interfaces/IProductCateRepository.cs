using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    // Defines the contract for a repository that handles data operations for product categories.
    public interface IProductCateRepository
    {
        // Method to retrieve all product categories from the data source.
        // Returns a task that, when completed, provides an enumerable collection of ProductCategory objects.
        Task<IEnumerable<ProductCategory>> GetProducts();
    }
}
