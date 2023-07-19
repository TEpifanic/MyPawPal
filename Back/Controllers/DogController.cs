using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPawPal;

[ApiController]
[Route("[controller]")]
public class DogController : ControllerBase
{
    private readonly MyDbContext _context;

    public DogController(MyDbContext context)
    {
        _context = context;
    }

    // GET: /Dog
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DogInfo>>> GetDogs()
    {
        return await _context.DogInfos.ToListAsync();
    }

    // GET: /Dog/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DogInfo>> GetDog(int id)
    {
        var dog = await _context.DogInfos.FindAsync(id);

        if (dog == null)
        {
            return NotFound();
        }

        return dog;
    }

    // POST: /Dog
    [HttpPost]
    public async Task<ActionResult<Task>> PostDog(DogInfo dog)
    {
        _context.DogInfos.Add(dog);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDog), new { id = dog.Dog_Id }, dog);
    }

    // PUT: /Dog/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDog(int id, DogInfo dog)
    {
        if (id != dog.Dog_Id)
        {
            return BadRequest();
        }

        _context.Entry(dog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DogInfos.Any(u => u.Dog_Id == id))
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

    // DELETE: /Dog/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
        var dog = await _context.DogInfos.FindAsync(id);

        if (dog == null)
        {
            return NotFound();
        }

        _context.DogInfos.Remove(dog);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}