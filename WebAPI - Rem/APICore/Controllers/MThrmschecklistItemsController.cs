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
    public class MThrmschecklistItemsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmschecklistItemsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmschecklistItems
        [HttpGet]
        public IEnumerable<MThrmschecklistItems> GetMThrmschecklistItems()
        {
            return _context.MThrmschecklistItems;
        }

        // GET: api/MThrmschecklistItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmschecklistItems([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmschecklistItems = await _context.MThrmschecklistItems.FindAsync(id);

            if (mThrmschecklistItems == null)
            {
                return NotFound();
            }

            return Ok(mThrmschecklistItems);
        }

        // PUT: api/MThrmschecklistItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmschecklistItems([FromRoute] long id, [FromBody] MThrmschecklistItems mThrmschecklistItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmschecklistItems.MThrmschecklistItemsId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmschecklistItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmschecklistItemsExists(id))
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

        // POST: api/MThrmschecklistItems
        [HttpPost]
        public async Task<IActionResult> PostMThrmschecklistItems([FromBody] MThrmschecklistItems mThrmschecklistItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmschecklistItems.Add(mThrmschecklistItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmschecklistItems", new { id = mThrmschecklistItems.MThrmschecklistItemsId }, mThrmschecklistItems);
        }

        // DELETE: api/MThrmschecklistItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmschecklistItems([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmschecklistItems = await _context.MThrmschecklistItems.FindAsync(id);
            if (mThrmschecklistItems == null)
            {
                return NotFound();
            }

            _context.MThrmschecklistItems.Remove(mThrmschecklistItems);
            await _context.SaveChangesAsync();

            return Ok(mThrmschecklistItems);
        }

        private bool MThrmschecklistItemsExists(long id)
        {
            return _context.MThrmschecklistItems.Any(e => e.MThrmschecklistItemsId == id);
        }
    }
}