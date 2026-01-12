namespace Ecommerce.Service.DTOs;

// Kategori verisini kullanıcıya gösterirken kullanacağımız kalıp
public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

// Yeni kategori eklerken kullanıcıdan isteyeceğimiz kalıp
public class CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
}