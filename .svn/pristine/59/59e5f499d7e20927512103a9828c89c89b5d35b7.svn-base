using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsinterviewChecklistEvaluation
    {
        public MThrmsinterviewChecklistEvaluation()
        {
            MThrmsinterviewChecklistEvaluationDetails = new HashSet<MThrmsinterviewChecklistEvaluationDetails>();
        }

        public long MThrmsinterviewChecklistEvaluationId { get; set; }
        public long? InterviewScheduleId { get; set; }
        public long? InterviewScheduleRoundId { get; set; }
        public long? InterviewScheduleRoundDetailsId { get; set; }
        public long? InterviewerId { get; set; }

        public MThrmsinterviewSchedule InterviewSchedule { get; set; }
        public MThrmsinterviewScheduleRounds InterviewScheduleRound { get; set; }
        public MThrmsinterviewScheduleRoundDetails InterviewScheduleRoundDetails { get; set; }
        public MThrmsemployee Interviewer { get; set; }
        public ICollection<MThrmsinterviewChecklistEvaluationDetails> MThrmsinterviewChecklistEvaluationDetails { get; set; }
    }
}
