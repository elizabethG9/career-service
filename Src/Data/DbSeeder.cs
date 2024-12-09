using MongoDB.Driver;
using System.Text.Json;

namespace CareerManagementService.Data.DataSeeder
{
    public class DbSeeder
    {
        private readonly DataContext _context;

        public DbSeeder(DataContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            // Cargar datos de carreras
            if (_context.Careers.CountDocuments(FilterDefinition<Career>.Empty) == 0)
            {
                var careers = LoadDataFromJson<Career>("DataSeeder/CareersData.json");
                _context.Careers.InsertMany(careers);
            }

            // Cargar datos de asignaturas
            if (_context.Subjects.CountDocuments(FilterDefinition<Subject>.Empty) == 0)
            {
                var subjects = LoadDataFromJson<Subject>("DataSeeder/SubjectsData.json");
                _context.Subjects.InsertMany(subjects);
            }
            if (_context.SubjectRelationships.CountDocuments(FilterDefinition<SubjectRelationship>.Empty) == 0)
            {
                var subjectRelationships = LoadDataFromJson<SubjectRelationship>("DataSeeder/SubjectsRelationsData.json");
                _context.SubjectRelationships.InsertMany(subjectRelationships);
            }
        }

        private List<T> LoadDataFromJson<T>(string path)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData);
        }
    }
}
