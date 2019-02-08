using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsbranch
    {
        public MThrmsbranch()
        {
            MThrmsemployee = new HashSet<MThrmsemployee>();
            MThrmsmanPowerBudget = new HashSet<MThrmsmanPowerBudget>();
            MThrmsresourceRequisition = new HashSet<MThrmsresourceRequisition>();
        }

        public long MThrmsbranchId { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public long? MThrmscompanyId { get; set; }
        public bool? Active { get; set; }

        public MThrmscompany MThrmscompany { get; set; }
        public ICollection<MThrmsemployee> MThrmsemployee { get; set; }
        public ICollection<MThrmsmanPowerBudget> MThrmsmanPowerBudget { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisition { get; set; }
    }
}
