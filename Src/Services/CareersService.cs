using careers_service.Src.Models;
using careers_service.Src.Repsositories.Interface;
using careers_service.Src.Services.Interface;

namespace careers_service.Src.Services
{
    public class CareersService : ICareersService
    {
        private readonly ICareersRepository _careersRepository;
        public CareersService(ICareersRepository careersRepository)
        {
            _careersRepository = careersRepository;
        }
        public async Task<List<Career>> GetAllCareers()
        {
            var careers= await _careersRepository.GetAllCareers();
            return careers;
        }
    }
   
}