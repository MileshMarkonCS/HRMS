using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmscandidateEntry
    {
        public MThrmscandidateEntry()
        {
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
        }

        public long MThrmscandidateEntryId { get; set; }
        public long? ManPowerId { get; set; }
        public long? JobCode { get; set; }
        public long? DesignationId { get; set; }
        public long? ResourceRequisitionId { get; set; }
        public long? ResourceAllocationId { get; set; }
        public long? RecruiterId { get; set; }
        public long? SourcingId { get; set; }
        public long? ShortlistId { get; set; }
        public long? CandidateId { get; set; }
        public long? OfferLetterId { get; set; }
        public long? InventoryManagementId { get; set; }
        public string Status { get; set; }

        public MThrmscvrepository Candidate { get; set; }
        public MThrmsdesignation Designation { get; set; }
        public MThrmsinventoryManagement InventoryManagement { get; set; }
        public MThrmsmanPowerBudget ManPower { get; set; }
        public MThrmsofferLetter OfferLetter { get; set; }
        public MThrmsemployee Recruiter { get; set; }
        public MThrmsresourceAllocation ResourceAllocation { get; set; }
        public MThrmsresourceRequisition ResourceRequisition { get; set; }
        public MThrmsshortlist Shortlist { get; set; }
        public MThrmssourcing Sourcing { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
    }
}
