using MongoDB.Bson.Serialization.Attributes;

namespace careers_service.Src.Models
{
    public class Subject
    {

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Department { get; set; } = null!;
        public int Credits { get; set; }
        public int Semester { get; set; }
    }
   
}