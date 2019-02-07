using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface IState
    {
        Task<List<StateIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<StateIndex> GetEntry(Int64 id);
        Task<SQLResult> Create(StateEntry pModel);
        Task<SQLResult> Edit(StateEntry pModel);
    }
}
