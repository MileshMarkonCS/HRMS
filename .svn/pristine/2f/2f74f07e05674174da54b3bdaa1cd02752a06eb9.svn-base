using ModelCore.FA.BK;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface IBank
    {
        Task<List<BankIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<BankIndex> GetEntry(Int64 id);
        Task<SQLResult> Create(BankEntry pModel);
        Task<SQLResult> Edit(BankEntry pModel);
    }
}
