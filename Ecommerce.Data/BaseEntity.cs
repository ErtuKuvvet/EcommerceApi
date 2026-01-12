namespace Ecommerce.Data;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Otomatik tarih atar
    public DateTime? UpdatedAt { get; set; } // Boş olabilir (nullable)
}