namespace Ecommerce.Data;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Bonus: Role-Based Auth için (Admin/User ayrımı)
    public string Role { get; set; } = "User"; 

    // İlişkiler (Bir kullanıcının birden çok siparişi olur)
    // Şimdilik burayı yorum satırı yapıyoruz, Order tablosunu yazınca açacağız.
public List<Order> Orders { get; set; } = new();
}