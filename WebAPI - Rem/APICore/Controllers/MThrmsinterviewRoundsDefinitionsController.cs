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
    public class MThrmsinterviewRoundsDefinitionsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsinterviewRoundsDefinitionsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsinterviewRoundsDefinitions
        [HttpGet]
        public IEnumerable<MThrmsinterviewRoundsDefinition> GetMThrmsinterviewRoundsDefinition()
        {
            return _context.MThrmsinterviewRoundsDefinition;
        }

        // GET: api/MThrmsinterviewRoundsDefinitions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsinterviewRoundsDefinition([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewRoundsDefinition = await _context.MThrmsinterviewRoundsDefinition.FindAsync(id);

            if (mThrmsinterviewRoundsDefinition == null)
            {
                return NotFound();
            }

            return Ok(mThrmsinterviewRoundsDefinition);
        }

        // PUT: api/MThrmsinterviewRoundsDefinitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsinterviewRoundsDefinition([FromRoute] long id, [FromBody] MThrmsinterviewRoundsDefinition mThrmsinterviewRoundsDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsinterviewRoundsDefinition.MThrmsinterviewRoundsDefinitionId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsinterviewRoundsDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsinterviewRoundsDefinitionExists(id))
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

        // POST: api/MThrmsinterviewRoundsDefinitions
        [HttpPost]
        public async Task<IActionResult> PostMThrmsinterviewRoundsDefinition([FromBody] MThrmsinterviewRoundsDefinition mThrmsinterviewRoundsDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsinterviewRoundsDefinition.Add(mThrmsinterviewRoundsDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsinterviewRoundsDefinition", new { id = mThrmsinterviewRoundsDefinition.MThrmsinterviewRoundsDefinitionId }, mThrmsinterviewRoundsDefinition);
        }

        // DELETE: api/MThrmsinterviewRoundsDefinitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsinterviewRoundsDefinition([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsinterviewRoundsDefinition = await _context.MThrmsinterviewRoundsDefinition.FindAsync(id);
            if (mThrmsinterviewRoundsDefinition == null)
            {
                return NotFound();
            }

            _context.MThrmsinterviewRoundsDefinition.Remove(mThrmsinterviewRoundsDefinition);
            await _context.SaveChangesAsync();

            return Ok(mThrmsinterviewRoundsDefinition);
        }

        private bool MThrmsinterviewRoundsDefinitionExists(long id)
        {
            return _context.MThrmsinterviewRoundsDefinition.Any(e => e.MThrmsinterviewRoundsDefinitionId == id);
        }
    }
}