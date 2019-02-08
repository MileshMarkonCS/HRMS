using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmscvrepository
    {
        public MThrmscvrepository()
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

        public long MThrmscvrepositoryId { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Faculty { get; set; }
        public string Degree { get; set; }
        public byte[] Cvfile { get; set; }
        public string Status { get; set; }

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
