using System.Text.Json;
using MongoDB.Driver;

public class DbSeeder{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _environment;

    public DbSeeder(DataContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task SeedAsync(){
        var filePath1 = Path.Combine(_environment.ContentRootPath, "Data", "DataSeeders", "CareersData.json");
        var filePath2 = Path.Combine(_environment.ContentRootPath, "Data", "DataSeeders", "SubjectsData.json");
        var filePath3 = Path.Combine(_environment.ContentRootPath, "Data", "DataSeeders", "SubjectsRelationsData.json");

        await SeedCollectionAsync(filePath1, _context.Careers);
        await SeedCollectionAsync(filePath2, _context.Subjects);
        await SeedCollectionAsync(filePath3, _context.SubjectRelationships);
    }

    private async Task SeedCollectionAsync<T>(string filePath, IMongoCollection<T> collection) where T : class
    {
        if (File.Exists(filePath))
        {
            var jsonData = await File.ReadAllTextAsync(filePath);
            var entities = JsonSerializer.Deserialize<List<T>>(jsonData);

            if (entities != null && entities.Any())
            {
                await collection.InsertManyAsync(entities);
            }
        }
    }

}
