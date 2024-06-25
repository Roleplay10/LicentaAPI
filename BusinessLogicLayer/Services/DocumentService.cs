using System.Text;
using BusinessLogicLayer.Builders;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;

namespace BusinessLogicLayer.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentBuilder _documentBuilder;
    private readonly string _fileStoragePath;
    private readonly IDocumentRepository _documentRepository;

    public DocumentService(IDocumentBuilder documentBuilder, IConfiguration configuration, IDocumentRepository documentRepository)
    {
        _documentBuilder = documentBuilder;
        _fileStoragePath = configuration["FileStorage:BasePath"];
        _documentRepository = documentRepository;
    }
    public async Task AddDocument(string id, IFormFile document, string type)
    {
        var docummentToSave = new Document();
        docummentToSave.UserId = ObjectId.Parse(id);
        docummentToSave.Type = type;
        var extension = Path.GetExtension(document.FileName);
        var path = GeneratePath(type, id, extension);
        docummentToSave.Path = path;
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await document.CopyToAsync(stream);
        }
        await _documentRepository.AddDocument(docummentToSave);
    }

    private string GeneratePath(string type,string id, string extension)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_fileStoragePath);
        stringBuilder.Append('/');
        stringBuilder.Append(id);
        stringBuilder.Append('/');
        stringBuilder.Append(type);
        stringBuilder.Append(extension);
        return stringBuilder.ToString();
    }

    private async Task<bool> SaveFile(string path, byte[] file)
    {
        return await Task.FromResult(false);
    }
}