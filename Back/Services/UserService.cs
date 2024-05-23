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

        public async Task<UserInfo> GetUserAsync(string userId)
        {
            return await _context.UserInfos.FindAsync(userId);
        }

        public async Task<List<DogInfo>> GetDogsForUserAsync(string userId)
        {
            var user = await _context.UserInfos.Include(u => u.Dogs).FirstOrDefaultAsync(u => u.UserId == userId);
            return user?.Dogs ?? new List<DogInfo>();
        }

        public async Task CreateUserAsync(UserInfo userInfo)
        {
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();
        }
    }
}
