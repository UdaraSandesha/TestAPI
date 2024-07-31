using Microsoft.AspNetCore.Mvc;
using TestAPI.Dtos;
using TestAPI.Requests;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly HttpClient _httpClient;

        public OrdersController(IOrderService orderService, HttpClient httpClient)
        {
            _orderService = orderService;
            _httpClient = httpClient;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(string id, [FromBody] UpdateOrderRequest request)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var updatedOrder = await _orderService.UpdateOrderAsync(id, request);
            return Ok(updatedOrder);
        }

        [HttpGet("file")]
        public async Task<FileStreamResult> GetFile()
        {
            var externalApiUrl = "";
            var response = await _httpClient.GetAsync(externalApiUrl);

            if (!response.IsSuccessStatusCode)
            {
                // return relavant statuscode
            }

            var stream = await response.Content.ReadAsStreamAsync();
            return File(stream, response.Content.Headers.ContentType.ToString(), "fileName");
        }
    }
}
