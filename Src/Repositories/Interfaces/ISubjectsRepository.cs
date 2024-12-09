public interface ISubjectsRepository
{
    Task<List<Subject>> GetAllSubjects();
    Task<List<SubjectRelationship>> GetPrerequisitesMapObjects();
    Task<Dictionary<string, List<string>>> GetPrerequisitesMap();
    Task<Dictionary<string, List<string>>> GetPostrequisitesMap();
    
}