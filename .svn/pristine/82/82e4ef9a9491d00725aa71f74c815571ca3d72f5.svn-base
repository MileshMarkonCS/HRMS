using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using ModelCore.HRMS.Admin.Recruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface IHRMSRolesResponsibility
    {
        Task<List<HRMSRolesResponsibilityIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<HRMSRolesResponsibilityEntry> GetEntry(Int64 id);
        Task<SQLResult> Create(HRMSRolesResponsibilityEntry pModel);
        Task<SQLResult> Edit(HRMSRolesResponsibilityEntry pModel);
        Task<SQLResult> Delete(HRMSRolesResponsibilityEntry pModel);
    }
}
