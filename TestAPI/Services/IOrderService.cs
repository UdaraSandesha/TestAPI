using TestAPI.Dtos;
using TestAPI.Requests;

namespace TestAPI.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderByIdAsync(string id);
        Task<OrderDTO> UpdateOrderAsync(string id, UpdateOrderRequest request);
    }
}
