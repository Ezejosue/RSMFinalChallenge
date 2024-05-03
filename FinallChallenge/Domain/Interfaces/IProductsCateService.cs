using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;

namespace FinallChallenge.Domain.Interfaces
{
    public interface IProductsCateService
    {
        Task<IEnumerable<GetProductCateDto>> GetProducts();
    }
}

