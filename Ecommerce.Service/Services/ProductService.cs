namespace Ecommerce.Service.Services;

using Ecommerce.Data;
using Ecommerce.Service.DTOs;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    // Veritabanı bağlantısını buraya çağırıyoruz (Constructor Injection)
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // 1. Ürün Ekleme Metodu
    public async Task<ServiceResponse<ProductDto>> CreateProductAsync(CreateProductDto dto)
    {
        // Gelen DTO'yu Veritabanı Nesnesine (Entity) çevir
        var newProduct = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            IsDeleted = false
        };

        // Veritabanına ekle ve kaydet
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();

        // Geriye döndürmek için tekrar DTO'ya çevir
        var responseDto = new ProductDto
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Price = newProduct.Price,
            Stock = newProduct.Stock,
            CategoryName = "Şimdilik Yok" // Kategoriyi sonra bağlayacağız
        };

        return ServiceResponse<ProductDto>.SuccessResponse(responseDto, "Ürün başarıyla eklendi");
    }

    // 2. Tüm Ürünleri Getirme Metodu
    public async Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync()
    {
        // Veritabanından tüm ürünleri çek
        var products = await _context.Products.ToListAsync();

        // Entity listesini DTO listesine çevir
        var dtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryName = "Kategori Yok"
        }).ToList();

        return ServiceResponse<List<ProductDto>>.SuccessResponse(dtos);
    }
}