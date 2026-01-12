namespace Ecommerce.Data;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // İlişki: Bir kategorinin içinde birden fazla ürün olabilir (One-to-Many)
    // Şimdilik burayı da yorum satırı yapıyoruz, Product'ı yazınca açacağız.
    public List<Product> Products { get; set; } = new();
}