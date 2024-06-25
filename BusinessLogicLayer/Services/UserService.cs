using BusinessLogicLayer.Builders;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Utilities;

namespace BusinessLogicLayer.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserBuilder _userBuilder;
    public UserService(IUserRepository userRepository, IUserBuilder userBuilder)
    {
        _userRepository = userRepository;
        _userBuilder = userBuilder;
    }
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();
        return users;
    }
    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        return user;
    }
    public async Task<User> GetUserById(string id)
    {
        var user = await _userRepository.GetUserById(id);
        return user;
    }
    public async Task<User> Login(string email, string password)
    {
        var user = await _userRepository.LoginUser(email, password);
        if (user != null)
        {
            if (PasswordHasher.VerifyPassword(password, user.Password))
            {
                return user;
            }
        }
        return null;
    }
    public async Task RegisterUser(UserDto user)
    {
        var newUser = _userBuilder.UserBuild(user);
        await _userRepository.RegisterUser(newUser);
    }
    public async Task UpdateUser(string id, UserDto user)
    {
        var newUser = _userBuilder.UserBuild(user);
        await _userRepository.UpdateUser(id, newUser);
    }
    public async Task DeleteUser(string id)
    {
        await _userRepository.DeleteUser(id);
    }
}