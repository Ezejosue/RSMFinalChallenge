using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCateController : ControllerBase
    {
        private readonly IProductsCateService _productsCateService;

        public ProductCateController(IProductsCateService productsCateService)
        {
            _productsCateService = productsCateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsCategory()
        {
            try
            {
                var ProductsCategory = await _productsCateService.GetProducts();
                return Ok(ProductsCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
