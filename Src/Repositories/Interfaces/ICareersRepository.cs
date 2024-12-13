using careers_service.Src.Models;

namespace careers_service.Src.Repsositories.Interface
{
    public interface ICareersRepository
    {
        Task<List<Career>> GetAllCareers();
    }
}
   