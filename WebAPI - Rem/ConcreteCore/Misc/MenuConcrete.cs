using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.Misc
{
    public class MenuConcrete : IMenu
    {
        private readonly DatabaseContext _Context;

        public MenuConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<List<SpMenus>> SpGetMenus(Int64 pUserId)
        {
            try
            {
                List<SpMenus> result = new List<SpMenus>();
                string csql = @" EXEC spGetMenus
                        @pi_UserId";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                      new SqlParameter("@pi_UserId", pUserId)
                };
                return await _Context.SpMenus.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ScreenRight> GetScreenRight(Int64 pUserId, Int64 pMenuId)
        {
            try
            {
                ScreenRight result = new ScreenRight();
                string csql = @" EXEC spGetScreenRight
                        @pi_UserId, @pi_MenuId";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                      new SqlParameter("@pi_UserId", pUserId),
                      new SqlParameter("@pi_MenuId", pMenuId)
                };
                return await _Context.GetScreenRights.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
