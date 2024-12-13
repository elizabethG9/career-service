namespace careers_service.Src.Models
{
    public class SubjectRelationship
    {
        public int Id { get; set; }
        public string SubjectCode { get; set; } = null!;
        public string PreSubjectCode { get; set; } = null!;
    }
   
}