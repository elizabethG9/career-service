using MongoDB.Driver;

public class DataContext
{
    private readonly IMongoDatabase _database;

   public DataContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<Career> Careers => _database.GetCollection<Career>("Careers");
    public IMongoCollection<Subject> Subjects => _database.GetCollection<Subject>("Subjects");
    public IMongoCollection<SubjectRelationship> SubjectRelationships => _database.GetCollection<SubjectRelationship>("SubjectRelationships");
}