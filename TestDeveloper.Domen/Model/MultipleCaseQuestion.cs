using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Domen
{
    public class MultipleCaseQuestion : Question
    {
        public int test { get; set; }
        public List<MultipleCaseAnswer> MultipleCaseAnswers { get; set; } = new List<MultipleCaseAnswer>();
    }
}
