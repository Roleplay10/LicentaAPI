using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PresentationLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScopeServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
var mongoDB = new MongoClient(connectionString).GetDatabase("licenta");
var dbContextOptions = new DbContextOptionsBuilder<MongoDbContext>()	
    .UseMongoDB(mongoDB.Client, mongoDB.DatabaseNamespace.DatabaseName);
builder.Services.AddDbContext<MongoDbContext>(options => options.UseMongoDB(mongoDB.Client, mongoDB.DatabaseNamespace.DatabaseName));

/*
var connectionString = "mongodb://myapp:elvin1234@localhost:27017/";
var databaseName = "licenta";
var client = new MongoClient(connectionString);

try
{
    var db = MongoDbContext.Create(client.GetDatabase(databaseName));
    Console.WriteLine("Successfully connected to the database.");

    var user = db.Users.First(m => m.Email == "string");
    Console.WriteLine(user.Email);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while connecting to the database: {ex.Message}");
}
*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();