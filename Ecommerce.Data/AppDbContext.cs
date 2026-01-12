namespace Ecommerce.Data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Veritabanı ayarlarını dışarıdan (Program.cs'ten) alabilmek için bu constructor lazım
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Hangi tablolar veritabanında oluşsun?
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
}