using apiUsers.Contexts;
using apiUsers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiUsers.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ConnSqlServer _context;

    public UsersController(ConnSqlServer context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _context.Users
            .Include(user => user.Profile)
            .Include(user => user.Position)
            .ToListAsync();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users
            .Include(user => user.Profile)
            .Include(user => user.Position)
            .FirstOrDefaultAsync(a => a.UserId == id);
        if (user == null) return NotFound();
        return Ok(user);
    }
}