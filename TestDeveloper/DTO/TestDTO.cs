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
                Type t = item.GetType();
                if (t.Equals(typeof(SingleCaseQuestion)))
                {
                    QuestionDTOs.Add(new SingleCaseQuestionDTO(item as SingleCaseQuestion));
                }
                else if (t.Equals(typeof(MultipleCaseQuestion)))
                {
                    QuestionDTOs.Add(new MultipleCaseQuestionDTO(item as MultipleCaseQuestion));
                }
            }
        }
    }
}
