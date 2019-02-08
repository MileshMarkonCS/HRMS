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
    public class MThrmsinterviewChecklistEvaluationsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewChecklistEvaluationsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewChecklistEvaluations
        [HttpGet]
        public IEnumerable<MThrmsinterviewChecklistEvaluation> GetMThrmsinterviewChecklistEvaluation()
        {
            return _context.MThrmsinterviewChecklistEvaluation;
        }


        [HttpGet("round/{id}")] 
        public IEnumerable<MThrmsinterviewChecklistEvaluation> GetMThrmsinterviewChecklistEvaluation2([FromRoute] long id)
        {
            return _context.MThrmsinterviewChecklistEvaluation.Where(u => u.InterviewScheduleRoundId == id).Include(x => x.MThrmsinterviewChecklistEvaluationDetails);;
        }

        // GET: api/MThrmsinterviewChecklistEvaluations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewChecklistEvaluation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewChecklistEvaluation = await _context.MThrmsinterviewChecklistEvaluation.FindAsync(id);

            if (mThrmsinterviewChecklistEvaluation == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewChecklistEvaluation);
        }

        // PUT: api/MThrmsinterviewChecklistEvaluations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewChecklistEvaluation([FromRoute] long id, [FromBody] MThrmsinterviewChecklistEvaluation mThrmsinterviewChecklistEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewChecklistEvaluation.MThrmsinterviewChecklistEvaluationId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewChecklistEvaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewChecklistEvaluationExists(id))
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

        // POST: api/MThrmsinterviewChecklistEvaluations
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewChecklistEvaluation([FromBody] MThrmsinterviewChecklistEvaluation mThrmsinterviewChecklistEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewChecklistEvaluation.Add(mThrmsinterviewChecklistEvaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewChecklistEvaluation", new { id = mThrmsinterviewChecklistEvaluation.MThrmsinterviewChecklistEvaluationId }, mThrmsinterviewChecklistEvaluation);
        }

        // DELETE: api/MThrmsinterviewChecklistEvaluations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewChecklistEvaluation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewChecklistEvaluation = await _context.MThrmsinterviewChecklistEvaluation.FindAsync(id);
            if (mThrmsinterviewChecklistEvaluation == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewChecklistEvaluation.Remove(mThrmsinterviewChecklistEvaluation);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewChecklistEvaluation);
        }

        private bool MThrmsinterviewChecklistEvaluationExists(long id)
        {
            return _context.MThrmsinterviewChecklistEvaluation.Any(e => e.MThrmsinterviewChecklistEvaluationId == id);
        }
    }
}