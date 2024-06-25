using MongoDB.Bson;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories;

public interface IDocumentRepository
{
    Task AddDocument(Document document);
}
public class DocumentRepository : IDocumentRepository
{
    private readonly MongoDbContext _db;
    public DocumentRepository(MongoDbContext db)
    {
        _db = db;
    }
    public async Task AddDocument(Document document)
    {
        await _db.Documents.AddAsync(document);
        await _db.SaveChangesAsync();
    }
}