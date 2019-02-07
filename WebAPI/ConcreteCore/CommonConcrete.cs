using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore
{
    public class CommonConcrete : ICommon
    {

        private readonly DatabaseContext _Context;

        public CommonConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<List<SelectDdl>> GetSelectDdl(SelectDdlParameters pModel)
        {
            List<SelectDdl> result = new List<SelectDdl>();
            try
            {
                string csql = @" EXEC GetSelectDdl
                    @pi_TableName
                    , @pi_DisplayColumnName
                    , @pi_IndexColumnName
                    , @pi_WhereClause
                    , @pi_OrderByClause
                    , @pi_NoneRecord";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                 new SqlParameter("@pi_TableName", pModel.TableName) ,
                 new SqlParameter("@pi_DisplayColumnName", pModel.DisplayColumnName) ,
                 new SqlParameter("@pi_IndexColumnName", pModel.IndexColumnName) ,
                 new SqlParameter("@pi_WhereClause", pModel.WhereClause) ,
                 new SqlParameter("@pi_OrderByClause", pModel.OrderByClause) ,
                 new SqlParameter("@pi_NoneRecord", pModel.NoneRecord) ,
                };
                result = await _Context.SelectDdl.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}
