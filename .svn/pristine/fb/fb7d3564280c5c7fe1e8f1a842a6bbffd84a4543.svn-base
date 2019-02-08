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
    public class MThrmsdesignationInventoriesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsdesignationInventoriesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsdesignationInventories
        [HttpGet]
        public IEnumerable<MThrmsdesignationInventory> GetMThrmsdesignationInventory()
        {
            return _context.MThrmsdesignationInventory;
        }

        // GET: api/MThrmsdesignationInventories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsdesignationInventory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsdesignationInventory = await _context.MThrmsdesignationInventory.FindAsync(id);

            if (mThrmsdesignationInventory == null)
            {
                return NotFound();
            }

            return Ok(mThrmsdesignationInventory);
        }

        // PUT: api/MThrmsdesignationInventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsdesignationInventory([FromRoute] long id, [FromBody] MThrmsdesignationInventory mThrmsdesignationInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsdesignationInventory.MThrmsdesignationInventoryId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsdesignationInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsdesignationInventoryExists(id))
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

        // POST: api/MThrmsdesignationInventories
        [HttpPost]
        public async Task<IActionResult> PostMThrmsdesignationInventory([FromBody] MThrmsdesignationInventory mThrmsdesignationInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsdesignationInventory.Add(mThrmsdesignationInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsdesignationInventory", new { id = mThrmsdesignationInventory.MThrmsdesignationInventoryId }, mThrmsdesignationInventory);
        }

        // DELETE: api/MThrmsdesignationInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsdesignationInventory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsdesignationInventory = await _context.MThrmsdesignationInventory.FindAsync(id);
            if (mThrmsdesignationInventory == null)
            {
                return NotFound();
            }

            _context.MThrmsdesignationInventory.Remove(mThrmsdesignationInventory);
            await _context.SaveChangesAsync();

            return Ok(mThrmsdesignationInventory);
        }

        private bool MThrmsdesignationInventoryExists(long id)
        {
            return _context.MThrmsdesignationInventory.Any(e => e.MThrmsdesignationInventoryId == id);
        }
    }
}