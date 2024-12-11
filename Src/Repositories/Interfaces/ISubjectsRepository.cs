using career_service.Src.Models;

namespace career_service.Src.Repsositories.Interface
{

    public interface ISubjectsRepository
    {
        Task<List<Subject>> GetAllSubjects();
        Task<List<SubjectRelationship>> GetPrerequisitesMapObjects();
        Task<Dictionary<string, List<string>>> GetPrerequisitesMap();
        Task<Dictionary<string, List<string>>> GetPostrequisitesMap();
        
    }
}
