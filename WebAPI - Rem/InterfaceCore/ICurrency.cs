using ModelCore.FA.BK.Master;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ICurrency
    {
        Task<List<CurrencyIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<CurrencyEntry> GetEntry(Int64 id);
        Task<SQLResult> Create(CurrencyEntry pModel);
        Task<SQLResult> Edit(CurrencyEntry pModel);
    }
}
