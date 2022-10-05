using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public abstract class AnswerDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public AnswerDTO (Answer answer)
        {
            Id = answer.Id;
            Content = answer.Content;
        }

        public abstract Answer ToAnswer();
    }
}
