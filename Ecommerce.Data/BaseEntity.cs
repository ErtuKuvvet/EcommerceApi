namespace Ecommerce.Data;

public abstract class BaseEntity
{
    public int Id { get; set; }
    
    // Zorunlu alan: Oluşturulma Tarihi
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Zorunlu alan: Güncellenme Tarihi (Boş olabilir)
    public DateTime? UpdatedAt { get; set; }
}