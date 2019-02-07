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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PageEventsController : ControllerBase
    {

        private readonly IPageEvents _repo;
        public PageEventsController(IPageEvents repo_State)
        {
            _repo = repo_State;
        }
        #region -- Sort Page
        [HttpPost("getsortpageentry/{pTableId}/{pUserId}")]
        public async Task<IActionResult> GetSortPageEntry(Int64 pTableId, Int64 pUserId)
        {
            List<PageSortEntry> result = await _repo.GetSortPageEntry(pTableId, pUserId);
            return Ok(result);
        }
        #endregion


    }
}