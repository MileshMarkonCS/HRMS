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
    public class BankController : ControllerBase
    {
        private readonly IBank _repo;
        public BankController(IBank repo)
        {
            _repo = repo;
        }
        #region -- mBank
        private bool Validate(BankEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.BankId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("Bank entry"));
                    return false;
                }
            }
            if (pModel.Bank.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Bank"));
                return false;
            }
            if (pModel.BankReferenceNo.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Bank reference number"));
                return false;
            }
            if (pModel.BankClearingNo.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Bank clearing number"));
                return false;
            }
            return true;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]BankEntry pModel)
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
        public async Task<IActionResult> Edit([FromBody]BankEntry pModel)
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
       #endregion -- mBank

    }
}