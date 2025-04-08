using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPrepAPI.Entities;

namespace JobPrepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDescriptionController : ControllerBase
    {
        private readonly JobDbContext _context;

        public JobDescriptionController(JobDbContext context)
        {
            _context = context;
        }

        // GET: api/JobDescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDescription>>> GetJobDescriptions()
        {
          if (_context.JobDescriptions == null)
          {
              return NotFound();
          }
            return await _context.JobDescriptions.ToListAsync();
        }

        // GET: api/JobDescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDescription>> GetJobDescription(int id)
        {
          if (_context.JobDescriptions == null)
          {
              return NotFound();
          }
            var jobDescription = await _context.JobDescriptions.FindAsync(id);

            if (jobDescription == null)
            {
                return NotFound();
            }

            return jobDescription;
        }

        // PUT: api/JobDescription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDescription(int id, JobDescription jobDescription)
        {
            if (id != jobDescription.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDescriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobDescription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobDescription>> PostJobDescription(JobDescription jobDescription)
        {
          if (_context.JobDescriptions == null)
          {
              return Problem("Entity set 'JobDbContext.JobDescriptions'  is null.");
          }
            _context.JobDescriptions.Add(jobDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDescription", new { id = jobDescription.Id }, jobDescription);
        }

        // DELETE: api/JobDescription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDescription(int id)
        {
            if (_context.JobDescriptions == null)
            {
                return NotFound();
            }
            var jobDescription = await _context.JobDescriptions.FindAsync(id);
            if (jobDescription == null)
            {
                return NotFound();
            }

            _context.JobDescriptions.Remove(jobDescription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobDescriptionExists(int id)
        {
            return (_context.JobDescriptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
