using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;
using FinallChallenge.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Services
{
    public class ProductCateService : IProductsCateService
    {
        private readonly IProductsCateRepository _service;

        public ProductCateService(IProductsCateRepository service)
        {
            _service = service;
        }

        public async Task<IEnumerable<GetProductCateDto>> GetProducts()
        {
            var productCates = await _service.GetProducts();
            List<GetProductCateDto> productCatesDto = new();

            foreach (var productCate in productCates)
            {
                GetProductCateDto dto = new()
                {
                    ProductCategoryID = productCate.ProductCategoryID,
                    Name = productCate.Name
                };
                productCatesDto.Add(dto);
            }

            return productCatesDto;
        }

    }
}
