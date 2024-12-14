using careers_service.Src.Models;
using careers_service.Src.Repsositories.Interface;
using careers_service.Src.Services.Interface;

namespace careers_service.Src.Services
{
    public class SubjectsService : ISubjectsService

    {
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }
        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _subjectsRepository.GetAllSubjects();
            return subjects;
        }
        public async Task<List<SubjectRelationship>> GetPrerequisitesMapObjects()
        {
            var subjectRelationships = await _subjectsRepository.GetPrerequisitesMapObjects();
            return subjectRelationships;
        }


        public async Task<Dictionary<string, List<string>>> GetPrerequisitesMap()
        {
            var subjectRelationships = await _subjectsRepository.GetPrerequisitesMap();
            return subjectRelationships;
        }

        public async Task<Dictionary<string, List<string>>> GetPostrequisitesMap()
        {
            var subjectRelationships = await _subjectsRepository.GetPostrequisitesMap();
            return subjectRelationships;
        }

        

        
    }
   
}