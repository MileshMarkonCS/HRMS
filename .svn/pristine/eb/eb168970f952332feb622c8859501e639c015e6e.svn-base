using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsresourceAllocation
    {
        public MThrmsresourceAllocation()
        {
            MThrmscandidateEntry = new HashSet<MThrmscandidateEntry>();
            MThrmsinterviewFeedback = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewSchedule = new HashSet<MThrmsinterviewSchedule>();
            MThrmsinventoryManagement = new HashSet<MThrmsinventoryManagement>();
            MThrmsofferLetter = new HashSet<MThrmsofferLetter>();
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
            MThrmsshortlist = new HashSet<MThrmsshortlist>();
            MThrmssourcing = new HashSet<MThrmssourcing>();
        }

        public long MThrmsresourceAllocationId { get; set; }
        public long? ResourceRequisitionId { get; set; }
        public long? JobCode { get; set; }
        public long? ManPowerId { get; set; }
        public long? RecruiterId { get; set; }
        public long? DesignationId { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Transport { get; set; }
        public decimal? Cola { get; set; }
        public decimal? Housing { get; set; }
        public decimal? Si { get; set; }
        public decimal? Sicompany { get; set; }
        public decimal? Pitax { get; set; }
        public decimal? Stamp { get; set; }

        public MThrmsdesignation Designation { get; set; }
        public MThrmsmanPowerBudget ManPower { get; set; }
        public MThrmsemployee Recruiter { get; set; }
        public MThrmsresourceRequisition ResourceRequisition { get; set; }
        public ICollection<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
        public ICollection<MThrmsinterviewSchedule> MThrmsinterviewSchedule { get; set; }
        public ICollection<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public ICollection<MThrmsofferLetter> MThrmsofferLetter { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
        public ICollection<MThrmsshortlist> MThrmsshortlist { get; set; }
        public ICollection<MThrmssourcing> MThrmssourcing { get; set; }
    }
}
