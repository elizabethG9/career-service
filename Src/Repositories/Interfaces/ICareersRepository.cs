public interface ICareersRepository
{
    Task<List<Career>> GetAllCareers();
}