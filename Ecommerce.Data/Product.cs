namespace Ecommerce.Data;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = string.Empty;

    // Kategori İlişkisi
    public int CategoryId { get; set; }
    public Category? Category { get; set; } // <-- Soru işareti eklendi

    // Soft Delete
    public bool IsDeleted { get; set; } = false;
}