using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class MultipleCaseQuestionDTO : QuestionDTO
    {
        public List<MultipleCaseAnswerDTO> MultipleCaseAnswerDTOs { get; set; } = new List<MultipleCaseAnswerDTO>();

        public MultipleCaseQuestionDTO(MultipleCaseQuestion question) : base(question)
        {
            foreach (var item in question.MultipleCaseAnswers)
            {
                MultipleCaseAnswerDTOs.Add(new MultipleCaseAnswerDTO(item));
            }
        }

        public MultipleCaseQuestionDTO(): base() { }
    }
}
