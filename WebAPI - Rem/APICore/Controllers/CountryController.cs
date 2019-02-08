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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountry _repo;
        public CountryController(ICountry repo)
        {
            _repo = repo;
        }
        #region -- mCountry

        // Get api/counrty/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            CountryIndex result = await _repo.GetEntry(id);
            return Ok(result);
        }

        private bool ValidatemCountry(CountryEntry pModel, AuditColumns pAuditColumns, Boolean isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.CountryId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("Country entry"));
                    return false;
                }
            }
            if (pModel.CountryCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Country code"));
                return false;
            }
            if (pModel.Country.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Country"));
                return false;
            }
            if (pModel.ISOAlpha2Code.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("ISO Alpha 2 Code"));
                return false;
            }
            if (pModel.ISOAlpha3Code.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("ISO Alpha 3 Code"));
                return false;
            }
            if (pModel.ISONumericCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("ISO Numeric Code"));
                return false;
            }
            if (pAuditColumns.UserId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("User"));
                return false;
            }
            if (pAuditColumns.MACAddress.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("MAC Address"));
                return false;
            }
            if (pAuditColumns.HostName.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Host Name"));
                return false;
            }
            if (pAuditColumns.IPAddress.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("IP Address"));
                return false;
            }
            if (pAuditColumns.DeviceType.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Device Type"));
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
                List<CountryIndex> result = new List<CountryIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CountryEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ValidatemCountry(pModel, pModel.AuditColumns, false) == false)
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
        public async Task<IActionResult> Edit([FromBody]CountryEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ValidatemCountry(pModel, pModel.AuditColumns, true) == false)
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
        public async Task<IActionResult> Delete([FromBody]CountryEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ValidatemCountry(pModel, pModel.AuditColumns, true) == false)
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

        #endregion -- mCountry

    }
}
