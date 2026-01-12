namespace Ecommerce.Data;

public class Order : BaseEntity
{
    // İlişki 1: Siparişi kim verdi?
    public int UserId { get; set; }
    public User? User { get; set; } // <-- Dikkat: User kelimesinin yanına ? koyduk

    // İlişki 2: Hangi ürünü aldı?
    public int ProductId { get; set; }
    public Product? Product { get; set; } // <-- Dikkat: Product kelimesinin yanına ? koyduk

    // Sipariş bilgileri
    public int Quantity { get; set; } // Kaç tane aldı?
    public decimal TotalPrice { get; set; } // Toplam tutar
}