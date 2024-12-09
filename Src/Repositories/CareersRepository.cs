
using MongoDB.Driver;

public class CareerRepository : ICareersRepository
{
    private readonly DataContext _context;

    public CareerRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Career>> GetAllCareers()
    {
        var careers = await _context.Careers.Find(FilterDefinition<Career>.Empty).ToListAsync();

        return careers;    
    }
}