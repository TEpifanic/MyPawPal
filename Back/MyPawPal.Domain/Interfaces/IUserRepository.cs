using MyPawPal.Domain.Entities;

namespace MyPawPal.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserInfo> GetByIdAsync(string id);
        Task<UserInfo> GetByEmailAsync(string email);
        Task AddAsync(UserInfo user);
        Task UpdateAsync(UserInfo user);
        Task DeleteAsync(string id);
    }
}