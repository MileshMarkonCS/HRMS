using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ISendSMSUtil
    {
        Task<SQLResult> GetSMSConfig();
    }
}
