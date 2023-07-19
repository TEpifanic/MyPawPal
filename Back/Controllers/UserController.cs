using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPawPal;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly MyDbContext _context;

    public UserController(MyDbContext context)
    {
        _context = context;
    }

    // GET: /User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfo>>> GetUsers()
    {
        return await _context.UserInfos.ToListAsync();
    }

    // GET: /User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserInfo>> GetUser(int id)
    {
        var user = await _context.UserInfos.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: /User
    [HttpPost]
    public async Task<ActionResult<Task>> PostUser(UserInfo user)
    {
        var passwordHasher = new PasswordHasher<UserInfo>();
        user.Password_Hash = passwordHasher.HashPassword(user, user.Password_Hash);

        _context.UserInfos.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.User_Id }, user);
    }

    // PUT: /User/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, UserInfo user)
    {
        if (id != user.User_Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.UserInfos.Any(u => u.User_Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: /User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.UserInfos.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.UserInfos.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}