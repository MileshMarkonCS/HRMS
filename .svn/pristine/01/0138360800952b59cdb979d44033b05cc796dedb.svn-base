using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelCore.Misc;
using ModelCore.Security.User;

namespace APICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _repo;
        private readonly IConfiguration _config;
        //private readonly ISendMailUtil _sendMailUtil;
        //private readonly ISendSMSUtil _sendSMSUtil;

        public UserController(
            IUser repo,
            IConfiguration config
            //ISendMailUtil sendMailUtil,
            //ISendSMSUtil sendSMSUtil
            )
        {
            _repo = repo;
            _config = config;
            //_sendMailUtil = sendMailUtil;
            //_sendSMSUtil = sendSMSUtil;
        }

        #region Change Password
        // Change Password
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePassword pModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                SignInUserProfile mLogin = await _repo.GetUserProfileAsync(pModel.Username);
                if (mLogin is null)
                {
                    ModelState.AddModelError("", Messages.Invalid("username or password"));
                    return BadRequest(ModelState);
                }
                if (mLogin.Active != true)
                {
                    ModelState.AddModelError("", Messages.ShowErrorMessage("User not active, please contact your software support to activation!"));
                    return BadRequest(ModelState);
                }
                AuditColumns mAuditColumns = new AuditColumns
                {
                    UserId = 1,
                    ApprovalStatusId = 0,
                    CompanyId = 10001,
                    DeviceType = "Undefined",
                    FinancialYearId = 1,
                    HostName = "Undefined",
                    IPAddress = "Undefined",
                    MACAddress = "Undefined"
                };
                // Password generation
                byte[] passwordHash;
                byte[] passwordSalt;
                Functions.CreatePasswordHash(pModel.Password, out passwordHash, out passwordSalt);
                pModel.PasswordHash = passwordHash;
                pModel.PasswordSalt = passwordSalt;

                SQLResult result = await _repo.ChangePassword(pModel, mAuditColumns);
                if (result.ErrorNo == 0)
                {
                    return Ok(result);
                } else
                {
                    return BadRequest(result);
                }
            }
            catch(Exception ex)
            {
                SQLResult errorResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errorResult);
            }
        }
        #endregion Change Password

        #region Login In
        // Sign In
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login pModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {


                SignInUserProfile mLogin = await _repo.Login(pModel.Username);
                if (mLogin is null)
                {
                    ModelState.AddModelError("", Messages.Invalid("username or password"));
                    return BadRequest(ModelState);
                }
                if (mLogin.Active != true)
                {
                    ModelState.AddModelError("", Messages.ShowErrorMessage("User not active, please contact your software support to active!"));
                    return BadRequest(ModelState);
                }
                SQLResult spres = Functions.VerifyPasswordHash(pModel.Password, mLogin.PasswordHash, mLogin.PasswordSalt);
                if (spres.ErrorNo != 0)
                {
                    ModelState.AddModelError("", spres.ErrorMessage);
                    return BadRequest(ModelState);
                }
                string mToken = Functions.GenerateToken(mLogin.UserId, mLogin.UserName, mLogin.FirstName, _config);
                mLogin.Token = mToken;
                return Ok(mLogin);
            }
            catch(Exception ex)
            {
                SQLResult errorResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errorResult);
            }
        }
        #endregion Login In
    }
}