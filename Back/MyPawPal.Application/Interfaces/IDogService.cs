using MyPawPal.Domain.Entities;

namespace MyPawPal.Application.Interfaces
{
    public interface IDogService
    {
        Task<IEnumerable<DogInfo>> GetDogsAsync();
        Task<DogInfo> GetDogAsync(int dogId);
        Task AddDogAsync(DogInfo dogInfo);
        Task UpdateDogAsync(DogInfo dogInfo);
        Task DeleteDogAsync(int dogId);
    }
}
