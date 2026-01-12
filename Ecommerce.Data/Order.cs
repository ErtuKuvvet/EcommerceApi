namespace Ecommerce.Data;

public class Order : BaseEntity
{
    // İlişki 1: Siparişi kim verdi?
    public int UserId { get; set; }
    public User? User { get; set; }

    // İlişki 2: Hangi ürünü aldı?
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    // Sipariş bilgileri
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    
    // --- İŞTE EKSİK OLAN SATIR BU ---
    public DateTime CreateDate { get; set; } = DateTime.Now; 
}