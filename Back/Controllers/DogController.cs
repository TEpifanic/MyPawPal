using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPawPal.Services;

[ApiController]
[Route("[controller]")]
public class DogController : ControllerBase
{
    private readonly IDogService _dogService;

    public DogController(IDogService dogService)
    {
        _dogService = dogService;
    }

    // GET: /Dog
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DogInfo>>> GetDogs()
    {
        return Ok(await _dogService.GetDogsAsync());
    }

    // GET: /Dog/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DogInfo>> GetDog(int id)
    {
        var dog = await _dogService.GetDogAsync(id);
        if (dog == null)
        {
            return NotFound();
        }

        return Ok(dog);
    }

    // POST: /Dog
    [HttpPost]
    public async Task<ActionResult> PostDog(DogInfo dog)
    {
        await _dogService.AddDogAsync(dog);
        return CreatedAtAction(nameof(GetDog), new { id = dog.DogId }, dog);
    }

    // PUT: /Dog/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDog(int id, DogInfo dog)
    {
        if (id != dog.DogId)
        {
            return BadRequest();
        }

        await _dogService.UpdateDogAsync(dog);
        return NoContent();
    }

    // DELETE: /Dog/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
        await _dogService.DeleteDogAsync(id);
        return NoContent();
    }
}