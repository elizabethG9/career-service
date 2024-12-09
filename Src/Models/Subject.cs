using MongoDB.Bson.Serialization.Attributes;


public class Subject
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public int Id { get; set; } 
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public int Credits { get; set; }
    public int Semester { get; set; }
}