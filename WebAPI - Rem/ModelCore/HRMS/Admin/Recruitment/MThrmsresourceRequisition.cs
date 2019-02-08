using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsresourceRequisition
    {
        public MThrmsresourceRequisition()
        {
            MThrmscandidateEntry = new HashSet<MThrmscandidateEntry>();
            MThrmsinterviewFeedback = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewSchedule = new HashSet<MThrmsinterviewSchedule>();
            MThrmsinventoryManagement = new HashSet<MThrmsinventoryManagement>();
            MThrmsofferLetter = new HashSet<MThrmsofferLetter>();
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
            MThrmsresourceAllocation = new HashSet<MThrmsresourceAllocation>();
            MThrmsshortlist = new HashSet<MThrmsshortlist>();
            MThrmssourcing = new HashSet<MThrmssourcing>();
        }

        public long MThrmsresourceRequisitionId { get; set; }
        public long JobCode { get; set; }
        public long? SupervisorId { get; set; }
        public long? SubordinateId { get; set; }
        public string RequisitionType { get; set; }
        public long? CompanyId { get; set; }
        public long? DepartmentId { get; set; }
        public long? BranchId { get; set; }
        public string ContractType { get; set; }
        public string JobTiming { get; set; }
        public long? EmployeeId { get; set; }
        public string ReasonOfLeave { get; set; }
        public string Remarks { get; set; }
        public long? ManPowerId { get; set; }
        public long? DesignationId { get; set; }
        public DateTime? PlannedClosingDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Status { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Transport { get; set; }
        public decimal? Cola { get; set; }
        public decimal? Housing { get; set; }
        public decimal? Si { get; set; }
        public decimal? Sicompany { get; set; }
        public decimal? Pitax { get; set; }
        public decimal? Stamp { get; set; }

        public MThrmsbranch Branch { get; set; }
        public MThrmscompany Company { get; set; }
        public MThrmsdepartment Department { get; set; }
        public MThrmsdesignation Designation { get; set; }
        public MThrmsemployee Employee { get; set; }
        public MThrmsmanPowerBudget ManPower { get; set; }
        public MThrmsemployee Subordinate { get; set; }
        public MThrmsemployee Supervisor { get; set; }
        public ICollection<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
        public ICollection<MThrmsinterviewSchedule> MThrmsinterviewSchedule { get; set; }
        public ICollection<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public ICollection<MThrmsofferLetter> MThrmsofferLetter { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
        public ICollection<MThrmsresourceAllocation> MThrmsresourceAllocation { get; set; }
        public ICollection<MThrmsshortlist> MThrmsshortlist { get; set; }
        public ICollection<MThrmssourcing> MThrmssourcing { get; set; }
    }
}
