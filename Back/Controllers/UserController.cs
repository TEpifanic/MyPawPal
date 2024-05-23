using Microsoft.AspNetCore.Mvc;
using MyPawPal.Services;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: /User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfo>>> GetUsers()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }

    // GET: /User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserInfo>> GetUser(string id)
    {
        var user = await _userService.GetUserAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // GET: /User/UserDogs/5
    [HttpGet("UserDogs/{id}")]
    public async Task<ActionResult<IEnumerable<DogInfo>>> GetDogsForUser(string id)
    {
        var dogs = await _userService.GetDogsForUserAsync(id);
        return Ok(dogs);
    }

    // POST: /User
    [HttpPost]
    public async Task<ActionResult> CreateUser(UserInfo userInfo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _userService.CreateUserAsync(userInfo);
        return CreatedAtAction(nameof(GetUser), new { id = userInfo.UserId }, userInfo);
    }
}