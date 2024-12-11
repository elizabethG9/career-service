
using career_service.Src.Data;
using career_service.Src.Models;
using career_service.Src.Repsositories.Interface;
using MongoDB.Driver;
namespace career_service.Src.Repsositories
{

    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly IMongoDatabase _database;
        public SubjectsRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _database.GetCollection<Subject>("Subjects").Find(FilterDefinition<Subject>.Empty).ToListAsync();
            return subjects;
        } public async Task<List<SubjectRelationship>> GetPrerequisitesMapObjects()
        {
            var subjectRelationships = await _database.GetCollection<SubjectRelationship>("SubjectRelationships").Find(FilterDefinition<SubjectRelationship>.Empty).ToListAsync();
            return subjectRelationships;
        }

        public async Task<Dictionary<string, List<string>>> GetPostrequisitesMap()
        {
            var relationships = await _database.GetCollection<SubjectRelationship>("SubjectRelationships").Find(FilterDefinition<SubjectRelationship>.Empty).ToListAsync();

            return relationships
                .GroupBy(r => r.SubjectCode)
                .ToDictionary(
                    group => group.Key, // Clave: Código de la asignatura
                    group => group.Select(r => r.PreSubjectCode).ToList() // Valor: Lista de prerrequisitos
                );
        }

        public async Task<Dictionary<string, List<string>>> GetPrerequisitesMap()
        {
            // Obtener todas las relaciones de prerrequisitos
            var relationships = await _database.GetCollection<SubjectRelationship>("SubjectRelationships").Find(FilterDefinition<SubjectRelationship>.Empty).ToListAsync();

            // Agrupar las relaciones por código de prerrequisito y crear un diccionario
            return relationships
                .GroupBy(r => r.PreSubjectCode)
                .ToDictionary(
                    group => group.Key, // Clave: Código del prerrequisito
                    group => group.Select(r => r.SubjectCode).ToList() // Valor: Lista de asignaturas que abre
                );
        }
    
    }
}
