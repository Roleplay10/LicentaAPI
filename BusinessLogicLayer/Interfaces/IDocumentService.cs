using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Interfaces;

public interface IDocumentService
{
    Task AddDocument(string id, IFormFile document, string type);
}