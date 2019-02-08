using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.FA.BK;
using ModelCore.Misc;

namespace APICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {

        private readonly ILedger _repo;
        public LedgerController(ILedger repo)
        {
            _repo = repo;
        }
        #region -- mLedger
        // Get api/Ledger/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            LedgerEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }

        [HttpPost("getpagedata/{pScreenId}/{pUserId}/{pRecordsPerPage}/{pPageNo}/{pTableId}/{pLastPage}")]
        public async Task<IActionResult> GetPageData(Int64 pScreenId, Int64 pUserId, Int64 pRecordsPerPage,
           Int64 pPageNo, Int64 pTableId, Boolean pLastPage)
        {
            SQLResult resultValidation = new SQLResult();
            resultValidation = Functions.ValidateGetPageData(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
            if (resultValidation.ErrorNo > 0)
            {
                return BadRequest(resultValidation.ErrorMessage);
            }
            try
            {
                List<LedgerIndex> result = new List<LedgerIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private bool Validate(LedgerEntry pModel, Boolean UpdateFlag)
        {
            if (UpdateFlag == true)
            {
                if (pModel.LedgerId <= 1)
                {
                    ModelState.AddModelError("", Messages.Blank("Ledger"));
                    return false;
                }
            }
            if (pModel.LedgerCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Ledger Code"));
                return false;
            }
            if (pModel.Ledger.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Ledger"));
                return false;
            }
            if (pModel.LedgerGroupId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Ledger Group"));
                return false;
            }


            if (pModel.MainLedgerGroupId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Main ledger group"));
                return false;
            }
            if (pModel.LedgerTypeId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Ledger type"));
                return false;
            }
            if (pModel.ControlAccountId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Control account"));
                return false;
            }
            if (pModel.AutomaticPostingId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Automatic posting"));
                return false;
            }
            if (pModel.CurrencyId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Currency"));
                return false;
            }
            if (pModel.AuditColumns.CompanyId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("Company"));
                return false;
            }
            if (pModel.AuditColumns.UserId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("User Id"));
                return false;
            }
            if (pModel.AuditColumns.MACAddress.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("MAC Address"));
                return false;
            }
            if (pModel.AuditColumns.HostName.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Host Name"));
                return false;
            }
            if (pModel.AuditColumns.IPAddress.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("IP Address"));
                return false;
            }
            if (pModel.AuditColumns.DeviceType.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Device Type"));
                return false;
            }
            return true;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]LedgerEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel, false) == false)
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
        public async Task<IActionResult> Edit([FromBody]LedgerEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel, true) == false)
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
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody]LedgerEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel, true) == false)
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

        [HttpGet("getMainLedgerGroupId/{pLedgerId}")]
        public async Task<IActionResult> getMainLedgerGroupId(Int64 pLedgerId)
        {
            try
            {
                IDModel result = new IDModel();
                result = await _repo.GetMainLedgerGroupId(pLedgerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        #endregion -- mLedger

    }
}