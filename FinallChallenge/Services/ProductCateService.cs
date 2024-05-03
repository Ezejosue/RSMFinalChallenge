using FinallChallenge.Domain.Interfaces;
using FinallChallenge.DTOs;

namespace FinallChallenge.Services
{
    /// <summary>
    /// Service for managing product categories.
    /// </summary>
    public class ProductCateService : IProductCateService
    {
        private readonly IProductCateRepository _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCateService"/> class.
        /// </summary>
        /// <param name="service">The product category repository.</param>
        public ProductCateService(IProductCateRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves product categories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of GetProductCateDto objects.</returns>
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