using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsemployee
    {
        public MThrmsemployee()
        {
            InverseManager = new HashSet<MThrmsemployee>();
            MThrmscandidateEntry = new HashSet<MThrmscandidateEntry>();
            MThrmsinterviewChecklistEvaluation = new HashSet<MThrmsinterviewChecklistEvaluation>();
            MThrmsinterviewFeedbackInterviewer = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewFeedbackRecruiter = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewSchedule = new HashSet<MThrmsinterviewSchedule>();
            MThrmsinterviewScheduleRoundDetails = new HashSet<MThrmsinterviewScheduleRoundDetails>();
            MThrmsinventoryManagement = new HashSet<MThrmsinventoryManagement>();
            MThrmsinventoryManagementDetails = new HashSet<MThrmsinventoryManagementDetails>();
            MThrmsofferLetter = new HashSet<MThrmsofferLetter>();
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
            MThrmsresourceAllocation = new HashSet<MThrmsresourceAllocation>();
            MThrmsresourceRequisitionEmployee = new HashSet<MThrmsresourceRequisition>();
            MThrmsresourceRequisitionSubordinate = new HashSet<MThrmsresourceRequisition>();
            MThrmsresourceRequisitionSupervisor = new HashSet<MThrmsresourceRequisition>();
            MThrmsshortlist = new HashSet<MThrmsshortlist>();
            MThrmssourcing = new HashSet<MThrmssourcing>();
        }

        public long MThrmsemployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string Employee { get; set; }
        public long? ManagerId { get; set; }
        public long? MThrmsdepartmentId { get; set; }
        public long? MThrmsdesignationId { get; set; }
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

        public MThrmsbranch MThrmsbranch { get; set; }
        public MThrmscompany MThrmscompany { get; set; }
        public MThrmsdepartment MThrmsdepartment { get; set; }
        public MThrmsdesignation MThrmsdesignation { get; set; }
        public MThrmsemployee Manager { get; set; }
        public ICollection<MThrmsemployee> InverseManager { get; set; }
        public ICollection<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public ICollection<MThrmsinterviewChecklistEvaluation> MThrmsinterviewChecklistEvaluation { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedbackInterviewer { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedbackRecruiter { get; set; }
        public ICollection<MThrmsinterviewSchedule> MThrmsinterviewSchedule { get; set; }
        public ICollection<MThrmsinterviewScheduleRoundDetails> MThrmsinterviewScheduleRoundDetails { get; set; }
        public ICollection<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public ICollection<MThrmsinventoryManagementDetails> MThrmsinventoryManagementDetails { get; set; }
        public ICollection<MThrmsofferLetter> MThrmsofferLetter { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
        public ICollection<MThrmsresourceAllocation> MThrmsresourceAllocation { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisitionEmployee { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisitionSubordinate { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisitionSupervisor { get; set; }
        public ICollection<MThrmsshortlist> MThrmsshortlist { get; set; }
        public ICollection<MThrmssourcing> MThrmssourcing { get; set; }
    }
}
