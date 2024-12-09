public interface ISubjectsService
{
    public Task<List<SubjectDto>> GetAllSubjects();
    public Task<List<SubjectRelationshipDto>> GetPrerequisitesMapObjects();
    public Task<Dictionary<string, List<string>>> GetPrerequisitesMap();
    public Task<Dictionary<string, List<string>>> GetPostrequisitesMap();
}