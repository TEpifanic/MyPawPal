using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class UserController(MyDbContext context) : ControllerBase
{
    private readonly MyDbContext _context = context;

    // GET: /User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfo>>> GetUsers()
    {
        return await _context.UserInfos.ToListAsync();
    }

    // GET: /User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserInfo>> GetUser(string id)
    {
        var user = await _context.UserInfos.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // GET: /User/5
    [HttpGet("UserDogs/{id}")]
    public async Task<List<DogInfo>> GetDogsForUser(string id)
    {
        var user = await _context.UserInfos.Include(u => u.Dogs).FirstOrDefaultAsync(u => u.UserId == id);

        if (user != null)
        {
            return user.Dogs;
        }

        return [];
    }

    // POST: /User
    [HttpPost]
    public async Task<ActionResult> CreateUser(UserInfo userInfo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.UserInfos.Add(userInfo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = userInfo.UserId }, userInfo);
    }

}