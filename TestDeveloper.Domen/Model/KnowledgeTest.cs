using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Domen
{
    public enum Status
    {
        InDevelopment = 10,
        Relevant = 20,
        Outdated = 30,
        Archived = 50,
    }
    public class KnowledgeTest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public Option Option { get; set; } = new Option();
        public Status Status { get; set; }
    }
}
