using ModelCore.CRM.Lead;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ICRMLead
    {
        Task<List<CRMLeadIndex>> GetIndex();
        Task<SQLResult> Create(CRMLeadEntry pModel);
        Task<SQLResult> Edit(CRMLeadEntry pModel);
        Task<SQLResult> Delete(CRMLeadEntry pModel);
    }
}
