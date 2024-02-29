using MyOnlineNotes.Core.Models;

namespace MyOnlineNotes.Application.Services {
    public interface IUsersService {
        Task<Guid> CreateUser(Users user);
        Task<List<Users>> GetAllUsers();
        Task<Users> GetById(Guid id);
        Task<Users> GetByLogin(string login);
        Task<bool> CheckLogin(string login);
        Task<bool> CheckUser(Users user);
    }
}