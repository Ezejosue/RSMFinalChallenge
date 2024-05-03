using FinallChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    // Defines a controller for handling API requests related to sales data by employees.
    [Route("api/[controller]")]
    [ApiController]
    public class SalesByEmployeeController : ControllerBase
    {
        // A service that provides operations related to sales by employees.
        private readonly ISaleByEmployeeService _salesByEmployeeService;

        // Constructor that injects a sales by employee service into the controller.
        public SalesByEmployeeController(ISaleByEmployeeService service)
        {
            _salesByEmployeeService = service;
        }

        // HTTP GET method to retrieve sales data filtered by various parameters.
        // This endpoint accepts optional query parameters for filtering the data.
        [HttpGet]
        public async Task<IActionResult> GetSalesByEmployeeAsync(
            [FromQuery] string? startDate, // Optional query parameter for the start date filter.
            [FromQuery] string? endDate,   // Optional query parameter for the end date filter.
            [FromQuery] string? employee,  // Optional query parameter to filter by employee.
            [FromQuery] string? product,   // Optional query parameter to filter by product.
            [FromQuery] int? page,         // Optional query parameter for pagination - specifies the page number.
            [FromQuery] int? pageSize)     // Optional query parameter for pagination - specifies the page size.
        {
            try
            {
                // Calls the service method to get filtered sales data based on provided parameters.
                var SalesByEmployee = await _salesByEmployeeService.GetSalesByEmployee(startDate, endDate, employee, product, page, pageSize);
                // Returns the filtered sales data with a 200 OK status if successful.
                return Ok(SalesByEmployee);
            }
            catch (Exception ex)
            {
                // Returns a 500 Internal Server Error status with the exception message in case of failure.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
