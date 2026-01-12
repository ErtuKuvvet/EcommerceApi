namespace Ecommerce.Service.Services;

using Ecommerce.Service.DTOs;

public interface IProductService
{
    // Tüm ürünleri getir
    Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync();
    
    // Yeni ürün ekle
    Task<ServiceResponse<ProductDto>> CreateProductAsync(CreateProductDto product);
}