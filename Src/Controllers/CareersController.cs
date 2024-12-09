using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CareersController : ControllerBase
{

    private readonly ICareersService _careersService;
    public CareersController(ICareersService careersService)
    {
        _careersService = careersService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CareerDto>>> GetAllCareers()
    {
        var careers = await _careersService.GetAllCareers();
        return Ok(careers);
    }

}