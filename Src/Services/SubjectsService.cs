using career_service.Src.DTOs;
using career_service.Src.Repsositories.Interface;
using career_service.Src.Services.Interface;

namespace career_service.Src.Services
{
    public class SubjectsService : ISubjectsService

    {
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }
        public async Task<List<SubjectDto>> GetAllSubjects()
        {
            var subjects = await _subjectsRepository.GetAllSubjects();
            var subjectDtos = subjects.Select(s => new SubjectDto
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Department = s.Department,
                Credits = s.Credits,
                Semester = s.Semester

            }).ToList();
            return subjectDtos;
        }
        public async Task<List<SubjectRelationshipDto>> GetPrerequisitesMapObjects()
        {
            var subjectRelationships = await _subjectsRepository.GetPrerequisitesMapObjects();
            var subjectRelationshipDtos = subjectRelationships.Select(sr => new SubjectRelationshipDto
            {
                Id = sr.Id,
                SubjectCode = sr.SubjectCode,
                PreSubjectCode = sr.PreSubjectCode
            }).ToList();
            return subjectRelationshipDtos;
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