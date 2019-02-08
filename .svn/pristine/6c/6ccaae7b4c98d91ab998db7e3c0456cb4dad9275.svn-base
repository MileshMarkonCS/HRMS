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
    public class MThrmssourcingsController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmssourcingsController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmssourcings
        [HttpGet]
        public IEnumerable<MThrmssourcing> GetMThrmssourcing()
        {
            return _context.MThrmssourcing;
        }


        [HttpGet("getalloc/{id}")]
        public IEnumerable<MThrmssourcing> GetMThrmssourcing2([FromRoute] long id)
        {
            return _context.MThrmssourcing.Where(u => u.ResourceAllocationId == id);
        }

        // GET: api/MThrmssourcings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmssourcing([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmssourcing = await _context.MThrmssourcing.FindAsync(id);

            if (mThrmssourcing == null)
            {
                return NotFound();
            }

            return Ok(mThrmssourcing);
        }

        // PUT: api/MThrmssourcings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmssourcing([FromRoute] long id, [FromBody] MThrmssourcing mThrmssourcing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmssourcing.MThrmssourcingId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmssourcing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmssourcingExists(id))
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

        // POST: api/MThrmssourcings
        [HttpPost]
        public async Task<IActionResult> PostMThrmssourcing([FromBody] MThrmssourcing mThrmssourcing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmssourcing.Add(mThrmssourcing);
            await _context.SaveChangesAsync();

            var _candidate = new MThrmscvrepository() { MThrmscvrepositoryId = (long)mThrmssourcing.CandidateId, Status="sourcing" };

            using (var newContext = new AMTDEVContext())
            {
                
                newContext.MThrmscvrepository.Attach(_candidate);
                newContext.Entry(_candidate).Property(X => X.Status).IsModified = true;
                newContext.SaveChanges();
            }

            var _shortlistrecord = new MThrmsshortlist()
            {
                MThrmsshortlistId= 0,
                ManPowerId= mThrmssourcing.ManPowerId,
                DesignationId= mThrmssourcing.DesignationId,
                ResourceRequisitionId= mThrmssourcing.ResourceRequisitionId,
                JobCode= mThrmssourcing.JobCode,
                ResourceAllocationId= mThrmssourcing.ResourceAllocationId,
                RecruiterId= mThrmssourcing.RecruiterId,
                SourcingId= mThrmssourcing.MThrmssourcingId,
                CandidateId= mThrmssourcing.CandidateId
            };
            using (var newContext = new AMTDEVContext())
            {

                newContext.MThrmsshortlist.Add(_shortlistrecord);
                newContext.SaveChanges();
            }

            return CreatedAtAction("GetMThrmssourcing", new { id = mThrmssourcing.MThrmssourcingId }, mThrmssourcing);
        }

        // DELETE: api/MThrmssourcings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmssourcing([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmssourcing = await _context.MThrmssourcing.FindAsync(id);
            if (mThrmssourcing == null)
            {
                return NotFound();
            }
            var _candidate = new MThrmscvrepository() { MThrmscvrepositoryId = (long)mThrmssourcing.CandidateId, Status = "available" };

            using (var newContext = new AMTDEVContext())
            {

                newContext.MThrmscvrepository.Attach(_candidate);
                newContext.Entry(_candidate).Property(X => X.Status).IsModified = true;
                newContext.SaveChanges();
            }

             var _shortlistrecord = new MThrmsshortlist() {SourcingId = (long)mThrmssourcing.MThrmssourcingId};
            // using (var newContext = new AMTDEVContext())
            // {

            //     //newContext.MThrmsshortlist.Attach(_shortlistrecord);
            _context.MThrmsshortlist.Attach(_shortlistrecord);
            _context.Remove(_shortlistrecord);
            //     newContext.SaveChanges();MIL
            // }

            _context.MThrmssourcing.Remove(mThrmssourcing);
            
            await _context.SaveChangesAsync();

            return Ok(mThrmssourcing);
        }

        private bool MThrmssourcingExists(long id)
        {
            return _context.MThrmssourcing.Any(e => e.MThrmssourcingId == id);
        }
    }
}