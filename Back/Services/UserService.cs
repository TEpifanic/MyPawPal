using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyPawPal.Services
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<UserInfo>> GetUserAsync(string id)
        {
            return await _context.UserInfos.FindAsync(id);
        }

        public async Task<List<DogInfo>> GetDogsForUserAsync(string id)
        {
            var user = await _context.UserInfos.Include(u => u.Dogs).FirstOrDefaultAsync(u => u.UserId == id);

            if (user != null)
            {
                return user.Dogs;
            }

            return [];
        }

        public async Task CreateUserAsync(UserInfo userInfo)
        {
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();
        }
    }
}
