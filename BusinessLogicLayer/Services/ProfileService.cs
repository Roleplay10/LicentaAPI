using BusinessLogicLayer.Builders;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using MongoDB.Bson;

namespace BusinessLogicLayer.Services;

public class ProfileService : IProfileService
{
    public IProfileRepository _profileRepository;
    public IProfileBuilder _profileBuilder;
    public ProfileService(IProfileRepository profileRepository, IProfileBuilder profileBuilder)
    {
        _profileRepository = profileRepository;
        _profileBuilder = profileBuilder;
    }
    public async Task ModifyProfile(ObjectId id, ProfileDTO profile)
    {
        var profileToModify = _profileBuilder.ProfileBuild(profile);
        await _profileRepository.ModifyProfile(id,profileToModify);
    }

    public async Task<ProfileDTO> GetProfile(ObjectId id)
    {
        var profile = await _profileRepository.GetProfile(id);
        if (profile == null)
        {
            return null;
        }
        return _profileBuilder.ProfileDTOBuild(profile);
    }

    public async Task SetToPending(ObjectId id)
    {
        await _profileRepository.SetToPending(id);
    }
}