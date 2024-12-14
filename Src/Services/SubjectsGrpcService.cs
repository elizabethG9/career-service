using careers_service.Src.Services.Interface;
using Grpc.Core;
using SubjectsProto;
namespace careers_service.Src.Services
{
    public class SubjectsGrpcService : SubjectService.SubjectServiceBase {
        private readonly ISubjectsService _subjectsService;
        public SubjectsGrpcService(ISubjectsService subjectsService) {
            _subjectsService = subjectsService;
        }
        public override async Task<SubjectsListResponse> GetAllSubjects(Empty request, ServerCallContext context) {

            var subjects = await _subjectsService.GetAllSubjects();
            var response = new SubjectsListResponse();

            foreach (var subject in subjects) {
                response.Subjects.Add(new Subject
                {
                    Id = subject.Id,
                    Code = subject.Code,
                    Name = subject.Name,
                    Department = subject.Department,
                    Credits = subject.Credits,
                    Semester = subject.Semester
                });
            }
            return response;
        }
        public override async Task<PrerequisitesMapObjectsListResponse> GetPrerequisitesMapObjects(Empty request, ServerCallContext context)
        {
            var subjectRelationships = await _subjectsService.GetPrerequisitesMapObjects();
            var response = new PrerequisitesMapObjectsListResponse();

            foreach (var subjectRelationship in subjectRelationships)
            {
                response.SubjectRelationships.Add(new SubjectRelationship
                {
                    Id = subjectRelationship.Id,
                    SubjectCode = subjectRelationship.SubjectCode,
                    PreSubjectCode = subjectRelationship.PreSubjectCode
                });
            }

            return response;
        }


        public override async Task<PrerequisitesMapResponse> GetPrerequisitesMap(Empty request, ServerCallContext context) {
            var prerequisitesMap = await _subjectsService.GetPrerequisitesMap();
            var response = new PrerequisitesMapResponse();

            foreach(var (key, values)in prerequisitesMap)
            {
                var prerequisiteList = new PrerequisiteList();
                prerequisiteList.SubjectCodes.AddRange(values);

                response.Prerequisites.Add(key, prerequisiteList);
            }
            return response;
        }

        public override async Task<PostrequisitesMapResponse> GetPostrequisitesMap(Empty request, ServerCallContext context) {
            var postrequisitesMap = await _subjectsService.GetPostrequisitesMap();
            var response = new PostrequisitesMapResponse();

            foreach(var (key, values)in postrequisitesMap)
            {
                var postrequisiteList = new PrerequisiteList();
                postrequisiteList.SubjectCodes.AddRange(values);

                response.Postrequisites.Add(key, postrequisiteList);
            }
            return response;
        }

        
    }
   
}