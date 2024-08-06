using Microsoft.AspNetCore.Mvc;
using MyPawPal.Application.Interfaces;
using MyPawPal.Application.DTOs;
using MyPawPal.Domain.Entities;

namespace MyPawPal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogDto>>> GetDogs()
        {
            var dogs = await _dogService.GetDogsAsync();
            return Ok(dogs.Select(d => new DogDto
            {
                DogId = d.DogId,
                Name = d.Name,
                Age = d.Age,
                Race = d.Race,
                UserId = d.UserId
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DogDto>> GetDog(int id)
        {
            var dog = await _dogService.GetDogAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            return Ok(new DogDto
            {
                DogId = dog.DogId,
                Name = dog.Name,
                Age = dog.Age,
                Race = dog.Race,
                UserId = dog.UserId
            });
        }

        [HttpPost]
        public async Task<ActionResult> PostDog(DogDto dogDto)
        {
            var dogInfo = new DogInfo
            {
                Name = dogDto.Name,
                Age = dogDto.Age,
                Race = dogDto.Race,
                UserId = dogDto.UserId
            };
            await _dogService.AddDogAsync(dogInfo);
            return CreatedAtAction(nameof(GetDog), new { id = dogInfo.DogId }, dogDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, DogDto dogDto)
        {
            if (id != dogDto.DogId)
            {
                return BadRequest();
            }
            var dogInfo = new DogInfo
            {
                DogId = dogDto.DogId,
                Name = dogDto.Name,
                Age = dogDto.Age,
                Race = dogDto.Race,
                UserId = dogDto.UserId
            };
            await _dogService.UpdateDogAsync(dogInfo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            await _dogService.DeleteDogAsync(id);
            return NoContent();
        }
    }
}