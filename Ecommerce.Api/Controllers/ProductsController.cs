namespace Ecommerce.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Services;
using Ecommerce.Service.DTOs;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    // Servisi buraya enjekte ediyoruz (Dependency Injection)
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products (Tüm ürünleri listele)
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(result); // 200 OK döner
    }

    // POST: api/products (Yeni ürün ekle)
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto product)
    {
        var result = await _productService.CreateProductAsync(product);
        return Ok(result);
    }
}