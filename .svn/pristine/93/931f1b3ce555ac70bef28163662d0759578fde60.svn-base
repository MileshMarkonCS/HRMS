using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.Misc
{
    public class PageEventsConcrete : IPageEvents
    {

        private readonly DatabaseContext _Context;

        public PageEventsConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public Task<SQLResult> Create(PageSortEntry pModel)
        {
            throw new NotImplementedException();
        }

        public Task<SQLResult> Edit(PageSortEntry pModel)
        {
            throw new NotImplementedException();
        }

        public Task<PageSortEntry> GetEntry(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PageSortIndex>> GetIndex(long ScreenId, long UserId, long RecordsPerPage, long PageNo, long TableId, bool LastPage)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PageSortEntry>> GetSortPageEntry(Int64 pTableId, Int64 pUserId)
        {
            List<PageSortEntry> result = new List<PageSortEntry>();
            try
            {

                string csql = @" EXEC spmPageColumnsEntry
                    @pi_mTableId
                    , @pi_mUserId";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_mTableId", pTableId) ,
                     new SqlParameter("@pi_mUserId", pUserId) ,
                    };
                return await _Context.PageSortEntry.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SQLResult> UpdateSortPage(List<PageSortEntry> pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                // typ_mPageColumnstable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mPageColumnsParameter = new SqlParameter("@pi_typ_mPageColumns", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mPageColumns"
                };
                var pRowCollection_typ_mPageColumns = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mPageColumnsId", SqlDbType.BigInt)
                                                , new SqlMetaData("mUserId", SqlDbType.BigInt)
                                                , new SqlMetaData("mTableId", SqlDbType.BigInt)
                                                , new SqlMetaData("mColumnId", SqlDbType.BigInt)
                                                , new SqlMetaData("OrderNo", SqlDbType.Int)
                                                , new SqlMetaData("SortOrderNo", SqlDbType.Int)
                                                , new SqlMetaData("mSortDirectionId", SqlDbType.BigInt)
                                                , new SqlMetaData("UserDisplayColumn", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                            );

                    pRow.SetInt64(0, item.PageColumnsId);
                    pRow.SetInt64(1, item.UserId);
                    pRow.SetInt64(2, item.TableId);
                    pRow.SetInt64(3, item.ColumnId);
                    pRow.SetInt32(4, item.OrderNo);
                    pRow.SetInt32(5, item.SortOrderNo);
                    pRow.SetInt64(6, item.SortDirectionId);
                    pRow.SetBoolean(7, item.DisplayColumn);
                    pRow.SetBoolean(8, item.Deleted);

                    pRowCollection_typ_mPageColumns.Add(pRow);
                }

                ptyp_mPageColumnsParameter.Value = pRowCollection_typ_mPageColumns;
                string csql = @" EXEC spmPageColumnsPageSortUpdate
                    @pi_typ_mPageColumns";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                    ptyp_mPageColumnsParameter
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
