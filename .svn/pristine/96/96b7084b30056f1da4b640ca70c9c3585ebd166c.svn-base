using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmscompany
    {
        public MThrmscompany()
        {
            MThrmsbranch = new HashSet<MThrmsbranch>();
            MThrmsdepartment = new HashSet<MThrmsdepartment>();
            MThrmsemployee = new HashSet<MThrmsemployee>();
            MThrmsmanPowerBudget = new HashSet<MThrmsmanPowerBudget>();
            MThrmsresourceRequisition = new HashSet<MThrmsresourceRequisition>();
        }

        public long MThrmscompanyId { get; set; }
        public string Company { get; set; }
        public string CompanyTitle { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public ICollection<MThrmsbranch> MThrmsbranch { get; set; }
        public ICollection<MThrmsdepartment> MThrmsdepartment { get; set; }
        public ICollection<MThrmsemployee> MThrmsemployee { get; set; }
        public ICollection<MThrmsmanPowerBudget> MThrmsmanPowerBudget { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisition { get; set; }
    }
}
