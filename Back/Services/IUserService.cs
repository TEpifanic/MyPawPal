using Microsoft.AspNetCore.Mvc;

namespace MyPawPal.Services
{
    public interface IUserService
    {
        Task<ActionResult<UserInfo>> GetUserAsync(string id);
        Task<List<DogInfo>> GetDogsForUserAsync(string id);
        Task CreateUserAsync(UserInfo userInfo);
    }
}
