using FinallChallenge.DTOs;

namespace FinallChallenge.Domain.Interfaces
{
    // Interface defining the contract for a service handling business logic for product categories.
    public interface IProductCateService
    {
        // Method to retrieve all product categories.
        // Returns a task that, when completed, provides an enumerable collection of GetProductCateDto objects,
        // which are data transfer objects containing the detailed information of product categories.
        Task<IEnumerable<GetProductCateDto>> GetProducts();
    }
}

