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
    public class MThrmsemployeesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsemployeesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsemployees
        [HttpGet]
        public IEnumerable<MThrmsemployee> GetMThrmsemployee()
        {
            return _context.MThrmsemployee;
        }

        // GET: api/MThrmsemployees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsemployee([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsemployee = await _context.MThrmsemployee.FindAsync(id);

            if (mThrmsemployee == null)
            {
                return NotFound();
            }

            return Ok(mThrmsemployee);
        }


        // GET: api/MThrmsemployees/test/5
        [HttpGet("test/{id}")]
        public async Task<IActionResult> GetMThrmsemployee2([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsemployee = await _context.MThrmsemployee.FindAsync(id);

            if (mThrmsemployee == null)
            {
                return NotFound();
            }

            return Ok(mThrmsemployee);
        }

        // PUT: api/MThrmsemployees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsemployee([FromRoute] long id, [FromBody] MThrmsemployee mThrmsemployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsemployee.MThrmsemployeeId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsemployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsemployeeExists(id))
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

        // POST: api/MThrmsemployees
        [HttpPost]
        public async Task<IActionResult> PostMThrmsemployee([FromBody] MThrmsemployee mThrmsemployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsemployee.Add(mThrmsemployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsemployee", new { id = mThrmsemployee.MThrmsemployeeId }, mThrmsemployee);
        }

        // DELETE: api/MThrmsemployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsemployee([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsemployee = await _context.MThrmsemployee.FindAsync(id);
            if (mThrmsemployee == null)
            {
                return NotFound();
            }

            _context.MThrmsemployee.Remove(mThrmsemployee);
            await _context.SaveChangesAsync();

            return Ok(mThrmsemployee);
        }

        private bool MThrmsemployeeExists(long id)
        {
            return _context.MThrmsemployee.Any(e => e.MThrmsemployeeId == id);
        }
    }
}