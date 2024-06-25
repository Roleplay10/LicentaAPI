using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace PresentationLayer.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    public IProfileService _profileService;
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }
    [HttpPost("{id}")]
    public async Task ModifyProfile(string id, ProfileDTO profile)
    {
        await _profileService.ModifyProfile(ObjectId.Parse(id), profile);
    }
    [HttpGet("{id}")]
    public async Task<ProfileDTO> GetProfile(string id)
    {
        return await _profileService.GetProfile(ObjectId.Parse(id));
    }
    [HttpPost("{id}/toPending")]
    public async Task SetToPending(string id)
    {
        await _profileService.SetToPending(ObjectId.Parse(id));
    }
}