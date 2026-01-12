using Ecommerce.Service.Services;
using Ecommerce.Data; // AppDbContext'i tanimasi icin
using Microsoft.EntityFrameworkCore; // UseSqlite'i tanimasi icin

var builder = WebApplication.CreateBuilder(args);

// --- 1. Servislerin Eklendigi Bölüm ---

// Swagger servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabani Baglantisi (SQLite)
// "Data Source=app.db" diyerek projenin ana klasorunde app.db adinda bir dosya olusturacagini soyluyoruz.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();

// --- 2. HTTP Istek Boru Hatti (Pipeline) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();