using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Domen
{
    public abstract class Question
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public Guid KnowledgeTestId { get; set; }
        public KnowledgeTest KnowledgeTest { get; set; }

    }
}
