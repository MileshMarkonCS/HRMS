using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsofferLetter
    {
        public MThrmsofferLetter()
        {
            MThrmscandidateEntry = new HashSet<MThrmscandidateEntry>();
            MThrmsinventoryManagement = new HashSet<MThrmsinventoryManagement>();
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
        }

        public long MThrmsofferLetterId { get; set; }
        public long? ManPowerId { get; set; }
        public long? JobCode { get; set; }
        public long? DesignationId { get; set; }
        public long? ResourceRequisitionId { get; set; }
        public long? ResourceAllocationId { get; set; }
        public long? RecruiterId { get; set; }
        public long? SourcingId { get; set; }
        public long? ShortlistId { get; set; }
        public long? CandidateId { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Transport { get; set; }
        public decimal? Cola { get; set; }
        public decimal? Housing { get; set; }
        public decimal? Si { get; set; }
        public decimal? Sicompany { get; set; }
        public decimal? Pitax { get; set; }
        public decimal? Stamp { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public string TypeOfContract { get; set; }
        public string AnnualLeaveDetails { get; set; }
        public DateTime? OfferLetterDate { get; set; }

        public MThrmscvrepository Candidate { get; set; }
        public MThrmsdesignation Designation { get; set; }
        public MThrmsmanPowerBudget ManPower { get; set; }
        public MThrmsemployee Recruiter { get; set; }
        public MThrmsresourceAllocation ResourceAllocation { get; set; }
        public MThrmsresourceRequisition ResourceRequisition { get; set; }
        public MThrmsshortlist Shortlist { get; set; }
        public MThrmssourcing Sourcing { get; set; }
        public ICollection<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public ICollection<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
    }
}
