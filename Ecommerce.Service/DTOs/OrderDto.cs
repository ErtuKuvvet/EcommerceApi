namespace Ecommerce.Service.DTOs;

// Siparişi gösterirken kullanacağımız kalıp
public class OrderDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; } // Birim fiyat
    public int Quantity { get; set; } // Adet
    public decimal TotalPrice { get; set; } // Toplam tutar
    public DateTime OrderDate { get; set; }
}

// Sipariş oluştururken isteyeceğimiz kalıp
public class CreateOrderDto
{
    public int UserId { get; set; } // Siparişi kim veriyor?
    public int ProductId { get; set; } // Neyi alıyor?
    public int Quantity { get; set; } // Kaç tane?
}