namespace Ecommerce.Data;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;     // Controller bunu arıyordu
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; // Controller bunu arıyordu
    public string Role { get; set; } = "Customer";       // Rol yönetimi için
}