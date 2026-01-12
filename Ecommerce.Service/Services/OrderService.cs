namespace Ecommerce.Service.Services;

using Ecommerce.Data;
using Ecommerce.Service.DTOs;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<OrderDto>> CreateOrderAsync(CreateOrderDto dto)
    {
        // 1. Ürünü bul
        var product = await _context.Products.FindAsync(dto.ProductId);
        if (product == null)
            return ServiceResponse<OrderDto>.ErrorResponse("Ürün bulunamadı!");

        // 2. Stok kontrolü yap
        if (product.Stock < dto.Quantity)
            return ServiceResponse<OrderDto>.ErrorResponse("Yetersiz stok! Mevcut stok: " + product.Stock);

        // 3. Stoğu düş
        product.Stock -= dto.Quantity;

        // 4. Siparişi oluştur
        var newOrder = new Order
        {
            UserId = dto.UserId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            TotalPrice = product.Price * dto.Quantity,
            
            // DÜZELTİLEN KISIM: Artık CreateDate değil, CreatedAt kullanıyoruz
            CreatedAt = DateTime.Now 
        };

        _context.Orders.Add(newOrder);
        await _context.SaveChangesAsync(); 

        // 5. Cevap hazırla
        var responseDto = new OrderDto
        {
            Id = newOrder.Id,
            ProductName = product.Name,
            Price = product.Price,
            Quantity = newOrder.Quantity,
            TotalPrice = newOrder.TotalPrice,
            
            // DÜZELTİLEN KISIM: Burada da CreatedAt kullanıyoruz
            OrderDate = newOrder.CreatedAt 
        };

        return ServiceResponse<OrderDto>.SuccessResponse(responseDto, "Sipariş başarıyla oluşturuldu.");
    }

    public async Task<ServiceResponse<List<OrderDto>>> GetAllOrdersAsync()
    {
        var orders = await _context.Orders
            .Include(x => x.Product)
            .ToListAsync();

        var dtos = orders.Select(o => new OrderDto
        {
            Id = o.Id,
            ProductName = o.Product != null ? o.Product.Name : "Silinmiş Ürün",
            Price = o.Product != null ? o.Product.Price : 0,
            Quantity = o.Quantity,
            TotalPrice = o.TotalPrice,
            
            // DÜZELTİLEN KISIM: Burada da CreatedAt
            OrderDate = o.CreatedAt 
        }).ToList();

        return ServiceResponse<List<OrderDto>>.SuccessResponse(dtos);
    }
}