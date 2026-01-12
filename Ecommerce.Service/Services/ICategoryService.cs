namespace Ecommerce.Service.Services;

using Ecommerce.Service.DTOs;

public interface ICategoryService
{
    // Kategorileri getir
    Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync();
    
    // Kategori ekle
    Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto category);
}