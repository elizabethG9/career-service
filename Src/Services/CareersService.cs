
public class CareersService : ICareersService
{
    private readonly ICareersRepository _careersRepository;
    public CareersService(ICareersRepository careersRepository)
    {
        _careersRepository = careersRepository;
    }
    public async Task<List<CareerDto>> GetAllCareers()
    {
        var careers= await _careersRepository.GetAllCareers();
        var careerDtos = careers.Select(c => new CareerDto
    {
        Id = c.Id,
        Name = c.Name
    }).ToList();

    return careerDtos;
    }
}