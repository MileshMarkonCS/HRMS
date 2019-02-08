using ModelCore.FA.BK;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ILedger
    {
        Task<LedgerEntry> GetEntry(Int64 id);
        Task<List<LedgerIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<SQLResult> Create(LedgerEntry pModel);
        Task<SQLResult> Edit(LedgerEntry pModel);
        Task<SQLResult> Delete(LedgerEntry pModel);
        Task<IDModel> GetMainLedgerGroupId(Int64 pLedgerId);
    }
}
