using Microsoft.EntityFrameworkCore;
using MyPawPal.Domain.Entities;
using MyPawPal.Domain.Interfaces;

namespace MyPawPal.Infrastructure.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly MyDbContext _context;

        public DogRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DogInfo>> GetAllAsync()
        {
            return await _context.DogInfos.ToListAsync();
        }

        public async Task<DogInfo> GetByIdAsync(int id)
        {
            return await _context.DogInfos.FindAsync(id);
        }

        public async Task<IEnumerable<DogInfo>> GetByUserIdAsync(string userId)
        {
            return await _context.DogInfos.Where(d => d.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(DogInfo dog)
        {
            await _context.DogInfos.AddAsync(dog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DogInfo dog)
        {
            _context.Entry(dog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dog = await _context.DogInfos.FindAsync(id);
            if (dog != null)
            {
                _context.DogInfos.Remove(dog);
                await _context.SaveChangesAsync();
            }
        }
    }
}