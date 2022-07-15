using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;
using Microsoft.EntityFrameworkCore;

namespace TestDeveloper.Infrastructure
{
    public class SingleCaseQuestionRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public SingleCaseQuestionRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public async Task<List<SingleCaseQuestion>> GetAllAsync(Guid testId)
        //{
        //    var questions = await _context.SingleCaseQuestions
        //                        .Include(a => a.Answers)
        //                        .Where(q => q.KnowledgeTest.Id == testId).ToListAsync();
        //    return questions;
        //}
    }
}
