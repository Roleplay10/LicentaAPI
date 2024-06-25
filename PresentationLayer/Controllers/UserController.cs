using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace PresentationLayer.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _config;
    public UserController(IUserService userService, IConfiguration config)
    {
        _userService = userService;
        _config = config;
    }
    [HttpGet("getAllUsers")]
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
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string email,string password)
    {
        var user = await _userService.Login(email, password);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(new { UserId = user.Id.ToString(), Token = JwtTokenGenerator.GenerateJwtToken(user, _config) });
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task RegisterUser(UserDto user)
    {
        await _userService.RegisterUser(user);
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