using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Builders;

public interface IProfileBuilder
{
    Profile ProfileBuild(ProfileDTO profile);
    ProfileDTO ProfileDTOBuild(Profile profile);
}

public class ProfileBuilder : IProfileBuilder
{
    public Profile ProfileBuild(ProfileDTO profile)
    {
        var newProfile = new Profile
        {
            Name = profile.Name,
            Surname = profile.Surname,
            Address = profile.Address,
            City = profile.City,
            County = profile.County,
            Phone = profile.Phone,
            CI = profile.CI,
            MotherName = profile.MotherName,
            FatherName = profile.FatherName,
            BirthDate = profile.BirthDate
        };
        return newProfile;
    }
    public ProfileDTO ProfileDTOBuild(Profile profile)
    {
        var newProfile = new ProfileDTO
        (
            profile.Name,
            profile.Surname,
            profile.Address,
            profile.City,
            profile.County,
            profile.Phone,
            profile.CI,
            profile.MotherName,
            profile.FatherName,
            profile.BirthDate,
            profile.isVerified
        );
        return newProfile;
    }
}