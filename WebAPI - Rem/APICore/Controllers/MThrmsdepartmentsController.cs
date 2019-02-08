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
    public class MThrmsdepartmentsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsdepartmentsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsdepartments
        [HttpGet]
        public IEnumerable<MThrmsdepartment> GetMThrmsdepartment()
        {
            return _context.MThrmsdepartment;
        }

        // GET: api/MThrmsdepartments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsdepartment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsdepartment = await _context.MThrmsdepartment.FindAsync(id);

            if (mThrmsdepartment == null)
            {
                return NotFound();
            }

            return Ok(mThrmsdepartment);
        }

        // PUT: api/MThrmsdepartments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsdepartment([FromRoute] long id, [FromBody] MThrmsdepartment mThrmsdepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsdepartment.MThrmsdepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsdepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsdepartmentExists(id))
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

        // POST: api/MThrmsdepartments
        [HttpPost]
        public async Task<IActionResult> PostMThrmsdepartment([FromBody] MThrmsdepartment mThrmsdepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsdepartment.Add(mThrmsdepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsdepartment", new { id = mThrmsdepartment.MThrmsdepartmentId }, mThrmsdepartment);
        }

        // DELETE: api/MThrmsdepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsdepartment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsdepartment = await _context.MThrmsdepartment.FindAsync(id);
            if (mThrmsdepartment == null)
            {
                return NotFound();
            }

            _context.MThrmsdepartment.Remove(mThrmsdepartment);
            await _context.SaveChangesAsync();

            return Ok(mThrmsdepartment);
        }

        private bool MThrmsdepartmentExists(long id)
        {
            return _context.MThrmsdepartment.Any(e => e.MThrmsdepartmentId == id);
        }
    }
}