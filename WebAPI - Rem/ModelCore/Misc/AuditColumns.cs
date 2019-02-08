using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    [NotMapped]
    public class AuditColumns
    {
        [Display(Name = "Approval Status")]
        public Int64 ApprovalStatusId { get; set; }

        [Display(Name = "Company")]
        public Int64 CompanyId { get; set; }

        [Display(Name = "BranchId")]
        public Int64 BranchId { get; set; }

        [Display(Name = "Financial Year")]
        public Int64 FinancialYearId { get; set; }

        [Display(Name = "User")]
        public Int64 UserId { get; set; }

        [Display(Name = "MAC Address")]
        public string MACAddress { get; set; }

        [Display(Name = "Host Name")]
        public string HostName { get; set; }

        [Display(Name = "IP Address")]
        public string IPAddress { get; set; }

        [Display(Name = "Device Type")]
        public string DeviceType { get; set; }
    }
}
