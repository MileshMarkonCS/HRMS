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
    public class MThrmsinterviewScheduleRoundDetailsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewScheduleRoundDetailsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewScheduleRoundDetails
        [HttpGet]
        public IEnumerable<MThrmsinterviewScheduleRoundDetails> GetMThrmsinterviewScheduleRoundDetails()
        {
            return _context.MThrmsinterviewScheduleRoundDetails;
        }

        // GET: api/MThrmsinterviewScheduleRoundDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewScheduleRoundDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewScheduleRoundDetails = await _context.MThrmsinterviewScheduleRoundDetails.FindAsync(id);

            if (mThrmsinterviewScheduleRoundDetails == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewScheduleRoundDetails);
        }

        // PUT: api/MThrmsinterviewScheduleRoundDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewScheduleRoundDetails([FromRoute] long id, [FromBody] MThrmsinterviewScheduleRoundDetails mThrmsinterviewScheduleRoundDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewScheduleRoundDetails.MThrmsinterviewScheduleRoundDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewScheduleRoundDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewScheduleRoundDetailsExists(id))
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

        // POST: api/MThrmsinterviewScheduleRoundDetails
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewScheduleRoundDetails([FromBody] MThrmsinterviewScheduleRoundDetails mThrmsinterviewScheduleRoundDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewScheduleRoundDetails.Add(mThrmsinterviewScheduleRoundDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewScheduleRoundDetails", new { id = mThrmsinterviewScheduleRoundDetails.MThrmsinterviewScheduleRoundDetailsId }, mThrmsinterviewScheduleRoundDetails);
        }

        // DELETE: api/MThrmsinterviewScheduleRoundDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewScheduleRoundDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewScheduleRoundDetails = await _context.MThrmsinterviewScheduleRoundDetails.FindAsync(id);
            if (mThrmsinterviewScheduleRoundDetails == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewScheduleRoundDetails.Remove(mThrmsinterviewScheduleRoundDetails);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewScheduleRoundDetails);
        }

        private bool MThrmsinterviewScheduleRoundDetailsExists(long id)
        {
            return _context.MThrmsinterviewScheduleRoundDetails.Any(e => e.MThrmsinterviewScheduleRoundDetailsId == id);
        }
    }
}