using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.HRMS.Admin.Recruitment;
using ModelCore.Misc;

namespace APICore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HRMSRolesResponsibilityController : Controller
    {
        private readonly IHRMSRolesResponsibility _repo;
        public HRMSRolesResponsibilityController(IHRMSRolesResponsibility repo)
        {
            _repo = repo;
        }

        #region -- mHRMSRolesResponsibility

        // Get api/Ledger/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            HRMSRolesResponsibilityEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }

        // [HttpPost("getpagedata/{pScreenId}/{pUserId}/{pRecordsPerPage}/{pPageNo}/{pTableId}/{pLastPage}")]
        // public async Task<IActionResult> GetPageData(Int64 pScreenId, Int64 pUserId, Int64 pRecordsPerPage,
        //    Int64 pPageNo, Int64 pTableId, Boolean pLastPage)
        // {
        //     SQLResult resultValidation = new SQLResult();
        //     resultValidation = Functions.ValidateGetPageData(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
        //     if (resultValidation.ErrorNo > 0)
        //     {
        //         return BadRequest(resultValidation.ErrorMessage);
        //     }
        //     try
        //     {
        //         List<HRMSRolesResponsibilityIndex> result = new List<HRMSRolesResponsibilityIndex>();

        //         result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
        //         return Ok(result);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message.ToString());
        //     }
        // }



        // private bool Validate(HRMSRolesResponsibilityEntry pModel, bool isUpdateValidation)
        // {
        //     if (isUpdateValidation == true)
        //     {
        //         if (pModel.HRMSRolesResponsibilityId <= 0)
        //         {
        //             ModelState.AddModelError("", Messages.Blank("HRMSRolesResponsibility entry"));
        //             return false;
        //         }
        //     }
        //     if (pModel.ResponsibilityName.Trim().Length == 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("Name"));
        //         return false;
        //     }
        //     if (pModel.Description.Trim().Length == 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("Description"));
        //         return false;
        //     }
        //     if (pModel.AuditColumns.CompanyId <= 1)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("Company"));
        //         return false;
        //     }
        //     if (pModel.AuditColumns.UserId <= 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("User Id"));
        //         return false;
        //     }
        //     if (pModel.AuditColumns.MACAddress.Trim().Length == 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("MAC Address"));
        //         return false;
        //     }
        //     if (pModel.AuditColumns.HostName.Trim().Length == 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("Host Name"));
        //         return false;
        //     }
        //     if (pModel.AuditColumns.IPAddress.Trim().Length == 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("IP Address"));
        //         return false;
        //     }
        //     if (pModel.AuditColumns.DeviceType.Trim().Length == 0)
        //     {
        //         ModelState.AddModelError("", Messages.Blank("Device Type"));
        //         return false;
        //     }
        //     return true;
        // }


        // [HttpPost("create")]
        // public async Task<IActionResult> Create([FromBody]HRMSRolesResponsibilityEntry pModel)
        // {
        //     // Validation
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     if (Validate(pModel,false) == false)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     else
        //     {
        //         // Execution of concrete process
        //         SQLResult result = new SQLResult();
        //         //result = await _repo_mHRMSRolesResponsibility.mHRMSRolesResponsibilityCreate(pModel, mAuditColumns);
        //         result = await _repo.Create(pModel);
        //         if (result.ErrorNo > 0)
        //         {
        //             return BadRequest(result);
        //         }
        //         else
        //         {
        //             return Ok(result);
        //         }
        //     }
        // }



        // [HttpPost("edit")]
        // public async Task<IActionResult> Edit([FromBody]HRMSRolesResponsibilityEntry pModel)
        // {
        //     // Validation
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     if (Validate(pModel,true) == false)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     else
        //     {
        //         // Execution of concrete process
        //         SQLResult result = new SQLResult();
        //         //result = await _repo_mHRMSRolesResponsibility.mHRMSRolesResponsibilityEdit(pModel, mAuditColumns);
        //         result = await _repo.Edit(pModel);
        //         if (result.ErrorNo > 0)
        //         {
        //             return BadRequest(result);
        //         }
        //         else
        //         {
        //             return Ok(result);
        //         }
        //     }
        // }



        // [HttpPost("delete")]
        // public async Task<IActionResult> Delete([FromBody]HRMSRolesResponsibilityEntry pModel)
        // {
        //     // Validation
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     if (Validate(pModel,true) == false)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     else
        //     {
        //         // Execution of concrete process
        //         SQLResult result = new SQLResult();
        //         //result = await _repo_mHRMSRolesResponsibility.mHRMSRolesResponsibilityDelete(pModel, mAuditColumns);
        //         result = await _repo.Delete(pModel);
        //         if (result.ErrorNo > 0)
        //         {
        //             return BadRequest(result);
        //         }
        //         else
        //         {
        //             return Ok(result);
        //         }
        //     }
        // }
        #endregion -- mHRMSRolesResponsibility
    }
}
