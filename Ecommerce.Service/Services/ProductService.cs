namespace Ecommerce.Service.Services;

using Ecommerce.Data;
using Ecommerce.Service.DTOs;
using Microsoft.EntityFrameworkCore; // Bu kütüphane .Include() için şart

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // 1. Ürün Ekleme Metodu
    public async Task<ServiceResponse<ProductDto>> CreateProductAsync(CreateProductDto dto)
    {
        var newProduct = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            IsDeleted = false
        };

        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();

        var responseDto = new ProductDto
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Price = newProduct.Price,
            Stock = newProduct.Stock,
            CategoryName = "Listeleme ekranında görünecek" 
        };

        return ServiceResponse<ProductDto>.SuccessResponse(responseDto, "Ürün başarıyla eklendi");
    }

    // 2. Tüm Ürünleri Getirme Metodu (GÜNCELLENEN KISIM)
    public async Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync()
    {
       //throw new Exception("TEST HATASI: Bakalım sistem yakalayacak mı?");
        
        // Include(x => x.Category) diyerek veritabanından kategori ismini de çekiyoruz (JOIN)
        var products = await _context.Products
            .Include(p => p.Category) 
            .ToListAsync();

        var dtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            // Eğer kategori varsa ismini yaz, yoksa 'Kategori Yok' yaz
            CategoryName = p.Category != null ? p.Category.Name : "Kategori Yok"
        }).ToList();

        return ServiceResponse<List<ProductDto>>.SuccessResponse(dtos);
    }
}