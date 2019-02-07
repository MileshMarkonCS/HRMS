using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.FA.BK.Master;
using ModelCore.Misc;

namespace APICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly ICurrency _repo;
        public CurrencyController(ICurrency repo_mCurrency)
        {
            _repo = repo_mCurrency;
        }
        #region -- mCurrency
        // Get api/Currency/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            CurrencyEntry result = await _repo.GetEntry(id);
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
                List<CurrencyIndex> result = new List<CurrencyIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        private bool Validate(CurrencyEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.CurrencyId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("Currency entry"));
                    return false;
                }
            }
            if (pModel.CurrencyCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Code"));
                return false;
            }
            if (pModel.Currency.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Currency"));
                return false;
            }
            if (pModel.Description.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Description"));
                return false;
            }
            if (pModel.CurrencySymbol.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Symbol"));
                return false;
            }
            return true;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CurrencyEntry pModel)
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
        public async Task<IActionResult> Edit([FromBody]CurrencyEntry pModel)
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
        #endregion -- mCurrency

    }
}