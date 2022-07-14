using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class TestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        //public Guid DeveloperId { get; set; } 
        public List<Question> QuestionDTOs { get; set; } = new List<Question>();
    

        public TestDTO(KnowledgeTest test)
        {
            Id = test.Id;
            Name = test.Title;
            Description = test.Description;
            Status = test.Status.ToString();
            // DeveloperId =
            QuestionDTOs = test.Questions;

        }
    }
}
