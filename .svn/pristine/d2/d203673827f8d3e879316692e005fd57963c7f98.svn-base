using ModelCore.Misc;
using ModelCore.HRMS.Admin.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ITRIALSp
    {
        Task<List<TRIALSpIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<TRIALSpIndex> GetEntry(Int64 id);
        Task<SQLResult> Create(TRIALSpEntry pModel);
        Task<SQLResult> Edit(TRIALSpEntry pModel);
        Task<SQLResult> Delete(TRIALSpEntry pModel);
    }
}