using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;

namespace TestDeveloper.API.DTO
{
    public class SingleCaseAnswerDTO : AnswerDTO
    {
        public bool TrueVarriant { get; set; }

        public SingleCaseAnswerDTO(SingleCaseAnswer answer) : base(answer)
        {
            TrueVarriant = answer.TrueVarriant;
        }

        public override Answer ToAnswer()
        {
            SingleCaseAnswer answer = new SingleCaseAnswer();
            answer.Id = Id;
            answer.Content = Content;
            answer.TrueVarriant = TrueVarriant;
            return answer;
        }
    }
}
