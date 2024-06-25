using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace DataAccessLayer.Repositories;

public interface IProfileRepository
{
    Task GenerateEmptyProfile(ObjectId id);
    Task ModifyProfile(ObjectId id, Profile profile);
    Task<Profile> GetProfile(ObjectId id);
    Task SetToPending(ObjectId id);
}

public class ProfileRepository : IProfileRepository
{
    private readonly MongoDbContext _db;
    private readonly IDocumentRepository _documentRepository;
    public ProfileRepository(MongoDbContext db, IDocumentRepository documentRepository)
    {
        _db = db;
        _documentRepository = documentRepository;
    }
    public async Task GenerateEmptyProfile(ObjectId id)
    {
        var profile = new Profile();
        profile.UserId = id;
        await _db.Profiles.AddAsync(profile);
        await _db.SaveChangesAsync();
    }

    public async Task ModifyProfile(ObjectId id, Profile profile)
    {
        var userToModify = await _db.Profiles.FirstOrDefaultAsync(p => p.UserId == id);
        if (userToModify == null)
        {
            Console.WriteLine("Profile not found");
            return;
        }
        userToModify.Name = profile.Name == null ? userToModify.Name : profile.Name;
        userToModify.Surname = profile.Surname == null ? userToModify.Surname : profile.Surname;
        userToModify.Address = profile.Address == null ? userToModify.Address : profile.Address;
        userToModify.City = profile.City == null ? userToModify.City : profile.City;
        userToModify.County = profile.County == null ? userToModify.County : profile.County;
        userToModify.Phone = profile.Phone == null ? userToModify.Phone : profile.Phone;
        userToModify.CI = profile.CI == null ? userToModify.CI : profile.CI;
        userToModify.MotherName = profile.MotherName == null ? userToModify.MotherName : profile.MotherName;
        userToModify.FatherName = profile.FatherName == null ? userToModify.FatherName : profile.FatherName;
        userToModify.BirthDate = profile.BirthDate == null ? userToModify.BirthDate : profile.BirthDate;
        userToModify.isVerified = profile.isVerified == null ? userToModify.isVerified : profile.isVerified;
        await _db.SaveChangesAsync();
    }

    public async Task<Profile> GetProfile(ObjectId id)
    {
        var profile = await _db.Profiles.FirstOrDefaultAsync(p => p.UserId == id);
        if (profile == null)
        {
            return null;
        }
        return profile;
    }

    public async Task SetToPending(ObjectId id)
    {
        var profile = await _db.Profiles.FirstOrDefaultAsync(p => p.UserId == id);
        if (profile == null)
        {
            Console.WriteLine("Profile not found");
            return;
        }
        profile.isVerified = "pending";
        await _db.SaveChangesAsync();
    }
}