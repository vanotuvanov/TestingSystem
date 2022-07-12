using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Domen
{
    public abstract class Answer
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
