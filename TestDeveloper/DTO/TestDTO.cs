using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class KnowledgeTestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Enum Status { get; set; }
        public List<QuestionDTO> QuestionDTOs { get; set; } = new List<QuestionDTO>();


        public KnowledgeTestDTO(KnowledgeTest test)
        {
            Id = test.Id;
            Name = test.Title;
            Description = test.Description;
            foreach (var item in test.Questions)
            {
                var dtoQuestions = new QuestionDTO(item);
                QuestionDTOs.Add(dtoQuestions);
            }
        }
    }
}
