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
    public class MThrmsattendancesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsattendancesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsattendances
        [HttpGet]
        public IEnumerable<MThrmsattendance> GetMThrmsattendance()
        {
            return _context.MThrmsattendance;
        }

        // GET: api/MThrmsattendances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsattendance([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsattendance = await _context.MThrmsattendance.FindAsync(id);

            if (mThrmsattendance == null)
            {
                return NotFound();
            }

            return Ok(mThrmsattendance);
        }

        // PUT: api/MThrmsattendances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsattendance([FromRoute] long id, [FromBody] MThrmsattendance mThrmsattendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsattendance.MThrmsattendanceId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsattendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsattendanceExists(id))
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

        // POST: api/MThrmsattendances
        [HttpPost]
        public async Task<IActionResult> PostMThrmsattendance([FromBody] MThrmsattendance mThrmsattendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsattendance.Add(mThrmsattendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsattendance", new { id = mThrmsattendance.MThrmsattendanceId }, mThrmsattendance);
        }

        // DELETE: api/MThrmsattendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsattendance([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsattendance = await _context.MThrmsattendance.FindAsync(id);
            if (mThrmsattendance == null)
            {
                return NotFound();
            }

            _context.MThrmsattendance.Remove(mThrmsattendance);
            await _context.SaveChangesAsync();

            return Ok(mThrmsattendance);
        }

        private bool MThrmsattendanceExists(long id)
        {
            return _context.MThrmsattendance.Any(e => e.MThrmsattendanceId == id);
        }
    }
}