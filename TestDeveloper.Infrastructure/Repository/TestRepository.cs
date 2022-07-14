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
                .Include(q => q.Questions)
                .ThenInclude(a => a.Answers)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            return test;
        }

        public async Task AddAsync(KnowledgeTest test)
        {
            _context.KnowledgeTests.Add(test);
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
