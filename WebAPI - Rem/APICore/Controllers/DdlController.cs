using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.Misc;

namespace APICore.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DdlController : ControllerBase
    {

        private readonly ICommon _repo;
        public DdlController(ICommon repo)
        {
            _repo = repo;
        }


        // Country List
        [HttpGet("country/{pNoneRecord}")]
        public async Task<IActionResult> Country(Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mCountry",
                        DisplayColumnName = "Country",
                        IndexColumnName = "mCountryId",
                        WhereClause = "",
                        OrderByClause = "",
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
        // State List
        [HttpGet("state/{pCountryId}/{pNoneRecord}")]
        public async Task<IActionResult> State(Int64 pCountryId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mState",
                        DisplayColumnName = "State",
                        IndexColumnName = "mStateId",
                        WhereClause = pCountryId == 0 ? "" : "mCountryId = " + pCountryId.ToString(),
                        OrderByClause = "",
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

        // City List
        [HttpGet("city/{pStateId}/{pNoneRecord}")]
        public async Task<IActionResult> City(Int64 pStateId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mCity",
                        DisplayColumnName = "City",
                        IndexColumnName = "mCityId",
                        WhereClause = pStateId == 0 ? "" : "mStateId = " + pStateId.ToString(),
                        OrderByClause = "",
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

        [HttpGet("acCountry/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACCountry(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mCountry",
                            DisplayColumnName = "Country",
                            IndexColumnName = "mCountryId",
                            WhereClause = "Country like '%" + pSearchText + "%'",
                            OrderByClause = "Country",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
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

        [HttpGet("acState/{pSearchText}/{pCountryId}/{pNoneRecord}")]
        public async Task<IActionResult> ACState(string pSearchText, Int64 pCountryId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mState",
                            DisplayColumnName = "State",
                            IndexColumnName = "mStateId",
                            WhereClause = "mCountryId = " + pCountryId.ToString() + " and State like '%" + pSearchText + "%'",
                            OrderByClause = "State",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
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

        [HttpGet("acCity/{pSearchText}/{pStateId}/{pNoneRecord}")]
        public async Task<IActionResult> ACCity(string pSearchText, Int64 pStateId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mCity",
                            DisplayColumnName = "City",
                            IndexColumnName = "mCityId",
                            WhereClause = "mStateId = " + pStateId.ToString() + " and City like '%" + pSearchText + "%'",
                            OrderByClause = "City",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
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

        [HttpGet("ddlSortColumn/{pTableId}/{pUserId}")]
        public async Task<IActionResult> DdlPageSortColumns(Int64 pTableId, Int64 pUserId)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mColumn",
                        DisplayColumnName = "ColumnName",
                        IndexColumnName = "mColumnId",
                        WhereClause = "DisplayColumn =  1 and mTableId = " + pTableId.ToString(),
                        OrderByClause = "ColumnName",
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


        // Ledger Group List
        [HttpGet("acLedgergroup/{pSearchText}/{pLedgerGroupId}/{pNoneRecord}")]
        public async Task<IActionResult> ACLedgerGroup(string pSearchText, Int64 pLedgerGroupId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mLedger",
                        DisplayColumnName = "Ledger",
                        IndexColumnName = "mLedgerId",
                        WhereClause = "LedgerGroupFlag = 1 and Active = 1 and Deleted = 0 " + 
                            " and Ledger like '%" + pSearchText + "%'" +
                            (pLedgerGroupId == 0 ? "" : " and mLedgerGroupID = " + pLedgerGroupId.ToString()),
                        OrderByClause = "Ledger",
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

        // Main Ledger Group List
        [HttpGet("mainLedgergroup")]
        public async Task<IActionResult> MainLedgergroup()
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mLedger",
                        DisplayColumnName = "Ledger",
                        IndexColumnName = "mLedgerId",
                        WhereClause = "LedgerGroupFlag = 1 and MainLedgerGroupId = 1 and Active = 1 and Deleted = 0 ",
                        OrderByClause = "Ledger",
                        NoneRecord = true
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

        // Currency List
        [HttpGet("currency/{pNoneRecord}")]
        public async Task<IActionResult> Currency(Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mCurrency",
                        DisplayColumnName = "Currency",
                        IndexColumnName = "mCurrencyId",
                        WhereClause = "",
                        OrderByClause = "",
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