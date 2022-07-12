namespace TestDeveloper.API.DTO
{
    public class TestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid DeveloperId { get; set; } 
        public List<QuestionDTO> QuestionDTOs { get; set; } = new List<QuestionDTO>();
    }
}
