using MyPawPal.Domain.Entities;
using MyPawPal.Domain.Interfaces;
using MyPawPal.Application.Interfaces;

namespace MyPawPal.Application.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;

        public DogService(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<IEnumerable<DogInfo>> GetDogsAsync()
        {
            return await _dogRepository.GetAllAsync();
        }

        public async Task<DogInfo> GetDogAsync(int dogId)
        {
            return await _dogRepository.GetByIdAsync(dogId);
        }

        public async Task AddDogAsync(DogInfo dogInfo)
        {
            await _dogRepository.AddAsync(dogInfo);
        }

        public async Task UpdateDogAsync(DogInfo dogInfo)
        {
            await _dogRepository.UpdateAsync(dogInfo);
        }

        public async Task DeleteDogAsync(int dogId)
        {
            await _dogRepository.DeleteAsync(dogId);
        }

        public async Task<IEnumerable<DogInfo>> GetDogsByUserIdAsync(string userId)
        {
            return await _dogRepository.GetByUserIdAsync(userId);
        }
    }
}