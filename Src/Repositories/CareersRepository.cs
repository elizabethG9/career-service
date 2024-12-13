
using careers_service.Src.Data;
using careers_service.Src.Models;
using careers_service.Src.Repsositories.Interface;
using MongoDB.Driver;
namespace careers_service.Src.Repsositories
{
    public class CareerRepository : ICareersRepository
    {
        private readonly IMongoDatabase _database;

        public CareerRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<List<Career>> GetAllCareers()
        {
            var careers = await _database.GetCollection<Career>("Careers").Find(Builders<Career>.Filter.Empty).ToListAsync();

            return careers;    
        }
    }

}