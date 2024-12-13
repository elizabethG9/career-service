using careers_service.Src.DTOs;

namespace careers_service.Src.Services.Interface
{
    public interface ICareersService
    {
        public Task<List<CareerDto>> GetAllCareers();
    }
   
}