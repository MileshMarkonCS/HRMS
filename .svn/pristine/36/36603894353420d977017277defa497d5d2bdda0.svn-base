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
    public class MThrmsinterviewScheduleRoundsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewScheduleRoundsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewScheduleRounds
        [HttpGet]
        public IEnumerable<MThrmsinterviewScheduleRounds> GetMThrmsinterviewScheduleRounds2()
        {
            return _context.MThrmsinterviewScheduleRounds.Include(u => u.MThrmsinterviewScheduleRoundDetails);
        }



        [HttpGet("tst")]
        public IEnumerable<MThrmsinterviewScheduleRounds> GetMThrmsinterviewScheduleRounds()
        {
            return _context.MThrmsinterviewScheduleRounds;
        }

        // GET: api/MThrmsinterviewScheduleRounds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewScheduleRounds([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewScheduleRounds = await _context.MThrmsinterviewScheduleRounds.FindAsync(id);

            if (mThrmsinterviewScheduleRounds == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewScheduleRounds);
        }

        // PUT: api/MThrmsinterviewScheduleRounds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewScheduleRounds([FromRoute] long id, [FromBody] MThrmsinterviewScheduleRounds mThrmsinterviewScheduleRounds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewScheduleRounds.MThrmsinterviewScheduleRoundsId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewScheduleRounds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewScheduleRoundsExists(id))
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

        // POST: api/MThrmsinterviewScheduleRounds
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewScheduleRounds([FromBody] MThrmsinterviewScheduleRounds mThrmsinterviewScheduleRounds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewScheduleRounds.Add(mThrmsinterviewScheduleRounds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewScheduleRounds", new { id = mThrmsinterviewScheduleRounds.MThrmsinterviewScheduleRoundsId }, mThrmsinterviewScheduleRounds);
        }

        // DELETE: api/MThrmsinterviewScheduleRounds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewScheduleRounds([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewScheduleRounds = await _context.MThrmsinterviewScheduleRounds.FindAsync(id);
            if (mThrmsinterviewScheduleRounds == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewScheduleRounds.Remove(mThrmsinterviewScheduleRounds);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewScheduleRounds);
        }

        private bool MThrmsinterviewScheduleRoundsExists(long id)
        {
            return _context.MThrmsinterviewScheduleRounds.Any(e => e.MThrmsinterviewScheduleRoundsId == id);
        }
    }
}