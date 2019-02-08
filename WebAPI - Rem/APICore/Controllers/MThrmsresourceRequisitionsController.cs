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
    public class MThrmsresourceRequisitionsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsresourceRequisitionsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsresourceRequisitions
        [HttpGet]
        public IEnumerable<MThrmsresourceRequisition> GetMThrmsresourceRequisition()
        {
            return _context.MThrmsresourceRequisition;
        }


        // // GET: api/MThrmsresourceRequisitions/getall
        // [HttpGet("getall")]
        // public List<MThrmsresourceRequisition> GetMThrmsresourceRequisition2()
        // {
        //     //return _context.MThrmsresourceRequisition;
        //     return _context.MThrmsresourceRequisition.FromSql("select mTHRMSResourceRequisitionId, JobCode from mTHRMSResourceRequisitionId").ToList();
        // }

        // GET: api/MThrmsresourceRequisitions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsresourceRequisition([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsresourceRequisition = await _context.MThrmsresourceRequisition.FindAsync(id);

            if (mThrmsresourceRequisition == null)
            {
                return NotFound();
            }

            return Ok(mThrmsresourceRequisition);
        }

        // PUT: api/MThrmsresourceRequisitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsresourceRequisition([FromRoute] long id, [FromBody] MThrmsresourceRequisition mThrmsresourceRequisition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsresourceRequisition.MThrmsresourceRequisitionId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsresourceRequisition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsresourceRequisitionExists(id))
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

        // POST: api/MThrmsresourceRequisitions
        [HttpPost("{idd}")]
        public async Task<IActionResult> PostMThrmsresourceRequisition([FromRoute] long idd, [FromBody] MThrmsresourceRequisition mThrmsresourceRequisition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsresourceRequisition.Add(mThrmsresourceRequisition);
            await _context.SaveChangesAsync();

            for(int i=1;i<=idd;i++)
            {
            long id=mThrmsresourceRequisition.MThrmsresourceRequisitionId;
            MThrmsresourceAllocation aa = new MThrmsresourceAllocation();
            aa.DesignationId = mThrmsresourceRequisition.DesignationId;
            aa.MThrmsresourceAllocationId = 0;
            aa.ResourceRequisitionId = id;
            aa.ManPowerId = mThrmsresourceRequisition.ManPowerId;
                _context.MThrmsresourceAllocation.Add(aa);
                await _context.SaveChangesAsync();
            } 

            

            return CreatedAtAction("GetMThrmsresourceRequisition", new { id = mThrmsresourceRequisition.MThrmsresourceRequisitionId }, mThrmsresourceRequisition);
        }

        // DELETE: api/MThrmsresourceRequisitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsresourceRequisition([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsresourceRequisition = await _context.MThrmsresourceRequisition.FindAsync(id);
            if (mThrmsresourceRequisition == null)
            {
                return NotFound();
            }

            _context.MThrmsresourceRequisition.Remove(mThrmsresourceRequisition);
            await _context.SaveChangesAsync();

            return Ok(mThrmsresourceRequisition);
        }

        private bool MThrmsresourceRequisitionExists(long id)
        {
            return _context.MThrmsresourceRequisition.Any(e => e.MThrmsresourceRequisitionId == id);
        }
    }
}