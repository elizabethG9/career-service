using careers_service.Src.Models;

namespace careers_service.Src.Services.Interface
{
    public interface ICareersService
    {
        public Task<List<Career>> GetAllCareers();
    }
   
}