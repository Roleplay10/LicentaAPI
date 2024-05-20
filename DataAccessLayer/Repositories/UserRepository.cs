using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(string id);
        Task AddUser(User user);
        Task UpdateUser(string id, User user);
        Task DeleteUser(string id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly MongoDbContext _db;
        public UserRepository(MongoDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _db.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _db.Users.Where(user => user.Email == email).FirstOrDefaultAsync();
            return user;
        }
        public async Task<User> GetUserById(string id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == ObjectId.Parse(id));
            return user;
        }
        public async Task AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateUser(string id,User user)
        {
            var oid = ObjectId.Parse(id);
            var userToUpdate = await _db.Users.FirstOrDefaultAsync(u => u.Id == oid);
            userToUpdate.Email = user.Email ??= userToUpdate.Email;
            userToUpdate.Password =  user.Password ??= userToUpdate.Password;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUser(string id)
        {
            var oid = ObjectId.Parse(id);
            var userToDelete = await _db.Users.FirstOrDefaultAsync(u => u.Id == oid);
            _db.Users.Remove(userToDelete);
            await _db.SaveChangesAsync();
        }   
    }
}