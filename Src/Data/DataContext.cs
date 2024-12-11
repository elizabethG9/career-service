using DotNetEnv;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Sprache;

public class DataContext 
{
    private readonly IMongoDatabase _database;

   public DataContext(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
    {
       _database = mongoClient.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Career> Careers => _database.GetCollection<Career>("Careers");
    public IMongoCollection<Subject> Subjects => _database.GetCollection<Subject>("Subjects");
    public IMongoCollection<SubjectRelationship> SubjectRelationships => _database.GetCollection<SubjectRelationship>("SubjectRelationships");


}