using Microsoft.AspNetCore.Mvc;
using MyPawPal.Domain.Entities;

namespace MyPawPal.Application.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<UserInfo>> GetUserAsync(string id);
        Task<IEnumerable<DogInfo>> GetDogsForUserAsync(string id);
        Task CreateUserAsync(UserInfo userInfo);
    }
}
