using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class AnswerDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public AnswerDTO (Answer answer)
        {
            Id = answer.Id;
            Content = answer.Content;
        }
        
        public AnswerDTO() { }
    }
}
