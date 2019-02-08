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
    public class MThrmsresourceAllocationsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsresourceAllocationsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsresourceAllocations
        [HttpGet]
        public IEnumerable<MThrmsresourceAllocation> GetMThrmsresourceAllocation()
        {
            return _context.MThrmsresourceAllocation;
            
        }

        // GET: api/MThrmsresourceAllocations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsresourceAllocation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsresourceAllocation = await _context.MThrmsresourceAllocation.FindAsync(id);

            if (mThrmsresourceAllocation == null)
            {
                return NotFound();
            }

            return Ok(mThrmsresourceAllocation);
        }

        // PUT: api/MThrmsresourceAllocations/5
        [HttpPost("{id}")]
        public async Task<IActionResult> PutMThrmsresourceAllocation([FromRoute] long id, [FromBody] MThrmsresourceAllocation mThrmsresourceAllocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsresourceAllocation.MThrmsresourceAllocationId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsresourceAllocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsresourceAllocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetMThrmsresourceAllocation", mThrmsresourceAllocation.MThrmsresourceAllocationId, mThrmsresourceAllocation);
            //return NoContent();
            
        }



        [HttpPost("rec/{id}/{recr}")]
        public async Task<IActionResult> PutMThrmsresourceAllocation2([FromRoute] long id, [FromRoute] long recr)
        {
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            // if (id != mThrmsresourceAllocation.MThrmsresourceAllocationId)
            // {
            //     return BadRequest();
            // }

            // _context.Entry(mThrmsresourceAllocation).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!MThrmsresourceAllocationExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }
            // return CreatedAtAction("GetMThrmsresourceAllocation", mThrmsresourceAllocation.MThrmsresourceAllocationId, mThrmsresourceAllocation);
            AMTDEVContext _context = new AMTDEVContext();
            var user = new MThrmsresourceAllocation { MThrmsresourceAllocationId = id, RecruiterId = recr };
            _context.MThrmsresourceAllocation.Attach(user).Property(x => x.RecruiterId).IsModified = true;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMThrmsresourceAllocation", user.MThrmsresourceAllocationId, user);

        }

        // POST: api/MThrmsresourceAllocations
        [HttpPost]
        public async Task<IActionResult> PostMThrmsresourceAllocation([FromBody] MThrmsresourceAllocation mThrmsresourceAllocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsresourceAllocation.Add(mThrmsresourceAllocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsresourceAllocation", new { id = mThrmsresourceAllocation.MThrmsresourceAllocationId }, mThrmsresourceAllocation);
        }

        // DELETE: api/MThrmsresourceAllocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsresourceAllocation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsresourceAllocation = await _context.MThrmsresourceAllocation.FindAsync(id);
            if (mThrmsresourceAllocation == null)
            {
                return NotFound();
            }

            _context.MThrmsresourceAllocation.Remove(mThrmsresourceAllocation);
            await _context.SaveChangesAsync();

            return Ok(mThrmsresourceAllocation);
        }

        private bool MThrmsresourceAllocationExists(long id)
        {
            return _context.MThrmsresourceAllocation.Any(e => e.MThrmsresourceAllocationId == id);
        }
    }
}