using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ICity
    {
        Task<List<CityIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<CityIndex> GetEntry(Int64 id);
        Task<SQLResult> Create(CityEntry pModel);
        Task<SQLResult> Edit(CityEntry pModel);
    }
}
