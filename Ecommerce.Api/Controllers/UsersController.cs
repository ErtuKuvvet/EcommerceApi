namespace Ecommerce.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Data;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    public UsersController(AppDbContext context) => _context = context;

    [HttpPost]
    public async Task<IActionResult> CreateTestUser()
    {
        var user = new User { Name = "Test Kullanıcısı", Email = "test@test.com", Password = "123", Role = "Customer" };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("Kullanıcı oluşturuldu! ID'si: " + user.Id);
    }
}