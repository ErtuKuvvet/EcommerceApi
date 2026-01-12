namespace Ecommerce.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Services;
using Ecommerce.Service.DTOs;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllCategoriesAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto category)
    {
        var result = await _categoryService.CreateCategoryAsync(category);
        
        // 201 Created döner
        return CreatedAtAction(nameof(GetAll), new { id = result.Data!.Id }, result);
    }
}