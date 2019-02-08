using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsdesignation
    {
        public MThrmsdesignation()
        {
            MThrmscandidateEntry = new HashSet<MThrmscandidateEntry>();
            MThrmsdesignationInventory = new HashSet<MThrmsdesignationInventory>();
            MThrmsemployee = new HashSet<MThrmsemployee>();
            MThrmsinterviewFeedback = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewSchedule = new HashSet<MThrmsinterviewSchedule>();
            MThrmsinventoryManagement = new HashSet<MThrmsinventoryManagement>();
            MThrmsmanPowerBudget = new HashSet<MThrmsmanPowerBudget>();
            MThrmsofferLetter = new HashSet<MThrmsofferLetter>();
            MThrmsonboarding = new HashSet<MThrmsonboarding>();
            MThrmsresourceAllocation = new HashSet<MThrmsresourceAllocation>();
            MThrmsresourceRequisition = new HashSet<MThrmsresourceRequisition>();
            MThrmsshortlist = new HashSet<MThrmsshortlist>();
            MThrmssourcing = new HashSet<MThrmssourcing>();
        }

        public long MThrmsdesignationId { get; set; }
        public string DesignationCode { get; set; }
        public string Designation { get; set; }
        public long? MThrmsdepartmentId { get; set; }
        public string DutiesResponsibilities { get; set; }
        public string MinimumQualification { get; set; }
        public string ExperienceRequired { get; set; }
        public string LanguageKnowledge { get; set; }
        public bool? ComputerKnowledge { get; set; }
        public string MinimumAge { get; set; }
        public string JobTitle { get; set; }
        public string JobPurpose { get; set; }
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

        public MThrmsdepartment MThrmsdepartment { get; set; }
        public ICollection<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public ICollection<MThrmsdesignationInventory> MThrmsdesignationInventory { get; set; }
        public ICollection<MThrmsemployee> MThrmsemployee { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
        public ICollection<MThrmsinterviewSchedule> MThrmsinterviewSchedule { get; set; }
        public ICollection<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public ICollection<MThrmsmanPowerBudget> MThrmsmanPowerBudget { get; set; }
        public ICollection<MThrmsofferLetter> MThrmsofferLetter { get; set; }
        public ICollection<MThrmsonboarding> MThrmsonboarding { get; set; }
        public ICollection<MThrmsresourceAllocation> MThrmsresourceAllocation { get; set; }
        public ICollection<MThrmsresourceRequisition> MThrmsresourceRequisition { get; set; }
        public ICollection<MThrmsshortlist> MThrmsshortlist { get; set; }
        public ICollection<MThrmssourcing> MThrmssourcing { get; set; }
    }
}
