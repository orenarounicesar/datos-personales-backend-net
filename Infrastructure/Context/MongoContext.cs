using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Context;

public class MongoContext<T>
{
    private readonly IMongoDatabase _database;

    public MongoContext(IConfiguration config)
    {
        var client = new MongoClient(System.Environment.GetEnvironmentVariable("DATABASE"));
        _database = client.GetDatabase(System.Environment.GetEnvironmentVariable("DATABASENAME"));
    }

    public IMongoCollection<T> DataBase => _database.GetCollection<T>(typeof(T).Name);
}