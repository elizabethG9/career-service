using MongoDB.Bson.Serialization.Attributes;
namespace career_service.Src.Models
{
    public class Career 
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
    }
   
}