using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using ModelCore.Security.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.Security.User
{
    public class UserConcrete : IUser
    {
        private readonly DatabaseContext _Context;

        public UserConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<SignInUserProfile> GetUserProfileAsync(string _username)
        {
            try
            {
                SignInUserProfile result = await _Context.SignInUserProfile.FromSql(
                    "Exec spGetUserProfile @pi_UserName",
                    new SqlParameter("@pi_UserName", _username)
                    ).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserProfile> GetUserProfileWithIdAsync(long pUserId)
        {
            try
            {
                UserProfile result = await _Context.UserProfile.FromSql(
                    "Exec spGetUserProfileWithId @pi_UserId",
                    new SqlParameter("@pi_UserId", pUserId)
                    ).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UserExists(string _username)
        {
            try
            {
                SQLResult result = await _Context.DBResult.FromSql(
                    "Exec spUserExists @pi_UserName",
                    new SqlParameter("@pi_UserName", _username)
                    ).SingleOrDefaultAsync();
                return (result.ErrorNo > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SQLResult> ChangePassword(ChangePassword pModel, AuditColumns pAuditColumns)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmUserChangePassword
                    @pi_mUserId
                    , @pi_UserName
                    , @pi_Password
                    , @pi_PasswordHash
                    , @pi_PasswordSalt
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_mUserId", pModel.UserId) ,
                     new SqlParameter("@pi_UserName", pModel.Username) ,
                     new SqlParameter("@pi_Password", pModel.Password) ,
                     new SqlParameter("@pi_PasswordHash", pModel.PasswordHash) ,
                     new SqlParameter("@pi_PasswordSalt", pModel.PasswordSalt) ,
                     new SqlParameter("@pi_UserId", pAuditColumns.UserId) ,
                     new SqlParameter("@pi_HostName", pAuditColumns.HostName) ,
                     new SqlParameter("@pi_IPAddress", pAuditColumns.IPAddress) ,
                     new SqlParameter("@pi_DeviceType", pAuditColumns.DeviceType) ,
                     new SqlParameter("@pi_MACAddress", pAuditColumns.MACAddress) ,
                };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
                if (result.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                }
                else
                {
                    _Context.Database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _Context.Database.RollbackTransaction();
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }

        public async Task<SignInUserProfile> Login(string _username)
        {
            try
            {
                SignInUserProfile result = await _Context.SignInUserProfile.FromSql(
                    "Exec spLogin @pi_UserName",
                    new SqlParameter("@pi_UserName", _username)
                    ).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
