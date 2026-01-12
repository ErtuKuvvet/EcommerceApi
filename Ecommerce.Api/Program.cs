using Ecommerce.Data;                 // Veritabanı context'i için
using Ecommerce.Service.Services;     // Servislerimizi tanıtmak için (Product, Category, Order)
using Microsoft.EntityFrameworkCore;  // SQL ayarları için

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------------
// 1. SERVİSLERİN EKLENDİĞİ BÖLÜM (Konfigürasyon)
// --------------------------------------------------------

// Controller desteğini açıyoruz (API uçları için şart)
builder.Services.AddControllers();

// Swagger (API Dokümantasyonu) ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı Bağlantısı (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// --- KENDİ YAZDIĞIMIZ SERVİSLERİ BURADA TANITIYORUZ ---
// (Sırasıyla: Ürün, Kategori ve Sipariş servisleri)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// --------------------------------------------------------

var app = builder.Build();

// --------------------------------------------------------
// 2. ÇALIŞMA ZAMANI AYARLARI (Middleware)
// --------------------------------------------------------

// Geliştirme modundaysak Swagger'ı göster
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Controller'ları haritala (İstekleri yönlendir)
app.MapControllers();

app.Run();