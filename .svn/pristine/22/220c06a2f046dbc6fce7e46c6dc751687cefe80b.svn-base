using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ICountry
    {
        Task<List<CountryIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<CountryIndex> GetEntry(Int64 id);
        Task<SQLResult> Create(CountryEntry pModel);
        Task<SQLResult> Edit(CountryEntry pModel);
        Task<SQLResult> Delete(CountryEntry pModel);
    }
}
