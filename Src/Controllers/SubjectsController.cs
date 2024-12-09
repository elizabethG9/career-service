
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class SubjectsController : ControllerBase
{
    private readonly ISubjectsService _subjectsService;
    public SubjectsController(ISubjectsService subjectsService)
    {
        _subjectsService = subjectsService;
    }

    [HttpGet ("/")]
    public async Task<ActionResult<List<SubjectDto>>> GetAllSubjects()
    {
        var subjects = await _subjectsService.GetAllSubjects();
        return Ok(subjects);
    }

    [HttpGet("/prerequisites-map/objects")]
    public async Task<ActionResult<List<SubjectRelationshipDto>>> GetPrerequisitesMapObjects()
    {
        var subjectRelationships = await _subjectsService.GetPrerequisitesMapObjects();
        return Ok(subjectRelationships);
    }

    [HttpGet("/prerequisites-map")]
    public async Task<ActionResult<Dictionary<string, List<string>>>> GetPrerequisitesMap()
    {
        var subjectRelationships = await _subjectsService.GetPrerequisitesMap();
        return Ok(subjectRelationships);
    }

    [HttpGet("/postrequisites-map")]
    public async Task<ActionResult<Dictionary<string, List<string>>>> GetPostrequisitesMap()
    {
        var subjectRelationships = await _subjectsService.GetPostrequisitesMap();
        return Ok(subjectRelationships);
    }

}