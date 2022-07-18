using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDeveloper.Domen;
using TestDeveloper.Infrastructure;

namespace TestDeveloper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly Context _context;
        private readonly TestRepository _testRepository;
        public TestController(Context context)
        {
            _context = context;
            _testRepository = new TestRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeTest>>> GetTests()
        {
            return await _testRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeTest>> GetTest(Guid id)
        {
            var test = await _testRepository.GetAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return test;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(Guid id, KnowledgeTest test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }

            await _testRepository.UpdateAsync(test);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<KnowledgeTest>> PostTest(KnowledgeTest test)
        {
            await _testRepository.AddAsync(test);
            return CreatedAtAction("GetPerson", new { id = test.Id }, test);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(Guid id)
        {
            var person = await _testRepository.GetAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _testRepository.DeleteAsync(id);

            return NoContent();
        }

        //private bool PersonExists(Guid id)
        //{
        //    return _context.
        //}
    }
}
