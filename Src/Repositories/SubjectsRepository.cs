
using MongoDB.Driver;

public class SubjectsRepository : ISubjectsRepository
{
    private readonly DataContext _context;
    public SubjectsRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Subject>> GetAllSubjects()
    {
        var subjects = await _context.Subjects.Find(FilterDefinition<Subject>.Empty).ToListAsync();
        return subjects;
    } public async Task<List<SubjectRelationship>> GetPrerequisitesMapObjects()
    {
        var subjectRelationships = await _context.SubjectRelationships.Find(FilterDefinition<SubjectRelationship>.Empty).ToListAsync();
        return subjectRelationships;
    }

    public async Task<Dictionary<string, List<string>>> GetPostrequisitesMap()
    {
        var relationships = await _context.SubjectRelationships.Find(FilterDefinition<SubjectRelationship>.Empty).ToListAsync();

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
        var relationships = await _context.SubjectRelationships.Find(FilterDefinition<SubjectRelationship>.Empty).ToListAsync();

        // Agrupar las relaciones por código de prerrequisito y crear un diccionario
        return relationships
            .GroupBy(r => r.PreSubjectCode)
            .ToDictionary(
                group => group.Key, // Clave: Código del prerrequisito
                group => group.Select(r => r.SubjectCode).ToList() // Valor: Lista de asignaturas que abre
            );
    }
   
}