using InterfaceCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using ModelCore.HRMS.Admin.Test;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.HRMS.Admin.Test
{
    public class TRIALSpConcrete : ITRIALSp
    {
        private readonly DatabaseContext _Context;

        public TRIALSpConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<List<TRIALSpIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
        {
            TRIALSpIndex result = new TRIALSpIndex();

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
                return await _Context.TRIALSpIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    public async Task<SQLResult> Create(TRIALSpEntry pModel)
    {
	SQLResult result = new SQLResult();
	_Context.Database.BeginTransaction();
	try
	{
		string csql = @" EXEC spmTRIALSpInsert
							@pi_Name
							, @pi_Active
							, @pi_UserId
							, @pi_HostName
							, @pi_IPAddress
							, @pi_DeviceType
							, @pi_MACAddress
		";
		List<SqlParameter> sqlparam = new List<SqlParameter>() {
			 new SqlParameter("@pi_Name", pModel.Name) , 
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

    public async Task<SQLResult> Edit(TRIALSpEntry pModel)
    {
	SQLResult result = new SQLResult();
	_Context.Database.BeginTransaction();
	try
	{
		string csql = @" EXEC spmTRIALSpUpdate
							@pi_mTRIALSpId
							, @pi_Name
							, @pi_Active
							, @pi_UserId
							, @pi_HostName
							, @pi_IPAddress
							, @pi_DeviceType
							, @pi_MACAddress
		";
			List<SqlParameter> sqlparam = new List<SqlParameter>() {
			 new SqlParameter("@pi_mTRIALSpId", pModel.TRIALSpId) , 
			 new SqlParameter("@pi_Name", pModel.Name) , 
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

     public async Task<SQLResult> Delete(TRIALSpEntry pModel)
    {
		SQLResult result = new SQLResult();
		_Context.Database.BeginTransaction();
		try
		{
				string csql = @" EXEC spmTRIALSpDelete
									@pi_mTRIALSpId
									, @pi_UserId
									, @pi_HostName
									, @pi_IPAddress
									, @pi_DeviceType
									, @pi_MACAddress
				";
						List<SqlParameter> sqlparam = new List<SqlParameter>() {
						 new SqlParameter("@pi_mTRIALSpId", pModel.TRIALSpId) , 
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

        public async Task<TRIALSpIndex> GetEntry(Int64 id)
        {
            try
            {
                TRIALSpIndex result = await _Context.TRIALSpIndex.FromSql("Exec spmTRIALSpEntry @pi_mTRIALSpId", new SqlParameter("@pi_mTRIALSpId", id)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}