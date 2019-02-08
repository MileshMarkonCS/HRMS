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
    public class MThrmsbranchesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsbranchesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsbranches
        [HttpGet]
        public IEnumerable<MThrmsbranch> GetMThrmsbranch()
        {
            return _context.MThrmsbranch;
        }

        // GET: api/MThrmsbranches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsbranch([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsbranch = await _context.MThrmsbranch.FindAsync(id);

            if (mThrmsbranch == null)
            {
                return NotFound();
            }

            return Ok(mThrmsbranch);
        }

        // PUT: api/MThrmsbranches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsbranch([FromRoute] long id, [FromBody] MThrmsbranch mThrmsbranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsbranch.MThrmsbranchId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsbranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsbranchExists(id))
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

        // POST: api/MThrmsbranches
        [HttpPost]
        public async Task<IActionResult> PostMThrmsbranch([FromBody] MThrmsbranch mThrmsbranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsbranch.Add(mThrmsbranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsbranch", new { id = mThrmsbranch.MThrmsbranchId }, mThrmsbranch);
        }

        // DELETE: api/MThrmsbranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsbranch([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsbranch = await _context.MThrmsbranch.FindAsync(id);
            if (mThrmsbranch == null)
            {
                return NotFound();
            }

            _context.MThrmsbranch.Remove(mThrmsbranch);
            await _context.SaveChangesAsync();

            return Ok(mThrmsbranch);
        }

        private bool MThrmsbranchExists(long id)
        {
            return _context.MThrmsbranch.Any(e => e.MThrmsbranchId == id);
        }
    }
}