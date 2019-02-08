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
    public class MThrmsinterviewSchedulesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewSchedulesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewSchedules
        [HttpGet]
        public IEnumerable<MThrmsinterviewSchedule> GetMThrmsinterviewSchedule()
        {
            //return _context.MThrmsinterviewSchedule;
             return _context.MThrmsinterviewSchedule.Include(u => u.MThrmsinterviewScheduleRounds);
        }


        

        [HttpGet("tst")]
        public IEnumerable<MThrmsinterviewSchedule> GetMThrmsinterviewSchedule2()
        {
            return _context.MThrmsinterviewSchedule.Include(u => u.MThrmsinterviewScheduleRounds);
        }

        // GET: api/MThrmsinterviewSchedules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewSchedule([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewSchedule = await _context.MThrmsinterviewSchedule.FindAsync(id);

            if (mThrmsinterviewSchedule == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewSchedule);
        }

        // PUT: api/MThrmsinterviewSchedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewSchedule([FromRoute] long id, [FromBody] MThrmsinterviewSchedule mThrmsinterviewSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewSchedule.MThrmsinterviewScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewScheduleExists(id))
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

        // POST: api/MThrmsinterviewSchedules
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewSchedule([FromBody] MThrmsinterviewSchedule mThrmsinterviewSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewSchedule.Add(mThrmsinterviewSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewSchedule", new { id = mThrmsinterviewSchedule.MThrmsinterviewScheduleId }, mThrmsinterviewSchedule);
        }

        // DELETE: api/MThrmsinterviewSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewSchedule([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewSchedule = await _context.MThrmsinterviewSchedule.FindAsync(id);
            if (mThrmsinterviewSchedule == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewSchedule.Remove(mThrmsinterviewSchedule);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewSchedule);
        }

        private bool MThrmsinterviewScheduleExists(long id)
        {
            return _context.MThrmsinterviewSchedule.Any(e => e.MThrmsinterviewScheduleId == id);
        }
    }
}