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
    public class MThrmsfiletestsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsfiletestsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsfiletests
        [HttpGet]
        public IEnumerable<MThrmsfiletest> GetMThrmsfiletest()
        {
            return _context.MThrmsfiletest;
        }

        // GET: api/MThrmsfiletests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsfiletest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsfiletest = await _context.MThrmsfiletest.FindAsync(id);

            if (mThrmsfiletest == null)
            {
                return NotFound();
            }

            return Ok(mThrmsfiletest);
        }

        // PUT: api/MThrmsfiletests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsfiletest([FromRoute] int id, [FromBody] MThrmsfiletest mThrmsfiletest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsfiletest.Id)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsfiletest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsfiletestExists(id))
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

        // POST: api/MThrmsfiletests
        [HttpPost]
        public async Task<IActionResult> PostMThrmsfiletest([FromBody] MThrmsfiletest mThrmsfiletest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsfiletest.Add(mThrmsfiletest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsfiletest", new { id = mThrmsfiletest.Id }, mThrmsfiletest);
        }

        // DELETE: api/MThrmsfiletests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsfiletest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsfiletest = await _context.MThrmsfiletest.FindAsync(id);
            if (mThrmsfiletest == null)
            {
                return NotFound();
            }

            _context.MThrmsfiletest.Remove(mThrmsfiletest);
            await _context.SaveChangesAsync();

            return Ok(mThrmsfiletest);
        }

        private bool MThrmsfiletestExists(int id)
        {
            return _context.MThrmsfiletest.Any(e => e.Id == id);
        }
    }
}