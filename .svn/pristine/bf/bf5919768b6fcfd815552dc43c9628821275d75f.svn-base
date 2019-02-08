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
    public class MThrmsinterviewFeedbacksController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewFeedbacksController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewFeedbacks
        [HttpGet]
        public IEnumerable<MThrmsinterviewFeedback> GetMThrmsinterviewFeedback()
        {
            return _context.MThrmsinterviewFeedback;
        }

        // GET: api/MThrmsinterviewFeedbacks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewFeedback([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewFeedback = await _context.MThrmsinterviewFeedback.FindAsync(id);

            if (mThrmsinterviewFeedback == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewFeedback);
        }

        // PUT: api/MThrmsinterviewFeedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewFeedback([FromRoute] long id, [FromBody] MThrmsinterviewFeedback mThrmsinterviewFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewFeedback.MThrmsinterviewFeedbackId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewFeedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewFeedbackExists(id))
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

        // POST: api/MThrmsinterviewFeedbacks
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewFeedback([FromBody] MThrmsinterviewFeedback mThrmsinterviewFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewFeedback.Add(mThrmsinterviewFeedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewFeedback", new { id = mThrmsinterviewFeedback.MThrmsinterviewFeedbackId }, mThrmsinterviewFeedback);
        }

        // DELETE: api/MThrmsinterviewFeedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewFeedback([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewFeedback = await _context.MThrmsinterviewFeedback.FindAsync(id);
            if (mThrmsinterviewFeedback == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewFeedback.Remove(mThrmsinterviewFeedback);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewFeedback);
        }

        private bool MThrmsinterviewFeedbackExists(long id)
        {
            return _context.MThrmsinterviewFeedback.Any(e => e.MThrmsinterviewFeedbackId == id);
        }
    }
}