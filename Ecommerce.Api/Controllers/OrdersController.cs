namespace Ecommerce.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Services;
using Ecommerce.Service.DTOs;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET: Tüm siparişleri getir
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _orderService.GetAllOrdersAsync();
        return Ok(result);
    }

    // POST: Yeni sipariş oluştur
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto order)
    {
        var result = await _orderService.CreateOrderAsync(order);
        if (!result.Success)
        {
            return BadRequest(result); // Hata varsa (stok yoksa) kırmızı uyarı ver
        }
        return Ok(result);
    }
}