using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonStudiesAPIv2.Models;

namespace PersonStudiesAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiesController : ControllerBase
    {
        private readonly PersonStudiesContext _context;

        public StudiesController(PersonStudiesContext context)
        {
            _context = context;
        }

        // GET: api/Studies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studie>>> GetStudie()
        {
            return await _context.Studie.ToListAsync();
        }

        // GET: api/Studies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studie>> GetStudie(int id)
        {
            var studie = await _context.Studie.FindAsync(id);

            if (studie == null)
            {
                return NotFound();
            }

            return studie;
        }

        // PUT: api/Studies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudie(int id, Studie studie)
        {
            if (id != studie.StudieId)
            {
                return BadRequest();
            }

            _context.Entry(studie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudieExists(id))
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

        // POST: api/Studies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Studie>> PostStudie(Studie studie)
        {
            _context.Studie.Add(studie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudie", new { id = studie.StudieId }, studie);
        }

        // DELETE: api/Studies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studie>> DeleteStudie(int id)
        {
            var studie = await _context.Studie.FindAsync(id);
            if (studie == null)
            {
                return NotFound();
            }

            _context.Studie.Remove(studie);
            await _context.SaveChangesAsync();

            return studie;
        }

        private bool StudieExists(int id)
        {
            return _context.Studie.Any(e => e.StudieId == id);
        }
    }
}
