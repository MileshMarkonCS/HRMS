using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.CRM.Lead;
using ModelCore.Misc;

namespace APICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CRMLeadController : ControllerBase
    {
        private readonly ICRMLead _repo;
        public CRMLeadController(ICRMLead repo)
        {
            _repo = repo;
        }
        #region -- spCRMLeadInsert
        private bool Validate(CRMLeadEntry pModel)
        {
            return true;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CRMLeadEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
               
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo.Create(pModel);
                if (result.ErrorNo > 0)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]CRMLeadEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Preparing audit columns

                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo.Edit(pModel);
                if (result.ErrorNo > 0)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody]CRMLeadEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Preparing audit columns
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo.Delete(pModel);
                if (result.ErrorNo > 0)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
        }
        #endregion -- spCRMLeadInsert

    }
}