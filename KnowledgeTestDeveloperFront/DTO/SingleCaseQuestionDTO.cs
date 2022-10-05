using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class SingleCaseQuestionDTO : QuestionDTO
    {

        public List<SingleCaseAnswerDTO> SingleCaseAnswerDTOs { get; set; } = new List<SingleCaseAnswerDTO>();


        public SingleCaseQuestionDTO(SingleCaseQuestion question) : base(question)
        {
            foreach (var item in question.SingleCaseAnswers)
            {
                SingleCaseAnswerDTOs.Add(new SingleCaseAnswerDTO(item));
            }
        }

        public SingleCaseQuestionDTO() : base() { }
    }
}
