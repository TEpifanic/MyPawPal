using Microsoft.EntityFrameworkCore;
using MyPawPal.Domain.Entities;
using MyPawPal.Domain.Interfaces;

namespace MyPawPal.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetByIdAsync(string id)
        {
            return await _context.UserInfos.FindAsync(id);
        }

        public async Task<UserInfo> GetByEmailAsync(string email)
        {
            return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(UserInfo user)
        {
            await _context.UserInfos.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserInfo user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _context.UserInfos.FindAsync(id);
            if (user != null)
            {
                _context.UserInfos.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}