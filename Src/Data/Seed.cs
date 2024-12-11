using System.Text.Json;
using career_service.Src.Models;
using MongoDB.Driver;

namespace career_service.Src.Data{

    public class Seed
    {
        private readonly IMongoDatabase _database;

        public Seed(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Seed the database with examples models in the json files if the database is empty.
        /// </summary>
        public void SeedData()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CallEachSeeder(options);
        }

        /// <summary>
        /// Centralize the call to each seeder method
        /// </summary>
        /// <param name="options">Options to deserialize json</param>
        private void CallEachSeeder(JsonSerializerOptions options)
        {
            SeedFirstOrderTables(options);
            SeedSecondOrderTables(options);
        }

        /// <summary>
        /// Seed the database with the tables that don't depend on other tables.
        /// </summary>
        /// <param name="options">Options to deserialize json</param>
        private void SeedFirstOrderTables(JsonSerializerOptions options)
        {
            SeedSubjects(options);
            SeedCareers(options);
        }

        /// <summary>
        /// Seed the database with the tables whose data depends on exactly one table.
        /// </summary>
        /// <param name="options">Options to deserialize json</param>
        private void SeedSecondOrderTables(JsonSerializerOptions options)
        {
            SeedSubjectsRelationships(options);
        }

        /// <summary>
        /// Seed the database with the subjects in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="options">Options to deserialize json</param>
        private void SeedSubjects(JsonSerializerOptions options)
        {
            var collection = _database.GetCollection<Subject>("Subjects");
            var result = collection.Find(_ => true).Any();
            if (result) return;

            var path = "Src/Data/DataSeeders/SubjectsData.json";
            var subjectsData = File.ReadAllText(path);
            var subjectsList = JsonSerializer.Deserialize<List<Subject>>(subjectsData, options) ??
                throw new Exception("SubjectsData.json is empty");

            // Normalize the name, code and department of the subjects
            subjectsList.ForEach(s =>
            {
                s.Code = s.Code.ToLower();
                s.Name = s.Name.ToLower();
                s.Department = s.Department.ToLower();
            });

            collection.InsertMany(subjectsList);
        }

        /// <summary>
        /// Seed the database with the careers in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="options">Options to deserialize json</param>
        private void SeedCareers(JsonSerializerOptions options)
        {
            var collection = _database.GetCollection<Career>("Careers");
            var result = collection.Find(_ => true).Any();
            if (result) return;

            var path = "Src/Data/DataSeeders/CareersData.json";
            var careersData = File.ReadAllText(path);
            var careersList = JsonSerializer.Deserialize<List<Career>>(careersData, options) ??
                throw new Exception("CareersData.json is empty");

            // Normalize the name and code of the careers
            careersList.ForEach(s =>
            {
                s.Name = s.Name.ToLower();
            });

            collection.InsertMany(careersList);
        }

        /// <summary>
        /// Seed the database with the subjects relationships in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="options">Options to deserialize json</param>
        private void SeedSubjectsRelationships(JsonSerializerOptions options)
        {
            var collection = _database.GetCollection<SubjectRelationship>("SubjectsRelationships");
            var result = collection.Find(_ => true).Any();
            if (result) return;

            var path = "Src/Data/DataSeeders/SubjectsRelationsData.json";
            var subjectsRelationshipsData = File.ReadAllText(path);
            var subjectsRelationshipsList = JsonSerializer
                .Deserialize<List<SubjectRelationship>>(subjectsRelationshipsData, options) ??
                throw new Exception("SubjectsRelationsData.json is empty");

            // Normalize the codes of the codes
            subjectsRelationshipsList.ForEach(s =>
            {
                s.SubjectCode = s.SubjectCode.ToLower();
                s.PreSubjectCode = s.PreSubjectCode.ToLower();
            });

            collection.InsertMany(subjectsRelationshipsList);
        }
    }
}

