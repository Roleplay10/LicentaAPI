using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Utilities;

namespace BusinessLogicLayer.Builders;

public interface IUserBuilder
{
    User UserBuild(UserDto userDto);
    string HashPassword(string password);
}

public class UserBuilder : IUserBuilder
{
    public User UserBuild(UserDto userDto)
    {
        var newUser = new User
        {
            Email = userDto.Email,
            Password = PasswordHasher.HashPassword(userDto.Password)
        };
        return newUser;
    }

    public string HashPassword(string password)
    {
        return PasswordHasher.HashPassword(password);
    }
}