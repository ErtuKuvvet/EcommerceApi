using Ecommerce.Data;
using Ecommerce.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Servis Ayarları ---

// Controller destegini ekle (YENI EKLENDI)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabani
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Servis Baglantisi (Dependency Injection)
builder.Services.AddScoped<IProductService, ProductService>();
// ProductService'in hemen altina ekle:
builder.Services.AddScoped<ICategoryService, CategoryService>();
var app = builder.Build();

// --- 2. HTTP Pipeline ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Controller rotalarini aktif et (YENI EKLENDI)
app.MapControllers();

app.Run();