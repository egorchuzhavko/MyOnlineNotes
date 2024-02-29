using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.Core.Models;
using MyOnlineNotes.DataAccess.Entities;

namespace MyOnlineNotes.DataAccess.Repositories {
    public class UserRepository : IUserRepository {
        private readonly MyOnlineNotesDbContext _context;

        public UserRepository(MyOnlineNotesDbContext context) {
            _context = context;
        }

        public async Task<List<Users>> GetAll() {
            var usersEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();
            var users = usersEntities.Select(u => Users.Create(
                    u.Id,
                    u.Login,
                    u.Password
                    ).User)
                .ToList();

            return users;
        }

        public async Task<Users> GetById(Guid id) {
            var userEntity = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            return Users.Create(userEntity.Id,
                userEntity.Login,
                userEntity.Password
                ).User;
        }

        public async Task<Users> GetByLogin(string login) {
            var userEntity = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login);

            return Users.Create(userEntity.Id,
                userEntity.Login,
                userEntity.Password
                ).User;
        }

        public async Task<Guid> Create(Users user) {
            var userEntity = new UserEntity {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<bool> CheckLogin(string login) {
            var result = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login);
            return result == null ? true : false;
        }

        public async Task<bool> CheckUser(Users user) {
            var result = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == user.Login & u.Password==user.Password);
            return result != null ? true : false;
        }
    }
}
