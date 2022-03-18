using System.Collections.Generic;
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

        public User Create(User element)
        {
            return _userRepository.Create(element);
        }

        public User Update(int id, User element)
        {
            return _userRepository.Update(id, element);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetForLogin(string email, string password)
        {
            return _userRepository.GetForLogin(email, password);
        }
    }
}
