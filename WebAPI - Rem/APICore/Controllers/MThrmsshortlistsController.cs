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
    public class MThrmsshortlistsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsshortlistsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsshortlists
        [HttpGet]
        public IEnumerable<MThrmsshortlist> GetMThrmsshortlist()
        {
            return _context.MThrmsshortlist;
        }

        // GET: api/MThrmsshortlists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsshortlist([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsshortlist = await _context.MThrmsshortlist.FindAsync(id);

            if (mThrmsshortlist == null)
            {
                return NotFound();
            }

            return Ok(mThrmsshortlist);
        }

        // PUT: api/MThrmsshortlists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsshortlist([FromRoute] long id, [FromBody] MThrmsshortlist mThrmsshortlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsshortlist.MThrmsshortlistId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsshortlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsshortlistExists(id))
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

        // POST: api/MThrmsshortlists
        [HttpPost]
        public async Task<IActionResult> PostMThrmsshortlist([FromBody] MThrmsshortlist mThrmsshortlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsshortlist.Add(mThrmsshortlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsshortlist", new { id = mThrmsshortlist.MThrmsshortlistId }, mThrmsshortlist);
        }

        // DELETE: api/MThrmsshortlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsshortlist([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsshortlist = await _context.MThrmsshortlist.FindAsync(id);
            if (mThrmsshortlist == null)
            {
                return NotFound();
            }

            _context.MThrmsshortlist.Remove(mThrmsshortlist);
            await _context.SaveChangesAsync();

            return Ok(mThrmsshortlist);
        }

        private bool MThrmsshortlistExists(long id)
        {
            return _context.MThrmsshortlist.Any(e => e.MThrmsshortlistId == id);
        }
    }
}