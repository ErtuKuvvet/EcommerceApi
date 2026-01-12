namespace Ecommerce.Service.DTOs;

// Kullanıcıya göstereceğimiz hali (Response)
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; } = string.Empty; // ID yerine ismini göstereceğiz!
}

// Kullanıcıdan ürün eklerken isteyeceğimiz hali (Create)
public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; } // Kullanıcı sadece ID gönderir
}