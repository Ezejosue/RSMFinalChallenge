using FinallChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    // Defines a controller class in the MVC pattern under the 'api/ProductCate' route.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCateController : ControllerBase
    {
        // Declaration of a service interface to handle product category operations.
        private readonly IProductCateService _productsCateService;

        // Constructor that injects the product category service into the controller.
        public ProductCateController(IProductCateService productsCateService)
        {
            _productsCateService = productsCateService;
        }

        // HTTP GET method to retrieve product categories.
        // Responds to 'GET api/ProductCate' requests.
        [HttpGet]
        public async Task<IActionResult> GetProductsCategory()
        {
            try
            {
                // Attempts to retrieve the product categories from the service.
                var ProductsCategory = await _productsCateService.GetProducts();
                // Returns a 200 OK status code with the product categories data.
                return Ok(ProductsCategory);
            }
            catch (Exception ex)
            {
                // Returns a 500 Internal Server Error status code with the error message.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
