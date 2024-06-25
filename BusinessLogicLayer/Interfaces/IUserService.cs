using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserByEmail(string email);
    Task<User> Login(string email, string password);
    Task RegisterUser(UserDto user);
    Task UpdateUser(string id, UserDto user);
    Task DeleteUser(string id);
    Task<User> GetUserById(string id);
}