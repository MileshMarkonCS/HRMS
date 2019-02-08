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
    public class MThrmscompaniesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmscompaniesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmscompanies
        [HttpGet]
        public IEnumerable<MThrmscompany> GetMThrmscompany()
        {
            return _context.MThrmscompany;
        }

        // GET: api/MThrmscompanies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmscompany([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmscompany = await _context.MThrmscompany.FindAsync(id);

            if (mThrmscompany == null)
            {
                return NotFound();
            }

            return Ok(mThrmscompany);
        }

        // PUT: api/MThrmscompanies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmscompany([FromRoute] long id, [FromBody] MThrmscompany mThrmscompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmscompany.MThrmscompanyId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmscompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmscompanyExists(id))
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

        // POST: api/MThrmscompanies
        [HttpPost]
        public async Task<IActionResult> PostMThrmscompany([FromBody] MThrmscompany mThrmscompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmscompany.Add(mThrmscompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmscompany", new { id = mThrmscompany.MThrmscompanyId }, mThrmscompany);
        }

        // DELETE: api/MThrmscompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmscompany([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmscompany = await _context.MThrmscompany.FindAsync(id);
            if (mThrmscompany == null)
            {
                return NotFound();
            }

            _context.MThrmscompany.Remove(mThrmscompany);
            await _context.SaveChangesAsync();

            return Ok(mThrmscompany);
        }

        private bool MThrmscompanyExists(long id)
        {
            return _context.MThrmscompany.Any(e => e.MThrmscompanyId == id);
        }
    }
}