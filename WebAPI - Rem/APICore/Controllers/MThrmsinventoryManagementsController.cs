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
    public class MThrmsinventoryManagementsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinventoryManagementsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinventoryManagements
        [HttpGet]
        public IEnumerable<MThrmsinventoryManagement> GetMThrmsinventoryManagement()
        {
            return _context.MThrmsinventoryManagement;
        }

        // GET: api/MThrmsinventoryManagements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinventoryManagement([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinventoryManagement = await _context.MThrmsinventoryManagement.FindAsync(id);

            if (mThrmsinventoryManagement == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinventoryManagement);
        }

        // PUT: api/MThrmsinventoryManagements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinventoryManagement([FromRoute] long id, [FromBody] MThrmsinventoryManagement mThrmsinventoryManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinventoryManagement.MThrmsinventoryManagementId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinventoryManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinventoryManagementExists(id))
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

        // POST: api/MThrmsinventoryManagements
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinventoryManagement([FromBody] MThrmsinventoryManagement mThrmsinventoryManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinventoryManagement.Add(mThrmsinventoryManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinventoryManagement", new { id = mThrmsinventoryManagement.MThrmsinventoryManagementId }, mThrmsinventoryManagement);
        }

        // DELETE: api/MThrmsinventoryManagements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinventoryManagement([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinventoryManagement = await _context.MThrmsinventoryManagement.FindAsync(id);
            if (mThrmsinventoryManagement == null)
            {
                return NotFound();
            }

            _context.MThrmsinventoryManagement.Remove(mThrmsinventoryManagement);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinventoryManagement);
        }

        private bool MThrmsinventoryManagementExists(long id)
        {
            return _context.MThrmsinventoryManagement.Any(e => e.MThrmsinventoryManagementId == id);
        }
    }
}