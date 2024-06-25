using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using MongoDB.Bson;

namespace BusinessLogicLayer.Interfaces;

public interface IProfileService
{
    Task ModifyProfile(ObjectId id, ProfileDTO profile);
    Task<ProfileDTO> GetProfile(ObjectId id);
    Task SetToPending(ObjectId id);
}