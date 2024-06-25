using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(string id);
        Task<User> LoginUser(string email, string password);
        Task RegisterUser(User user);
        Task UpdateUser(string id, User user);
        Task DeleteUser(string id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly MongoDbContext _db;
        private readonly IProfileRepository _profileRepository;
        public UserRepository(MongoDbContext db, IProfileRepository profileRepository)
        {
            _db = db;
            _profileRepository = profileRepository;
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

        public async Task<User> LoginUser(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return null;
            }
            return user;
        }
        public async Task RegisterUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            var checkUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (checkUser == null)
            {
                return;
            }
            await _profileRepository.GenerateEmptyProfile(checkUser.Id);
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
            var profileToDelete = await _db.Profiles.FirstOrDefaultAsync(p => p.UserId == oid);
            _db.Users.Remove(userToDelete);
            _db.Profiles.Remove(profileToDelete);
            await _db.SaveChangesAsync();
        }   
    }
}