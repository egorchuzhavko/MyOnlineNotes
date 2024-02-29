using MyOnlineNotes.Core.Models;
using MyOnlineNotes.DataAccess.Repositories;

namespace MyOnlineNotes.Application.Services {
    public class UsersService : IUsersService {
        private readonly IUserRepository _usersRepository;

        public UsersService(IUserRepository usersRepository) {
            _usersRepository = usersRepository;
        }

        public async Task<List<Users>> GetAllUsers() {
            return await _usersRepository.GetAll();
        }

        public async Task<Users> GetById(Guid id) {
            return await _usersRepository.GetById(id);
        }
        public async Task<Users> GetByLogin(string login) {
            return await _usersRepository.GetByLogin(login);
        }

        public async Task<Guid> CreateUser(Users user) {
            return await _usersRepository.Create(user);
        }

        public async Task<bool> CheckLogin(string login) {
            return await _usersRepository.CheckLogin(login);
        }

        public async Task<bool> CheckUser(Users user) {
            return await _usersRepository.CheckUser(user);
        }
    }
}
