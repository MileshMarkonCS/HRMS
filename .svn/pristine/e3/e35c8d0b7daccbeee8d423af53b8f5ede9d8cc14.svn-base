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
    public class MThrmsinventoryManagementDetailsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinventoryManagementDetailsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinventoryManagementDetails
        [HttpGet]
        public IEnumerable<MThrmsinventoryManagementDetails> GetMThrmsinventoryManagementDetails()
        {
            return _context.MThrmsinventoryManagementDetails;
        }

        // GET: api/MThrmsinventoryManagementDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinventoryManagementDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinventoryManagementDetails = await _context.MThrmsinventoryManagementDetails.FindAsync(id);

            if (mThrmsinventoryManagementDetails == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinventoryManagementDetails);
        }

        // PUT: api/MThrmsinventoryManagementDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinventoryManagementDetails([FromRoute] long id, [FromBody] MThrmsinventoryManagementDetails mThrmsinventoryManagementDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinventoryManagementDetails.MThrmsinventoryManagementDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinventoryManagementDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinventoryManagementDetailsExists(id))
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

        // POST: api/MThrmsinventoryManagementDetails
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinventoryManagementDetails([FromBody] MThrmsinventoryManagementDetails mThrmsinventoryManagementDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinventoryManagementDetails.Add(mThrmsinventoryManagementDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinventoryManagementDetails", new { id = mThrmsinventoryManagementDetails.MThrmsinventoryManagementDetailsId }, mThrmsinventoryManagementDetails);
        }

        // DELETE: api/MThrmsinventoryManagementDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinventoryManagementDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinventoryManagementDetails = await _context.MThrmsinventoryManagementDetails.FindAsync(id);
            if (mThrmsinventoryManagementDetails == null)
            {
                return NotFound();
            }

            _context.MThrmsinventoryManagementDetails.Remove(mThrmsinventoryManagementDetails);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinventoryManagementDetails);
        }

        private bool MThrmsinventoryManagementDetailsExists(long id)
        {
            return _context.MThrmsinventoryManagementDetails.Any(e => e.MThrmsinventoryManagementDetailsId == id);
        }
    }
}