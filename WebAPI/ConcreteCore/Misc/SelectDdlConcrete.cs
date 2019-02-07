using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.Misc
{
    public class SelectDdlConcrete
    {
        //public async task<list<selectddl>> getselectddl(selectddlparameters pmodel)
        //{

        //    try
        //    {
        //        list<selectddl> result = new list<selectddl>();
        //        string csql = @" exec getselectddl
        //            @pi_tablename
        //            , @pi_displaycolumnname
        //            , @pi_indexcolumnname
        //            , @pi_whereclause
        //            , @pi_orderbyclause
        //            , @pi_nonerecord";
        //        list<sqlparameter> sqlparam = new list<sqlparameter>() {
        //             new sqlparameter("@pi_tablename", pmodel.tablename) ,
        //             new sqlparameter("@pi_displaycolumnname", pmodel.displaycolumnname) ,
        //             new sqlparameter("@pi_indexcolumnname", pmodel.indexcolumnname) ,
        //             new sqlparameter("@pi_whereclause", pmodel.whereclause) ,
        //             new sqlparameter("@pi_orderbyclause", pmodel.orderbyclause) ,
        //             new sqlparameter("@pi_nonerecord", pmodel.nonerecord) ,
        //            };
        //        result = await _context.getselectddl.fromsql(csql, sqlparam.toarray()).tolistasync();
        //        return result;
        //    }
        //    catch (exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
