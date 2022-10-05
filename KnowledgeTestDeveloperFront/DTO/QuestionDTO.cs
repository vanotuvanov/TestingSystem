using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }

        public QuestionDTO(Question question)
        {
            Id = question.Id;
            Content = question.Content;
        }

        public QuestionDTO() { }

    }
}
