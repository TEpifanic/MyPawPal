using MyPawPal.Domain.Entities;

namespace MyPawPal.Domain.Interfaces
{
    public interface IDogRepository
    {
        Task<IEnumerable<DogInfo>> GetAllAsync();
        Task<DogInfo> GetByIdAsync(int id);
        Task<IEnumerable<DogInfo>> GetByUserIdAsync(string userId);
        Task AddAsync(DogInfo dog);
        Task UpdateAsync(DogInfo dog);
        Task DeleteAsync(int id);
    }
}