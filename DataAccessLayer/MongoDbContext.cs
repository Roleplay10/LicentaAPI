using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DataAccessLayer;

public class MongoDbContext : DbContext
{
    public DbSet<User> Users { get; init; }
    public DbSet<Profile> Profiles { get; init; }
    public DbSet<Document> Documents { get; init; }

    public static MongoDbContext Create(IMongoDatabase database) => new(
        new DbContextOptionsBuilder<MongoDbContext>().UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName).Options);
    
    public MongoDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.Entity<User>().ToCollection("users");
        modelBuilder.Entity<Profile>().ToCollection("profiles");
        modelBuilder.Entity<Document>().ToCollection("documents");
    }
}