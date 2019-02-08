using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsmanPowerBudget
    {
        public MThrmsmanPowerBudget()
        {
            MThrmscandidateEntry = new HashSet<MThrmscandidateEntry>();
            MThrmsinterviewFeedback = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewSchedule = new HashSet<MThrmsinterviewSchedule>();
            MThrmsinventoryManagement = new HashSet<MThrmsinventoryManagement>();
            MThrmsofferLetter = new HashSet<MThrmsofferLetter>();
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
            MThrmsresourceAllocation = new HashSet<MThrmsresourceAllocation>();
            MThrmsresourceRequisition = new HashSet<MThrmsresourceRequisition>();
            MThrmsshortlist = new HashSet<MThrmsshortlist>();
            MThrmssourcing = new HashSet<MThrmssourcing>();
        }

        public long MThrmsmanPowerBudgetId { get; set; }
        public string ManPowerBudgetCode { get; set; }
        public long? MThrmsdesignationId { get; set; }
        public long? MThrmsdepartmentId { get; set; }
        public long? MThrmsbranchId { get; set; }
        public long? MThrmscompanyId { get; set; }
        public bool? Active { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Transport { get; set; }
        public decimal? Cola { get; set; }
        public decimal? Housing { get; set; }
        public decimal? Si { get; set; }
        public decimal? Sicompany { get; set; }
        public decimal? Pitax { get; set; }
        public decimal? Stamp { get; set; }
        public int? HeadCount { get; set; }
        public decimal? TotalBudget { get; set; }
        public string Status { get; set; }

        public MThrmsbranch MThrmsbranch { get; set; }
        public MThrmscompany MThrmscompany { get; set; }
        public MThrmsdepartment MThrmsdepartment { get; set; }
        public MThrmsdesignation MThrmsdesignation { get; set; }
        public ICollection<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
        public ICollection<MThrmsinterviewSchedule> MThrmsinterviewSchedule { get; set; }
        public ICollection<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public ICollection<MThrmsofferLetter> MThrmsofferLetter { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
        public ICollection<MThrmsresourceAllocation> MThrmsresourceAllocation { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisition { get; set; }
        public ICollection<MThrmsshortlist> MThrmsshortlist { get; set; }
        public ICollection<MThrmssourcing> MThrmssourcing { get; set; }
    }
}
