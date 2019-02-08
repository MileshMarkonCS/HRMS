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
    public class MThrmsmanPowerBudgetsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsmanPowerBudgetsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsmanPowerBudgets
        [HttpGet]
        public IEnumerable<MThrmsmanPowerBudget> GetMThrmsmanPowerBudget()
        {
            return _context.MThrmsmanPowerBudget;
        }

        // GET: api/MThrmsmanPowerBudgets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsmanPowerBudget([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsmanPowerBudget = await _context.MThrmsmanPowerBudget.FindAsync(id);

            if (mThrmsmanPowerBudget == null)
            {
                return NotFound();
            }

            return Ok(mThrmsmanPowerBudget);
        }

        // PUT: api/MThrmsmanPowerBudgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsmanPowerBudget([FromRoute] long id, [FromBody] MThrmsmanPowerBudget mThrmsmanPowerBudget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsmanPowerBudget.MThrmsmanPowerBudgetId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsmanPowerBudget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsmanPowerBudgetExists(id))
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

        // POST: api/MThrmsmanPowerBudgets
        [HttpPost]
        public async Task<IActionResult> PostMThrmsmanPowerBudget([FromBody] MThrmsmanPowerBudget mThrmsmanPowerBudget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsmanPowerBudget.Add(mThrmsmanPowerBudget);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsmanPowerBudget", new { id = mThrmsmanPowerBudget.MThrmsmanPowerBudgetId }, mThrmsmanPowerBudget);
        }

        // DELETE: api/MThrmsmanPowerBudgets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsmanPowerBudget([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsmanPowerBudget = await _context.MThrmsmanPowerBudget.FindAsync(id);
            if (mThrmsmanPowerBudget == null)
            {
                return NotFound();
            }

            _context.MThrmsmanPowerBudget.Remove(mThrmsmanPowerBudget);
            await _context.SaveChangesAsync();

            return Ok(mThrmsmanPowerBudget);
        }

        private bool MThrmsmanPowerBudgetExists(long id)
        {
            return _context.MThrmsmanPowerBudget.Any(e => e.MThrmsmanPowerBudgetId == id);
        }
    }
}