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
    public class BankConcrete : IBank
    {
        private readonly DatabaseContext _Context;

        public BankConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<List<BankIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
        {
            BankIndex result = new BankIndex();

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
                return await _Context.BankIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BankIndex> GetEntry(Int64 id)
        {
            try
            {
                BankIndex result = await _Context.BankIndex.FromSql("Exec spmBankEntry @pi_mBankId", new SqlParameter("@pi_mCityId", id)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SQLResult> Create(BankEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmBankInsert
                    @pi_Bank
                    , @pi_BankReferenceNo
                    , @pi_BankClearingNo
                    , @pi_CashAccount
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mBankDetail";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_Bank", pModel.Bank) ,
                     new SqlParameter("@pi_BankReferenceNo", pModel.BankReferenceNo) ,
                     new SqlParameter("@pi_BankClearingNo", pModel.BankClearingNo) ,
                     new SqlParameter("@pi_CashAccount", pModel.CashAccount) ,
                     new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                     new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                     new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                     new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                     new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                     new SqlParameter("@pi_typ_mBankDetail", pModel.BankDetailEntry) ,
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

        public Task<SQLResult> Edit(BankEntry pModel)
        {
            throw new NotImplementedException();
        }
    }
}
