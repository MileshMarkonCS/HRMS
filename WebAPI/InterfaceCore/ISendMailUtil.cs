using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface ISendMailUtil
    {
        Task<MailConfig> GetMailConfig();
        Task<SQLResult> AddMailToInbox(Int64 pMailConfigId, string pReceiverMailAddress, string pSubjectLine, string pBody, int pPriority, bool pMailStatus);
        Task<SQLResult> UpdateMailStatus(Int64 ptxnMailId, bool pMailStatus);
        Task<SQLResult> UpdateMailStatus(Int64 ptxnMailId, bool pMailStatus, SQLResult pSqlResult);

    }
}
