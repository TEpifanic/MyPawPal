using Microsoft.AspNetCore.Mvc;
using MyPawPal.Application.Interfaces;
using MyPawPal.Application.DTOs;
using MyPawPal.Domain.Entities;

namespace MyPawPal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var userResult = await _userService.GetUserAsync(id);

            if (userResult.Result is NotFoundResult)
            {
                return NotFound();
            }

            var user = userResult.Value;

            return Ok(new UserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age
            });
        }

        [HttpGet("UserDogs/{id}")]
        public async Task<ActionResult<IEnumerable<DogDto>>> GetDogsForUser(string id)
        {
            var dogs = await _userService.GetDogsForUserAsync(id);
            return Ok(dogs.Select(d => new DogDto
            {
                DogId = d.DogId,
                Name = d.Name,
                Age = d.Age,
                Race = d.Race,
                UserId = d.UserId
            }).ToList());
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var userInfo = new UserInfo
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age
            };
            await _userService.CreateUserAsync(userInfo);
            return CreatedAtAction(nameof(GetUser), new { id = userInfo.UserId }, userDto);
        }
    }
}