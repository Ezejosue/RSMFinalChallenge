using FinallChallenge.Domain.Interfaces;
using FinallChallenge.DTOs;

namespace FinallChallenge.Services
{
    public class ProductCateService : IProductCateService
    {
        private readonly IProductCateRepository _service;

        public ProductCateService(IProductCateRepository service)
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
