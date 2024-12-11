namespace career_service.Src.DTOs
{
    public class SubjectRelationshipDto
    {
        public int Id { get; set; }
        public string SubjectCode { get; set; } = null!;
        public string PreSubjectCode { get; set; } = null!;
    }
   
}