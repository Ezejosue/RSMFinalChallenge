using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;

namespace FinallChallenge.Domain.Interfaces
{
    public interface IProductCateService
    {
        Task<IEnumerable<GetProductCateDto>> GetProducts();
    }
}

