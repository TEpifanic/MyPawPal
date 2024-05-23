namespace MyPawPal.Services
{
    public interface IUserService
    {
        Task<UserInfo> GetUserAsync(string userId);
        Task<List<DogInfo>> GetDogsForUserAsync(string userId);
        Task CreateUserAsync(UserInfo userInfo);
    }
}
