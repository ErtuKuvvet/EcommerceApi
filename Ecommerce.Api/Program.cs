using Ecommerce.Data;
using Ecommerce.Service.Services; // Servisler için
using Ecommerce.Service.DTOs;     // DTO'lar için
using Microsoft.EntityFrameworkCore;
using Ecommerce.Api.Middlewares;  // Hata yakalama middleware'i için

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------------
// 1. SERVİSLERİN EKLENDİĞİ BÖLÜM (DI Container)
// --------------------------------------------------------

// Controller desteği (Products ve Orders için hala lazım)
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Kendi Servislerimiz
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// --------------------------------------------------------
// 2. MIDDLEWARE (Ara Katmanlar)
// --------------------------------------------------------

// Kendi yazdığımız Hata Yakalayıcı (Global Exception Handler)
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Klasik Controller'ları haritala (Products ve Orders buradan çalışır)
app.MapControllers();

// --------------------------------------------------------
// 3. MINIMAL API ENDPOINTLERİ (Sadece Kategoriler İçin)
// --------------------------------------------------------
// Hocanın istediği "Minimal API" şartını burada sağlıyoruz.
// Artık CategoriesController yok, rotalar burada:

// GET: Tüm Kategorileri Getir
app.MapGet("/api/categories", async (ICategoryService service) =>
{
    var result = await service.GetAllCategoriesAsync();
    return Results.Ok(result);
})
.WithTags("Categories"); // Swagger'da "Categories" başlığı altında görünsün diye

// POST: Yeni Kategori Ekle
app.MapPost("/api/categories", async (ICategoryService service, CreateCategoryDto dto) =>
{
    var result = await service.CreateCategoryAsync(dto);
    
    // 201 Created Dönüyoruz (Ödev Şartı)
    return Results.Created($"/api/categories/{result.Data!.Id}", result);
})
.WithTags("Categories");

// --------------------------------------------------------

app.Run();