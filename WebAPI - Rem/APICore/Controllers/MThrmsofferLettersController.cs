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
    public class MThrmsofferLettersController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsofferLettersController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsofferLetters
        [HttpGet]
        public IEnumerable<MThrmsofferLetter> GetMThrmsofferLetter()
        {
            return _context.MThrmsofferLetter;
        }

        // GET: api/MThrmsofferLetters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsofferLetter([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsofferLetter = await _context.MThrmsofferLetter.FindAsync(id);

            if (mThrmsofferLetter == null)
            {
                return NotFound();
            }

            return Ok(mThrmsofferLetter);
        }

        // PUT: api/MThrmsofferLetters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsofferLetter([FromRoute] long id, [FromBody] MThrmsofferLetter mThrmsofferLetter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsofferLetter.MThrmsofferLetterId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsofferLetter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsofferLetterExists(id))
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

        // POST: api/MThrmsofferLetters
        [HttpPost]
        public async Task<IActionResult> PostMThrmsofferLetter([FromBody] MThrmsofferLetter mThrmsofferLetter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsofferLetter.Add(mThrmsofferLetter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsofferLetter", new { id = mThrmsofferLetter.MThrmsofferLetterId }, mThrmsofferLetter);
        }

        // DELETE: api/MThrmsofferLetters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsofferLetter([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsofferLetter = await _context.MThrmsofferLetter.FindAsync(id);
            if (mThrmsofferLetter == null)
            {
                return NotFound();
            }

            _context.MThrmsofferLetter.Remove(mThrmsofferLetter);
            await _context.SaveChangesAsync();

            return Ok(mThrmsofferLetter);
        }

        private bool MThrmsofferLetterExists(long id)
        {
            return _context.MThrmsofferLetter.Any(e => e.MThrmsofferLetterId == id);
        }
    }
}