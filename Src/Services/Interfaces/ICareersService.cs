using career_service.Src.DTOs;

namespace career_service.Src.Services.Interface
{
    public interface ICareersService
    {
        public Task<List<CareerDto>> GetAllCareers();
    }
   
}