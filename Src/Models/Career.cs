using MongoDB.Bson.Serialization.Attributes;
namespace careers_service.Src.Models
{
    public class Career 
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
    }
   
}