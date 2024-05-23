namespace MyPawPal.Services
{
    public interface IDogService
    {
        Task<List<DogInfo>> GetDogsAsync();
        Task<DogInfo> GetDogAsync(int dogId);
        Task AddDogAsync(DogInfo dogInfo);
        Task UpdateDogAsync(DogInfo dogInfo);
        Task DeleteDogAsync(int dogId);
    }
}
