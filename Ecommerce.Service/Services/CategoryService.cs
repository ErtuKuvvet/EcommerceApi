namespace Ecommerce.Service.Services;

using Ecommerce.Data;
using Ecommerce.Service.DTOs;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto dto)
    {
        var category = new Category { Name = dto.Name };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        var responseDto = new CategoryDto { Id = category.Id, Name = category.Name };
        return ServiceResponse<CategoryDto>.SuccessResponse(responseDto);
    }

    public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        var dtos = categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name }).ToList();
        return ServiceResponse<List<CategoryDto>>.SuccessResponse(dtos);
    }
}