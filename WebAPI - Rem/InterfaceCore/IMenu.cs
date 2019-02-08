using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface IMenu
    {
        Task<List<SpMenus>> SpGetMenus(Int64 pUserId);
        Task<ScreenRight> GetScreenRight(Int64 pUserId, Int64 pMenuId);
    }
}
