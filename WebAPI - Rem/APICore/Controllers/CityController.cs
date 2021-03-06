﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;

namespace APICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICity _repo;
        public CityController(ICity repo)
        {
            _repo = repo;
        }

        #region -- mCity
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            CityIndex result = await _repo.GetEntry(id);
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
                List<CityIndex> result = new List<CityIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private bool Validate(CityEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.CityId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("City entry"));
                    return false;
                }
            }
            if (pModel.CityCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Code"));
                return false;
            }
            if (pModel.City.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("City"));
                return false;
            }
            if (pModel.CountryId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("CountryId"));
                return false;
            }
            if (pModel.StateId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("StateId"));
                return false;
            }
            return true;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CityEntry pModel)
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
        public async Task<IActionResult> Edit([FromBody]CityEntry pModel)
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
        #endregion -- mCity
    }
}