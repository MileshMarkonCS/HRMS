using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.Security.Admin.Regional
{
    public class CityConcrete : ICity
    {

        private readonly DatabaseContext _Context;

        public CityConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<List<CityIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
        {
            try
            {
                string csql = @" EXEC spGetPageData
                    @pi_mScreenId
                    , @pi_mUserId
                    , @pi_RecordsPerPage
                    , @pi_PageNo
                    , @pi_mTableId
                    , @pi_LastPage";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_mScreenId", ScreenId) ,
                     new SqlParameter("@pi_mUserId", UserId) ,
                     new SqlParameter("@pi_RecordsPerPage", RecordsPerPage) ,
                     new SqlParameter("@pi_PageNo", PageNo) ,
                     new SqlParameter("@pi_mTableId", TableId) ,
                     new SqlParameter("@pi_LastPage", LastPage) ,
                    };
                return await _Context.CityIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CityIndex> GetEntry(Int64 id)
        {
            try
            {
                CityIndex result = await _Context.CityIndex.FromSql("Exec spmCityEntry @pi_mCityId", new SqlParameter("@pi_mCityId", id)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SQLResult> Create(CityEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmCityInsert
                    @pi_CityCode
                    , @pi_City
                    , @pi_mCountryId
                    , @pi_mStateId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                 new SqlParameter("@pi_CityCode", pModel.CityCode) ,
                 new SqlParameter("@pi_City", pModel.City) ,
                 new SqlParameter("@pi_mCountryId", pModel.CountryId) ,
                 new SqlParameter("@pi_mStateId", pModel.StateId) ,
                 new SqlParameter("@pi_Active", pModel.Active) ,
                 new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                 new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                 new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                 new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                 new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
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

        public async Task<SQLResult> Edit(CityEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmCityUpdate
                    @pi_mCityId
                    , @pi_CityCode
                    , @pi_City
                    , @pi_mCountryId
                    , @pi_mStateId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                 new SqlParameter("@pi_mCityId", pModel.CityId) ,
                 new SqlParameter("@pi_CityCode", pModel.CityCode) ,
                 new SqlParameter("@pi_City", pModel.City) ,
                 new SqlParameter("@pi_mCountryId", pModel.CountryId) ,
                 new SqlParameter("@pi_mStateId", pModel.StateId) ,
                 new SqlParameter("@pi_Active", pModel.Active) ,
                 new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                 new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                 new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                 new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                 new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
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

    }
}
