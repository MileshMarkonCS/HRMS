using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using ModelCore.HRMS.Admin.Test;

namespace APICore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TRIALSpController : Controller
    {
        private readonly ITRIALSp _repo;
        public TRIALSpController(ITRIALSp repo)
        {
            _repo = repo;
        }
        #region -- mTRIALSp

        // Get api/trialsp/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            TRIALSpIndex result = await _repo.GetEntry(id);
            return Ok(result);
        }

        private bool Validate(TRIALSpEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                    if (pModel.TRIALSpId <= 0)
                    {
                            ModelState.AddModelError("", Messages.Blank("TRIALSp entry"));
                            return false;
                    }
            }
            if ( pModel.Name.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Name"));
                return false;
            }
            return true;
        }


        [HttpPost("getpagedata/{pScreenId}/{pUserId}/{pRecordsPerPage}/{pPageNo}/{pTableId}/{pLastPage}")]
        public async Task<IActionResult> GetPageData(Int64 pScreenId, Int64 pUserId, Int64 pRecordsPerPage, 
            Int64 pPageNo, Int64 pTableId, Boolean pLastPage)
        {
            SQLResult resultValidation = new SQLResult();
            resultValidation =Functions.ValidateGetPageData(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
            if (resultValidation.ErrorNo > 0)
            {
                return BadRequest(resultValidation.ErrorMessage);
            }
            try
            {
                List<TRIALSpIndex> result = new List<TRIALSpIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]TRIALSpEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel,false) == false)
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


// {
//   "name": "INR",
//   "active": true,
//   "auditColumns": {
//     "approvalStatusId": 1100001,
//     "companyId": 1,
//     "branchId": 10001,
//     "financialYearId": 1,
//     "userId": "100",
//     "mACAddress": "unidentified",
//     "hostName": "unidentified",
//     "iPAddress": "unidentified",
//     "deviceType": "Win32"
//   },
// }



        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]TRIALSpEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel,true) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
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


// {
//   "trialspid":  101, 		
//   "name": "INR",
//   "active": true,
//   "auditColumns": {
//     "approvalStatusId": 1100001,
//     "companyId": 1,
//     "branchId": 10001,
//     "financialYearId": 1,
//     "userId": "100",
//     "mACAddress": "unidentified",
//     "hostName": "unidentified",
//     "iPAddress": "unidentified",
//     "deviceType": "Win32"
//   },
// }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody]TRIALSpEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel,true) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
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
        #endregion -- mTRIALSp

    }

}