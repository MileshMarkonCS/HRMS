using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsinterviewScheduleRoundDetails
    {
        public MThrmsinterviewScheduleRoundDetails()
        {
            MThrmsinterviewChecklistEvaluation = new HashSet<MThrmsinterviewChecklistEvaluation>();
            MThrmsinterviewFeedback = new HashSet<MThrmsinterviewFeedback>();
        }

        public long MThrmsinterviewScheduleRoundDetailsId { get; set; }
        public long? InterviewScheduleId { get; set; }
        public long? InterviewScheduleRoundId { get; set; }
        public long? InterviewerId { get; set; }

        public MThrmsinterviewSchedule InterviewSchedule { get; set; }
        public MThrmsinterviewScheduleRounds InterviewScheduleRound { get; set; }
        public MThrmsemployee Interviewer { get; set; }
        public ICollection<MThrmsinterviewChecklistEvaluation> MThrmsinterviewChecklistEvaluation { get; set; }
        public ICollection<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
    }
}
