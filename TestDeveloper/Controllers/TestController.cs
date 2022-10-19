using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDeveloper.Domen;
using TestDeveloper.API.DTO;
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
            _testRepository = new TestRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeTestDTO>>> GetTests()
        {
            var knownowledgeTests = await _testRepository.GetAllAsync();
            List<KnowledgeTestDTO> knownowledgeTestDTOs = new List<KnowledgeTestDTO>();
            foreach (var knownowledge in knownowledgeTests)
            {
                var knowledgeTestDTO = new KnowledgeTestDTO(knownowledge);
                knownowledgeTestDTOs.Add(knowledgeTestDTO);
            }
            return knownowledgeTestDTOs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeTest>> GetTest(string id)
        {
            var test = await _testRepository.GetAsync(new Guid(id));
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
        public async Task<ActionResult<KnowledgeTest>> PostTest(KnowledgeTestDTO test)
        {
            _context.KnowledgeTests.Add(test.ToKnowldgeTest());
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTest", new { id = test.ToKnowldgeTest().Id }, test.ToKnowldgeTest());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(Guid id)
        {
            var test = await _context.KnowledgeTests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.KnowledgeTests.Remove(test);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
