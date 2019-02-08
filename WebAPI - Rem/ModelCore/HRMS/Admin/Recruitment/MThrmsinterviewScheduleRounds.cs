using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsinterviewScheduleRounds
    {
        public MThrmsinterviewScheduleRounds()
        {
            MThrmsinterviewChecklistEvaluation = new HashSet<MThrmsinterviewChecklistEvaluation>();
            MThrmsinterviewFeedback = new HashSet<MThrmsinterviewFeedback>();
            MThrmsinterviewScheduleRoundDetails = new HashSet<MThrmsinterviewScheduleRoundDetails>();
        }

        public long MThrmsinterviewScheduleRoundsId { get; set; }
        public long? InterviewScheduleId { get; set; }
        public long? RoundId { get; set; }
        public string Status { get; set; }
        public DateTime? CandidatePlanDate { get; set; }
        public DateTime? InterviewPlanDate { get; set; }

        public MThrmsinterviewSchedule InterviewSchedule { get; set; }
        public MThrmsinterviewRoundsDefinition Round { get; set; }
        public ICollection<MThrmsinterviewChecklistEvaluation> MThrmsinterviewChecklistEvaluation { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
        public ICollection<MThrmsinterviewScheduleRoundDetails> MThrmsinterviewScheduleRoundDetails { get; set; }
    }
}
