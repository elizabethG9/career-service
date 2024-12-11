using career_service.Src.DTOs;

namespace career_service.Src.Services.Interface
{
    public interface ISubjectsService
    {
        public Task<List<SubjectDto>> GetAllSubjects();
        public Task<List<SubjectRelationshipDto>> GetPrerequisitesMapObjects();
        public Task<Dictionary<string, List<string>>> GetPrerequisitesMap();
        public Task<Dictionary<string, List<string>>> GetPostrequisitesMap();
    }
   
}