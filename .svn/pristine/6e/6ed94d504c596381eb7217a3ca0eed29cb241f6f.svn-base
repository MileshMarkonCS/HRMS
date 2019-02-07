using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.Misc;

namespace APICore.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommon _repo;
        public CommonController(ICommon repo)
        {
            _repo = repo;
        }


        // Misc List
        [HttpGet("selectddlmisc/{pMiscId}/{pParentMiscId}")]
        public async Task<IActionResult> SelectDdlMisc(Int64 pMiscId, Int64 pParentMiscId)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "MiscDetail",
                        DisplayColumnName = "MiscText",
                        IndexColumnName = "MiscDetailId",
                        WhereClause = " MiscId = " + pMiscId.ToString() + " and ParentMiscDetailId = " + pParentMiscId.ToString(),
                        OrderByClause = "OrderNo",
                        NoneRecord = false
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        // Misc List
        [HttpGet("selectddlmisc/{pMiscId}/{pParentMiscId}/{pNoneRecord}")]
        public async Task<IActionResult> SelectDdlMisc(Int64 pMiscId, Int64 pParentMiscId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "MiscDetail",
                        DisplayColumnName = "MiscText",
                        IndexColumnName = "MiscDetailId",
                        WhereClause = " MiscId = " + pMiscId.ToString() + " and ParentMiscDetailId = " + pParentMiscId.ToString(),
                        OrderByClause = "OrderNo",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }



    }
}