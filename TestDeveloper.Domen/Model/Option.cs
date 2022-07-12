using System;

namespace TestDeveloper.Domen
{
    public class Option
    {
        public Guid Id { get; set; }
        public int TestTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public int NumberOfEttemps { get; set; }
        
        public Guid KnowledgeTestId { get; set; }
        public KnowledgeTest KnowledgeTest { get; set; }

    }
}
