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
    public class MenuController : ControllerBase
    {
        private readonly IMenu _repo_Menu;
        public MenuController(IMenu repo_Menu)
        {
            _repo_Menu = repo_Menu;
        }
        #region -- Menu

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            List<SpMenus> result = await _repo_Menu.SpGetMenus(id);
            List<NavItem> mNav = new List<NavItem>();
            List<NavItem> mNavDummy = new List<NavItem>();
            mNav = Functions.GenerateNav(mNavDummy, result, 0);
            return Ok(mNav);
        }

        [HttpPost("getScreenRights/{pUserId}/{pMenuId}")]
        public async Task<IActionResult> GetScreenRights(Int64 pUserId, Int64 pMenuId)
        {
            try
            {
                ScreenRight result = new ScreenRight();

                result = await _repo_Menu.GetScreenRight(pUserId, pMenuId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        /*
        private bool ValidateMenu(SpMenus pModel)
        {
            return true;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody]MenuEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ValidateMenu(pModel) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Preparing audit columns

                AuditColumns mAuditColumns = new AuditColumns
                {
                    ApprovalStatusId = 0,
                    DeviceType = pModel.DeviceTypeCR,
                    HostName = pModel.HostNameCR,
                    IPAddress = pModel.IPAddressCR,
                    MACAddress = pModel.MACAddressCR,
                    CompanyId = pModel.CompanyId,
                    DivisionId = pModel.DivisionId,
                    FinancialYearId = pModel.FinancialYearId,
                    UserId = pModel.UserCR
                };
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo_Menu.MenuCreate(pModel, mAuditColumns);
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
        [HttpPost]
        public async Task<IActionResult> EditMenu([FromBody]MenuEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ValidateMenu(pModel) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Preparing audit columns

                AuditColumns mAuditColumns = new AuditColumns
                {
                    ApprovalStatusId = 0,
                    DeviceType = pModel.DeviceTypeCR,
                    HostName = pModel.HostNameCR,
                    IPAddress = pModel.IPAddressCR,
                    MACAddress = pModel.MACAddressCR,
                    CompanyId = pModel.CompanyId,
                    DivisionId = pModel.DivisionId,
                    FinancialYearId = pModel.FinancialYearId,
                    UserId = pModel.UserCR
                };
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo_Menu.MenuEdit(pModel, mAuditColumns);
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
        [HttpPost]
        public async Task<IActionResult> DeleteMenu([FromBody]MenuEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ValidateMenu(pModel) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Preparing audit columns

                AuditColumns mAuditColumns = new AuditColumns
                {
                    ApprovalStatusId = 0,
                    DeviceType = pModel.DeviceTypeCR,
                    HostName = pModel.HostNameCR,
                    IPAddress = pModel.IPAddressCR,
                    MACAddress = pModel.MACAddressCR,
                    CompanyId = pModel.CompanyId,
                    DivisionId = pModel.DivisionId,
                    FinancialYearId = pModel.FinancialYearId,
                    UserId = pModel.UserCR
                };
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo_Menu.MenuDelete(pModel, mAuditColumns);
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
        */
        #endregion -- Menu

    }
}