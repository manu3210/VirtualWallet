using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(User element)
        {
            return await _userRepository.CreateAsync(element);
        }

        public async Task<User> Update(int id, User element)
        {
            return await _userRepository.UpdateAsync(id, element);
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> Get(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetForLogin(string email, string password)
        {
            return await _userRepository.GetForLoginAsync(email, password);
        }
    }
}
