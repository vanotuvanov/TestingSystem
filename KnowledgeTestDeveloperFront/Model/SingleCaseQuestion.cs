using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Domen
{
    public class SingleCaseQuestion : Question
    {
        public List<SingleCaseAnswer> SingleCaseAnswers { get; set; } = new List<SingleCaseAnswer>();
    }
}
