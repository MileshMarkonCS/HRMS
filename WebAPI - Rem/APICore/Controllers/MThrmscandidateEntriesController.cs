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
    public class MThrmscandidateEntriesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmscandidateEntriesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmscandidateEntries
        [HttpGet]
        public IEnumerable<MThrmscandidateEntry> GetMThrmscandidateEntry()
        {
            return _context.MThrmscandidateEntry;
        }

        // GET: api/MThrmscandidateEntries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmscandidateEntry([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmscandidateEntry = await _context.MThrmscandidateEntry.FindAsync(id);

            if (mThrmscandidateEntry == null)
            {
                return NotFound();
            }

            return Ok(mThrmscandidateEntry);
        }

        // PUT: api/MThrmscandidateEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmscandidateEntry([FromRoute] long id, [FromBody] MThrmscandidateEntry mThrmscandidateEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmscandidateEntry.MThrmscandidateEntryId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmscandidateEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmscandidateEntryExists(id))
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

        // POST: api/MThrmscandidateEntries
        [HttpPost]
        public async Task<IActionResult> PostMThrmscandidateEntry([FromBody] MThrmscandidateEntry mThrmscandidateEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmscandidateEntry.Add(mThrmscandidateEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmscandidateEntry", new { id = mThrmscandidateEntry.MThrmscandidateEntryId }, mThrmscandidateEntry);
        }

        // DELETE: api/MThrmscandidateEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmscandidateEntry([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmscandidateEntry = await _context.MThrmscandidateEntry.FindAsync(id);
            if (mThrmscandidateEntry == null)
            {
                return NotFound();
            }

            _context.MThrmscandidateEntry.Remove(mThrmscandidateEntry);
            await _context.SaveChangesAsync();

            return Ok(mThrmscandidateEntry);
        }

        private bool MThrmscandidateEntryExists(long id)
        {
            return _context.MThrmscandidateEntry.Any(e => e.MThrmscandidateEntryId == id);
        }
    }
}