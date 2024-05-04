using FinallChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    // Controller for handling API requests related to sales reports.
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        // A service that provides data access operations for sales reports.
        private readonly ISaleService _salesreport;

        // Constructor that injects the sales report service into the controller.
        public SalesReportController(ISaleService salesreport)
        {
            _salesreport = salesreport;
        }

        // HTTP GET method to retrieve sales report data.
        // This endpoint uses query parameters to filter sales data based on various criteria.
        /// <summary>
        /// Gets all sales 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSalesData(
            [FromQuery] string categoryFilter,    // Required query parameter for category filter.
            [FromQuery] string? regionFilter,     // Optional query parameter for region filter.
            [FromQuery] string? StartDate,        // Optional query parameter for start date of the reporting period.
            [FromQuery] string? EndDate,          // Optional query parameter for end date of the reporting period.
            [FromQuery] int? page,                // Optional query parameter for pagination - specifies the page number.
            [FromQuery] int? pageSize)            // Optional query parameter for pagination - specifies the page size.
        {
            try
            {
                // Retrieves sales data filtered by the provided parameters from the sales service.
                var salesData = await _salesreport.GetSalesDataByFilterAsync(categoryFilter, regionFilter, StartDate, EndDate, page, pageSize);
                // Returns the filtered sales data with a 200 OK status if successful.
                return Ok(salesData);
            }
            catch (Exception ex)
            {
                // Returns a 500 Internal Server Error status with the exception message in case of failure.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
