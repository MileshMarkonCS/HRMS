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
    public class MThrmsinventoriesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinventoriesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinventories
        [HttpGet]
        public IEnumerable<MThrmsinventory> GetMThrmsinventory()
        {
            return _context.MThrmsinventory;
        }

        // GET: api/MThrmsinventories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinventory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinventory = await _context.MThrmsinventory.FindAsync(id);

            if (mThrmsinventory == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinventory);
        }

        // PUT: api/MThrmsinventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinventory([FromRoute] long id, [FromBody] MThrmsinventory mThrmsinventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinventory.MThrmsinventory1)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinventoryExists(id))
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

        // POST: api/MThrmsinventories
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinventory([FromBody] MThrmsinventory mThrmsinventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinventory.Add(mThrmsinventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinventory", new { id = mThrmsinventory.MThrmsinventory1 }, mThrmsinventory);
        }

        // DELETE: api/MThrmsinventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinventory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinventory = await _context.MThrmsinventory.FindAsync(id);
            if (mThrmsinventory == null)
            {
                return NotFound();
            }

            _context.MThrmsinventory.Remove(mThrmsinventory);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinventory);
        }

        private bool MThrmsinventoryExists(long id)
        {
            return _context.MThrmsinventory.Any(e => e.MThrmsinventory1 == id);
        }
    }
}