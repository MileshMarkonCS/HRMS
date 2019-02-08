using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsdepartment
    {
        public MThrmsdepartment()
        {
            MThrmsdesignation = new HashSet<MThrmsdesignation>();
            MThrmsemployee = new HashSet<MThrmsemployee>();
            MThrmsmanPowerBudget = new HashSet<MThrmsmanPowerBudget>();
            MThrmsresourceRequisition = new HashSet<MThrmsresourceRequisition>();
        }

        public long MThrmsdepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string Department { get; set; }
        public long? MThrmscompanyId { get; set; }
        public bool? Active { get; set; }

        public MThrmscompany MThrmscompany { get; set; }
        public ICollection<MThrmsdesignation> MThrmsdesignation { get; set; }
        public ICollection<MThrmsemployee> MThrmsemployee { get; set; }
        public ICollection<MThrmsmanPowerBudget> MThrmsmanPowerBudget { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisition { get; set; }
    }
}
