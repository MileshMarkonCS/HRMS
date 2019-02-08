using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelCore.HRMS.Admin.Recruitment;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MThrmsonboardingsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsonboardingsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsonboardings
        [HttpGet]
        public IEnumerable<MThrmsonboarding> GetMThrmsonboarding()
        {
            return _context.MThrmsonboarding;
        }

        // GET: api/MThrmsonboardings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsonboarding([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsonboarding = await _context.MThrmsonboarding.FindAsync(id);

            if (mThrmsonboarding == null)
            {
                return NotFound();
            }

            return Ok(mThrmsonboarding);
        }

        // PUT: api/MThrmsonboardings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsonboarding([FromRoute] long id, [FromBody] MThrmsonboarding mThrmsonboarding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsonboarding.MThrmsonboardingId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsonboarding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsonboardingExists(id))
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

        // POST: api/MThrmsonboardings
        [HttpPost]
        public async Task<IActionResult> PostMThrmsonboarding([FromBody] MThrmsonboarding mThrmsonboarding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsonboarding.Add(mThrmsonboarding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsonboarding", new { id = mThrmsonboarding.MThrmsonboardingId }, mThrmsonboarding);
        }

        // DELETE: api/MThrmsonboardings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsonboarding([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsonboarding = await _context.MThrmsonboarding.FindAsync(id);
            if (mThrmsonboarding == null)
            {
                return NotFound();
            }

            _context.MThrmsonboarding.Remove(mThrmsonboarding);
            await _context.SaveChangesAsync();

            return Ok(mThrmsonboarding);
        }

        private bool MThrmsonboardingExists(long id)
        {
            return _context.MThrmsonboarding.Any(e => e.MThrmsonboardingId == id);
        }
    }
}