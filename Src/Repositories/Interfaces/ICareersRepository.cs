using career_service.Src.Models;

namespace career_service.Src.Repsositories.Interface
{
    public interface ICareersRepository
    {
        Task<List<Career>> GetAllCareers();
    }
}
   