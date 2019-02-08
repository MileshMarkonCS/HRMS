using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface IPageEvents
    {
        Task<List<PageSortEntry>> GetSortPageEntry(Int64 pTableId, Int64 pUserId);
        Task<List<PageSortIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<PageSortEntry> GetEntry(Int64 id);
        Task<SQLResult> Create(PageSortEntry pModel);
        Task<SQLResult> Edit(PageSortEntry pModel);
        Task<SQLResult> UpdateSortPage(List<PageSortEntry> pModel);
    }
}
