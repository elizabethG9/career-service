
using career_service.Src.Data;
using career_service.Src.Models;
using career_service.Src.Repsositories.Interface;
using MongoDB.Driver;
namespace career_service.Src.Repsositories
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