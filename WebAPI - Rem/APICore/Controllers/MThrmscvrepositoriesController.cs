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
    public class MThrmscvrepositoriesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmscvrepositoriesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmscvrepositories
        [HttpGet]
        public IEnumerable<MThrmscvrepository> GetMThrmscvrepository()
        {
            return _context.MThrmscvrepository;
        }


        [HttpGet("available")]
        public IEnumerable<MThrmscvrepository> GetMThrmscvrepositoryAvailable()
        {
            
            return _context.MThrmscvrepository.Where(u => u.Status == "available");
        }

        


        // GET: api/MThrmscvrepositories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmscvrepository([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmscvrepository = await _context.MThrmscvrepository.FindAsync(id);

            if (mThrmscvrepository == null)
            {
                return NotFound();
            }

            return Ok(mThrmscvrepository);
        }

        // PUT: api/MThrmscvrepositories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmscvrepository([FromRoute] long id, [FromBody] MThrmscvrepository mThrmscvrepository)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmscvrepository.MThrmscvrepositoryId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmscvrepository).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmscvrepositoryExists(id))
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

        // POST: api/MThrmscvrepositories
        [HttpPost]
        public async Task<IActionResult> PostMThrmscvrepository([FromBody] MThrmscvrepository mThrmscvrepository)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmscvrepository.Add(mThrmscvrepository);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmscvrepository", new { id = mThrmscvrepository.MThrmscvrepositoryId }, mThrmscvrepository);
        }

        // DELETE: api/MThrmscvrepositories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmscvrepository([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmscvrepository = await _context.MThrmscvrepository.FindAsync(id);
            if (mThrmscvrepository == null)
            {
                return NotFound();
            }

            _context.MThrmscvrepository.Remove(mThrmscvrepository);
            await _context.SaveChangesAsync();

            return Ok(mThrmscvrepository);
        }

        private bool MThrmscvrepositoryExists(long id)
        {
            return _context.MThrmscvrepository.Any(e => e.MThrmscvrepositoryId == id);
        }
    }
}