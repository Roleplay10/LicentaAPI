using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userService.GetAllUsers();
    }
    [HttpGet("email")]
    public async Task<User> GetUserByEmail(string email)
    {
        return await _userService.GetUserByEmail(email);
    }
    [HttpGet("{id}")]
    public async Task<User> GetUserById(string id)
    {
        return await _userService.GetUserById(id);
    }
    [HttpPost]
    public async Task AddUser(UserDto user)
    {
        await _userService.AddUser(user);
    }
    [HttpPut("{id}")]
    public async Task UpdateUser(string id, UserDto user)
    {
        await _userService.UpdateUser(id, user);
    }
    [HttpDelete("{id}")]
    public async Task DeleteUser(string id)
    {
        await _userService.DeleteUser(id);
    }
}