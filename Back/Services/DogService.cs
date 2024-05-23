using Microsoft.EntityFrameworkCore;

namespace MyPawPal.Services
{
    public class DogService : IDogService
    {
        private readonly MyDbContext _context;

        public DogService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<DogInfo>> GetDogsAsync()
        {
            return await _context.DogInfos.ToListAsync();
        }

        public async Task<DogInfo> GetDogAsync(int dogId)
        {
            return await _context.DogInfos.FindAsync(dogId);
        }

        public async Task AddDogAsync(DogInfo dogInfo)
        {
            _context.DogInfos.Add(dogInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDogAsync(DogInfo dogInfo)
        {
            _context.Entry(dogInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDogAsync(int dogId)
        {
            var dog = await _context.DogInfos.FindAsync(dogId);
            if (dog != null)
            {
                _context.DogInfos.Remove(dog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
