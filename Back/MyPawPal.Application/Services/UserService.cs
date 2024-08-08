using MyPawPal.Domain.Entities;
using MyPawPal.Domain.Interfaces;
using MyPawPal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyPawPal.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDogRepository _dogRepository;

        public UserService(IUserRepository userRepository, IDogRepository dogRepository)
        {
            _userRepository = userRepository;
            _dogRepository = dogRepository;
        }

        public async Task<ActionResult<UserInfo>> GetUserAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<DogInfo>> GetDogsForUserAsync(string id)
        {
            return await _dogRepository.GetByUserIdAsync(id);
        }

        public async Task CreateUserAsync(UserInfo userInfo)
        {
            await _userRepository.AddAsync(userInfo);
        }
    }
}