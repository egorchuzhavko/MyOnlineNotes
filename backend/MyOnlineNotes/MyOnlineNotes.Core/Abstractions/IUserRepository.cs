using MyOnlineNotes.Core.Models;

namespace MyOnlineNotes.DataAccess.Repositories {
    public interface IUserRepository {
        Task<Guid> Create(Users user);
        Task<List<Users>> GetAll();
        Task<Users> GetById(Guid id);
        Task<Users> GetByLogin(string login);
        Task<bool> CheckLogin(string login);
        Task<bool> CheckUser(Users user);
    }
}