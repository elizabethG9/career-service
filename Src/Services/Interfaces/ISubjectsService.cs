using careers_service.Src.Models;

namespace careers_service.Src.Services.Interface
{
    public interface ISubjectsService
    {
        public Task<List<Subject>> GetAllSubjects();
        public Task<List<SubjectRelationship>> GetPrerequisitesMapObjects();
        public Task<Dictionary<string, List<string>>> GetPrerequisitesMap();
        public Task<Dictionary<string, List<string>>> GetPostrequisitesMap();
    }
   
}