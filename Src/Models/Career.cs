using MongoDB.Bson.Serialization.Attributes;

public class Career 
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}