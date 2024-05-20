using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Utilities;

namespace BusinessLogicLayer.Builders;

public interface IUserBuilder
{
    User UserBuild(UserDto UserDto);
}

public class UserBuilder : IUserBuilder
{
    public User UserBuild(UserDto UserDto)
    {
        var newUser = new User
        {
            Email = UserDto.Email,
            Password = PasswordHasher.HashPassword(UserDto.Password)
        };
        return newUser;
    }
}