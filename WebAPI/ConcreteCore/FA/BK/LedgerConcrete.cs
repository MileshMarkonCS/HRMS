using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.FA.BK;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.FA.BK
{
    public class LedgerConcrete : ILedger
    {

        private readonly DatabaseContext _Context;

        public LedgerConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<LedgerEntry> GetEntry(Int64 id)
        {
            try
            {
                LedgerEntry result = await _Context.LedgerEntry.FromSql("Exec spmLedgerEntry @pi_mLedgerId", new SqlParameter("@pi_mLedgerId", id)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LedgerIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
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
                return await _Context.LedgerIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<SQLResult> Create(LedgerEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmLedgerInsert
                    @pi_LedgerCode
                    , @pi_Ledger
                    , @pi_LedgerGroupFlag
                    , @pi_LedgerGroupId
                    , @pi_MainLedgerGroupId
                    , @pi_LedgerTypeId
                    , @pi_ControlAccountId
                    , @pi_NoJVPosting
                    , @pi_AutomaticPostingId
                    , @pi_mCurrencyId
                    , @pi_LevelNo
                    , @pi_EffectiveFrom
                    , @pi_EffectiveTo
                    , @pi_AnalysisCodeApplicableFlag
                    , @pi_CostCenterApplication
                    , @pi_VersionNo
                    , @pi_Active
                    , @pi_mMyParentId
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                 new SqlParameter("@pi_LedgerCode", pModel.LedgerCode) ,
                 new SqlParameter("@pi_Ledger", pModel.Ledger) ,
                 new SqlParameter("@pi_LedgerGroupFlag", pModel.LedgerGroupFlag) ,
                 new SqlParameter("@pi_LedgerGroupId", pModel.LedgerGroupId) ,
                 new SqlParameter("@pi_MainLedgerGroupId", pModel.MainLedgerGroupId) ,
                 new SqlParameter("@pi_LedgerTypeId", pModel.LedgerTypeId) ,
                 new SqlParameter("@pi_ControlAccountId", pModel.ControlAccountId) ,
                 new SqlParameter("@pi_NoJVPosting", pModel.NoJVPosting) ,
                 new SqlParameter("@pi_AutomaticPostingId", pModel.AutomaticPostingId) ,
                 new SqlParameter("@pi_mCurrencyId", pModel.CurrencyId) ,
                 new SqlParameter("@pi_LevelNo", pModel.LevelNo) ,
                 new SqlParameter("@pi_EffectiveFrom", pModel.EffectiveFrom) ,
                 new SqlParameter("@pi_EffectiveTo", pModel.EffectiveTo) ,
                 new SqlParameter("@pi_AnalysisCodeApplicableFlag", pModel.AnalysisCodeApplicableFlag) ,
                 new SqlParameter("@pi_CostCenterApplication", pModel.CostCenterApplication) ,
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

        public Task<SQLResult> Delete(LedgerEntry pModel)
        {
            throw new NotImplementedException();
        }

        public async Task<SQLResult> Edit(LedgerEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmLedgerUpdate
                    @pi_mLedgerId
                    , @pi_LedgerCode
                    , @pi_Ledger
                    , @pi_LedgerGroupFlag
                    , @pi_LedgerGroupId
                    , @pi_MainLedgerGroupId
                    , @pi_LedgerTypeId
                    , @pi_ControlAccountId
                    , @pi_NoJVPosting
                    , @pi_AutomaticPostingId
                    , @pi_mCurrencyId
                    , @pi_LevelNo
                    , @pi_EffectiveFrom
                    , @pi_EffectiveTo
                    , @pi_AnalysisCodeApplicableFlag
                    , @pi_CostCenterApplication
                    , @pi_VersionNo
                    , @pi_Active
                    , @pi_mMyParentId
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_mLedgerId", pModel.LedgerId) ,
                     new SqlParameter("@pi_LedgerCode", pModel.LedgerCode) ,
                     new SqlParameter("@pi_Ledger", pModel.Ledger) ,
                     new SqlParameter("@pi_LedgerGroupFlag", pModel.LedgerGroupFlag) ,
                     new SqlParameter("@pi_LedgerGroupId", pModel.LedgerGroupId) ,
                     new SqlParameter("@pi_MainLedgerGroupId", pModel.MainLedgerGroupId) ,
                     new SqlParameter("@pi_LedgerTypeId", pModel.LedgerTypeId) ,
                     new SqlParameter("@pi_ControlAccountId", pModel.ControlAccountId) ,
                     new SqlParameter("@pi_NoJVPosting", pModel.NoJVPosting) ,
                     new SqlParameter("@pi_AutomaticPostingId", pModel.AutomaticPostingId) ,
                     new SqlParameter("@pi_mCurrencyId", pModel.CurrencyId) ,
                     new SqlParameter("@pi_LevelNo", pModel.LevelNo) ,
                     new SqlParameter("@pi_EffectiveFrom", pModel.EffectiveFrom) ,
                     new SqlParameter("@pi_EffectiveTo", pModel.EffectiveTo) ,
                     new SqlParameter("@pi_AnalysisCodeApplicableFlag", pModel.AnalysisCodeApplicableFlag) ,
                     new SqlParameter("@pi_CostCenterApplication", pModel.CostCenterApplication) ,
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

        public async Task<IDModel> GetMainLedgerGroupId(Int64 pLedgerId)
        {
            SQLResult result = new SQLResult();
            try
            {
                string csql = @" EXEC spGetMainLedgerGroupId
                    @pi_mLedgerId";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                    new SqlParameter("@pi_mLedgerId", pLedgerId) ,
                };
                return await _Context.IDModel.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
