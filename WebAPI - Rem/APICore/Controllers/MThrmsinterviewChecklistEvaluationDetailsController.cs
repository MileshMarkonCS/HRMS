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
    public class MThrmsinterviewChecklistEvaluationDetailsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewChecklistEvaluationDetailsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewChecklistEvaluationDetails
        [HttpGet]
        public IEnumerable<MThrmsinterviewChecklistEvaluationDetails> GetMThrmsinterviewChecklistEvaluationDetails()
        {
            return _context.MThrmsinterviewChecklistEvaluationDetails;
        }

        // GET: api/MThrmsinterviewChecklistEvaluationDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewChecklistEvaluationDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewChecklistEvaluationDetails = await _context.MThrmsinterviewChecklistEvaluationDetails.FindAsync(id);

            if (mThrmsinterviewChecklistEvaluationDetails == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewChecklistEvaluationDetails);
        }

        // PUT: api/MThrmsinterviewChecklistEvaluationDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewChecklistEvaluationDetails([FromRoute] long id, [FromBody] MThrmsinterviewChecklistEvaluationDetails mThrmsinterviewChecklistEvaluationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewChecklistEvaluationDetails.MThrmsinterviewChecklistEvaluationDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewChecklistEvaluationDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewChecklistEvaluationDetailsExists(id))
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

        // POST: api/MThrmsinterviewChecklistEvaluationDetails
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewChecklistEvaluationDetails([FromBody] MThrmsinterviewChecklistEvaluationDetails mThrmsinterviewChecklistEvaluationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewChecklistEvaluationDetails.Add(mThrmsinterviewChecklistEvaluationDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewChecklistEvaluationDetails", new { id = mThrmsinterviewChecklistEvaluationDetails.MThrmsinterviewChecklistEvaluationDetailsId }, mThrmsinterviewChecklistEvaluationDetails);
        }

        // DELETE: api/MThrmsinterviewChecklistEvaluationDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewChecklistEvaluationDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewChecklistEvaluationDetails = await _context.MThrmsinterviewChecklistEvaluationDetails.FindAsync(id);
            if (mThrmsinterviewChecklistEvaluationDetails == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewChecklistEvaluationDetails.Remove(mThrmsinterviewChecklistEvaluationDetails);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewChecklistEvaluationDetails);
        }

        private bool MThrmsinterviewChecklistEvaluationDetailsExists(long id)
        {
            return _context.MThrmsinterviewChecklistEvaluationDetails.Any(e => e.MThrmsinterviewChecklistEvaluationDetailsId == id);
        }
    }
}