using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsinterviewChecklistEvaluationDetails
    {
        public long MThrmsinterviewChecklistEvaluationDetailsId { get; set; }
        public long? InterviewChecklistEvaluationId { get; set; }
        public long? ChecklistItemId { get; set; }
        public decimal? Score { get; set; }

        public MThrmschecklistItems ChecklistItem { get; set; }
        public MThrmsinterviewChecklistEvaluation InterviewChecklistEvaluation { get; set; }
    }
}
