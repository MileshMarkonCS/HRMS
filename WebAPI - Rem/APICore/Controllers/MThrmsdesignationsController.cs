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
    public class MThrmsdesignationsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsdesignationsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsdesignations
        [HttpGet]
        public IEnumerable<MThrmsdesignation> GetMThrmsdesignation()
        {
            return _context.MThrmsdesignation;
        }

        // GET: api/MThrmsdesignations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsdesignation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsdesignation = await _context.MThrmsdesignation.FindAsync(id);

            if (mThrmsdesignation == null)
            {
                return NotFound();
            }

            return Ok(mThrmsdesignation);
        }

        // PUT: api/MThrmsdesignations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsdesignation([FromRoute] long id, [FromBody] MThrmsdesignation mThrmsdesignation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsdesignation.MThrmsdesignationId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsdesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsdesignationExists(id))
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

        // POST: api/MThrmsdesignations
        [HttpPost]
        public async Task<IActionResult> PostMThrmsdesignation([FromBody] MThrmsdesignation mThrmsdesignation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsdesignation.Add(mThrmsdesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsdesignation", new { id = mThrmsdesignation.MThrmsdesignationId }, mThrmsdesignation);
        }

        // DELETE: api/MThrmsdesignations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsdesignation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsdesignation = await _context.MThrmsdesignation.FindAsync(id);
            if (mThrmsdesignation == null)
            {
                return NotFound();
            }

            _context.MThrmsdesignation.Remove(mThrmsdesignation);
            await _context.SaveChangesAsync();

            return Ok(mThrmsdesignation);
        }

        private bool MThrmsdesignationExists(long id)
        {
            return _context.MThrmsdesignation.Any(e => e.MThrmsdesignationId == id);
        }
    }
}