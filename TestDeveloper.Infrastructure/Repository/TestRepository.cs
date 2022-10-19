using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;

namespace TestDeveloper.Infrastructure
{
    public class TestRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public TestRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<KnowledgeTest>> GetAllAsync()
        {
            var test = await _context.KnowledgeTests
                                .Include(o => o.Option)
                                .OrderBy(a => a.Title).ToListAsync();
            return test;
        }

        public async Task<KnowledgeTest> GetAsync(Guid id)
        {
            var test = await _context.KnowledgeTests
                .Include(o => o.Option)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            var singleCaseQuestions = await _context.SingleCaseQuestions
                .Include(sq => sq.SingleCaseAnswers)
                .Where(sq => sq.KnowledgeTest.Id == id)
                .ToListAsync();

            test.Questions.AddRange(singleCaseQuestions);

            var multipleCaseQuestions = await _context.MultipleCaseQuestions
                .Include(mq => mq.MultipleCaseAnswers)
                .Where(mq => mq.KnowledgeTest.Id == id)
                .ToListAsync();

            test.Questions.AddRange(multipleCaseQuestions);

            return test;
        }

        public async Task AddAsync(KnowledgeTest test)
        {
            _context.KnowledgeTests.Add(test);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(KnowledgeTest test)
        {
            var existTest = await _context.KnowledgeTests.FindAsync(test.Id);
            _context.Entry(existTest).CurrentValues.SetValues(test);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            KnowledgeTest test = await _context.KnowledgeTests.FindAsync(id);
            _context.Remove(test);
            await _context.SaveChangesAsync();
        }
    }
}
