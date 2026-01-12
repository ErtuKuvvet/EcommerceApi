namespace Ecommerce.Service.Services;
using Ecommerce.Service.DTOs;

public interface IOrderService
{
    Task<ServiceResponse<List<OrderDto>>> GetAllOrdersAsync();
    Task<ServiceResponse<OrderDto>> CreateOrderAsync(CreateOrderDto orderDto);
}